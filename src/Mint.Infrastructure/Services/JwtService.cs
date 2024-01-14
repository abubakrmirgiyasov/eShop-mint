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

/// <inheritdoc cref="IJwtService"/>
public class JwtService(
    ILogger<JwtService> logger,
    IOptions<AppSettings> appSettings,
    ApplicationDbContext context) : IJwtService
{
    private readonly ILogger<JwtService> _logger = logger;
    private readonly AppSettings _appSettings = appSettings.Value;
    private readonly ApplicationDbContext _context = context;

    /// <inheritdoc />
    public string GenerateJwtToken(User user)
    {
        try
        {
            var key = Encoding.ASCII.GetBytes(_appSettings.IdentitySettings.SecretKey);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[] 
                { 
                    new Claim("id", user.Id.ToString()),
                    new Claim("fullName", string.Join(" ", user.FirstName, user.SecondName)),
                    new Claim("role", string.Join(",", user.UserRoles.Select(x => x.Role.UniqueKey.ToLower()))),
                    //new Claim("avatar", ToBase64(user.Photo))
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    key: new SymmetricSecurityKey(key),
                    algorithm: SecurityAlgorithms.HmacSha256Signature),
            };

            var phone = user.Contacts.FirstOrDefault(x => x.Type == ContactType.Phone);
            var email = user.Contacts.FirstOrDefault(x => x.Type == ContactType.Email);

            if (phone is null && email is not null)
            {
                tokenDescriptor.Subject.AddClaim(new Claim("email", email.ContactInformation));
            }
            else if (phone is not null && email is null)
            {
                tokenDescriptor.Subject.AddClaim(new Claim("phone", phone.ContactInformation));
            }
            else if (phone is not null && email is not null)
            {
                tokenDescriptor.Subject.AddClaim(new Claim("phone", phone.ContactInformation));
                tokenDescriptor.Subject.AddClaim(new Claim("email", email.ContactInformation));
            }

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
            return new RefreshToken
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
            tokenHandler.ValidateToken(token, new TokenValidationParameters()
            {
                ValidateIssuer = _appSettings.IdentitySettings.ValidateIssuer,
                ValidIssuer = _appSettings.IdentitySettings.ValidIssuer,
                ValidateAudience = _appSettings.IdentitySettings.ValidateAudience,
                ValidAudience = _appSettings.IdentitySettings.Audience,
                ValidateLifetime = _appSettings.IdentitySettings.ValidateLifetime,
                IssuerSigningKey = _appSettings.IdentitySettings.GetSecurityKey(),
                ValidateIssuerSigningKey = _appSettings.IdentitySettings.ValidateIssuerSigningKey,
                ClockSkew = TimeSpan.Zero,
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            return Guid.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
        }
        catch (SecurityTokenExpiredException ex)
        {
            _logger.LogCritical("SecurityTokenExpiredException Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new SecurityTokenExpiredException(ex.Message, ex);
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
