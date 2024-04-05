namespace Mint.WebApp.Admin.Application.Operations.Dtos.Products;

public class ProductFullViewModel
{
    public required Guid Id { get; set; }

    public int ProductNumber { get; set; }

    public bool ShowOnHomePage { get; set; }

    public bool IsPublished { get; set; }

    public required string ShortName { get; set; }

    public required string LongName { get; set; }

    public required long Sku { get; set; }

    public required string Gtin { get; set; }

    public required string AdminComment { get; set; }

    public required string ShortDescription { get; set; }

    public required string FullDescription { get; set; }

    public decimal Price { get; set; }

    public decimal OldPrice { get; set; }
}
