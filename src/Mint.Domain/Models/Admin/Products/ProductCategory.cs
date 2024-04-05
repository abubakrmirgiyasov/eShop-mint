using Mint.Domain.Models.Admin.Categories;

namespace Mint.Domain.Models.Admin.Products;

public class ProductCategory
{
    public int DisplayOrder { get; set; }

    public Guid CategoryId { get; set; }

    public Category Category { get; set; } = default!;

    public Guid ProductId { get; set; }

    public Product Product { get; set; } = default!;
}
