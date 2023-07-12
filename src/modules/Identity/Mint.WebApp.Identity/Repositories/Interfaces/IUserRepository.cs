using Mint.WebApp.Identity.DTO_s;

namespace Mint.WebApp.Identity.Repositories.Interfaces;

/// <summary>
/// User Interface Interface
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Method gets all users
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<IEnumerable<UserFullViewModel>> GetUsersAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Method gets single user by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<UserFullViewModel> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Method gets single user by email
    /// </summary>
    /// <param name="email"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<UserFullViewModel> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default);

    /// <summary>
    /// Method gets single user by phone number
    /// </summary>
    /// <param name="phone"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<UserFullViewModel> GetUserByPhoneAsync(long phone, CancellationToken cancellationToken = default);

    /// <summary>
    /// Method creates new user by email
    /// </summary>
    /// <param name="model"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<UserFullViewModel> CreateUserWithEmailAsync(UserFullBindingModel model, CancellationToken cancellationToken = default);

    /// <summary>
    /// Method creates new user by phone number
    /// </summary>
    /// <param name="model"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<UserFullViewModel> CreateUserWithPhoneAsync(UserFullBindingModel model, CancellationToken cancellationToken = default);

    /// <summary>
    /// Method updates user
    /// </summary>
    /// <param name="model"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<UserFullViewModel> UpdateUserAsync(UserFullBindingModel model, CancellationToken cancellationToken = default);

    /// <summary>
    /// Method deletes user
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task DeleteUserAsync(Guid id, CancellationToken cancellationToken = default);
}
