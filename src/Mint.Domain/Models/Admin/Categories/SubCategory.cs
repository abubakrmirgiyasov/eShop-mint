using Mint.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models.Admin.Categories;

public class SubCategory : Entity<Guid>
{
    [Required(ErrorMessage = "Заполните обязательное поле")]
    [MaxLength(100, ErrorMessage = "Превышено макс. длина строки (100).")]
    public string Name { get; set; } = null!;

    [MaxLength(400, ErrorMessage = "Превышено макс. длина строки (400).")]
    public string? FullName { get; set; }

    [Required(ErrorMessage = "Заполните обязательное поле")]
    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")]
    public string DefaultLink { get; set; } = null!;

    public int DisplayOrder { get; set; }

    public Guid? CategoryId { get; set; }

    public Category? Category { get; set; }
}
