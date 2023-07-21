namespace Mint.WebApp.Admin.Models.Categories;

public class CategoryTag
{
    public Guid? CategoryId { get; set; }

    public Category? Category { get; set; }

    public Guid? TagId { get; set; }

    public Tag? Tag { get; set; }
}
