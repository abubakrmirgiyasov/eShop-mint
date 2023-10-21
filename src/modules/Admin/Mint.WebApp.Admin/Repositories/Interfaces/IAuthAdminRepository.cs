using Mint.Domain.DTO_s.Identity;
using Mint.WebApp.Admin.DTO_s.Authentication;

namespace Mint.WebApp.Admin.Repositories.Interfaces;

public interface IAuthAdminRepository
{
    Task<AuthResponse> SignIn(UserSignInBindingModel model, CancellationToken cancellationToken = default);
}
