using Mint.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.DTO_s.Identity;

public class SignInRequest
{
    public string? Ip { get; set; }

    public ContactType Type { get; set; }

    [Required(ErrorMessage = "Заполните поле логин")]
    public string Login { get; set; } = default!;

    [Required(ErrorMessage = "Заполните поле пароль")]
    public string Password { get; set; } = default!;
}
