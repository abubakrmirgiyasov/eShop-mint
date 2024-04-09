using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mint.Domain.Common;
using Mint.Domain.DTO_s.Identity;
using Mint.Domain.Exceptions;
using Mint.Domain.FormingModels.Identity;
using Mint.Domain.Models.Identity;
using Mint.WebApp.Identity.Application.Operations.Repositories;

namespace Mint.Infrastructure.Repositories.Identity;

/// <inheritdoc cref="IUserRepository"/>
internal sealed class UserRepository(
    ApplicationDbContext context,
    ILogger<UserRepository> logger
) : GenericRepository<User>(context), IUserRepository
{
    private readonly ILogger<UserRepository> _logger = logger;
    private readonly ApplicationDbContext _context = context;

    /// <inheritdoc/>
    public async Task<IEnumerable<UserFullViewModel>> GetUsersAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var users = await _context.Users
                .Include(x => x.Photo)
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .ToListAsync(cancellationToken);

            return UserDTOConverter.FormingMultiViewModels(users);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<UserAddressFullViewModel>> GetUserAddressesAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var users = await _context.Users
                .Include(x => x.UserAddresses)
                .ToListAsync(cancellationToken);

            var user = users.FirstOrDefault(x => x.Id == id)
                ?? throw new UserNotFoundException("Пользователь не существует");

            return UserAddressDTOConverter.FormingMultiViewModels(user.UserAddresses);
        }
        catch (UserNotFoundException ex)
        {
            throw new UserNotFoundException(ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    /// <inheritdoc/>
    public async Task<User> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var user = await _context.Users
                .AsNoTracking()
                .Include(x => x.Photo)
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
                    ?? throw new UserNotFoundException("Пользователь не найден.");

            return user;
        }
        catch (UserNotFoundException ex)
        {
            throw new UserNotFoundException(ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    /// <inheritdoc/>
    public async Task<string[]> GetUserRoleForAuthAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var users = await _context.Users
                .Include(x => x.Photo)
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .ToListAsync(cancellationToken);

            var user = users.FirstOrDefault(x => x.Id == id)
                    ?? throw new UserNotFoundException("Пользователь не существует");

            var roles = user.UserRoles
                .Select(x => x.Role.TranslateEn)
                .ToArray();

            return roles;
        }
        catch (UserNotFoundException ex)
        {
            throw new UserNotFoundException(ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    /// <inheritdoc/>
    public async Task<UserFullViewModel> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        try
        {
            var users = await _context.Users
                .Include(x => x.Photo)
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .ToListAsync(cancellationToken);

            var user = users.FirstOrDefault() // x => x.Email == email
                ?? throw new UserNotFoundException("Пользователь не существует");

            return UserDTOConverter.FormingSingleViewModel(user);
        }
        catch (UserNotFoundException ex)
        {
            throw new UserNotFoundException(ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    /// <inheritdoc/>
    public async Task<UserFullViewModel> GetUserByPhoneAsync(long phone, CancellationToken cancellationToken = default)
    {
        try
        {
            var users = await _context.Users
                .Include(x => x.Photo)
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .ToListAsync(cancellationToken);

            var user = users.FirstOrDefault() // x => x.Phone == phone
                ?? throw new UserNotFoundException("Пользователь не существует");

            return UserDTOConverter.FormingSingleViewModel(user);
        }
        catch (UserNotFoundException ex)
        {
            throw new UserNotFoundException(ex.Message);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    /// <inheritdoc/>
    public async Task<User?> GetUserWithPhotoAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await _context.Users
            .Include(x => x.Photo)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        return user;
    }

    /// <inheritdoc/>
    public Task<int> SendEmailConfirmationCodeAsync(string email)
    {
        try
        {
            var random = new Random();
            int code = random.Next(100000, 999999);

            //var isUserExists = _context.Users.FirstOrDefault(x => x.Email == email);

            //if (isUserExists != null)
            //    throw new Exception("Пользователь с таким адресом электронной почты существует");

            //var user = new User()
            //{
            //    Email = email,
            //    ConfirmationCode = code,
            //};

            //await _sender.SendAsync(user, null, Constants.CONFIRMATION_KEY);
            //return code;
            return (Task<int>)Task.CompletedTask;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    /// <inheritdoc/>
    public Task<UserFullViewModel> CreateUserWithEmailAsync(UserFullBindingModel model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task<UserFullViewModel> CreateUserWithPhoneAsync(UserFullBindingModel model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public async Task<UserAddressFullViewModel> CreateUserAddressAsync(UserAddressFullBindingModel model, CancellationToken cancellationToken = default)
    {
        try
        {
            var users = await _context.Users.ToListAsync(cancellationToken);

            var user = users.FirstOrDefault() // x => x.Email?.ToLower() == model.Email?.ToLower()
                ?? throw new ArgumentNullException(nameof(model), "Пользователь не существует");

            var address = UserAddressDTOConverter.FormingSingleFullBindingModel(model);
            address.UserId = user.Id;

            await _context.UserAddresses.AddAsync(address, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return UserAddressDTOConverter.FormingSingleFullViewModel(address);
        }
        catch (ArgumentNullException ex)
        {
            throw new ArgumentNullException(ex.Message, ex);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    /// <inheritdoc/>
    public async Task<UserAddressFullViewModel> UpdateUserAddressAsync(UserAddressFullBindingModel model, CancellationToken cancellationToken = default)
    {
        try
        {
            var addresses = await _context.UserAddresses.ToListAsync(cancellationToken);
            var address = addresses.FirstOrDefault(x => x.Id == model.Id)
                ?? throw new ArgumentNullException(nameof(User), "Адрес не существует");

            //address.Country = model.Country?.Label ?? address.Country;
            address.City = model.City ?? address.City;
            address.Street = model.Street ?? address.Street;
            address.ZipCode = model.ZipCode ?? address.ZipCode;
            address.Description = model.Description;

            _context.UserAddresses.Update(address);
            await _context.SaveChangesAsync(cancellationToken);

            return UserAddressDTOConverter.FormingSingleFullViewModel(address);
        }
        catch (ArgumentNullException ex)
        {
            throw new ArgumentNullException(ex.Message, ex);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    /// <inheritdoc/>
    public async Task UpdateUserPasswordAsync(UserFullBindingModel model, CancellationToken cancellationToken = default)
    {
        try
        {
            var users = await _context.Users.ToListAsync(cancellationToken);
            var user = users.FirstOrDefault(x => x.Id == model.Id)
                ?? throw new ArgumentNullException(nameof(User), "Адрес не существует");

            if (user.Password != new Hasher().GetHash(user.Password, user.Salt))
            {
                user.NumOfAttempts += 1;
                await _context.SaveChangesAsync(cancellationToken);

                throw new Exception("Не правильный пароль");
            }

            var salt = new Hasher().GetSalt();

            user.Password = new Hasher().GetHash(model.NewPassword!, salt);
            user.Salt = salt;

            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    /// <inheritdoc/>
    public async Task DeleteUserAddressAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var addresses = await _context.UserAddresses.ToListAsync(cancellationToken);
            var address = addresses.FirstOrDefault(x => x.Id == id)
                ?? throw new ArgumentNullException(nameof(User), "Адрес не существует");

            _context.UserAddresses.Remove(address);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (ArgumentNullException ex)
        {
            throw new ArgumentNullException(ex.Message, ex);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    /// <inheritdoc/>
    public async Task<UserFullViewModel> UpdateUserAsync(UserFullBindingModel model, CancellationToken cancellationToken = default)
    {
        try
        {


            await _context.SaveChangesAsync();
            return new UserFullViewModel();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    /// <inheritdoc/>
    public Task DeleteUserAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task<User> FindByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
