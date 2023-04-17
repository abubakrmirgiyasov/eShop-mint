using Microsoft.EntityFrameworkCore;
using Mint.Domain.BindingModels;
using Mint.Domain.Common;
using Mint.Domain.Exceptions;
using Mint.Domain.FormingModels;
using Mint.Domain.Models;
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

    public async Task AddNewUser(UserFullBindingModel model)
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

            var user = new UserManager().FormingBindingModelAddNewUser(model);
            user.UserRoles?.Add(new UserRole() { RoleId = role!.Id, });

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
