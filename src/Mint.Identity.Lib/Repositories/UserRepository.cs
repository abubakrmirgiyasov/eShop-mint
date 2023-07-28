using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mint.Domain.Common;
using Mint.Domain.Models.Identity;
using Mint.Identity.Lib.DTO_s;
using Mint.Identity.Lib.FormingModels;
using Mint.Identity.Lib.Repositories.Interfaces;
using Mint.Identity.Lib.Services;
using Mint.Infrastructure.MessageBrokers.Interfaces;

namespace Mint.Identity.Lib.Repositories;

/// <summary>
/// User Repository class
/// </summary>
public class UserRepository : IUserRepository
{
    private readonly ILogger<UserRepository> _logger;
    private readonly ApplicationDbContext _context;
    private readonly IMessageSender<User> _sender;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="context"></param>
    public UserRepository(
        ILogger<UserRepository> logger, 
        ApplicationDbContext context, 
        IMessageSender<User> sender)
    {
        _context = context;
        _logger = logger;
        _sender = sender;
    }

    /// <summary>
    /// This method gets all users
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
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
    
    /// <summary>
    /// Gets all addresses single user by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<IEnumerable<UserAddressFullViewModel>> GetUserAddressesAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var users = await _context.Users
                .Include(x => x.UserAddresses)
                .ToListAsync(cancellationToken);

            var user = users.FirstOrDefault(x => x.Id == id)
                ?? throw new ArgumentNullException(nameof(User), "Пользователь не существует");

            return UserAddressDTOConverter.FormingMultiViewModels(user.UserAddresses);
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

    /// <summary>
    /// This method gets single user by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<UserFullViewModel> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var users = await _context.Users
                .Include(x => x.Photo)
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .ToListAsync(cancellationToken);

            var user = users.FirstOrDefault(x => x.Id == id)
                ?? throw new ArgumentNullException(nameof(User), "User doesn't exists");
            
            return UserDTOConverter.FormingSingleViewModel(user);
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

    /// <summary>
    /// This method gets single user by email
    /// </summary>
    /// <param name="email"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<UserFullViewModel> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        try
        {
            var users = await _context.Users
                .Include(x => x.Photo)
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .ToListAsync(cancellationToken);

            var user = users.FirstOrDefault(x => x.Email == email)
                ?? throw new ArgumentNullException(nameof(User), "User doesn't exists");

            return UserDTOConverter.FormingSingleViewModel(user);
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

    /// <summary>
    /// This method gets single user by phone
    /// </summary>
    /// <param name="phone"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<UserFullViewModel> GetUserByPhoneAsync(long phone, CancellationToken cancellationToken = default)
    {
        try
        {
            var users = await _context.Users
                .Include(x => x.Photo)
                .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
                .ToListAsync(cancellationToken);

            var user = users.FirstOrDefault(x => x.Phone == phone)
                ?? throw new ArgumentNullException(nameof(User), "User doesn't exists");

            return UserDTOConverter.FormingSingleViewModel(user);
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

    /// <summary>
    /// This method sends to user email confirmation code
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<int> SendEmailConfirmationCodeAsync(string email)
    {
        try
        {
            var random = new Random();
            int code = random.Next(100000, 999999);

            var isUserExists = _context.Users.FirstOrDefault(x => x.Email == email);

            if (isUserExists != null)
                throw new Exception("Пользователь с таким адресом электронной почты существует");

            var user = new User()
            {
                Email = email,
                ConfirmationCode = code,
            };

            await _sender.SendAsync(user, null, Constants.ConfirmationKey);
            return code;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public Task<UserFullViewModel> CreateUserWithEmailAsync(UserFullBindingModel model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<UserFullViewModel> CreateUserWithPhoneAsync(UserFullBindingModel model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<UserAddressFullViewModel> CreateUserAddressAsync(UserAddressFullBindingModel model, CancellationToken cancellationToken = default)
    {
        try
        {
            var users = await _context.Users.ToListAsync(cancellationToken);

            var user = users.FirstOrDefault(x => x.Email?.ToLower() == model.Email?.ToLower())
                ?? throw new ArgumentNullException(nameof(User), "Пользователь не существует");

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

    public Task DeleteUserAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
