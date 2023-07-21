//using Mint.Infrastructure.Repositories.Interfaces;
//using Mint.Infrastructure.Services;

//namespace Mint.WebApp.Middlewares;

//public class JwtMiddleware
//{
//    private readonly RequestDelegate _next;

//    public JwtMiddleware(RequestDelegate next)
//    {
//        _next = next;
//    }

//    public async Task Invoke(HttpContext context, IUserRepository user, IJwt jwt)
//    {
//        var token = context.Request.Headers["Authorization"]
//            .FirstOrDefault()?
//            .Split(" ")
//            .Last();
//        var userId = jwt.ValidateJwtToken(token!);

//        if (userId != null)
//            context.Items["User"] = user.GetUserById(userId.Value);
    
//        await _next(context);
//    }
//}
