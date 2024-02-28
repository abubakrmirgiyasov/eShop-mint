namespace Mint.WebApp.Admin.Operations.Dtos.SubCategories;

public class SubCategoryFullBindingModel
{
    public int DisplayOrder { get; set; }

    public required string Name { get; set; }

    public required string DefaultLink { get; set; }

    public string? FullName { get; set; }

    public Guid? CategoryId { get; set; }
}
