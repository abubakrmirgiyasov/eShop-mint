using Mint.WebApp.Ordering.Infrastructure.Interfaces;
using MongoDB.Driver;

namespace Mint.WebApp.Ordering.Infrastructure;

public class MongoDbContext : IMongoDbContext
{
    private IMongoDatabase _database = null!;
    private readonly List<Func<Task>> _commands;
    private readonly IConfiguration _configuration;

    public MongoDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _commands = new List<Func<Task>>();
    }

    public IClientSessionHandle? Session { get; set; }

    public MongoClient Client { get; set; } = null!;

    public IMongoCollection<T> GetCollection<T>(string name)
    {
        ConfigureMongo();

        return _database.GetCollection<T>(name);
    }

    public void AddCommand(Func<Task> func)
    {
        _commands.Add(func);
    }

    public async Task<int> SaveChangesAsync()
    {
        ConfigureMongo();

        using (Session = await Client.StartSessionAsync())
        {
            Session.StartTransaction();

            var commandTasks = _commands.Select(x => x());

            await Task.WhenAll(commandTasks);
            await Session.CommitTransactionAsync();
        }

        return _commands.Count;
    }

    private void ConfigureMongo()
    {
        if (Client != null)
            return;

        Client = new MongoClient(_configuration["MongoSettings:Connection"]);
        _database = Client.GetDatabase(_configuration["MongoSettings:DatabaseName"]);
    }

    public void Dispose()
    {
        Session?.Dispose();
        GC.SuppressFinalize(this);
    }
}
