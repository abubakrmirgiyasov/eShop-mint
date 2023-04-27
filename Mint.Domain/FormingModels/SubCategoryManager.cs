using Mint.Domain.BindingModels;
using Mint.Domain.Models;
using Mint.Domain.ViewModels;

namespace Mint.Domain.FormingModels;

public class SubCategoryManager
{
    public SubCategory FormingBindingModel(SubCategoryBindingModel model)
    {
        try
        {
            return new SubCategory()
            {
                Id = Guid.NewGuid(),
                Name = model.Name!,
                Ico = model.Ico,
                DisplayOrder = model.DisplayOrder,
            };
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public List<SubCategoryOnlylViewModel> FormingOnlyViewModels(List<SubCategory> models)
    {
        try
        {
            var subCategories = new List<SubCategoryOnlylViewModel>();

            for (int i = 0; i < models.Count; i++)
            {
                subCategories.Add(new SubCategoryOnlylViewModel()
                {
                    Value = models[i].Id,
                    Label = models[i].Name,
                });
            }
            return subCategories;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public SubCategoryFullViewModel FormingSingleViewModel(SubCategory model)
    {
        try
        {
            return new SubCategoryFullViewModel()
            {
                Id = model.Id.ToString(),
                Name = model.Name,
                DisplayOrder = model.DisplayOrder,
                Ico = model.Ico,
            };
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public List<SubCategoryFullViewModel> FormingViewModels(List<SubCategory> models)
    {
        try
        {
            var subCategories = new List<SubCategoryFullViewModel>();

            for (int i = 0; i < models.Count; i++)
            {
                subCategories.Add(new SubCategoryFullViewModel()
                {
                    Id = models[i].Id.ToString(),
                    Name = models[i].Name,
                    DisplayOrder = models[i].DisplayOrder,
                    Ico = models[i].Ico,
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
