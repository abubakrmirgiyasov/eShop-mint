using Mint.Domain.Models;

namespace Mint.Infrastructure.Repositories.Interfaces;

public interface IUserRepository
{
    List<User> GetUsers();

    User GetUserById(Guid id);

    User GetUserByToken(string token);
}
