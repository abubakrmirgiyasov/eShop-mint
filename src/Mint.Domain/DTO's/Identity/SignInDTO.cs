using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.DTO_s.Identity;

public class SignInRequest
{
    public string? Ip { get; set; }

    public string Type { get; set; } = default!;

    [Required(ErrorMessage = "Заполните поле логин")]
    public string Login { get; set; } = default!;

    [Required(ErrorMessage = "Заполните поле пароль")]
    public string Password { get; set; } = default!;

    public string CountryCode { get; set; } = default!;
}
