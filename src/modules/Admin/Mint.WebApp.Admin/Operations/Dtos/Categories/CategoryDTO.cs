using Mint.WebApp.Admin.Operations.Dtos.Manufactures;

namespace Mint.WebApp.Admin.Operations.Dtos.Categories;

public class CategoryFullBindingModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string? Ico { get; set; }

    public string? BadgeStyle { get; set; }

    public string? BadgeText { get; set; }

    public string? DefaultLink { get; set; }

    public string? Description { get; set; }

    public int DisplayOrder { get; set; }

    public bool IsPublished { get; set; }

    public bool ShowOnHomePage { get; set; }

    public string? Folder { get; set; }

    public IFormFile? Photo { get; set; }

    public List<Guid>? Childs { get; set; }

    public List<CategoryTagBindingModel>? CategoryTags { get; set; }

    public List<ManufactureCategoryBindingModel>? ManufactureCategories { get; set; }
}

public class CategoryPhoto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string Bucket { get; set; } = default!;

    public IFormFile Photo { get; set; } = default!;
}

public record CategorySampleViewModel(
    Guid? Value = null,
    string? Label = null);

public record CategoryFullViewModel(
    Guid? Id = null,
    string? Name = null,
    string? Ico = null,
    string? BadgeStyle = null,
    string? BadgeText = null,
    string? DefaultLink = null,
    int? DisplayOrder = null,
    string? Photo = null,
    List<SubCategorySampleViewModel>? SubCategories = null,
    List<CategoryTagSampleViewModel>? CategoryTags = null,
    List<ManufactureSampleViewModel>? Manufactures = null);
