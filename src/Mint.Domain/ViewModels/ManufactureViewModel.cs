namespace Mint.Domain.ViewModels;

public class ManufactureViewModel
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public int DisplayOrder { get; set; }

    public string? Description { get; set; }

    public string? Photo { get; set; }
}

public class ManufactureOnly
{
    public Guid Value { get; set; }

    public string? Label { get; set; }
}