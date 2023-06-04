using Mint.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace Mint.WebApp.Middlewares;

public class ExceptionMiddleWare
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleWare(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            response.StatusCode = error switch
            {
                UserNotFoundException => (int)HttpStatusCode.NotFound,
                BlockedException => (int)HttpStatusCode.Locked,
                _ => (int)HttpStatusCode.BadRequest,
            };

            var res = JsonSerializer.Serialize(new { message = error?.Message });
            await response.WriteAsync(res);
        }
    }
}
