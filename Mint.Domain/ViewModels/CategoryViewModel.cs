namespace Mint.Domain.ViewModels;

public class CategoryViewModel
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? FullName { get; set; }

    public string? BadgeText { get; set; }

    public string? BadgeStyle { get; set; }

    public string? ExternalLink { get; set; }

    public int DisplayOrder { get; set; }

    public string? Photo { get; set; }

    public string? SubCategory { get; set; }

    public string? Manufacture { get; set; }

    public string? DefaultLink { get; set; }
}
