namespace Mint.Domain.Models;

public class CategoryAttribute
{
    public Guid? CategoryId { get; set; }

    public Category? Category { get; set; }

    public Guid? AttributeId { get; set; }

    public Attribute? Attribute { get; set; }
}
