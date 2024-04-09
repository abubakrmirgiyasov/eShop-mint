namespace Mint.WebApp.Admin.Application.Operations.Dtos.Manufactures;

public class ManufactureCategoryBindingModel
{
    public Guid? Value { get; set; }
}

public record ManufactureCategoryFullViewModel();

public class ManufactureSampleViewModel
{
    public required Guid Value { get; set; }

    public required string Label { get; set; }
}

