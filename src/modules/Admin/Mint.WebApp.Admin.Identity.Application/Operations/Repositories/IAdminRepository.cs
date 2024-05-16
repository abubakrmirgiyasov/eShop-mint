using Mint.Application.Interfaces;
using Mint.Domain.Models.Identity;
using Mint.WebApp.Admin.Identity.Application.Operations.Dtos;

namespace Mint.WebApp.Admin.Application.Operations.Repositories;

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

    /// <summary>
    /// This method allows an admin user to sign in. 
    /// </summary>
    /// <param name="model"></param>
    /// <returns>AuthenticationAdminResponse which includes the authentication result and related information</returns>
    /// <exception cref="UnauthorizedAccessException"></exception>
    /// <exception cref="LogicException"></exception>
    /// <exception cref="Exception"></exception>
    Task<AuthenticationAdminResponse> SignAsAdmin(SignInRequest model, CancellationToken cancellationToken = default);
}
