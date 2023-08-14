namespace Mint.WebApp.Admin.DTO_s;

public class TagFullBindingModel
{
    public Guid? Value { get; set; }

    public string? Label { get; set; }

    public string? Translate { get; set; }
}

public record TagFullViewModel(
    Guid? Value = null,
    string? Label = null,
    string? Translate = null);
