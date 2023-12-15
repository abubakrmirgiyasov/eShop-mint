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
            var response = context.Response;
            response.ContentType = "application/json";

            response.StatusCode = ex switch
            {
                ValidationException => (int)HttpStatusCode.BadRequest,
                UserNotFoundException => (int)HttpStatusCode.NotFound,
                BlockedException => (int)HttpStatusCode.Locked,
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                SecurityTokenExpiredException => (int)HttpStatusCode.Unauthorized,
                _ => (int)HttpStatusCode.BadRequest,
            };

            var res = JsonSerializer.Serialize(new { message = ex?.Message });
            await response.WriteAsync(res);

            _logger.LogCritical("{Type}: {Message}", ex?.GetType(), ex?.Message);
        }
    }
}
