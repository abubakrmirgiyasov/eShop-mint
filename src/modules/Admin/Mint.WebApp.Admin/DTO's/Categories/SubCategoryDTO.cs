namespace Mint.WebApp.Admin.DTO_s.Categories;

public class SubCategoryFullViewModel
{
    public string Name { get; set; } = null!;

    public string? FullName { get; set; }

    public string DefaultLink { get; set; } = null!;

    public int DisplayOrder { get; set; }

    public Guid CategoryId { get; set; }
}

public class SubCategoryFullBindingModel
{
    public string Name { get; set; } = null!;

    public string? FullName { get; set; }

    public string DefaultLink { get; set; } = null!;

    public int DisplayOrder { get; set; }

    public Guid? CategoryId { get; set; }
}