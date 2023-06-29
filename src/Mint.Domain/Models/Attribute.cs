using Mint.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models;

public class Attribute : Entity<Guid>
{
    [Required(ErrorMessage = "Заполните обязательное поле")]
    [MaxLength(100, ErrorMessage = "Превышено макс. длина строки (100).")]
    [MinLength(2, ErrorMessage = "Мин. длина строки (2).")]
    public string Name { get; set; } = null!;

    [MaxLength(100, ErrorMessage = "Превышено макс. длина строки (100).")]
    [MinLength(2, ErrorMessage = "Мин. длина строки (2).")]
    public string? Translate { get; set; }

    public List<ProductAttribute>? ProductAttributes { get; set; }

    public List<CategoryAttribute>? CategoryAttributes { get; set; }
}
