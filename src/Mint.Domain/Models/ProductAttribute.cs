namespace Mint.Domain.Models;

public class ProductAttribute
{
    public Guid? ProductId { get; set; }

    public Product? Product { get; set; }

    public Guid? AttributeId { get; set; }

    public Attribute? Attribute { get; set; }
}
