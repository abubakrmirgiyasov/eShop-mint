using Mint.WebApp.Identity.Repositories.Interfaces;
using Mint.WebApp.Identity.Services.Interfaces;

namespace Mint.WebApp.Identity.Services;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;

    public JwtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IUserRepository user, IJwt jwt)
    {
        var token = context
            .Request
            .Headers["Authorization"]
            .FirstOrDefault()?
            .Split(" ")
            .Last();

        var userId = jwt.ValidateJwtToken(token!);
        context.Items["User"] = await user.GetUserByIdAsync(userId);
        await _next(context);
    }
}
