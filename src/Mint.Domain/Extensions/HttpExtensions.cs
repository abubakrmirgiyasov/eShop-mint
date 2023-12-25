using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace Mint.Domain.Extensions;

/// <summary>
/// Helper class for <see cref="HttpRequest"/>, <see cref="HttpResponse"/>
/// </summary>
public static class HttpExtensions
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="response"></param>
    /// <param name="token"></param>
    public static void SetTokenCookie(this HttpResponse response, string token)
    {
        var cookieOptions = new CookieOptions()
        {
            HttpOnly = true,
            Expires = DateTime.UtcNow.AddDays(7),
        };
        response.Cookies.Append("refresh_token", token, cookieOptions);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public static string? GetIp(this HttpRequest request)
    {
        if (request.Headers.TryGetValue("X-Forwarded-For", out StringValues value))
            return value;
        else
            return request.HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public static string? GetUserAgent(this HttpRequest request)
    {
        return request.Headers["User-Agent"];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public static string? GetUserAcceptLanguage(this HttpRequest request)
    {
        return request.Headers["Accept-Language"];
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="response"></param>
    /// <param name="code"></param>
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
