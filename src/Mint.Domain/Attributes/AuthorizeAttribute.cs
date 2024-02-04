using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Mint.Domain.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Mint.Domain.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public string? Roles { get; set; }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var isAllowedAnonymus = context
            .ActionDescriptor
            .EndpointMetadata
            .OfType<AllowAnonymousAttribute>()
            .Any();

        if (!isAllowedAnonymus)
        {
            var token = context.HttpContext.Request.Headers["Authorization"].ToString();

            var roles = GetRoles(token);

            if (!string.IsNullOrEmpty(roles))
            {
                if (!string.IsNullOrEmpty(Roles))
                {
                    bool isValid = false;

                    string[] splitRoles = Roles.Split(',');
                    string[] splitHeaderRoles = roles.Split(',');

                    for (int i = 0; i < splitRoles.Length; i++)
                    {
                        for (int j = 0; j < splitHeaderRoles.Length; j++)
                        {
                            if (splitRoles[i].Trim() == splitHeaderRoles[j].Trim())
                            {
                                isValid = true;
                                break;
                            }
                        }

                        if (isValid)
                            break;
                    }

                    if (!isValid)
                        context.Result = new JsonResult(new { message = "Forbidden" })
                        {
                            StatusCode = StatusCodes.Status403Forbidden,
                        };
                }
            }
            else
            {
                context.Result = new JsonResult(new { message = "Unauthorized" })
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                };
            }
        }
    }

    private string? GetRoles(string token)
    {
        if (string.IsNullOrWhiteSpace(token))
            return "";

        //var key = Encoding.ASCII.GetBytes(_appSettings.IdentitySettings.SecretKey);
        //var parameters = new TokenValidationParameters
        //{
        //    ValidateIssuer = _appSettings.IdentitySettings.ValidateIssuer,
        //    ValidIssuer = _appSettings.IdentitySettings.ValidIssuer,
        //    ValidateAudience = _appSettings.IdentitySettings.ValidateAudience,
        //    ValidAudience = _appSettings.IdentitySettings.ValidAudience,
        //    ValidateIssuerSigningKey = _appSettings.IdentitySettings.ValidateIssuerSigningKey,
        //    ValidateLifetime = _appSettings.IdentitySettings.ValidateLifetime,
        //    IssuerSigningKey = new SymmetricSecurityKey(key),
        //    ClockSkew = TimeSpan.Zero
        //};


        //var claims = new JwtSecurityTokenHandler().ValidateToken(token, parameters, out var _);

        //return claims.Claims.First(x => x.Type == "role").Value;
        return "";
    }
}
