using Mint.Domain.BindingModels;
using Mint.Domain.Models;
using Mint.Domain.ViewModels;

namespace Mint.Infrastructure.Repositories.Interfaces;

public interface IUserRepository
{
    Task<List<UserFullBindingModel>> GetUsers();

    User GetUserById(Guid id);

    User GetUserByToken(string token);

    Task AddNewUserAsync(UserFullBindingModel model);

    Task UpdateUserInfoAsync(UserFullBindingModel model);

    Task UpdateUserPaswordAsync(UserUpdatePasswordBindingModel model);

    Task AddUserAddressAsync(AddressBindingModel model);

    Task<List<AddressViewModel>> GetUserAddressesByIdAsync(Guid userId);
}
