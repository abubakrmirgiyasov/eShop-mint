﻿using Mint.Domain.BindingModels;
using Mint.Domain.Common;
using Mint.Domain.Models;
using Mint.Domain.ViewModels;

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
                DisplayOrder = model.DisplayOrder,
                FullName = model.FullName,
                ManufactureId = model.ManufactureId != null ? Guid.Parse(model.ManufactureId) : null,
                ExternalLink = null,
                DefaultLink = model.DefaultLink?.Trim('/'),
                SubCategoryId = model.SubCategoryId != null ? Guid.Parse(model.SubCategoryId) : null,
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
            return new CategoryViewModel()
            {
                Id = model.Id,
                DisplayOrder = model.DisplayOrder,
                Name = model.Name,
                FullName = model.FullName,
                SubCategory = model.SubCategory?.Name,
                Manufacture = model.Manufacture?.Name,
                ExternalLink = model.ExternalLink,
                DefaultLink = model.DefaultLink,
                BadgeText = model.SubCategory?.BadgeText,
                BadgeStyle = model.SubCategory?.BadgeStyle,
                Photo = model.Photo.GetImage64(),
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
                categories.Add(new CategoryViewModel()
                {
                    Id = models[i].Id,
                    SubCategory = models[i].SubCategory?.Name,
                    Manufacture = models[i].Manufacture?.Name,
                    ExternalLink = models[i].ExternalLink,
                    DisplayOrder = models[i].DisplayOrder,
                    FullName = models[i].FullName,
                    Name = models[i].Name,
                    BadgeStyle = models[i].SubCategory?.BadgeStyle?.ToLower(),
                    BadgeText = models[i].SubCategory?.BadgeText?.ToLower(),
                    Photo =  models[i].Photo.GetImage64(),
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
