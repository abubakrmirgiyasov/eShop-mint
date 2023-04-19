using Mint.Domain.BindingModels;
using Mint.Domain.Models;
using System.Data;

namespace Mint.Domain.FormingModels;

public class AuthenticationResponseManager
{
    public AuthenticationResponse FormingModel(User model, string refreshToken, string accessToken, List<RoleSampleBindingModel>? roles = null)
    {
        byte[] bytes = File.ReadAllBytes(model.Photo != null ? model.Photo.FilePath : "ifnull.png");

        return new AuthenticationResponse()
        {
            Id = model.Id,
            FirstName = model.FirstName,
            SecondName = model.SecondName,
            Email = model.Email,
            RefreshToken = refreshToken,
            AccessToken = accessToken,
            ImagePath = "data:image/*;base64," + Convert.ToBase64String(bytes),
            Roles = roles,
        };
    }
}
