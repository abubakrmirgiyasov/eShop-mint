using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Mint.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace Mint.Infrastructure.Services;

public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ExceptionMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        context.Response.StatusCode = exception switch
        {
            ValidationException => (int)HttpStatusCode.BadRequest,
            UserNotFoundException => (int)HttpStatusCode.NotFound,
            BlockedException => (int)HttpStatusCode.Locked,
            UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
            SecurityTokenExpiredException => (int)HttpStatusCode.Unauthorized,
            _ => (int)HttpStatusCode.BadRequest,
        };

        var res = JsonSerializer.Serialize(new { message = exception?.Message });
        await context.Response.WriteAsync(res);

        _logger.LogCritical("{Type}: {Message}", exception?.GetType(), exception?.Message);
    }
}
