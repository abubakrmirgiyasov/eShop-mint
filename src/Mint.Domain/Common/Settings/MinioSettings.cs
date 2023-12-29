#nullable disable

namespace Mint.Domain.Common.Settings;

public class MinioSettings
{
    public string Endpoint { get; set; }

    public string SecretKey { get; set; }

    public string AccessKey { get; set; }

    public bool Secure { get; set; }

    public int Expiry { get; set; }
}
