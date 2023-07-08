#nullable disable

namespace Mint.Domain.Common;

public class AppSettings
{
    public string SecretKey { get; set; }

    public int RefreshTokenTTL { get; set; }
}
