using Microsoft.AspNetCore.Http;

namespace Mint.Domain.Extensions;

public static class HttpExtensions
{
    public static void SetTokenCookie(this HttpResponse response, string token)
    {
        var cookieOptions = new CookieOptions()
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddDays(7),
        };
        response.Cookies.Append("refresh_token", token, cookieOptions);
    }

    public static string? GetIp(this HttpRequest request)
    {
        if (request.Headers.ContainsKey("X-Forwarded-For"))
            return request.Headers["X-Forwarded-For"];
        else
            return request.HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
    }

    public static string? GetUserAgent(this HttpRequest request)
    {
        return request.Headers["User-Agent"];
    }

    public static string? GetUserAcceptLanguage(this HttpRequest request)
    {
        return request.Headers["Accept-Language"];
    }

    public static void SetConfirmationCode(this HttpResponse response, int code)
    {
        var cookieOptions = new CookieOptions()
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddHours(1),
        };
        response.Cookies.Append("--custom-access-code", code.ToString(), cookieOptions);
    }
}
