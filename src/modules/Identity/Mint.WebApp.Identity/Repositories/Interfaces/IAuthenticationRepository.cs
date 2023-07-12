﻿using Mint.WebApp.Identity.DTO_s;

namespace Mint.WebApp.Identity.Repositories.Interfaces;

/// <summary>
/// Authentication Repository Interface
/// </summary>
public interface IAuthenticationRepository
{
    /// <summary>
    /// This method calls when user is signing
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<AuthenticationResponse> SignInAsync(UserFullBindingModel model);

    /// <summary>
    /// This method calls when user is creating new profile
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<UserFullViewModel> SignUpAsync(UserFullBindingModel model);

    /// <summary>
    /// This method calls when users token has been expired
    /// </summary>
    /// <param name="refreshToken"></param>
    /// <param name="ip"></param>
    /// <returns></returns>
    Task<AuthenticationResponse> RefreshToken(string? refreshToken, string? ip);

    /// <summary>
    /// This method calls when user wants change his password
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task UpdatePasswordAsync(UserFullBindingModel model);

    /// <summary>
    /// This method calls when user forgot his password
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task ForgotPasswordAsync(UserFullBindingModel model);

    /// <summary>
    /// This method calls when user is logout
    /// </summary>
    /// <param name="refreshToken"></param>
    /// <param name="ip"></param>
    /// <returns></returns>
    Task RevokeToken(string? refreshToken, string? ip);
}
