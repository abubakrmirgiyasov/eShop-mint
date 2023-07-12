using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Attributes;
using Mint.WebApp.Identity.DTO_s;
using Mint.WebApp.Identity.Extensions;
using Mint.WebApp.Identity.Repositories.Interfaces;

namespace Mint.WebApp.Identity.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationRepository _authentication;

    public AuthenticationController(IAuthenticationRepository authentication)
    {
        _authentication = authentication;
    }

    [HttpPost]
    public async Task<IActionResult> SignIn([FromBody] UserFullBindingModel model)
    {
        try
        {
            model.Ip = Request.GetIp();

            var response = await _authentication.SignInAsync(model);
            Response.SetTokenCookie(response.RefreshToken!);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> SingUp([FromBody] UserFullBindingModel model)
    {
        try
        {
            model.UserAgent = Request.GetUserAgent();
            model.Ip = Request.GetIp();
            model.AcceptLanguage = Request.GetUserAcceptLanguage();

            var user = await _authentication.SignUpAsync(model);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> RefreshToken()
    {
        try
        {
            var refreshToken = Request.Cookies["refresh_token"];
            var response = await _authentication.RefreshToken(refreshToken, Request.GetIp());
            Response.SetTokenCookie(response.RefreshToken!);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> UpdatePassword([FromBody] UserFullBindingModel model)
    {
        try
        {
            await _authentication.UpdatePasswordAsync(model);
            return Ok(new { message = "Обновлено успешно"});
        }
        catch (Exception ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> ForgetPassword([FromBody] UserFullBindingModel model)
    {
        try
        {
            await _authentication.ForgotPasswordAsync(model);
            return Ok(new { message = "Обновлено успешно" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> SignOut(RevokeTokenRequest model)
    {
        try
        {
            var token = model.Token ?? Request.Cookies["refresh_token"];
            await _authentication.RevokeToken(token, Request.GetIp());
            return Ok(new { message = "Token was revoked successfully" });
        }
        catch (Exception ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }
}
