using Mint.Domain.Models.Admin.Manufactures;
using Mint.Domain.Models.Admin.Stores;
using Mint.Domain.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace Mint.Domain.Models.Admin.Products;

public class Product : Entity<Guid>
{
    public int ProductNumber { get; set; }

    [Required(ErrorMessage = "Заполните обязательное поле")]
    [StringLength(255, ErrorMessage = "Перевешено макс. длина строки (255).")]
    public required string ShortName { get; set; }

    [StringLength(450, ErrorMessage = "Перевешено макс. длина строки (450).")]
    public required string LongName { get; set; }

    [Required(ErrorMessage = "Заполните обязательное поле.")]
    public required string Sku { get; set; }

    [StringLength(255, ErrorMessage = "Превышено макс. длина строки (255).")]
    public long? Gtin { get; set; }

    [Required(ErrorMessage = "Заполните обязательное поле.")]
    [StringLength(800, ErrorMessage = "Превышено макс. длина строки (800).")]
    public required string ShortDescription { get; set; }

    [Required(ErrorMessage = "Заполните обязательное поле.")]
    [StringLength(4000, ErrorMessage = "Превышено макс. длина строки (4000).")]
    public required string FullDescription { get; set; }

    [StringLength(255, ErrorMessage = "Превышено макс. длина строки (255).")]
    public string? AdminComment { get; set; }

    [StringLength(255, ErrorMessage = "Превышено макс. длина строки (255).")]
    public string UrlToProduct { get; set; } = "";

    public bool ShowOnHomePage { get; set; } = false;

    public bool DisableBuyButton { get; set; }

    public string? CountryOfOrigin { get; set; }

    [Required(ErrorMessage = "Заполните обязательное поле.")]
    [MaxLength(7, ErrorMessage = "Превышено макс. длина строки (7).")]
    [MinLength(2, ErrorMessage = "Мин. длина строки (2).")]
    public decimal? Price { get; set; } = 0;

    [Required(ErrorMessage = "Заполните обязательное поле.")]
    [MaxLength(7, ErrorMessage = "Превышено макс. длина строки (7).")]
    [MinLength(2, ErrorMessage = "Мин. длина строки (2).")]
    public decimal? OldPrice { get; set; } = 0;

    public bool CustomerEntersPrice { get; set; } = false;

    public decimal? MinCustomerEntersPrice { get; set; }

    public decimal? MaxCustomerEntersPrice { get; set; }

    public decimal? SpecialPrice { get; set; }

    public DateTimeOffset? SpecialPriceStartDateTimeUtc { get; set; }
    
    public DateTimeOffset? SpecialPriceEndDateTimeUtc { get; set; }

    public bool IsPublished { get; set; } = false;

    public bool? IsFreeTax { get; set; } = false;

    public decimal? TaxPrice { get; set; } = 0;

    public int DeliveryMinDay { get; set; }

    public int DeliveryMaxDay { get; set; }

    public bool OwnStorage { get; set; } = false;

    public bool OwnStore { get; set; } = false;

    public Guid? UnitId { get; set; }

    public Unit? Unit { get; set; }

    public Guid? ManufactureId { get; set; }

    public Manufacture? Manufacture { get; set; }

    public Guid? StoreId { get; set; }

    public Store? Store { get; set; }

    public Guid? DiscountId { get; set; }

    public Discount? Discount { get; set; }

    public List<ProductPhoto>? ProductPhotos { get; set; }

    public List<ProductTag>? ProductTags { get; set; }

    public List<CommonCharacteristic>? CommonCharacteristics { get; set; }

    public List<ProductCharacteristic>? ProductCharacteristics { get; set; }

    public List<Storage>? Storages { get; set; }

    public List<ProductReview>? ProductReviews { get; set; }

    public List<ProductCategory>? ProductCategories { get; set; }

    public List<ProductDiscount>? ProductDiscounts { get; set; }
}
