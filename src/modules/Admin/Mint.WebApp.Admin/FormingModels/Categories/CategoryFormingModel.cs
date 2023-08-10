using Mint.Domain.Models.Admin.Categories;
using Mint.WebApp.Admin.DTO_s.Categories;

namespace Mint.WebApp.Admin.FormingModels.Categories;

public class CategoryFormingModel
{
    public IEnumerable<CategoryFullViewModel> FormingMultiFullViewModels(List<Category> model)
    {
        var categories = new List<CategoryFullViewModel>();
        foreach (var category in model)
        {

        }
        return categories;
    }
}
