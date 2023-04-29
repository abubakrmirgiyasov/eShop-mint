using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models;

public class SubCategory
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Заполните поле Название")]
    [MaxLength(100, ErrorMessage = "Перевышено макс. длина строки (100).")]
    public string Name { get; set; } = null!;

    [MaxLength(60, ErrorMessage = "Перевышено макс. длина строки (60).")]
    public string? Ico { get; set; }

    public int DisplayOrder { get; set; }

    [MaxLength(30, ErrorMessage = "Перевышено макс. длина строки (30).")]
    public string? BadgeText { get; set; }

    [MaxLength(60, ErrorMessage = "Перевышено макс. длина строки (60).")]
    public string? BadgeStyle { get; set; }

    public List<Category>? Categories { get; set; }
}
