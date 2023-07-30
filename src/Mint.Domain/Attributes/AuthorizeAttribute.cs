using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Mint.Domain.Models.Identity;

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
            var roles = context.HttpContext.Request.Headers["X-Role"].ToString();

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
}
