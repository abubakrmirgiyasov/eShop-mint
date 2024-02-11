using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Mint.Domain.DTO_s.Identity;
using Mint.Domain.Models.Identity;

namespace Mint.Infrastructure.Attributes;

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
            var user = (UserJwtAuthorize?)context.HttpContext.Items["User"];

            if (user is null)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" })
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                };
                return;
            }


            if (!string.IsNullOrEmpty(Roles))
            {
                bool isValid = false;

                string[] splitRoles = Roles.Split(',');

                foreach (var role in splitRoles)
                {
                    foreach (var userRole in user.Roles)
                    {
                        if (role != userRole)
                            continue;
                     
                        isValid = true;
                        break;
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
