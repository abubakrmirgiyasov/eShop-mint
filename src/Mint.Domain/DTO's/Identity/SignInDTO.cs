namespace Mint.Domain.DTO_s.Identity;

public class SignInRequest
{
    public string? Ip { get; set; }

    public string Email { get; set; } = default!;

    public string Password { get; set; } = default!;
}
