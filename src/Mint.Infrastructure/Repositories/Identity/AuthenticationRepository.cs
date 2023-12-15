using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Mint.Domain.Common;
using Mint.Domain.DTO_s.Identity;
using Mint.Domain.Exceptions;
using Mint.Domain.FormingModels.Identity;
using Mint.Domain.Helpers;
using Mint.Domain.Models.Identity;
using Mint.Infrastructure.Repositories.Identity.Interfaces;
using Mint.Infrastructure.Services.Interfaces;

namespace Mint.Infrastructure.Repositories.Identity;

/// <inheritdoc cref="IAuthenticationRepository"/>
public class AuthenticationRepository(
    IOptions<AppSettings> appSettings,
    ILogger<AuthenticationRepository> logger,
    ApplicationDbContext context,
    IJwt jwt) : IAuthenticationRepository
{
    private readonly ILogger<AuthenticationRepository> _logger = logger;
    private readonly AppSettings _appSettings = appSettings.Value;
    private readonly ApplicationDbContext _context = context;
    private readonly IJwt _jwt = jwt;

    /// <inheritdoc />
    public async Task<AuthenticationAdminResponse> SignAsAdmin(SignInRequest model, CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await _context.Users
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .Where(x => x.UserRoles.Any(y => y.Role.UniqueKey == nameof(Constants.ADMIN)) && x.Email == model.Email)
                .FirstOrDefaultAsync(cancellationToken)
                ?? throw new UnauthorizedAccessException("Не правильный Email/Пароль");

            if (!user.IsActive)
                throw new Exception("Аккаунт не активен");

            if (user.NumOfAttempts >= 10)
            {
                user.IsActive = false;
                await _context.SaveChangesAsync(cancellationToken);
                throw new BlockedException("Аккаунт заблокирован");
            }

            if (user.Password != new Hasher().GetHash(model.Password ?? "", user.Salt))
            {
                user.NumOfAttempts++;
                await _context.SaveChangesAsync(cancellationToken);
                throw new UnauthorizedAccessException("Не правильный Email/Пароль");
            }

            var token = _jwt.GenerateJwtToken(user);

            return new AuthenticationAdminResponse
            {
                Id = user.Id,
                Token = token,
            };
        }
        catch (UnauthorizedAccessException ex)
        {
            _logger.LogError("UnauthorizedAccessException Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new UnauthorizedAccessException(ex.Message, ex);
        }
        catch (BlockedException ex)
        {
            _logger.LogError("BlockedException Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new BlockedException(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }

    /// <inheritdoc />
    public async Task<AuthenticationResponse> SignInAsync(SignInRequest model, CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await _context.Users
                .Include(x => x.Photo)
                .Include(x => x.RefreshTokens)
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .FirstOrDefaultAsync(x => x.Email == model.Email, cancellationToken)
                ?? throw new UnauthorizedAccessException("Не правильный Email/Пароль");

            if (!user.IsActive)
                throw new Exception("Аккаунт не активен");

            if (user.NumOfAttempts >= 10)
            {
                user.IsActive = false;
                await _context.SaveChangesAsync(cancellationToken);
                throw new BlockedException("Аккаунт заблокирован");
            }

            if (user.Password != new Hasher().GetHash(model.Password ?? "", user.Salt))
            {
                user.NumOfAttempts++;
                await _context.SaveChangesAsync(cancellationToken);
                throw new UnauthorizedAccessException("Не правильный Email/Пароль");
            }

            var jwt = _jwt.GenerateJwtToken(user);
            var refreshToken = _jwt.GenerateRefreshToken(model.Ip);
            user.RefreshTokens.Add(refreshToken);

            RemoveOldRefreshToken(user);

            _context.Update(user);
            await _context.SaveChangesAsync(cancellationToken);

            return new AuthenticationResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                LastName = user.LastName,
                Phone = user.Phone,
                Email = user.Email,
                RefreshToken = refreshToken.Token,
                AccessToken = jwt,
                Image = PhotoHelper.GetImage64(user.Photo?.FilePath),
                DateBirth = user.DateBirth,
                Gender = user.Gender,
                IsConfirmedEmail = user.IsConfirmedEmail,
                IsConfirmedPhone = user.IsConfirmedPhone,
                IsSeller = user.UserRoles.Exists(x => x.Role.UniqueKey == "SELLER"),
                Description = user.Description,
                Roles = RoleDTOConverter.FormingSampleMultiViewModel(user.UserRoles).ToList(),
            };
        }
        catch (UnauthorizedAccessException ex)
        {
            _logger.LogError("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new UnauthorizedAccessException(ex.Message, ex);
        }
        catch (BlockedException ex)
        {
            _logger.LogError("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new BlockedException(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }

    /// <inheritdoc />
    public async Task<UserFullViewModel> SignUpAsync(UserFullBindingModel model, CancellationToken cancellationToken = default)
    {
        try
        {
            if (!string.IsNullOrEmpty(model.Email))
            {
                var isExistUser = _context.Users.FirstOrDefault(x => x.Email == model.Email);

                if (isExistUser != null)
                    throw new Exception("Пользователь с таким адресом электронной почты существует");
            }
            else if (long.TryParse(model.Phone?.ToString(), out long phone))
            {
                var isExistUser = _context.Users.FirstOrDefault(x => x.Phone == phone);

                if (isExistUser != null)
                    throw new Exception("Пользователь с таким номером телефона существует");
            }

            var salt = new Hasher().GetSalt();
            var password = new Hasher().GetHash(model.Password!, salt);

            model.Password = password;
            model.Salt = salt;

            var role = _context.Roles.FirstOrDefault(x => x.UniqueKey == nameof(Constants.BUYER))
                ?? throw new Exception("Что-то пошло не так");

            var user = UserDTOConverter.FormingSingleBindingModel(model);

            user.UserRoles =
            [
                new UserRole()
                {
                    RoleId = role.Id,
                    UserId = user.Id,
                },
            ];

            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return UserDTOConverter.FormingSingleViewModel(user);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }

    /// <inheritdoc />
    public async Task<AuthenticationResponse> RefreshTokenAsync(string? refreshToken, string? ip, CancellationToken cancellationToken = default)
    {
        try
        {
            if (string.IsNullOrEmpty(refreshToken))
                throw new ArgumentNullException(nameof(refreshToken), "Refresh token null");

            var user = GetUserByRefreshToken(refreshToken);
            var token = user.RefreshTokens.FirstOrDefault(x => x.Token == refreshToken)
                ?? throw new ArgumentNullException(nameof(refreshToken), "Invalid token");

            if (token.IsRevoked)
            {
                RevokeDescendantRefreshTokens(
                    refreshToken: token,
                    user: user,
                    ip: ip!,
                    reason: $"Attempted reuse of revoked ancestor token: {refreshToken}");

                _context.Update(user);
                await _context.SaveChangesAsync(cancellationToken);
            }

            if (!token.IsActive)
                throw new InvalidOperationException("Invalid token");

            var newRefreshToken = RotateRefreshToken(token, ip!);
            user.RefreshTokens.Add(newRefreshToken);

            RemoveOldRefreshToken(user);

            _context.Update(user);
            await _context.SaveChangesAsync(cancellationToken);

            var jwt = _jwt.GenerateJwtToken(user);

            return new AuthenticationResponse()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                LastName = user.LastName,
                Phone = user.Phone,
                Email = user.Email,
                RefreshToken = newRefreshToken.Token,
                AccessToken = jwt,
                Image = PhotoHelper.GetImage64(user.Photo?.FilePath),
                DateBirth = user.DateBirth,
                Gender = user.Gender,
                IsConfirmedEmail = user.IsConfirmedEmail,
                IsConfirmedPhone = user.IsConfirmedPhone,
                IsSeller = user.UserRoles.Exists(x => x.Role.UniqueKey == "SELLER"),
                Description = user.Description,
                Roles = RoleDTOConverter.FormingSampleMultiViewModel(user.UserRoles).ToList(),
            };
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogError("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new InvalidOperationException(ex.Message, ex);
        }
        catch (ArgumentNullException ex)
        {
            _logger.LogError("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new ArgumentNullException(ex.Message, ex);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }

    /// <inheritdoc />
    public Task ForgotPasswordAsync(UserFullBindingModel model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task RevokeToken(string? refreshToken, string? ip, CancellationToken cancellationToken = default)
    {
        try
        {
            if (string.IsNullOrEmpty(refreshToken))
                throw new Exception("Token is required");

            var user = GetUserByRefreshToken(refreshToken);

            var token = user.RefreshTokens.FirstOrDefault(x => x.Token == refreshToken)
                ?? throw new ArgumentNullException(nameof(refreshToken), "Invalid token");

            if (!token.IsActive)
                throw new InvalidOperationException("Invalid token");

            RevokeRefreshToken(user.RefreshTokens.First(), ip!, "Revoked without replacement");

            _context.Update(user);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogError("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new InvalidOperationException(ex.Message, ex);
        }
        catch (ArgumentNullException ex)
        {
            _logger.LogError("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }

    #region Helpers
    private void RevokeDescendantRefreshTokens(RefreshToken refreshToken, User user, string ip, string reason)
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

    private RefreshToken RotateRefreshToken(RefreshToken refreshToken, string ip)
    {
        var newRefreshToken = _jwt.GenerateRefreshToken(ip);
        RevokeRefreshToken(refreshToken, ip, "Replaced by new token", newRefreshToken.Token);
        return newRefreshToken;
    }

    private void RevokeRefreshToken(RefreshToken token, string ip, string? reason = null, string? replacedByToken = null)
    {
        token.Revoked = DateTime.UtcNow;
        token.RevokedByIp = ip;
        token.ReplacedByToken = replacedByToken;
        token.ReasonRevoked = reason;
    }

    private void RemoveOldRefreshToken(User user)
    {
        user.RefreshTokens.RemoveAll(x => x.IsActive && x.CreatedDate.AddDays(_appSettings.IdentitySettings.RefreshTokenTTL) <= DateTime.UtcNow);
    }

    private User GetUserByRefreshToken(string token)
    {
        var user = _context.Users
            .Include(x => x.Photo)
            .Include(x => x.RefreshTokens)
            .Include(x => x.UserRoles)
            .ThenInclude(x => x.Role)
            .ToList();
        return user.FirstOrDefault(x => x.RefreshTokens.Any(y => y.Token == token))
            ?? throw new ArgumentNullException(nameof(User), "Invalid token");
    }
    #endregion
}
