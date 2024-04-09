using Mint.Application.Interfaces;
using Mint.Domain.DTO_s.Identity;
using Mint.Domain.Models.Identity;
using Mint.Domain.Exceptions;

namespace Mint.WebApp.Identity.Application.Operations.Repositories;

public interface IAdminAuthenticationRepository : IGenericRepository<User>
{
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
