using Mint.Domain.Models.Identity;

namespace Mint.Infrastructure.Services.Interfaces;

/// <summary>
/// Interface for Jwt generator & checker class
/// </summary>
public interface IJwtService
{
    /// <summary>
    /// Generates jwt token
    /// </summary>
    /// <param name="user"></param>
    /// <returns>generated jwt token (string)</returns>
    string GenerateJwtToken(User user);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    string? ValidateJwtToken(string? token);

    /// <summary>
    /// Generates Refresh Token
    /// </summary>
    /// <param name="ip"></param>
    /// <returns>refreshed token</returns>
    RefreshToken GenerateRefreshToken(string? ip);
}
