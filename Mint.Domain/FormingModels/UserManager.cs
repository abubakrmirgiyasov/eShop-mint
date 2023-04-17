using Mint.Domain.BindingModels;
using Mint.Domain.Common;
using Mint.Domain.Models;
using Mint.Domain.ViewModels;

namespace Mint.Domain.FormingModels;

public class UserManager
{
    public User FormingBindingModelAddNewUser(UserFullBindingModel model)
    {
        try
        {
            var salt = new Hasher().GetSalt();
            var user = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = model.FirstName!,
                SecondName = model.SecondName!,
                LastName = model.LastName!,
                Email = model.Email!,
                Password = new Hasher().GetHash(model.Password!, salt),
                Salt = salt,
                CreatedDate = DateTime.Now,
                DateBirth = DateTime.Parse(model.DateOfBirth!),
                Phone = model.Phone,
                Gender = model.Gender!,
                Description = model.Description!,
                Ip = model.Ip!,
                IsActive = true,
                IsConfirmedEmail = false,
                NumOfAttempts = 0,
                ZipCode = 0,
                UserRoles = new List<UserRole>(),
            };
            return user;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public UserFullViewModel FormingFullViewModel(User model)
    {
		try
		{
            return new UserFullViewModel
            {
                Id = model.Id,
                FirstName = model.FirstName,
                SecondName = model.SecondName,
                LastName = model.LastName,
                Email = model.Email,
                Description = model.Description,
                Phone = model.Phone,
                Gender = model.Gender,
                IsConfirmedEmail = model.IsConfirmedEmail,
                DateBirth = model.DateBirth,
            };
        }
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
    }
}
