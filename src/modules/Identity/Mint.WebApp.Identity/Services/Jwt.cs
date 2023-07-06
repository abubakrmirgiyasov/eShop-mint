using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Mint.Domain.Common;
using Mint.WebApp.Identity.Models;
using Mint.WebApp.Identity.Repositories;
using Mint.WebApp.Identity.Services.Interfaces;
using MongoDB.Bson;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Mint.WebApp.Identity.Services;

public class Jwt : IJwt
{
    private readonly ILogger<Jwt> _logger;
    private readonly AppSettings _appSettings;
    private readonly AuthenticationRepository _authentication;

    public Jwt(
        ILogger<Jwt> logger,
        IOptions<AppSettings> appSettings,
        AuthenticationRepository authentication)
    {
        _logger = logger;
        _appSettings = appSettings.Value;
        _authentication = authentication;
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
                Token = _authentication.GetUniqueToken(),
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

    public ObjectId ValidateJwtToken(string token)
    {
        try
        {
            if (token == null)
                throw new ArgumentNullException(nameof(RefreshToken), "token is null");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            tokenHandler.ValidateToken(token, new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidIssuer = "change me pls, ISSUER",
                ValidateAudience = true,
                ValidAudience = "change me pls, AUDIENCE",
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            return ObjectId.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
        }
        catch (Exception ex)
        {
            _logger.LogCritical("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }
}
