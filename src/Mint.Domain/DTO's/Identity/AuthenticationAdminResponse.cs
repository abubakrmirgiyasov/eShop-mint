using System.Text.Json.Serialization;

namespace Mint.Domain.DTO_s.Identity;

public class AuthenticationAdminResponse
{
    [JsonPropertyName("token")]
    public string Token { get; set; } = null!;
}
