using Microsoft.EntityFrameworkCore;
using Mint.Domain.Models.Identity;
using Mint.WebApp.Identity.DTO_s;
using Mint.WebApp.Identity.FormingModels;
using Mint.WebApp.Identity.Repositories.Interfaces;
using Mint.WebApp.Identity.Services;

namespace Mint.WebApp.Identity.Repositories;

/// <summary>
/// User Repository class
/// </summary>
public class UserRepository : IUserRepository
{
    private readonly ILogger<UserRepository> _logger;
    private readonly ApplicationDbContext _context;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="context"></param>
    public UserRepository(ILogger<UserRepository> logger, ApplicationDbContext context)
    {
        _context = context;
        _logger = logger;
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

    public Task<UserFullViewModel> CreateUserWithEmailAsync(UserFullBindingModel model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<UserFullViewModel> CreateUserWithPhoneAsync(UserFullBindingModel model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<UserFullViewModel> UpdateUserAsync(UserFullBindingModel model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteUserAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
