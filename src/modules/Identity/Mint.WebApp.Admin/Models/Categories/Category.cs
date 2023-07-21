using Mint.Domain.Models;
using Mint.Domain.Models.Base;
using Mint.WebApp.Admin.Models.Products;
using System.ComponentModel.DataAnnotations;

namespace Mint.WebApp.Admin.Models.Categories;

public class Category : Entity<Guid>
{
    [Required(ErrorMessage = "Заполните поле Название")]
    [MaxLength(100, ErrorMessage = "Превышено макс. длина строки (100).")]
    public string Name { get; set; } = null!;

    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")]
    public string? Ico { get; set; }

    [MaxLength(30, ErrorMessage = "Превышено макс. длина строки (30).")]
    public string? BadgeText { get; set; }

    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")]
    public string? BadgeStyle { get; set; }

    [MaxLength(60, ErrorMessage = "Превышено макс. длина строки (60).")]
    public string? DefaultLink { get; set; }

    public int DisplayOrder { get; set; }

    public Guid? PhotoId { get; set; }

    public Photo? Photo { get; set; }

    public Guid? ManufactureId { get; set; }

    public Manufacture? Manufacture { get; set; }

    public List<SubCategory>? SubCategories { get; set; }

    public List<CategoryTag>? CategoryTags { get; set; }

    //public List<StoreCategory>? StoreCategories { get; set; }

    public List<Product>? Products { get; set; }
}
