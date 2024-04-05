namespace Mint.WebApp.Admin.Application.Operations.Dtos.Products;

public class ProductPriceViewModel
{
}

public class ProductPriceBindingModel
{
    public bool IsFreeTax { get; set; }

    public decimal TaxPrice { get; set; }

    public decimal Price { get; set; }

    public int[]? Delivery { get; set; }

    public decimal? SpecialPrice { get; set; }

    public DateTimeOffset? SpecialDateFrom { get; set; }

    public DateTimeOffset? SpecialDateTo { get; set; }

    public Guid? DiscountId { get; set; }
}
