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

    public static IEnumerable<CategorySampleViewModel> FormingSampleViewModels(List<Category> models)
    {
        try
        {
            var categories = new List<CategorySampleViewModel>();
            foreach (var model in models)
            {
                categories.Add(new CategorySampleViewModel()
                {
                    Value = model.Id,
                    Label = model.Name,
                });
            }
            return categories;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
