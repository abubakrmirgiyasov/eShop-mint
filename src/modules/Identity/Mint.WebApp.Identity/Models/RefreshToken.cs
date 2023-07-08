using Mint.Domain.Models.Base;

namespace Mint.WebApp.Identity.Models;

public class RefreshToken : Entity<Guid>
{
    public string? Token { get; set; }

    public DateTime Expires { get; set; }

    public DateTime? Revoked { get; set; }

    public string? CreatedByIp { get; set; }

    public string? RevokedByIp { get; set; }

    public string? ReplacedByToken { get; set; }

    public string? ReasonRevoked { get; set; }

    public string? UserAgent { get; set; }

    public string? AcceptLanguage { get; set; }

    public bool IsExpired => DateTime.UtcNow >= Expires;

    public bool IsRevoked => Revoked != null;

    public bool IsActive => !IsRevoked && !IsExpired;

    public Guid UserId { get; set; }

    public User User { get; set; } = null!;
}
