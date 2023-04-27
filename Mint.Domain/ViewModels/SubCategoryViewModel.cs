namespace Mint.Domain.ViewModels;

public class SubCategoryFullViewModel
{
    public string? Id { get; set; }

    public string? Name { get; set; }

    public string? Ico { get; set; }

    public int DisplayOrder { get; set; }
}

public class SubCategoryOnlylViewModel
{
    public Guid Value { get; set; }

    public string? Label { get; set; }
}