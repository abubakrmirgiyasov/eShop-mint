using MongoDB.Driver;

namespace Mint.WebApp.Ordering.Interfaces;

public interface IMongoDbContext : IDisposable
{
    void AddCommand(Func<Task> func);

    Task<int> SaveChangesAsync();

    IMongoCollection<T> GetCollection<T>(string name);
}
