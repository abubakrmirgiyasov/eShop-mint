namespace Mint.WebApp.Admin.Application.Operations.Dtos.Tags;

public class TagFullBindingModel
{
    public Guid? Value { get; set; }

    public string? Label { get; set; }

    public string? Translate { get; set; }
}

public class TagFullViewModel
{
    public required Guid Value { get; set; }

    public required string Label { get; set; }

    public required string Translate { get; set; }
}

public class TagSampleViewModel
{
    public required Guid Value { get; set; }

    public required string Label { get; set; }
}