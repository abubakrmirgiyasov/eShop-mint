namespace Mint.WebApp.Admin.DTO_s.Categories;

public class SubCategoryFullBindingModel
{
    public string Name { get; set; } = null!;

    public string? FullName { get; set; }

    public string DefaultLink { get; set; } = null!;

    public int DisplayOrder { get; set; }

    public Guid? CategoryId { get; set; }
}

public record SubCategoryFullViewModel(
    Guid? Id = null,
    string? Name = null,
    string? FullName = null,
    string? DefaultLink = null,
    int? DisplayOrder = null,
    CategoryFullViewModel? Category = null);

public record SubCategorySampleViewModel(
    Guid? Value = null,
    string? Label = null);
