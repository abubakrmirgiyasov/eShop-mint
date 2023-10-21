using Mint.Domain.DTO_s.Identity;
using Mint.WebApp.Admin.DTO_s.Authentication;
using Mint.WebApp.Admin.Repositories.Interfaces;

namespace Mint.WebApp.Admin.Repositories;

public class AuthAdminRepository : IAuthAdminRepository
{
    public Task<AuthResponse> SignIn(UserSignInBindingModel model, CancellationToken cancellationToken = default)
    {
		try
		{

		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
    }
}
