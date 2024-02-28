using Mint.WebApp.Admin.Operations.Dtos.Categories;

namespace Mint.WebApp.Admin.Operations.Dtos.SubCategories;

public class SubCategoryFullViewModel
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required string DefaultLink { get; set; }

    public required CategoryFullViewModel Category { get; set; }

    public string? FullName { get; set; }
}
