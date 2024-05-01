using Mint.WebApp.Admin.Application.Operations.Dtos.Discounts;

namespace Mint.WebApp.Admin.Application.Operations.Dtos.Products;

public class ProductPriceViewModel
{
    public required bool IsFreeTax { get; set; }

    public decimal? TaxPrice { get; set; }

    public required decimal Price { get; set; }

    public decimal? SpecialPrice { get; set; }

    public DateOnly? SpecialDateFrom { get; set; }

    public DateOnly? SpecialDateTo { get; set; }

    public required int DeliveryMinDay { get; set; }

    public required int DeliveryMaxDay { get; set; }

    public required bool DisableBuyButton { get; set; }

    public required bool CustomerEntersPrice { get; set; }

    public decimal? MinCustomerEntersPrice { get; set; }

    public decimal? MaxCustomerEntersPrice { get; set; }

    public required SimpleDiscountViewModel ProductDiscount { get; set; }
}

public class ProductPriceBindingModel
{
    public required bool IsFreeTax { get; set; }

    public decimal? TaxPrice { get; set; }

    public required decimal Price { get; set; }

    public required int[] Delivery { get; set; }

    public decimal? SpecialPrice { get; set; }

    public SpecialDate? SpecialDate { get; set; }

    public required bool DisableBuyButton { get; set; }

    public required bool CustomerPrice { get; set; }

    public decimal? CustomerPriceMin { get; set; }

    public decimal? CustomerPriceMax { get; set; }

    public Guid? DiscountId { get; set; }
}

public sealed class SpecialDate
{
    public required DateOnly From { get; set; }

    public required DateOnly To { get; set; }
}
