using Mint.Domain.BindingModels;
using Mint.Domain.Models;

namespace Mint.Infrastructure.Repositories.Interfaces;

public interface IUserRepository
{
    Task<List<UserFullBindingModel>> GetUsers();

    User GetUserById(Guid id);

    User GetUserByToken(string token);

    Task AddNewUserAsync(UserFullBindingModel model);

    Task UpdateUserInfoAsync(UserFullBindingModel model);
}
