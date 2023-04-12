using Microsoft.EntityFrameworkCore;
using Mint.Domain.Exceptions;
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

    public List<User> GetUsers()
    {
        throw new NotImplementedException();
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
}
