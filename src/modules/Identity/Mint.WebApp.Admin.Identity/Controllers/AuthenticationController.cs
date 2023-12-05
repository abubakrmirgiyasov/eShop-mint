using Microsoft.AspNetCore.Mvc;
using Mint.Domain.DTO_s.Identity;
using Mint.Domain.Extensions;
using Mint.Infrastructure.Repositories.Identity.Interfaces;

namespace Mint.WebApp.Admin.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class AuthenticationController(IAuthenticationRepository authentication) : ControllerBase
{
    private readonly IAuthenticationRepository _authentication = authentication;

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
