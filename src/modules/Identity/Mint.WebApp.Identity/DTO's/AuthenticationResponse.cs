using System.Text.Json.Serialization;

namespace Mint.WebApp.Identity.DTO_s;

public class AuthenticationResponse
{
    public Guid Id { get; set; }

    public string? FirstName { get; set; }

    public string? SecondName { get; set; }

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public DateTime? DateBirth { get; set; }

    public bool IsConfirmedEmail { get; set; }

    public bool IsConfirmedPhone { get; set; }

    public bool IsSeller { get; set; }

    public string? Email { get; set; }

    public string? AccessToken { get; set; }

    public string? Image { get; set; }

    public long Phone { get; set; }

    [JsonIgnore]
    public string? RefreshToken { get; set; }

    public List<RoleSampleDTO>? Roles { get; set; }
}
