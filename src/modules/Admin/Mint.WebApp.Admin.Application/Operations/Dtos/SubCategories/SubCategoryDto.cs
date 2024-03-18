using Mint.WebApp.Admin.Application.Operations.Dtos.Categories;

namespace Mint.WebApp.Admin.Application.Operations.Dtos.SubCategories;

public class SubCategoryFullBindingModel
{
    public int DisplayOrder { get; set; }

    public required string Name { get; set; }

    public required string DefaultLink { get; set; }

    public string? FullName { get; set; }

    public Guid? CategoryId { get; set; }
}

public class SubCategoryFullViewModel
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required string DefaultLink { get; set; }

    public required CategoryFullViewModel Category { get; set; }

    public string? FullName { get; set; }
}

public class SubCategorySampleViewModel
{
    public required Guid Value { get; set; }

    public required string Label { get; set; }

}
