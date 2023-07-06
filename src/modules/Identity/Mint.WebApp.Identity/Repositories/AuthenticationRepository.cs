using Microsoft.Extensions.Options;
using Mint.Domain.Common;
using Mint.Domain.Exceptions;
using Mint.Infrastructure.MongoDb.Services;
using Mint.WebApp.Identity.DTO_s;
using Mint.WebApp.Identity.FormingModels;
using Mint.WebApp.Identity.Models;
using Mint.WebApp.Identity.Services.Interfaces;
using System.Security.Cryptography;

namespace Mint.WebApp.Identity.Repositories;

/// <summary>
/// Authentication Repository
/// </summary>
public class AuthenticationRepository : Repository<User>
{
    private readonly ILogger<AuthenticationRepository> _logger;
    private readonly AppSettings _appSettings;
    private readonly IJwt _jwt;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="settings"></param>
    /// <param name="logger"></param>
    /// <param name="appSettings"></param>
    /// <param name="jwt"></param>
    public AuthenticationRepository(
        IOptions<MongoDbSettings> settings,
        ILogger<AuthenticationRepository> logger,
        IOptions<AppSettings> appSettings,
        IJwt jwt)
        : base(settings)
    {
        _logger = logger;
        _appSettings = appSettings.Value;
        _jwt = jwt;
    }

