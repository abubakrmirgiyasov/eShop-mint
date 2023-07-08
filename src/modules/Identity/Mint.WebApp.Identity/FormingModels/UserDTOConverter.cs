using Mint.WebApp.Identity.DTO_s;
using Mint.WebApp.Identity.Models;

namespace Mint.WebApp.Identity.FormingModels;

/// <summary>
/// Converting user data transfer objects to user
/// </summary>
public class UserDTOConverter
{
    public static UserFullViewModel FormingSingleViewModel(User model)
    {
        return new UserFullViewModel()
        {

        };
    }

    /// <summary>
    /// Converting single binding model
    /// </summary>
    /// <param name="model"></param>
    /// <returns>User</returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="Exception"></exception>
    public static User FormingSingleBindingModel(UserFullBindingModel model)
    {
        try
        {
            if (model == null) 
                throw new ArgumentNullException(nameof(model));

            return new()
            {
                FirstName = model.FirstName!,
                SecondName = model.SecondName!,
                LastName = model.LastName!,
                DateBirth = model.DateBirth,
                Description = model.Description,
                Password = model.Password!,
                Email = model.Email!,
                Gender = model.Gender!,
                Ip = model.Ip,
                Phone = (long)model.Phone!,
                IsActive = true,
                NumOfAttempts = 0,
                IsConfirmedEmail = false,
                IsConfirmedPhone = false,
            };
        }
        catch (ArgumentNullException ex)
        {
            throw new ArgumentException(ex.Message, ex);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
