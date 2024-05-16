using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Mint.Domain.Exceptions;
using System.Net;

namespace Mint.Infrastructure.Middlewares;

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
            NotFoundException => (int)HttpStatusCode.NotFound,
            SecurityTokenExpiredException => (int)HttpStatusCode.Unauthorized,
            _ => (int)HttpStatusCode.BadRequest,
        };

        await context.Response.WriteAsync(exception.Message);

        _logger.LogCritical("{Type}: {Message}", exception?.GetType(), exception?.Message);
    }
}
