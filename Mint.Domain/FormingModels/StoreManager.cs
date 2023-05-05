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
				Url = model.Url!,
				IsOwnStorage = model.IsOwnStorage,
				Country = model.Country,
				City = model.City,
				Street = model.Street,
				ZipCode = model.ZipCode,
				AddressDescription = model.AddressDescription,
				UserId = Guid.Parse(model.UserId!),
			};

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
			};
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
    }
}
