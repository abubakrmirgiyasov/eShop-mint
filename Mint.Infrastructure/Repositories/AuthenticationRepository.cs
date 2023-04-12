using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Mint.Domain.BindingModels;
using Mint.Domain.Common;
using Mint.Domain.Models;
using Mint.Infrastructure.Repositories.Interfaces;
using Mint.Infrastructure.Services;

namespace Mint.Infrastructure.Repositories;

public class AuthenticationRepository : IAuthenticationRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IJwt _jwt;
    private readonly AppSettings _appSettings;
    private readonly IUserRepository _user;

    public AuthenticationRepository(IJwt jwt, ApplicationDbContext context, IOptions<AppSettings> appSettings, IUserRepository user)
    {
        _context = context;
        _jwt = jwt;
        _appSettings = appSettings.Value;
        _user = user;
    }

    public AuthenticationResponse Signin(UserSigninBindingModel model, string ip)
    {
        try
        {
            var newUser = _context.Users
                .Include(x => x.UserRoles!)
                .ThenInclude(x => x.Role)
                .Include(x => x.RefreshTokens)
                .FirstOrDefault(x => x.Email == model.Email);

            if (newUser != null)
            {
                if (newUser.NumOfAttempts >= 10)
                {
                    newUser.IsActive = false;
                    _context.SaveChanges();

                    throw new Exception("Учетная запись заблокировано");
                }
                else
                {
                    if (newUser.Password == new Hasher().GetHash(model.Password!, newUser.Salt))
                    {
                        if (newUser.IsActive)
                        {
                            var jwtToken = _jwt.GenerateJwtToken(newUser);
                            var refreshToken = _jwt.GenerateRefreshToken(ip);
                            newUser.RefreshTokens!.Add(refreshToken);

                            RemoveOldRefreshToken(newUser);

                            _context.Update(newUser);
                            _context.SaveChanges();

                            var roles = new List<RoleSampleBindingModel>();

                            for (int i = 0; i < newUser.UserRoles?.Count; i++)
                            {
                                roles.Add(new RoleSampleBindingModel()
                                {
                                    Value = newUser.UserRoles[i].RoleId,
                                    Label = newUser.UserRoles[i].Role.Name,
                                });
                            }

                            return new AuthenticationResponse()
                            {
                                Id = newUser.Id,
                                FirstName = newUser.FirstName,
                                SecondName = newUser.SecondName,
                                Email = newUser.Email,
                                RefreshToken = refreshToken.Token,
                                AccessToken = jwtToken,
                                Roles = roles,
                            };
                        }
                        else
                        {
                            throw new Exception("Учетная запись не активна");
                        }
                    }
                    else
                    {
                        var updateUser = _context.Users.FirstOrDefault(x => x.Email == model.Email);

                        if (updateUser != null)
                        {
                            updateUser.NumOfAttempts++;
                            _context.SaveChanges();
                        }

                        throw new Exception("Не правильный Email/Пароль");
                    }
                }
            }
            else
            {
                throw new Exception("Не правильный Email/Пароль");
            }

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public AuthenticationResponse RefreshToken(string token, string ip)
    {
        try
        {
            var user = _user.GetUserByToken(token);
            var refreshToken = user.RefreshTokens?.FirstOrDefault(x => x.Token == token);

            if (refreshToken!.IsRevoked)
            {
                RevokeDescendantRefreshTokens(refreshToken, user, ip, $"Attempted reuse of revoked ancestor token: {token}");

                _context.Update(user);
                _context.SaveChanges();
            }

            if (!refreshToken.IsActive) throw new Exception("Invalid token.");

            var newRefreshToken = RotateRefreshToken(refreshToken, ip);
            user.RefreshTokens?.Add(newRefreshToken);

            RemoveOldRefreshToken(user);

            _context.Update(_user);
            _context.SaveChanges();

            var jwtToken = _jwt.GenerateJwtToken(user);

            return new AuthenticationResponse()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                Email = user.Email,
                RefreshToken = refreshToken.Token,
                AccessToken = jwtToken,
            };
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public void RevokeToken(string token, string ip)
    {
        try
        {
            if (!string.IsNullOrEmpty(token))
            {
                var user = _user.GetUserByToken(token);
                var refreshToken = user.RefreshTokens?.FirstOrDefault(x => x.Token == token);

                if (refreshToken!.IsActive == false) throw new Exception("Invalid token.");

                RevokeRefreshToken(refreshToken, ip, "Revoked without replacement.");
                _context.Update(user);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Token is required.");
            }
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
            var childToken = user.RefreshTokens?.FirstOrDefault(x => x.Token == refreshToken.ReplacedByToken);

            if (childToken!.IsActive)
                RevokeRefreshToken(childToken, ip, reason);
            else
                RevokeDescendantRefreshTokens(refreshToken, user, ip, reason);
        }
    }

    private void RemoveOldRefreshToken(User user)
    {
        user.RefreshTokens?.RemoveAll(x => !x.IsActive && x.Created.AddDays(_appSettings.RefreshTokenTTL) <= DateTime.UtcNow);
    }

    private void RevokeRefreshToken(RefreshToken token, string ip, string? reason = null, string? replacedByToken = null)
    {
        token.Revoked = DateTime.UtcNow;
        token.RevokedByIp = ip;
        token.ReplacedByToken = replacedByToken;
        token.ReasonRevoked = reason;
    }

    private RefreshToken RotateRefreshToken(RefreshToken refreshToken, string ip)
    {
        var newRefreshToken = _jwt.GenerateRefreshToken(ip);
        RevokeRefreshToken(refreshToken, ip, "Replaced by new token.", newRefreshToken.Token!);
        return newRefreshToken;
    }
}
