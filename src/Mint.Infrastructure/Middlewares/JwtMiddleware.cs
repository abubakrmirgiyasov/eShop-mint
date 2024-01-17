using Microsoft.AspNetCore.Http;
using Mint.Domain.Common;
using Mint.Infrastructure.Repositories.Identity.Interfaces;
using Mint.Infrastructure.Services.Interfaces;

namespace Mint.Infrastructure.Middlewares;

public class JwtMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context, IUserRepository user, IJwtService jwt)
    {
        var token = context
            .Request
            .Headers["Authorization"]
            .FirstOrDefault()?
            .Split(" ")
            .Last();

        //var userId = jwt.ValidateJwtToken(token!);

        //if (userId is not null)
        //{
        //    var roles = await user.GetUserRoleForAuthAsync(userId.Value);
        //    context.Request.Headers.Add("X-Role", roles);
        //}

        await _next(context);
    }
}
