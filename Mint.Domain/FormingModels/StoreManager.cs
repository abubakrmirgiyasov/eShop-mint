using Mint.Domain.Common;
using Mint.Domain.Models;
using Mint.Domain.ViewModels;

namespace Mint.Domain.FormingModels;

public class StoreManager
{
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
