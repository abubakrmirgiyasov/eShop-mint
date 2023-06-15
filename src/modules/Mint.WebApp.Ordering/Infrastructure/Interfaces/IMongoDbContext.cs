using MongoDB.Driver;

namespace Mint.WebApp.Ordering.Infrastructure.Interfaces;

public interface IMongoDbContext : IDisposable
{
    void AddCommand(Func<Task> func);

    Task<int> SaveChangesAsync();

    IMongoCollection<T> GetCollection<T>(string name);
}
