namespace Mint.WebApp.Admin.Operations.Dtos.Manufactures;

public class ManufactureCategoryBindingModel
{
    public Guid? Value { get; set; }
}

public record ManufactureCategoryFullViewModel();

public record ManufactureSampleViewModel(
    Guid? Value = null,
    string? Label = null);
