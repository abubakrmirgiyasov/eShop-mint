#nullable disable

using Mint.Domain.Common.Settings;

namespace Mint.Domain.Common;

public class AppSettings
{
    public OcelotRoutesOptions Routes { get; set; }

    public IdentitySettings IdentitySettings { get; set; }

    public RedisSettings RedisSettings { get; set; }

    public MailConfig MailConfig { get; set; }

    public MinioSettings MinioSettings { get; set; }
}

public class MailConfig
{
    public string From { get; set; }

    public string Host { get; set; }

    public int Port { get; set; }

    public string Name { get; set; }

    public string Login { get; set; }

    public string Password { get; set; }

    public bool SSL { get; set; }

    public bool IsBodyHtml { get; set; }

    public bool UseDefaultCredentials { get; set; }
}

public class IdentitySettings
{
    public string SecretKey { get; set; }

    public int RefreshTokenTTL { get; set; }

    public string Issuer { get; set; }

    public string Audience { get; set; }
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
