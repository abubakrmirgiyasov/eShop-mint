using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Mint.Domain.Common;
using Mint.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Mint.Infrastructure.Services;

/// <summary>
/// Jwt generator & checker class
/// </summary>
public class Jwt : IJwt
{
    private readonly ApplicationDbContext _context;
    private readonly AppSettings _appSettings;

    public Jwt(ApplicationDbContext context, IOptions<AppSettings> appSettings)
    {
        _context = context;
        _appSettings = appSettings.Value;

    }

    public string GenerateJwtToken(User user)
    {
        try
        {
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    key: new SymmetricSecurityKey(key),
                    algorithm: SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public RefreshToken GenerateRefreshToken(string ip)
    {
        try
        {
            return new RefreshToken()
            {
                Token = GetUniqueToken(),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow,
                CreatedByIp = ip,
            };
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public Guid? ValidateJwtToken(string token)
    {
        try
        {
            if (token == "Object]")
                return null;

            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            tokenHandler.ValidateToken(token, new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero,
            }, out SecurityToken validatedToken);
            var jwtToken = (JwtSecurityToken)validatedToken;
            return Guid.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
        }
        catch
        {
            return null;
        }
    }

    private string GetUniqueToken()
    {
        var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        var isUniqueToken = !_context.Users.Any(x => x.RefreshTokens!.Any(y => y.Token == token));

        return isUniqueToken ? token : GetUniqueToken();
    }
}

/// <summary>
/// Interface for Jwt generator & checker class
/// </summary>
public interface IJwt
{
    /// <summary>
    /// Generate Jwt Token
    /// </summary>
    /// <param name="user">User user</param>
    /// <returns>string of token</returns>
    string GenerateJwtToken(User user);

    /// <summary>
    /// Validate Jwt Token
    /// </summary>
    /// <param name="token">string token</param>
    /// <returns>userId if valid else null</returns>
    Guid? ValidateJwtToken(string token);

    /// <summary>
    /// Generate Refresh Token
    /// </summary>
    /// <param name="ip">string ip</param>
    /// <returns>RefreshToken</returns>
    RefreshToken GenerateRefreshToken(string ip);
}
