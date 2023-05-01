using Mint.Domain.BindingModels;
using Mint.Domain.Common;
using Mint.Domain.Models;
using Mint.Domain.ViewModels;

namespace Mint.Domain.FormingModels;

public class UserManager
{
    public async Task<User> FormingBindingModelAddNewUser(UserFullBindingModel model)
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
                UserRoles = new List<UserRole>(),
            };

            if (model.Photo != null && model.Folder != null)
                user.Photo = await PhotoManager.CopyPhotoAsync(model.Photo, user.Id, model.Folder);

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

    public UserFullViewModel FormingUpdateViewModel(User model)
    {
        try
        {
            return new UserFullViewModel()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                SecondName = model.SecondName,
                Gender = model.Gender,
                ImagePath = model.Photo.GetImage64(),
                DateBirth = model.DateBirth,
                Description = model.Description,
            };
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
