using Mint.Domain.Models.Admin.Categories;
using Mint.WebApp.Admin.DTO_s.Categories;

namespace Mint.WebApp.Admin.FormingModels.Categories;

public class SubCategoryFormingModel
{
    public static IEnumerable<SubCategoryFullViewModel> FormingFullViewModels(List<SubCategory> models)
    {
        try
        {
            var subCategories = new List<SubCategoryFullViewModel>();
            foreach (var model in models)
            {
                subCategories.Add(new SubCategoryFullViewModel()
                {
                    Id = model.Id,
                    Name = model.Name,
                    FullName = model.FullName,
                    DefaultLink = model.DefaultLink,
                    DisplayOrder = model.DisplayOrder,
                    Category = new CategoryFullViewModel()
                    {
                        Id = model.Category?.Id,
                        Name = model.Category?.Name,
                        BadgeText = model.Category?.BadgeText,
                        BadgeStyle = model.Category?.BadgeStyle,
                        DefaultLink = model.Category?.DefaultLink,
                        DisplayOrder = model.Category?.DisplayOrder,
                        Ico = model.Category?.Ico,
                    },
                });
            }
            return subCategories;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public static SubCategory FormingSingleBindingModel(SubCategoryFullBindingModel model)
    {
        try
        {
            return new SubCategory()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                CategoryId = model.CategoryId,
                DefaultLink = model.DefaultLink,
                DisplayOrder = model.DisplayOrder,
                FullName = model.FullName,
            };
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public static IEnumerable<SubCategorySampleViewModel> FormingSampleModels(List<SubCategory> models)
    {
        try
        {
            var subCategories = new List<SubCategorySampleViewModel>();
            foreach (var model in models)
            {
                subCategories.Add(new SubCategorySampleViewModel()
                {
                    Label = model.Name,
                    Value = model.Id,
                });
            }
            return subCategories;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
