using Microsoft.AspNetCore.Http;

namespace Mint.Domain.BindingModels;
public class ProductFullBindingModel
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? ShortDescription { get; set; }

    public string? FullDescription { get; set; }

    public string? AdminComment { get; set; }

    public bool? ShowOnHomePage { get; set; }

    public string? CountryOfOrigin { get; set; }

    public string? Sku { get; set; }

    public string? Gtin { get; set; }

    public decimal Price { get; set; }

    public decimal OldPrice { get; set; }

    public bool IsPublished { get; set; }

    public bool IsFreeTax { get; set; }

    public decimal TaxPrice { get; set; }

    public int Quantity { get; set; }

    public DateTime DateCreate { get; set; } = DateTime.Now;

    public int DeliveryMinDay { get; set; }

    public int DeliveryMaxDay { get; set; }

    public Guid? ManufactureId { get; set; }

    public Guid? CategoryId { get; set; }

    public Guid? StoreId { get; set; }

    public Guid? DiscountId { get; set; }

    public CommonCharacteristicFullBindingModel? CommonCharacteristic { get; set; }

    public IFormFileCollection? Files { get; set; }
}

public class ProductInfoBindingModel
{
    public Guid Id { get; set; }

    public string? Name { get; set; }
    
    public string? Sku { get; set; }
    
    public int Gtin { get; set; }

    public string? CountryOfOrigin { get; set; }

    public bool IsPublished { get; set; }
    
    public int DeliveryMinDay { get; set; }
    
    public int DeliveryMaxDay { get; set; }
    
    public string? ShortDescription { get; set; }
    
    public string? FullDescription { get; set; }
    
    public string? AdminComment { get; set; }
    
    public string? StoreId { get; set; }

    public int Quantity { get; set; }
}

public class ProductPriceBindingModel
{
    public Guid Id { get; set; }

    public Guid ProductId { get; set; }

    public bool IsFreeTax { get; set; }

    public decimal TaxPrice { get; set; }

    public decimal Price { get; set; }

    public decimal OldPrice { get; set; }
}

public class ProductPicturesBindingModel
{
    public Guid ProductId { get; set; }

    public string? FileType { get; set; }

    public IFormFileCollection? Files { get; set; }
}

public class ProductCategoryMappingsBindingModel
{
    public Guid ProductId { get; set; }

    public Guid CategoryId { get; set; }

    public int DisplayOrder { get; set; }
}

public class ProductManufactureMappingsBindingModel
{
    public Guid ProductId { get; set; }

    public Guid ManufactureId { get; set; }
}

public class ProductPromotionsBindingModel
{
    public Guid ProductId { get; set; }

    public Guid PromotionId { get; set; }
}