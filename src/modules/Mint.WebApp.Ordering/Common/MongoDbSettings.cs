#nullable disable

namespace Mint.WebApp.Ordering.Common;

public class MongoDbSettings : IMongoDbSettings
{
    public string DatabaseName { get; set; }

    public string ConnectionString { get; set; }
}

public interface IMongoDbSettings
{
    string DatabaseName { get; set; }

    string ConnectionString { get; set; }
}