using Mint.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mint.WebApp.Admin.Models.Products;

public class Product : Entity<Guid>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ProductNumber { get; set; }

    [Required(ErrorMessage = "Заполните обязательное поле.")]
    [StringLength(255, ErrorMessage = "Перевешено макс. длина строки (255).")]
    public string ShortName { get; set; } = null!;

    [StringLength(450, ErrorMessage = "Перевешено макс. длина строки (450).")]
    public string LongName { get; set; } = null!;

    [Required(ErrorMessage = "Заполните обязательное поле.")]
    public int Sku { get; set; }

    [StringLength(255, ErrorMessage = "Превышено макс. длина строки (255).")]
    public string? Gtin { get; set; }

    [Required(ErrorMessage = "Заполните обязательное поле.")]
    [StringLength(800, ErrorMessage = "Превышено макс. длина строки (800).")]
    public string ShortDescription { get; set; } = null!;

    [Required(ErrorMessage = "Заполните обязательное поле.")]
    [StringLength(4000, ErrorMessage = "Превышено макс. длина строки (4000).")]
    public string FullDescription { get; set; } = null!;

    [StringLength(255, ErrorMessage = "Превышено макс. длина строки (255).")]
    public string? AdminComment { get; set; }

    public bool? ShowOnHomePage { get; set; }

    public string? CountryOfOrigin { get; set; }

    [Required(ErrorMessage = "Заполните обязательное поле.")]
    [MaxLength(7, ErrorMessage = "Превышено макс. длина строки (7).")]
    [MinLength(2, ErrorMessage = "Мин. длина строки (2).")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Заполните обязательное поле.")]
    [MaxLength(7, ErrorMessage = "Превышено макс. длина строки (7).")]
    [MinLength(2, ErrorMessage = "Мин. длина строки (2).")]
    public decimal OldPrice { get; set; }

    public bool IsPublished { get; set; } = false;

    public bool IsFreeTax { get; set; } = false;

    public decimal TaxPrice { get; set; } = 0;

    public int DeliveryMinDay { get; set; }

    public int DeliveryMaxDay { get; set; }

    public Guid? CharacteristicId { get; set; }

    public Characteristic? Characteristic { get; set; }

    public List<ProductPhoto>? ProductPhotos { get; set; }

    public List<ProductTag>? ProductTags { get; set; }

    public List<CommonCharacteristic>? CommonCharacteristics { get; set; }
}
