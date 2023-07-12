using Mint.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models.Identity;

public class Role : Entity<Guid>
{
    [Required(ErrorMessage = "Заполните поле Название")]
    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")] 
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Заполните поле Перевод")]
    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")]
    public string TranslateEn { get; set; } = null!;

    [Required(ErrorMessage = "Заполните поле Ключ")]
    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")]
    public string UniqueKey { get; set; } = null!;

    public List<UserRole> UserRoles { get; set; } = null!;
}
