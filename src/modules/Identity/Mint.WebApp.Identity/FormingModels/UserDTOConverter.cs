using Mint.Domain.Helpers;
using Mint.Domain.Models.Identity;
using Mint.WebApp.Identity.DTO_s;

namespace Mint.WebApp.Identity.FormingModels;

/// <summary>
/// Converting user data transfer objects to user
/// </summary>
public class UserDTOConverter
{
    /// <summary>
    /// Converting list of models to view models
    /// </summary>
    /// <param name="models"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static IEnumerable<UserFullViewModel> FormingMultiViewModels(List<User> models)
    {
        try
        {
            var users = new List<UserFullViewModel>();

            foreach (var model in models)
            {
                var user = new UserFullViewModel()
                {
                    Id = model.Id,
                    FirstName = model.FirstName,
                    SecondName = model.LastName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Phone = model.Phone,
                    DateBirth = model.DateBirth,
                    Gender = model.Gender,
                    Description = model.Description,
                    IsConfirmedEmail = model.IsConfirmedEmail,
                    IsConfirmedPhone = model.IsConfirmedPhone,
                    Photo = PhotoHelper.GetImage64(model.Photo?.FilePath),
                    Roles = new List<RoleSampleDTO>(),
                };

                foreach (var role in model.UserRoles)
                {
                    user.Roles.Add(new RoleSampleDTO()
                    {
                        Label = role.Role.Name,
                        Value = role.Role.UniqueKey,
                    });
                }

                users.Add(user);
            }

            return users;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    /// <summary>
    /// Converting single model to view model
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public static UserFullViewModel FormingSingleViewModel(User model)
    {
        var user = new UserFullViewModel()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            SecondName = model.LastName,
            LastName = model.LastName,
            Email = model.Email,
            Phone = model.Phone,
            DateBirth = model.DateBirth,
            Gender = model.Gender,
            Description = model.Description,
            IsConfirmedEmail = model.IsConfirmedEmail,
            IsConfirmedPhone = model.IsConfirmedPhone,
            Photo = PhotoHelper.GetImage64(model.Photo?.FilePath),
            Roles = new List<RoleSampleDTO>(),
        };

        foreach (var role in model.UserRoles)
        {
            user.Roles.Add(new RoleSampleDTO()
            {
                Label = role.Role.Name,
                Value = role.Role.UniqueKey,
            });
        }

        return user;
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
