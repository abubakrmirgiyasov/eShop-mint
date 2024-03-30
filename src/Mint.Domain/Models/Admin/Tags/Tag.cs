using Mint.Domain.Models.Admin.Categories;
using Mint.Domain.Models.Admin.Products;
using Mint.Domain.Models.Admin.Manufactures;
using Mint.Domain.Models.Base;
using Mint.Domain.Models.Stores;
using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models.Admin.Tags;

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

    public List<StoreTag>? StoreTags { get; set; }

    public List<ManufactureTag>? ManufactureTags { get; set; }
}
