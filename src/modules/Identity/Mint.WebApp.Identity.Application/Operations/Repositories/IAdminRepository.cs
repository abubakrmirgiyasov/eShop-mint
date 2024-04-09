using Mint.Application.Interfaces;
using Mint.Domain.Models.Identity;

namespace Mint.WebApp.Identity.Application.Operations.Repositories;

/// <summary>
/// Admin Repository
/// </summary>
public interface IAdminRepository : IGenericRepository<User>
{
    /// <summary>
    /// Retrieves a user by unique identifier.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<User?> GetAdminWithPhotoAsync(Guid userId, CancellationToken cancellationToken = default);
}
