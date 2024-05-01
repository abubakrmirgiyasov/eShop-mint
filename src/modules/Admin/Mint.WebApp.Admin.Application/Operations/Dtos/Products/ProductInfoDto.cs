namespace Mint.WebApp.Admin.Application.Operations.Dtos.Products;

public class ProductInfoViewModel : ProductViewModel
{
    public required string UrlToProduct { get; set; }

    public required Guid StoreId { get; set; }

    public required DateTimeOffset CreatedDate { get; set; }
}

public class ProductInfoBindingModel
{
    public bool ShowOnHomePage { get; set; }

    public bool IsPublished { get; set; }

    public required string ProductType { get; set; }

    public required string ShortName { get; set; }

    public required string LongName { get; set; }

    public required string Sku { get; set; }

    public long? Gtin { get; set; }

    public required string ShortDescription { get; set; }

    public required string FullDescription { get; set; }

    public string? AdminComment { get; set; }

    public Guid? Store { get; set; }
}
