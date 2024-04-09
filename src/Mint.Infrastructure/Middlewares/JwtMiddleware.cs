using Microsoft.AspNetCore.Http;
using Mint.Application.Interfaces;
using Mint.WebApp.Identity.Application.Operations.Repositories;

namespace Mint.Infrastructure.Middlewares;

public class JwtMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context, IUserRepository user, IJwtService jwt)
    {
        var token = context
            .Request
            .Headers
            .Authorization
            .FirstOrDefault()?
            .Split(" ")
            .Last();

        var userId = jwt.ValidateJwtToken(token);

        if (Guid.TryParse(userId, out Guid id))
            context.Items["User"] = await user.GetUserByIdAsync(id);

        await _next(context);
    }
}
