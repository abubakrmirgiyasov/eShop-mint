using Mint.WebApp.Identity.DTO_s;
using Mint.WebApp.Identity.Models;

namespace Mint.WebApp.Identity.FormingModels;

/// <summary>
/// Converting Role data transfer object to role
/// </summary>
public class RoleDTOConverter
{
	/// <summary>
	/// Converting list of roles
	/// </summary>
	/// <param name="models"></param>
	/// <returns></returns>
	/// <exception cref="Exception"></exception>
    public static IEnumerable<RoleDTO> FormingMultiViewModel(IEnumerable<Role> models)
    {
		try
		{
			var roles = new List<RoleDTO>();
			foreach (var model in models)
			{
				roles.Add(new RoleDTO()
				{
                    Id = model.Id,
                    Name = model.Name,
                    CreationDate = model.CreatedDate.Date,
                    TranslateEn = model.TranslateEn,
                    UniqueKey = model.UniqueKey,
                    UpdateDate = model.UpdateDateTime?.Date,
                });
			}
			return roles;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
    }

	/// <summary>
	/// Converting roles to dto
	/// </summary>
	/// <param name="models"></param>
	/// <returns></returns>
	/// <exception cref="Exception"></exception>
	public static IEnumerable<RoleSampleDTO> FormingSampleMultiViewModel(IEnumerable<UserRole> models)
	{
		try
		{
			var roles = new List<RoleSampleDTO>();
			foreach (var role in models)
			{
				roles.Add(new RoleSampleDTO(
					Label: role.Role.Name,
					Value: role.RoleId));
			}
			return roles;
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
	}

	/// <summary>
	/// Converting single role to dto
	/// </summary>
	/// <param name="role"></param>
	/// <returns></returns>
	/// <exception cref="ArgumentNullException"></exception>
	/// <exception cref="Exception"></exception>
    public static RoleDTO FormingSingleViewModel(Role role)
	{
		try
		{
			if (role == null)
				throw new ArgumentNullException(nameof(role));

			return new RoleDTO()
			{
				Id = role.Id,
				Name = role.Name,
				TranslateEn = role.TranslateEn,
				CreationDate = role.CreatedDate.Date,
				UniqueKey = role.UniqueKey,
				UpdateDate = role.UpdateDateTime?.Date,
			};
		}
		catch (ArgumentNullException ex)
		{
			throw new ArgumentNullException(ex.Message, ex);
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
    }

    /// <summary>
    /// Converting single dto to role
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    public static Role FormingSingleBindingModel(RoleDTO model)
	{
		try
		{
			if (model == null)
                throw new ArgumentNullException(nameof(model));

			return new()
			{
				Name = model.Name!,
				TranslateEn = model.TranslateEn!,
				UniqueKey = model.UniqueKey!,
			};
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
	}
}
