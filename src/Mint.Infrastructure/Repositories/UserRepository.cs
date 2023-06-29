using Microsoft.EntityFrameworkCore;
using Mint.Domain.BindingModels;
using Mint.Domain.Common;
using Mint.Domain.Exceptions;
using Mint.Domain.FormingModels;
using Mint.Domain.Models;
using Mint.Domain.ViewModels;
using Mint.Infrastructure.Repositories.Interfaces;

namespace Mint.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<UserFullBindingModel>> GetUsers()
    {
        try
        {
            var users = await _context.Users.ToListAsync();
            return new List<UserFullBindingModel>();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public User GetUserById(Guid id)
    {
        try
        {
            var user = _context.Users
                .Include(x => x.RefreshTokens!)
                .Include(x => x.UserRoles!)
                .ThenInclude(x => x.Role)
                .FirstOrDefault(x => x.Id == id);
            return user ?? throw new UserNotFoundException("Пользователь не найден.");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public User GetUserByToken(string token)
    {
        try
        {
            var user = _context.Users
                .Include(x => x.RefreshTokens)
                .FirstOrDefault(x => x.RefreshTokens!.Any(y => y.Token == token));
            return user ?? throw new Exception("Invalid token.");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task AddNewUserAsync(UserFullBindingModel model)
    {
        try
        {
            var users = await _context.Users.ToListAsync();
            var role = await _context.Roles.FirstOrDefaultAsync(x => x.Name == Constants.BUYER);
            var isEmailExist = users.FirstOrDefault(x => x.Email == model.Email);
            var isPhoneExist = users.FirstOrDefault(x => x.Phone == model.Phone);

            if (isEmailExist != null)
                throw new Exception("Email error");

            if (isPhoneExist != null)
                throw new Exception("Phone error");

            var user = await new UserManager().FormingBindingModelAddNewUser(model);
            user.UserRoles?.Add(new UserRole() { RoleId = role!.Id, });

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<UserFullViewModel> UpdateUserInfoAsync(UserFullBindingModel model)
    {
        try
        {
            var user = await _context.Users
                .Include(x => x.Photo)
                .FirstOrDefaultAsync(x => x.Id == model.Id)
                ?? throw new UserNotFoundException("Пользователь не найден.");

            user.FirstName = model.FirstName!;
            user.SecondName = model.SecondName!;
            user.LastName = model.LastName;
            user.Gender = model.Gender!;
            user.Description = model.Description!;
            user.DateBirth = DateTime.Parse(model.DateOfBirth!);

            if (model.Photo != null && model.Folder != null)
            {
                var photo = await PhotoManager.CopyPhotoAsync(model.Photo, model.Id, model.Folder);
                photo.Users = new List<User> { user };
                await _context.Photos.AddAsync(photo);
            }

            await _context.SaveChangesAsync();

            return new UserManager().FormingUpdateViewModel(user);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task UpdateUserPaswordAsync(UserUpdatePasswordBindingModel model)
    {
        try
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Id == model.Id)
                ?? throw new UserNotFoundException("Пользователь не найден.");

            if (user.NumOfAttempts >= 10)
            {
                user.IsActive = false;
                await _context.SaveChangesAsync();
                throw new Exception("Учетная запись заблокирована.");
            }

            if (user.Password == new Hasher().GetHash(model.OldPassword!, user.Salt))
            {
                var salt = new Hasher().GetSalt();

                user.Password = new Hasher().GetHash(model.NewPassword!, salt);
                user.Salt = salt;
                await _context.SaveChangesAsync();
            }
            else
            {
                user.NumOfAttempts++;
                await _context.SaveChangesAsync();
                throw new Exception("Введенный пароль не правильный");
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<List<AddressViewModel>> GetUserAddressesByIdAsync(Guid userId)
    {
        try
        {
            var address = await _context.Addresses
                .Include(x => x.User)
                .AsNoTracking()
                .Where(x => x.UserId == userId)
                .ToListAsync();
            return new AddressManager().FormingViewModels(address);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<AddressViewModel> AddUserAddressAsync(AddressBindingModel model)
    {
        try
        {
            var address = new AddressManager().FormingBindingModel(model);
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();

            var temp = await _context.Addresses
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.UserId == model.UserId)
                ?? throw new Exception("Произошла ошибка. Адрес не найден");
            return new AddressManager().FormingSingleViewMdoel(temp!);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task UpdateUserAddressAsync(AddressBindingModel model)
    {
        try
        {
            var address = await _context.Addresses
                .FirstOrDefaultAsync(x => x.Id == model.Id) 
                ?? throw new Exception("Адрес не существует.");
            address.FullAddress = model.FullAddress!;
            address.City = model.City!;
            address.Country = model.Country!;
            address.ZipCode = model.ZipCode;
            address.Description = model.Description!;
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task DeleteUserAddressAsync(Guid id)
    {
        try
        {
            var address = await _context.Addresses
                .FirstOrDefaultAsync(x => x.Id == id) 
                ?? throw new Exception("Адрес не существует.");

            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
