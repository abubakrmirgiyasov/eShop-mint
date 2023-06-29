using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Mint.Domain.Models;

namespace Mint.WebApp.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : System.Attribute, IAuthorizationFilter
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
            var user = (User?)context.HttpContext.Items["User"];
            
            if (user != null)
            {
                if (!string.IsNullOrEmpty(Roles))
                {
                    bool isValid = false;

                    string[] roles = Roles.Split(',');

                    for (int i = 0; i < roles.Length; i++)
                    {
                        for (int j = 0; j < user.UserRoles?.Count; j++)
                        {
                            if (roles[i] == user.UserRoles[j].Role.Name)
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
