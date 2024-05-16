using Mint.WebApp.Admin.Application.Operations.Dtos.Categories;

namespace Mint.WebApp.Admin.Application.Operations.Dtos.Products;

public class ProductCategoryViewModel
{
}

public class ProductCategoryBindingModel
{
    public required int DisplayOrder { get; set; }

    public required CategorySimpleBindingModel Category { get; set; }
}
