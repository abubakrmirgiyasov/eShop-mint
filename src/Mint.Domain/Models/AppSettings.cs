#nullable disable

namespace Mint.Domain.Models;

public class AppSettings
{
    public string SecretKey { get; set; }

    public int RefreshTokenTTL { get; set; }
}
