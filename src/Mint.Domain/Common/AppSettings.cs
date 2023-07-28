#nullable disable

namespace Mint.Domain.Common;

public class IdentitySettings
{
    public string SecretKey { get; set; }

    public int RefreshTokenTTL { get; set; }
}
