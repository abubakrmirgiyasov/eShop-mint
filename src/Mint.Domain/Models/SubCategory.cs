using Mint.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models;

public class SubCategory : Entity<Guid>
{
    [Required(ErrorMessage = "Заполните поле Название")]
    [MaxLength(100, ErrorMessage = "Превышено макс. длина строки (100).")]
    public string Name { get; set; } = null!;

    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")]
    public string? Ico { get; set; }

    public int DisplayOrder { get; set; }

    [MaxLength(30, ErrorMessage = "Превышено макс. длина строки (30).")]
    public string? BadgeText { get; set; }

    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")]
    public string? BadgeStyle { get; set; }

    public List<Category>? Categories { get; set; }
}
