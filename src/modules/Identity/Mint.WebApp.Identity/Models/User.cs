using Mint.Infrastructure.MongoDb.Attributes;
using Mint.Infrastructure.MongoDb.Models;

namespace Mint.WebApp.Identity.Models;

[BsonCollection("users")]
public class User : Document
{
    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    public long Phone { get; set; }

    public string Password { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? DateBirth { get; set; }

    public string Gender { get; set; } = null!;

    public byte[]? Salt { get; set; }

    public string? Ip { get; set; }

    public bool IsActive { get; set; } = false;

    public int NumOfAttempts { get; set; } = 0;

    public bool IsConfirmedEmail { get; set; } = false;

    public bool IsConfirmedPhone { get; set; } = false;

    public string? UserAgent { get; set; }

    public string? AcceptLanguage { get; set; }

    public Guid? PhotoId { get; set; }

    public Photo? Photo { get; set; }

    public List<UserRole> UserRoles { get; set; } = null!;

    public List<RefreshToken> RefreshTokens { get; set; } = null!;
}
