using Microsoft.AspNetCore.Mvc;
using Mint.Domain.BindingModels;
using Mint.Domain.FormingModels;
using Mint.Infrastructure.Repositories.Interfaces;
using Mint.WebApp.Attributes;

namespace Mint.WebApp.Controllers;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _user;

    public UserController(IUserRepository user)
    {
        _user = user;
    }

    public IActionResult GetUsers()
    {
        try
        {
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetUserById(Guid id)
    {
        try
        {
            var user = _user.GetUserById(id);
            return Ok(new UserManager().FormingFullViewModel(user));
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost]
    [AllowAnonymous]
    public IActionResult Registration([FromBody] UserFullBindingModel model)
    {
        try
        {
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
