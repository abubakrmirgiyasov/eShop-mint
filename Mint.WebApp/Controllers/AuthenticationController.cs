using Microsoft.AspNetCore.Mvc;
using Mint.Domain.BindingModels;
using Mint.Infrastructure.Repositories.Interfaces;
using Mint.WebApp.Attributes;
using Mint.WebApp.Extensions;

namespace Mint.WebApp.Controllers;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationRepository _authentication;

    public AuthenticationController(IAuthenticationRepository authentication)
    {
        _authentication = authentication;
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Signin([FromBody] UserSigninBindingModel model)
    {
        try
        {
            var response = _authentication.Signin(model, Request.GetIp()!);
            Response.SetTokenCookie(response.RefreshToken!);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult RefreshToken()
    {
        try
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = _authentication.RefreshToken(refreshToken!, Request.GetIp()!);
            Response.SetTokenCookie(response.RefreshToken!);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost]
    public IActionResult Signout(RevokeTokenRequest model)
    {
        try
        {
            var token = model.Token ?? Request.Cookies["refreshToken"];
            _authentication.RevokeToken(token!, Request.GetIp()!);
            return Ok(new { message = "Успешно." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
