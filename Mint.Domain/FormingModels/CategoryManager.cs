using Mint.Domain.BindingModels;
using Mint.Domain.Models;
using Mint.Domain.ViewModels;
using System.Reflection;

namespace Mint.Domain.FormingModels;

public class CategoryManager
{
    public Category FormingBindingModel(CategoryFullBindingModel model)
    {
        try
        {
            return new Category()
            {
                Id = Guid.NewGuid(),
                BadgeText = model.BadgeText,
                BadgeStyle = model.BadgeStyle,
                DisplayOrder = model.DisplayOrder,
                FullName = model.FullName,
                ManufactureId = model.ManufactureId != null ? Guid.Parse(model.ManufactureId!) : null,
                ExternalLink = null,
            };
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public CategoryViewModel FormingModel(Category model)
    {
        try
        {
            byte[] bytes = File.ReadAllBytes(model.Photo != null ? model.Photo.FilePath : "default-image.png");

            return new CategoryViewModel()
            {
                Id = model.Id,
                BadgeText = model.BadgeText,
                DisplayOrder = model.DisplayOrder,
                Name = model.Name,
                BadgeStyle = model.BadgeStyle,
                FullName = model.FullName,
                SubCategory = model.SubCategory?.Name,
                Manufacture = model.Manufacture?.Name,
                ExternalLink = model.ExternalLink,
                Photo = Convert.ToBase64String(bytes),
            };
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public List<CategoryViewModel> FormingViewModels(List<Category> models)
    {
        try
        {
            var categories = new List<CategoryViewModel>();

            for (int i = 0; i < models.Count; i++)
            {
                byte[] bytes = File.ReadAllBytes(models[i].Photo != null ? models[i].Photo!.FilePath : "default-image.png");

                categories.Add(new CategoryViewModel()
                {
                    Id = models[i].Id,
                    SubCategory = models[i].SubCategory?.Name,
                    Manufacture = models[i].Manufacture?.Name,
                    ExternalLink = models[i].ExternalLink,
                    DisplayOrder = models[i].DisplayOrder,
                    FullName = models[i].FullName,
                    Name = models[i].Name,
                    BadgeStyle = models[i].BadgeStyle,
                    BadgeText = models[i].BadgeText,
                    Photo = "data:image/*;base64," + Convert.ToBase64String(bytes),
                });
            };

            return categories;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
