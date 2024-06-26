﻿using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Mint.Application.Interfaces;
using Mint.Domain.Common;
using Mint.Domain.Models.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Mint.Infrastructure.Services;

/// <inheritdoc cref="IJwtService"/>
public class JwtService(
    ILogger<JwtService> logger,
    IOptions<AppSettings> appSettings,
    ApplicationDbContext context
) : IJwtService
{
    private readonly ILogger<JwtService> _logger = logger;
    private readonly AppSettings _appSettings = appSettings.Value;
    private readonly ApplicationDbContext _context = context;

    /// <inheritdoc />
    public string GenerateJwtToken(User user)
    {
        try
        {
            var claims = new List<Claim> 
            {
                new("id", user.Id.ToString()),
                new("fullName", string.Join(" ", user.FirstName, user.SecondName)),
                new("role", string.Join(",", user.UserRoles.Select(x => x.Role.UniqueKey.ToLower()))),
                new("isSeller", user.IsSeller.ToString())
            };

            var phone = user.Contacts.FirstOrDefault(x => x.Type == ContactType.Phone);
            var email = user.Contacts.FirstOrDefault(x => x.Type == ContactType.Email);

            if (phone is null && email is not null)
            {
                claims.Add(new Claim("email", email.ContactInformation));
            }
            else if (phone is not null && email is null)
            {
                claims.Add(new Claim("phone", phone.ContactInformation));
            }
            else if (phone is not null && email is not null)
            {
                claims.Add(new Claim("phone", phone.ContactInformation));
                claims.Add(new Claim("email", email.ContactInformation));
            }

            var key = Encoding.ASCII.GetBytes(_appSettings.IdentitySettings.SecretKey);
            var credentials = new SigningCredentials(
                key: new SymmetricSecurityKey(key),
                algorithm: SecurityAlgorithms.HmacSha256Signature
            );

            var jwtToken = new JwtSecurityToken(
                issuer: _appSettings.IdentitySettings.ValidIssuer,
                audience: _appSettings.IdentitySettings.ValidAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: _appSettings.IdentitySettings.GetCredentialsKey()
            );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
        catch (Exception ex)
        {
            _logger.LogCritical("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }

    public string? ValidateJwtToken(string? token)
    {
        if (string.IsNullOrWhiteSpace(token))
            return default;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.IdentitySettings.SecretKey);

        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateLifetime = _appSettings.IdentitySettings.ValidateLifetime,
                ValidAudience = _appSettings.IdentitySettings.ValidAudience,
                ValidIssuer = _appSettings.IdentitySettings.ValidIssuer,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            return jwtToken.Claims.First(x => x.Type == "id").Value;
        }
        catch
        {
            return default;
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