    /// <summary>
    /// Login user
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="UnauthorizedAccessException"></exception>
    /// <exception cref="BlockedException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<AuthenticationResponse> SignInAsync(UserFullBindingModel model)
    {
        try
        {
            var user = await FindOneAsync(x => x.Email.ToLower() == model.Email!.ToLower())
                ?? throw new UnauthorizedAccessException("Не правильный Email/Пароль");

            if (user.NumOfAttempts >= 10)
            {
                user.IsActive = false;
                await ReplaceOneAsync(user);
                throw new BlockedException("Аккаунт заблокирован");
            }

            if (user.Password != new Hasher().GetHash(model.Password ?? "", user.Salt ?? Array.Empty<byte>()))
            {
                user.NumOfAttempts++;
                await ReplaceOneAsync(user);
                throw new UnauthorizedAccessException("Не правильный Email/Пароль");
            }

            if (!user.IsActive)
                throw new Exception("Аккаунт не активен");

            var jwt = _jwt.GenerateJwtToken(user);
            var refreshToken = _jwt.GenerateRefreshToken(model.Ip);
            user.RefreshTokens.Add(refreshToken);

            RemoveOldRefreshToken(user);

            await ReplaceOneAsync(user);

            return new AuthenticationResponse()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                Email = user.Email,
                RefreshToken = refreshToken.Token,
                AccessToken = jwt,
                Image = "",
                Roles = RoleDTOConverter.FormingSampleMultiViewModel(user.UserRoles).ToList(),
            };
        }
        catch (UnauthorizedAccessException ex)
        {
            _logger.LogCritical("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new UnauthorizedAccessException(ex.Message, ex);
        }
        catch (BlockedException ex)
        {
            _logger.LogCritical("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new BlockedException(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogCritical("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }

    /// <summary>
    /// Registration new User
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<UserFullViewModel> SignUpAsync(UserFullBindingModel model)
    {
        try
        {
            await InsertOneAsync(UserDTOConverter.FormingSingleBindingModel(model));
            return UserDTOConverter.FormingSingleViewModel(new User());
        }
        catch (Exception ex)
        {
            _logger.LogCritical("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }

    /// <summary>
    /// Refresh token
    /// </summary>
    /// <param name="refreshToken"></param>
    /// <param name="ip"></param>
    /// <returns></returns>
    /// <exception cref="InvalidDataException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task<AuthenticationResponse> RefreshToken(string? refreshToken, string? ip)
    {
        try
        {
            if (string.IsNullOrEmpty(refreshToken))
                throw new ArgumentNullException(nameof(refreshToken), "Refresh token null");

            var user = FilterBy(x => x.FirstName != ".")
                .FirstOrDefault(x => x.RefreshTokens.FirstOrDefault(y => y.Token == refreshToken) != null)
                ?? throw new ArgumentNullException(nameof(User), "refresh token doesn't exists {refresh token}");

            if (user.RefreshTokens.First().IsRevoked)
            {
                RevokeDescendantRefreshTokens(user.RefreshTokens.First(), user, ip!, $"Attempted reuse of revoked ancestor token: {refreshToken}");

                await ReplaceOneAsync(user);
            }

            if (!user.RefreshTokens.First().IsActive)
                throw new InvalidOperationException("Invalid token");

            var newRefreshToken = RotateRefreshToken(user.RefreshTokens.First(), ip!);
            user.RefreshTokens.Add(newRefreshToken);

            RemoveOldRefreshToken(user);

            await ReplaceOneAsync(user);

            var jwt = _jwt.GenerateJwtToken(user);
            
            return new AuthenticationResponse()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                Email = user.Email,
                RefreshToken = newRefreshToken.Token,
                AccessToken = jwt,
                Image = "",
                Roles = RoleDTOConverter.FormingSampleMultiViewModel(user.UserRoles).ToList(),
            };
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogCritical("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new InvalidOperationException(ex.Message, ex);
        }
        catch (ArgumentNullException ex)
        {
            _logger.LogCritical("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new ArgumentNullException(ex.Message, ex);
        }
        catch (Exception ex)
        {
            _logger.LogCritical("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }

    /// <summary>
    /// Logout || revoke token
    /// </summary>
    /// <param name="refreshToken"></param>
    /// <param name="ip"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    public async Task RevokeToken(string? refreshToken, string? ip)
    {
        try
        {
            if (string.IsNullOrEmpty(refreshToken))
                throw new Exception("Token is required");

            var user = FilterBy(x => x.FirstName != ".")
                .FirstOrDefault(x => x.RefreshTokens.FirstOrDefault(y => y.Token == refreshToken) != null)
                ?? throw new ArgumentNullException(nameof(User), "refresh token doesn't exists {refresh token}");

            if (!user.RefreshTokens.First().IsActive)
                throw new InvalidOperationException("Invalid token");

            RevokeRefreshToken(user.RefreshTokens.First(), ip!, "Revoked without replacement");

            await ReplaceOneAsync(user);
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogCritical("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new InvalidOperationException(ex.Message, ex);
        }
        catch (ArgumentNullException ex)
        {
            _logger.LogCritical("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
        catch (Exception ex)
        {
            _logger.LogCritical("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }

    #region Helpers
    public string GetUniqueToken()
    {
        try
        {
            var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            var isUniqueToken = !FilterBy(x => x.RefreshTokens.Any(y => y.Token == token)).Any();
            return isUniqueToken ? token : GetUniqueToken();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    private void RevokeDescendantRefreshTokens(RefreshToken refreshToken, User user, string ip, string reason)
    {
        if (!string.IsNullOrEmpty(refreshToken.ReplacedByToken))
        {
            var childToken = user.RefreshTokens.FirstOrDefault(x => x.Token == refreshToken.ReplacedByToken);

            if (childToken != null)
            {
                if (childToken.IsActive)
                    RevokeRefreshToken(childToken, ip, reason);
                else
                    RevokeDescendantRefreshTokens(refreshToken, user, ip, reason);
            }
        }
    }

    private RefreshToken RotateRefreshToken(RefreshToken refreshToken, string ip)
    {
        var newRefreshToken = _jwt.GenerateRefreshToken(ip);
        RevokeRefreshToken(refreshToken, ip, "Replaced by new token", newRefreshToken.Token);
        return newRefreshToken;
    }

    private void RevokeRefreshToken(RefreshToken token, string ip, string? reason = null, string? replacedByToken = null)
    {
        token.Revoked = DateTime.UtcNow;
        token.RevokedByIp = ip;
        token.ReplacedByToken = replacedByToken;
        token.ReasonRevoked = reason;
    }

    private void RemoveOldRefreshToken(User user)
    {
        user.RefreshTokens.RemoveAll(x => x.IsActive && x.CreationDate.AddDays(_appSettings.RefreshTokenTTL) <= DateTime.UtcNow);
    }
    #endregion
}
