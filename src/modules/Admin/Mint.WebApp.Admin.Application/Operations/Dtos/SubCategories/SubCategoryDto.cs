using Mint.WebApp.Admin.Application.Operations.Dtos.Categories;

namespace Mint.WebApp.Admin.Application.Operations.Dtos.SubCategories;

public class SubCategoryInfoBindingModel
{
    public required int DisplayOrder { get; set; }

    public required string Name { get; set; }

    public required string DefaultLink { get; set; }

    public string? FullName { get; set; }

    public required CategorySimpleViewModel Category { get; set; }
}

public class SubCategoryInfoViewModel
{
    public Guid Id { get; set; }

    public int DisplayOrder { get; set; }

    public required string Name { get; set; }

    public required string DefaultLink { get; set; }

    public required CategorySimpleViewModel Category { get; set; }

    public string? FullName { get; set; }
}

public class SubCategorySimpleViewModel
{
    public required Guid Value { get; set; }

    public required string Label { get; set; }

}
