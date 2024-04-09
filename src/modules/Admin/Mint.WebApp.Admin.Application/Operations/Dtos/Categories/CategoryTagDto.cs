using Mint.WebApp.Admin.Application.Operations.Dtos.Tags;

namespace Mint.WebApp.Admin.Application.Operations.Dtos.Categories;

public class CategoryTagBindingModel
{
    public Guid? Value { get; set; }
}

public class CategoryTagViewModel
{
    public required TagSampleViewModel Tag { get; set; }

    public required CategorySampleViewModel Category { get; set; }
}