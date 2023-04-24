namespace Mint.Domain.ViewModels;

public class ManufactureViewModel
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public int DisplayOrder { get; set; }

    public string? Description { get; set; }

    public string? Photo { get; set; }
}
