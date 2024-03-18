namespace Mint.WebApp.Admin.Application.Operations.Dtos.Tags;

public class TagFullBindingModel
{
    public Guid? Value { get; set; }

    public string? Label { get; set; }

    public string? Translate { get; set; }
}

public class TagFullViewModel
{
    public Guid? Value { get; set; }

    public string? Label { get; set; }

    public string? Translate { get; set; }
}
