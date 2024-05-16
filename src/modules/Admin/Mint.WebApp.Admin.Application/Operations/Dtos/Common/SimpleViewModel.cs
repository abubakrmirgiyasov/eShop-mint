namespace Mint.WebApp.Admin.Application.Operations.Dtos.Common;

public class SimpleViewModel
{
    public required Guid Value { get; set; }

    public required string Label { get; set; }
}

public class SimpleBindingModel
{
    public required Guid Value { get; set; }

    public required string Label { get; set; }
}
