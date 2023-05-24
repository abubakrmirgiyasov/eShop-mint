using Mint.Domain.BindingModels;
using System.Text.Json.Serialization;

namespace Mint.Domain.Models;

public class AuthenticationResponse
{
    public Guid Id { get; set; }

    public string? FirstName { get; set; }

    public string? SecondName { get; set; }

    public string? Email { get; set; }

    public string? AccessToken { get; set; }

    public string? ImagePath { get; set; }

    public List<RoleSampleBindingModel>? Roles { get; set; }

    [JsonIgnore]
    public string? RefreshToken { get; set; }
}
