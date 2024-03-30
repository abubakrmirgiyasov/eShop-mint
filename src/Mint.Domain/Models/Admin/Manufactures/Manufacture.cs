using Mint.Domain.Models.Admin.Products;
using Mint.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models.Admin.Manufactures;

public class Manufacture : Entity<Guid>
{
    public int DisplayOrder { get; set; }

    [Required(ErrorMessage = "Заполните обязательное поле")]
    [MaxLength(100, ErrorMessage = "Превышено макс. длина строки (100).")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Заполните обязательное поле")]
    [MaxLength(100, ErrorMessage = "Превышено макс. длина строки (100).")]
    public string Country { get; set; } = null!;

    [MaxLength(100, ErrorMessage = "Превышено макс. длина строки (100).")]
    public string? FullAddress { get; set; }

    [MaxLength(800, ErrorMessage = "Превышено макс. длина строки (800).")]
    public string? Description { get; set; }

    [DataType(DataType.Url)]
    [MaxLength(100, ErrorMessage = "Превышено макс. длина строки (100).")]
    public string? Website { get; set; }

    public Guid? PhotoId { get; set; }

    public Photo? Photo { get; set; }

    public List<ManufactureCategory>? ManufactureCategories { get; set; }

    public List<ManufactureTag>? ManufactureTags { get; set; }

    public List<Product>? Products { get; set; }

    public List<ManufactureContact> Contacts { get; set; } = null!;
}
