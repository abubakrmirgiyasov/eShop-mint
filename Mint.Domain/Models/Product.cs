using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models;

public class Product
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Заполните обязательное поле.")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Заполните обязательное поле.")]
    [StringLength(800, ErrorMessage = "Перевышено макс. длина строки (800).")]
    public string ShortDescription { get; set; } = null!;

    [Required(ErrorMessage = "Заполните обязательное поле.")]
    [StringLength(4000, ErrorMessage = "Перевышено макс. длина строки (4000).")]
    public string FullDescription { get; set; } = null!;
    
    [StringLength(255, ErrorMessage = "Перевышено макс. длина строки (255).")]
    public string? AdminComment { get; set; }
    
    public bool? ShowOnHomePage { get; set; }

    public string? CountryOfOrigin { get; set; }

    [Required(ErrorMessage = "Заполните обязательное поле.")]
    [StringLength(255, ErrorMessage = "Перевышено макс. длина строки (255).")]
    public string Sku { get; set; } = null!;

    public string? Gtin { get; set; }

    [Required(ErrorMessage = "Заполните обязательное поле.")]
    [MaxLength(7, ErrorMessage = "Перевышено макс. длина строки (7).")]
    [MinLength(2, ErrorMessage = "Мин. длина строки (2).")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Заполните обязательное поле.")]
    [MaxLength(7, ErrorMessage = "Перевышено макс. длина строки (7).")]
    [MinLength(2, ErrorMessage = "Мин. длина строки (2).")]
    public decimal OldPrice { get; set; }

    public bool IsFreeTax { get; set; } = false;

    public decimal TaxPrice { get; set; } = 0;
        
    public DateTime DateCreate { get; set; } = DateTime.Now;

    public int DeliveryMinDay { get; set; }

    public int DeliveryMaxDay { get; set; }

    public Guid? ManufactureId { get; set; }

    public Manufacture? Manufacture { get; set; }

    public Guid? CategoryId { get; set; }

    public Category? Category { get; set; }

    public Guid? StoreId { get; set; }

    public Store? Store { get; set; }

    public Guid? CommonCharacteristicId { get; set; }

    public CommonCharacteristic? CommonCharacteristic { get; set; }

    public Guid? DiscountId { get; set; }

    public Discount? Discount { get; set; }

    public List<ProductPhoto>? ProductPhotos { get; set; }

    public List<Order> Orders { get; set; } = null!;

    public List<Storage>? Storages { get; set; }
}
