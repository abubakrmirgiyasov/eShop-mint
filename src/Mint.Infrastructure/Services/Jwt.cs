using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Mint.Domain.Common;
using Mint.Domain.Models.Identity;
using Mint.Infrastructure.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Mint.Infrastructure.Services;

public class Jwt : IJwt
{
    private readonly ILogger<Jwt> _logger;
    private readonly IdentitySettings _appSettings;
    private readonly ApplicationDbContext _context;

    public Jwt(
        ILogger<Jwt> logger,
        IOptions<IdentitySettings> appSettings,
        ApplicationDbContext context)
    {
        _logger = logger;
        _appSettings = appSettings.Value;
        _context = context;
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
            _logger.LogCritical("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }

    public RefreshToken GenerateRefreshToken(string? ip)
    {
        try
        {
            return new RefreshToken()
            {
                Token = GetUniqueToken(),
                Expires = DateTime.UtcNow.AddDays(7),
                CreatedByIp = ip,
            };
        }
        catch (Exception ex)
        {
            _logger.LogCritical("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }

    public Guid? ValidateJwtToken(string token)
    {
        try
        {
            if (string.IsNullOrEmpty(token))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            tokenHandler.ValidateToken(token, new TokenValidationParameters()
            {
                ValidateIssuer = false,
                ValidIssuer = "change me pls, ISSUER",
                ValidateAudience = false,
                ValidAudience = "change me pls, AUDIENCE",
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero,
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            return Guid.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
        }
        catch (Exception ex)
        {
            _logger.LogCritical("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }

    public string GetUniqueToken()
    {
        try
        {
            var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            var isUniqueToken = !_context.Users.Any(x => x.RefreshTokens.Any(y => y.Token == token));
            return isUniqueToken ? token : GetUniqueToken();
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }
}
