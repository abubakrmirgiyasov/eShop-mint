using Microsoft.EntityFrameworkCore;
using Mint.Domain.Models.Identity;
using Mint.WebApp.Identity.Application.Operations.Repositories;

namespace Mint.Infrastructure.Repositories.Identity;

/// <inheritdoc cref="IAdminRepository"/>
internal sealed class AdminRepository(
    ApplicationDbContext context
) : GenericRepository<User>(context), IAdminRepository
{
    private readonly ApplicationDbContext _context = context;

    /// <inheritdoc/>
    public Task<User?> GetAdminWithPhotoAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        var user = _context.Users
            .Include(x => x.Photo)
            .Include(x => x.BackgroundPhoto)
            .FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);

        return user;
    }
}
