#nullable disable

namespace Mint.Domain.Common;

public class AppSettings
{
    public string SecretKey { get; set; }

    public int RefreshTokenTTL { get; set; }
}

public class MongoDbSettings
{
    public string DatabaseName { get; set; }

    public string ConnectionString { get; set; }
}
