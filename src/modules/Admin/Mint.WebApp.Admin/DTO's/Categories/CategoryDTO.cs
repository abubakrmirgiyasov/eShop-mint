using Microsoft.AspNetCore.Http;
using Mint.WebApp.Admin.DTO_s.Manufactures;

namespace Mint.WebApp.Admin.DTO_s.Categories;

public class CategoryFullBindingModel
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? Ico { get; set; }

    public string? BadgeStyle { get; set; }

    public string? BadgeText { get; set; }

    public string? DefaultLink { get; set; }

    public int DisplayOrder { get; set; }

    public string? Folder { get; set; }

    public IFormFile? Photo { get; set; }

    public List<Guid>? Childs { get; set; }

    public List<CategoryTagBindingModel>? CategoryTags { get; set; }

    public List<ManufactureCategoryBindingModel>? ManufactureCategories { get; set; }
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
    string? Folder = null,
    List<SubCategoryFullViewModel>? SubCategories = null,
    List<CategoryTagFullViewModel>? CategoryTags = null,
    List<ManufactureCategoryFullViewModel>? ManufactureCategories = null);
