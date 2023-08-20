namespace Mint.WebApp.Admin.DTO_s.Manufactures;

public class ManufactureFullBindingModel
{
    public Guid? Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Country { get; set; }

    public string? Email { get; set; }

    public long Phone { get; set; }

    public string? FullAddress { get; set; }

    public string? Website { get; set; }

    public int DisplayOrder { get; set; }

    public string? Folder { get; set; }

    public IFormFile? Photo { get; set; }

    public List<ManufactureCategoryBindingModel>? ManufactureCategories { get; set; }

    public List<ManufactureTagBindingModel>? ManufactureTags { get; set; }
}

public record ManufactureFullViewModel(
    Guid? Id = null,
    string? Name = null,
    string? Description = null,
    string? Email = null,
    long Phone = 0,
    string? FullAddress = null,
    string? Website = null,
    string? Folder = null,
    int DisplayOrder = 0,
    string? ImagePath = null,
    List<ManufactureCategoryFullViewModel>? ManufactureCategories = null,
    List<object>? Products = null);
