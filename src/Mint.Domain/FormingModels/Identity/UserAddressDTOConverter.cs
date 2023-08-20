using Mint.Domain.DTO_s.Identity;
using Mint.Domain.Models.Identity;

namespace Mint.Domain.FormingModels.Identity;

/// <summary>
/// User address data transfer object converter class
/// </summary>
public class UserAddressDTOConverter
{
    /// <summary>
    /// Converts list of user addresses to user view model
    /// </summary>
    /// <param name="models"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static List<UserAddressFullViewModel> FormingMultiViewModels(List<UserAddress>? models = null)
    {
        try
        {
            var addresses = new List<UserAddressFullViewModel>();

            for (int i = 0; i < models?.Count; i++)
            {
                addresses.Add(new UserAddressFullViewModel()
                {
                    Id = models[i].Id,
                    Email = models[i].Email,
                    Phone = models[i].Phone,
                    FullName = models[i].FullName,
                    FullAddress = models[i].FullAddress,
                    Country = models[i].Country,
                    Street = models[i].Street,
                    City = models[i].City,
                    CreatedDate = models[i].CreatedDate,
                    ZipCode = models[i].ZipCode,
                    Description = models[i].Description,
                });
            }
            return addresses;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    /// <summary>
    /// Converts single user address model to user address view model
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static UserAddressFullViewModel FormingSingleFullViewModel(UserAddress model)
    {
        try
        {
            return new UserAddressFullViewModel()
            {
                Id = Guid.NewGuid(),
                FullName = model.FullName,
                Email = model.Email,
                Phone = model.Phone,
                FullAddress = model.FullAddress,
                Country = model.Country,
                Street = model.Street,
                City = model.City,
                ZipCode = model.ZipCode,
                Description = model.Description,
            };
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    /// <summary>
    /// Converts single user address binding model to user address
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static UserAddress FormingSingleFullBindingModel(UserAddressFullBindingModel model)
    {
        try
        {
            return new UserAddress()
            {
                Id = Guid.NewGuid(),
                FullName = model.FullName!,
                Email = model.Email!,
                Phone = (long)model.Phone!,
                FullAddress = model.FullAddress!,
                Country = model.Country?.Label!,
                Street = model.Street,
                City = model.City!,
                ZipCode = (int)model.ZipCode!,
                Description = model.Description,
            };
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
