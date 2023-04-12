using Mint.Domain.BindingModels;
using Mint.Domain.Models;

namespace Mint.Infrastructure.Repositories.Interfaces;

public interface IAuthenticationRepository
{
    AuthenticationResponse Signin(UserSigninBindingModel model, string ip);

    AuthenticationResponse RefreshToken(string token, string ip);

    void RevokeToken(string token, string ip);
}
