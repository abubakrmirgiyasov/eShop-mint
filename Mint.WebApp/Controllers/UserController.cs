using Microsoft.AspNetCore.Mvc;
using Mint.Domain.BindingModels;
using Mint.Domain.FormingModels;
using Mint.Infrastructure.Repositories.Interfaces;
using Mint.WebApp.Attributes;
using Mint.WebApp.Extensions;

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

    [HttpGet]
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
    public async Task<IActionResult> Registration([FromForm] UserFullBindingModel model)
    {
        try
        {
            //model.Ip = Request.GetIp();
            //await _user.AddNewUser(model);
            return Ok(new { message = "Успешно." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
