using Mint.Domain.Models.Base;
using Mint.WebApp.Admin.Models.Categories;
using Mint.WebApp.Admin.Models.Products;
using System.ComponentModel.DataAnnotations;

namespace Mint.WebApp.Admin.Models;

public class Tag : Entity<Guid>
{
    [Required(ErrorMessage = "Заполните обязательное поле")]
    [MaxLength(100, ErrorMessage = "Превышено макс. длина строки (100).")]
    [MinLength(2, ErrorMessage = "Мин. длина строки (2).")]
    public string Name { get; set; } = null!;

    [MaxLength(100, ErrorMessage = "Превышено макс. длина строки (100).")]
    [MinLength(2, ErrorMessage = "Мин. длина строки (2).")]
    public string? Translate { get; set; }

    public List<ProductTag>? ProductTags { get; set; }

    public List<CategoryTag>? CategoryTags { get; set; }
}
