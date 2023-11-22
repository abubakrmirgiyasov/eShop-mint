using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Mint.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace Mint.Infrastructure.Services;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            response.StatusCode = ex switch
            {
                UserNotFoundException => (int)HttpStatusCode.NotFound,
                BlockedException => (int)HttpStatusCode.Locked,
                SecurityTokenExpiredException => (int)HttpStatusCode.Unauthorized,
                _ => (int)HttpStatusCode.BadRequest,
            };

            var res = JsonSerializer.Serialize(new { message = ex?.Message });
            await response.WriteAsync(res);
        }
    }
}
