using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models;

public class Category
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Заполните объязательное поле")]
    [MaxLength(100, ErrorMessage = "Перевышено макс. длина строки (100).")]
    public string Name { get; set; } = null!;

    [MaxLength(400, ErrorMessage = "Перевышено макс. длина строки (400).")]
    public string? FullName { get; set; }

    [MaxLength(30, ErrorMessage = "Перевышено макс. длина строки (30).")]
    public string? BadgeText { get; set; }

    [MaxLength(60, ErrorMessage = "Перевышено макс. длина строки (60).")]
    public string? BadgeStyle { get; set; }

    [MaxLength(60, ErrorMessage = "Перевышено макс. длина строки (60).")]
    public string? ExternalLink { get; set; }

    [Required(ErrorMessage = "Заполните объязательное поле")]
    [MaxLength(60, ErrorMessage = "Перевышено макс. длина строки (60).")]
    public string Ico { get; set; } = null!;

    public int DisplayOrder { get; set; }

    public List<SubCategory>? SubCategories { get; set; }

    public Guid? ManufactureId { get; set; }

    public Manufacture? Manufacture { get; set; }
}
