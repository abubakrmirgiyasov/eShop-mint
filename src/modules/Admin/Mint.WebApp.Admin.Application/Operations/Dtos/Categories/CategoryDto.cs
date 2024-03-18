using Microsoft.AspNetCore.Http;
using Mint.WebApp.Admin.Application.Operations.Dtos.Manufactures;
using Mint.WebApp.Admin.Application.Operations.Dtos.SubCategories;

namespace Mint.WebApp.Admin.Application.Operations.Dtos.Categories;

public class CategoryFullBindingModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string? Ico { get; set; }

    public string? BadgeStyle { get; set; }

    public string? BadgeText { get; set; }

    public string? DefaultLink { get; set; }

    public int DisplayOrder { get; set; }

    public bool IsPublished { get; set; }

    public bool ShowOnHomePage { get; set; }

    public string? Folder { get; set; }

    public string? Description { get; set; }

    public IFormFile? Photo { get; set; }

    public List<Guid>? Childs { get; set; }

    public List<CategoryTagBindingModel>? CategoryTags { get; set; }

    public List<ManufactureCategoryBindingModel>? ManufactureCategories { get; set; }
}

public class CategoryPhotoDto
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required string Bucket { get; set; }

    public required IFormFile Photo { get; set; }
}

public class CategorySampleViewModel
{
    public required Guid Value { get; set; }

    public required string Label { get; set; }
}

public class CategoryFullViewModel
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public string? Ico { get; set; }

    public string? BadgeStyle { get; set; }

    public string? BadgeText { get; set; }

    public string? DefaultLink { get; set; }

    public int DisplayOrder { get; set; }

    public string? Photo { get; set; }

    public List<SubCategorySampleViewModel>? SubCategories { get; set; }

    public List<CategoryTagSampleViewModel>? CategoryTags { get; set; }

    public List<ManufactureSampleViewModel>? Manufactures { get; set; }
}
