namespace Mint.WebApp.Admin.Application.Operations.Dtos.Categories;

public class CategoryTagBindingModel
{
    public Guid? Value { get; set; }
}

public record CategoryTagFullViewModel(
    Guid? Value = null,
    string? Name = null);

public record CategoryTagSampleViewModel(
    Guid? Value = null,
    string? Label = null);

public record CategoryViewModel();
