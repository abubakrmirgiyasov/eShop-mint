using System.Text.Json.Serialization;

namespace Mint.Domain.DTO_s.Identity;

public class AuthenticationAdminResponse
{
    [JsonPropertyName("access_token")]
    public string Token { get; set; } = null!;
}
