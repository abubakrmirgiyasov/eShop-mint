using Mint.Domain.BindingModels;
using Mint.Domain.Models;
using Mint.Domain.ViewModels;

namespace Mint.Domain.FormingModels;

public class AddressManager
{
    public Address FormingBindingModel(AddressBindingModel model)
    {
        try
        {
            return new Address()
            {
                Id = model.Id,
                Country = model.Country!,
                City = model.City!,
                ZipCode = model.ZipCode,
                CreatedDate = DateTime.Now,
                Description = model.Description,
                FullAddress = model.FullAddress!,
                UserId = model.UserId,
            };
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public AddressViewModel FormingSingleViewMdoel(Address model)
    {
        try
        {
            if (model is null)
                return new AddressViewModel();

            return new AddressViewModel()
            {
                Id = model.Id,
                FullName = $"{model.User.FirstName} {model.User.SecondName}",
                Email = model.User.Email,
                Phone = model.User.Phone,
                Country = model.Country,
                City = model.City,
                ZipCode = model.ZipCode,
                FullAddress = model.FullAddress,
                Description = model.Description,
            };
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public List<AddressViewModel> FormingViewModels(List<Address> addresses)
    {
        try
        {
            var extractedModels = new List<AddressViewModel>();

            foreach (var address in addresses)
            {
                extractedModels.Add(new AddressViewModel()
                {
                    Id = address.Id,
                    FullName = $"{address.User.FirstName} {address.User.SecondName}",
                    Email = address.User.Email,
                    Phone = address.User.Phone,
                    Country = address.Country,
                    City = address.City,
                    ZipCode = address.ZipCode,
                    FullAddress = address.FullAddress,
                    Description = address.Description,
                });
            }
            return extractedModels;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
