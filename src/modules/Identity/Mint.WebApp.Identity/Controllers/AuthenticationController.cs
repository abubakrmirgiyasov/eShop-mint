using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mint.WebApp.Identity.Models;
using Mint.WebApp.Identity.Repositories;

namespace Mint.WebApp.Identity.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class AuthenticationController : ControllerBase
{
    private readonly AuthenticationRepository _authentication;

    public AuthenticationController(AuthenticationRepository authentication)
    {
        _authentication = authentication;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var x = _authentication.FilterBy(x => x.FirstName != ".");
        return Ok(x);
    }

    [HttpPost]
    public async Task<IActionResult> SignIn([FromBody] User model)
    {
        try
        {
            _authentication.InsertOne(model);
            return Ok(_authentication.FilterBy(x => x.FirstName != "."));
        }
        catch (Exception ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
    }
}
