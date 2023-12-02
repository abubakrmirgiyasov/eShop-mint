#nullable disable

namespace Mint.Domain.Common;

public class AppSettings
{
    public OcelotRoutesOptions Routes { get; set; }

    public IdentitySettings IdentitySettings { get; set; }

    public RedisSettings RedisSettings { get; set; }
}

public class IdentitySettings
{
    public string SecretKey { get; set; }

    public int RefreshTokenTTL { get; set; }
}

public class RedisSettings
{
    public string Host { get; set; }

    public int Port { get; set; }
}

public class OcelotRouteOptions
{
    public List<string> UpstreamPathTemplates { get; set; }

    public string Downstream { get; set; }
}

public class OcelotRoutesOptions : Dictionary<string, OcelotRouteOptions>;
