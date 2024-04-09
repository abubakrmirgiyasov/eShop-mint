using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mint.Application.Interfaces;
using Mint.Domain.Common;
using Mint.Domain.DTO_s.Identity;
using Mint.Domain.Exceptions;
using Mint.Domain.Models.Identity;
using Mint.WebApp.Identity.Application.Operations.Repositories;

namespace Mint.Infrastructure.Repositories.Identity;

/// <inheritdoc cref="IAdminAuthenticationRepository"/>
internal sealed class AdminAuthenticationRepository(
    ApplicationDbContext context,
    ILogger<AdminAuthenticationRepository> logger,
    IJwtService jwtService
) : GenericRepository<User>(context), IAdminAuthenticationRepository
{
    private readonly ILogger<AdminAuthenticationRepository> _logger = logger;
    private readonly ApplicationDbContext _context = context;
    private readonly IJwtService _jwt = jwtService;

    /// <inheritdoc />
    public async Task<AuthenticationAdminResponse> SignAsAdmin(SignInRequest model, CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await _context.Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .Include(x => x.Contacts)
                .Where(x => x.UserRoles.Any(y => y.Role.UniqueKey == nameof(Constants.ADMIN)))
                .FirstOrDefaultAsync(x => x.Contacts.Any(y => y.ContactInformation.ToLower() == model.Login), cancellationToken)
                    ?? throw new UnauthorizedAccessException("Не правильный Логин/Пароль");

            if (!user.IsActive)
                throw new Exception("Аккаунт не активен.");

            if (user.NumOfAttempts >= 10)
            {
                user.IsActive = false;
                await _context.SaveChangesAsync(cancellationToken);
                throw new LogicException("Аккаунт заблокирован.");
            }

            if (user.Password != new Hasher().GetHash(model.Password ?? "", user.Salt))
            {
                user.NumOfAttempts++;
                await _context.SaveChangesAsync(cancellationToken);
                throw new UnauthorizedAccessException("Не правильный Логин/Пароль.");
            }

            var token = _jwt.GenerateJwtToken(user);

            return new AuthenticationAdminResponse(token);
        }
        catch (UnauthorizedAccessException ex)
        {
            _logger.LogError("UnauthorizedAccessException Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new UnauthorizedAccessException(ex.Message, ex);
        }
        catch (LogicException ex)
        {
            _logger.LogError("BlockedException Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new LogicException(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }

    #region Helpers
    private static void RevokeDescendantRefreshTokens(RefreshToken refreshToken, User user, string ip, string reason)
    {
        if (!string.IsNullOrEmpty(refreshToken.ReplacedByToken))
        {
            var childToken = user.RefreshTokens.FirstOrDefault(x => x.Token == refreshToken.ReplacedByToken);

            if (childToken != null)
            {
                if (childToken.IsActive)
                    RevokeRefreshToken(childToken, ip, reason);
                else
                    RevokeDescendantRefreshTokens(refreshToken, user, ip, reason);
            }
        }
    }

    private static void RevokeRefreshToken(RefreshToken token, string ip, string? reason = null, string? replacedByToken = null)
    {
        token.Revoked = DateTime.UtcNow;
        token.RevokedByIp = ip;
        token.ReplacedByToken = replacedByToken;
        token.ReasonRevoked = reason;
    }
    #endregion
}
