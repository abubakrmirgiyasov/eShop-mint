using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace Mint.WebApp.Identity.DTO_s;

public class AuthenticationResponse
{
    public ObjectId Id { get; set; }

    public string? FirstName { get; set; }

    public string? SecondName { get; set; }

    public string? Email { get; set; }

    public string? AccessToken { get; set; }

    public string? Image { get; set; }

    [JsonIgnore]
    public string? RefreshToken { get; set; }

    public List<RoleSampleDTO>? Roles { get; set; }
}
