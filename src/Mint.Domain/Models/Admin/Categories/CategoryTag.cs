using Mint.Domain.Models.Admin.Tags;

namespace Mint.Domain.Models.Admin.Categories;

public class CategoryTag
{
    public Guid? CategoryId { get; set; }

    public Category? Category { get; set; }

    public Guid? TagId { get; set; }

    public Tag? Tag { get; set; }
}
