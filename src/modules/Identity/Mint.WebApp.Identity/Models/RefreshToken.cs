using Mint.Infrastructure.MongoDb.Attributes;
using Mint.Infrastructure.MongoDb.Models;

namespace Mint.WebApp.Identity.Models;

[BsonCollection("refresh_tokens")]
public class RefreshToken : Document
{
    public string? Token { get; set; }

    public DateTime Expires { get; set; }

    public DateTime? Revoked { get; set; }

    public string? CreatedByIp { get; set; }

    public string? RevokedByIp { get; set; }

    public string? ReplacedByToken { get; set; }

    public string? ReasonRevoked { get; set; }

    public bool IsExpired => DateTime.UtcNow >= Expires;

    public bool IsRevoked => Revoked != null;

    public bool IsActive => !IsRevoked && !IsExpired;

    public Guid? UserId { get; set; }

    public User? User { get; set; }
}
