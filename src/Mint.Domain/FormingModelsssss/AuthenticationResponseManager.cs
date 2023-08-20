using Mint.Domain.BindingModels;
using Mint.Domain.Common;
using Mint.Domain.Models;

namespace Mint.Domain.FormingModels;

public class AuthenticationResponseManager
{
    public AuthenticationResponse FormingModel(User model, string refreshToken, string accessToken, List<RoleSampleBindingModel>? roles = null)
    {
        return new AuthenticationResponse()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            SecondName = model.SecondName,
            Email = model.Email,
            RefreshToken = refreshToken,
            AccessToken = accessToken,
            ImagePath = model.Photo.GetImage64(),
            Roles = roles,
        };
    }
}
