using Mint.Domain.Models;
using Mint.Domain.Models.Base;
using Mint.WebApp.Admin.Models.Products;
using System.ComponentModel.DataAnnotations;

namespace Mint.WebApp.Admin.Models.Categories;

public class Manufacture : Entity<Guid>
{
    [Required(ErrorMessage = "Заполните обязательное поле")]
    [MaxLength(100, ErrorMessage = "Превышено макс. длина строки (100).")]
    public string Name { get; set; } = null!;

    [MaxLength(100, ErrorMessage = "Превышено макс. длина строки (100).")]
    public string Country { get; set; } = null!;

    [Required(ErrorMessage = "Заполните обязательное поле")]
    [DataType(DataType.EmailAddress)]
    [MaxLength(100, ErrorMessage = "Превышено макс. длина строки (100).")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Заполните обязательное поле")]
    [DataType(DataType.PhoneNumber)]
    public long Phone { get; set; }

    [MaxLength(100, ErrorMessage = "Превышено макс. длина строки (100).")]
    public string? FullAddress { get; set; }

    [MaxLength(800, ErrorMessage = "Превышено макс. длина строки (800).")]
    public string? Description { get; set; }

    [DataType(DataType.Url)]
    [MaxLength(100, ErrorMessage = "Превышено макс. длина строки (100).")]
    public string? Website { get; set; }

    public int DisplayOrder { get; set; }

    public Guid? PhotoId { get; set; }

    public Photo? Photo { get; set; }

    public List<Category>? Categories { get; set; }

    public List<Product>? Products { get; set; }
}
