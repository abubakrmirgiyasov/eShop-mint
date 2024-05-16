namespace Mint.WebApp.Admin.Identity.Application.Operations.Dtos;

public class SignInRequest
{
    public string? Ip { get; set; }

    public required string Type { get; set; }

    public required string Login { get; set; }

    public required string Password { get; set; }
}
