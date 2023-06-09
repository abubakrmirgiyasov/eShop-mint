﻿using Mint.Domain.BindingModels;
using Mint.Domain.Common;
using Mint.Domain.Models;
using Mint.Domain.ViewModels;

namespace Mint.Domain.FormingModels;

public class ManufactureManager
{
    public async Task<Manufacture> FormingBindingModel(ManufactureBindingModel model)
    {
        try
        {
            var manufacture = new Manufacture()
            {
                Id = Guid.Empty == model.Id ? Guid.NewGuid() : model.Id,
                Name = model.Name!,
                Description = model.Description,
                DisplayOrder = model.DisplayOrder,
            };

            if (model.Photo != null && model.Folder != null)
                manufacture.Photo = await PhotoManager.CopyPhotoAsync(model.Photo, manufacture.Id, model.Folder);

            return manufacture;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public ManufactureViewModel FormingSingleViewModel(Manufacture model)
    {
        try
        {
            return new ManufactureViewModel()
            {
                Id = model.Id,
                DisplayOrder = model.DisplayOrder,
                Name = model.Name,
                Description = model.Description,
                Photo = model.Photo.GetImage64(),
            };
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public List<ManufactureOnly> FormingOnlyViewModel(List<Manufacture> models)
    {
        try
        {
            var manufactures = new List<ManufactureOnly>();

            models = models.OrderBy(x => x.DisplayOrder).ToList();

            for (int i = 0; i < models.Count; i++)
            {
                manufactures.Add(new ManufactureOnly()
                {
                    Value = models[i].Id,
                    Label = models[i].Name,
                });
            }
            return manufactures;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public List<ManufactureViewModel> FormingViewModels(List<Manufacture> models)
    {
        try
        {
            var manufactures = new List<ManufactureViewModel>();

            for (int i = 0; i < models.Count; i++)
            {
                manufactures.Add(new ManufactureViewModel()
                {
                    Id = models[i].Id,
                    Name = models[i].Name,
                    DisplayOrder = models[i].DisplayOrder,
                    Description = models[i].Description,
                    Photo = models[i].Photo.GetImage64(),
                });
            }
            return manufactures;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
