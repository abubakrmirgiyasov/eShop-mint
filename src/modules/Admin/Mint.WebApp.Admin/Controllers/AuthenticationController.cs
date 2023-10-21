using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Attributes;
using Mint.Domain.DTO_s.Identity;
using Mint.Infrastructure.Repositories.Identity.Interfaces;
using Mint.Domain.Extensions;

namespace Mint.WebApp.Admin.Controllers;

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
    public async Task<IActionResult> SignIn([FromBody] UserSignInBindingModel model)
    {
        try
        {
            model.Ip = Request.GetIp();
            var response = await _authentication.SignAsAdmin(model);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
