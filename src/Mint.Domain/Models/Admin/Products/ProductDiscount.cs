namespace Mint.Domain.Models.Admin.Products;

public class ProductDiscount
{
    public Guid DiscountId { get; set; }

    public Discount Discount { get; set; } = default!;

    public Guid ProductId { get; set; }

    public Product Product { get; set; } = default!;
}
