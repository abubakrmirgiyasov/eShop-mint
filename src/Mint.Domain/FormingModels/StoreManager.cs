using Mint.Domain.BindingModels;
using Mint.Domain.Common;
using Mint.Domain.Models;
using Mint.Domain.ViewModels;

namespace Mint.Domain.FormingModels;

public class StoreManager
{
    public async Task<Store> FormingBindingModel(StoreFullBindingModel model)
    {
		try
		{
			var store = new Store()
			{
				Id = Guid.NewGuid(),
				Name = model.Name!,
				Url = model.Url!.ToLower(),
				IsOwnStorage = model.IsOwnStorage,
				Country = model.Country,
				City = model.City,
				Street = model.Street,
				ZipCode = model.ZipCode,
				AddressDescription = model.AddressDescription,
				UserId = Guid.Parse(model.UserId!),
				StoreCategories = new List<StoreCategory>(),
			};

			for (int i = 0; i < model.Categories?.Count; i++)
			{
				store.StoreCategories.Add(new StoreCategory()
				{
					StoreId = store.Id,
					CategoryId = model.Categories[i].Value,
				});
			}

			if (model.FileType != null && model.Photo != null) 
				store.Photo = await PhotoManager.CopyPhotoAsync(model.Photo, store.Id, model.FileType);

			return store;

        }
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
    }

    public StoreFullViewModel FormingViewModel(Store model)
    {
		try
		{
			var categories = new List<CategoryOnlyViewModel>();

			for (int i = 0; i < model.StoreCategories?.Count; i++)
			{
                categories.Add(new CategoryOnlyViewModel()
                {
                    Label = model.StoreCategories[i].Category?.Name,
                    Value = model.StoreCategories[i].Category!.Id,
                });
            }

            return new StoreFullViewModel()
			{
				Id = model.Id,
				Name = model.Name,
				Url = model.Url,
				Country = model.Country,
				Street = model.Street,
				City = model.City,
				ZipCode	= model.ZipCode,
				IsOwnStorage = model.IsOwnStorage,
				AddressDescription = model.AddressDescription,
				Photo = model.Photo.GetImage64(),
				Categories = categories,
			};
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
    }

    public List<StoreFullViewModel> FormingViewModels(List<Store> models)
    {
		try
		{
			var stores = new List<StoreFullViewModel>();

			for (int i = 0; i < models.Count; i++)
			{
				stores.Add(new StoreFullViewModel()
				{
					Id = models[i].Id,
					Name = models[i].Name,
					Url = models[i].Url,
					IsOwnStorage = models[i].IsOwnStorage,
					Country = models[i].Country,
					City = models[i].City,
 					Street = models[i].Street,
					ZipCode = models[i].ZipCode,
					AddressDescription = models[i].AddressDescription,
					Photo = models[i].Photo.GetImage64(),
				});
			}

			return stores;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
    }
}
