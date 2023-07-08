using Mint.WebApp.Identity.DTO_s;
using Mint.WebApp.Identity.Repositories.Interfaces;

namespace Mint.WebApp.Identity.Repositories;

/// <summary>
/// 
/// </summary>
public class UserRepository : IUserRepository
{
    public Task<UserFullViewModel> CreateUserWithEmailAsync(UserFullBindingModel model, CancellationToken? cancellationToken = null)
    {
        throw new NotImplementedException();
    }

    public Task<UserFullViewModel> CreateUserWithPhoneAsync(UserFullBindingModel model, CancellationToken? cancellationToken = null)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUserAsync(Guid id, CancellationToken? cancellationToken = null)
    {
        throw new NotImplementedException();
    }

    public Task<UserFullViewModel> GetUserByEmailAsync(string email, CancellationToken? cancellationToken = null)
    {
        throw new NotImplementedException();
    }

    public Task<UserFullViewModel> GetUserByIdAsync(Guid id, CancellationToken? cancellationToken = null)
    {
        throw new NotImplementedException();
    }

    public Task<UserFullViewModel> GetUserByPhoneAsync(long phone, CancellationToken? cancellationToken = null)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserFullViewModel>> GetUsersAsync(CancellationToken? cancellationToken = null)
    {
        throw new NotImplementedException();
    }

    public Task<UserFullViewModel> UpdateUserAsync(UserFullBindingModel model, CancellationToken? cancellationToken = null)
    {
        throw new NotImplementedException();
    }
}
