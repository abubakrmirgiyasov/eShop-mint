using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Mint.Domain.Models;

public class RefreshToken
{
    [Key]
    [JsonIgnore]
    public Guid Id { get; set; }

    public string? Token { get; set; }

    public DateTime Expires { get; set; }

    public DateTime Created { get; set; }

    public DateTime? Revoked { get; set; }

    public string? CreatedByIp { get; set; }

    public string? RevokedByIp { get; set; }

    public string? ReplacedByToken { get; set; }

    public string? ReasonRevoked { get; set; }

    public bool IsExpired => DateTime.UtcNow >= Expires;

    public bool IsRevoked => Revoked != null;

    public bool IsActive => !IsRevoked && !IsExpired;

    public string? UserAgent { get; set; }

    public string? DeviceType { get; set; }

    public Guid? UserId { get; set; }

    public User? User { get; set; }
}
