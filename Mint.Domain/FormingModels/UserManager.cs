using Mint.Domain.Models;
using Mint.Domain.ViewModels;

namespace Mint.Domain.FormingModels;

public class UserManager
{
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
