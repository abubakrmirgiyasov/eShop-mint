using Microsoft.EntityFrameworkCore;
using Mint.Application.Interfaces;
using Mint.Domain.Common;
using Mint.Domain.Exceptions;
using Mint.Domain.Models.Identity;
using Mint.WebApp.Admin.Application.Operations.Repositories;
using Mint.WebApp.Admin.Identity.Application.Operations.Dtos;

namespace Mint.Infrastructure.Repositories.Identity;

/// <inheritdoc cref="IAdminRepository"/>
internal sealed class AdminRepository(
    ApplicationDbContext context,
    IJwtService jwtService
) : GenericRepository<User>(context), IAdminRepository
{
    private readonly ApplicationDbContext _context = context;
    private readonly IJwtService _jwtService = jwtService;

    /// <inheritdoc/>
    public Task<User?> GetAdminWithPhotoAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var user = _context.Users
            .Include(x => x.Photo)
            .Include(x => x.BackgroundPhoto)
            .FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);

        return user;
    }

    /// <inheritdoc />
    public async Task<AuthenticationAdminResponse> SignAsAdmin(SignInRequest request, CancellationToken cancellationToken = default)
    {
        var user = await _context.Users
            .Include(x => x.UserRoles)
            .ThenInclude(x => x.Role)
            .Include(x => x.Contacts)
            .Where(x => x.UserRoles.Any(y => y.Role.UniqueKey == nameof(Constants.ADMIN)))
            .FirstOrDefaultAsync(x => x.Contacts.Any(y => y.ContactInformation.ToLower() == request.Login), cancellationToken)
                ?? throw new UnauthorizedAccessException("Не правильный Логин/Пароль");

        if (!user.IsActive)
            throw new LogicException("Аккаунт не активен.");

        if (user.NumOfAttempts >= 10)
        {
            user.IsActive = false;
            await _context.SaveChangesAsync(cancellationToken);
            throw new LogicException("Аккаунт заблокирован.");
        }

        if (user.Password != new Hasher().GetHash(request.Password ?? "", user.Salt))
        {
            user.NumOfAttempts++;
            await _context.SaveChangesAsync(cancellationToken);
            throw new UnauthorizedAccessException("Не правильный Логин/Пароль.");
        }

        return new AuthenticationAdminResponse(_jwtService.GenerateJwtToken(user));
    }
}
