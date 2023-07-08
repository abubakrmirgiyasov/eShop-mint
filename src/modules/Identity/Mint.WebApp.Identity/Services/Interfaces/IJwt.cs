﻿using Mint.WebApp.Identity.Models;

namespace Mint.WebApp.Identity.Services.Interfaces;

/// <summary>
/// Interface for Jwt generator & checker class
/// </summary>
public interface IJwt
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <returns>generated jwt token (string)</returns>
    string GenerateJwtToken(User user);

    /// <summary>
    /// Validate Jwt Token
    /// </summary>
    /// <param name="token"></param>
    /// <returns>if valid userId else null</returns>
    Guid ValidateJwtToken(string token);

    /// <summary>
    /// Generates Refresh Token
    /// </summary>
    /// <param name="ip"></param>
    /// <returns>refreshed token</returns>
    RefreshToken GenerateRefreshToken(string? ip);
}
