using Microsoft.AspNetCore.Mvc;
using Mint.Domain.BindingModels;
using Mint.Domain.FormingModels;
using Mint.Domain.ViewModels;
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
            model.Ip = Request.GetIp();
            await _user.AddNewUserAsync(model);
            return Ok(new { message = "Успешно." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUserInfo([FromForm] UserFullBindingModel model)
    {
        try
        {
            await _user.UpdateUserInfoAsync(model);
            return Ok(new { message = "Успешно." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserAddressesById(Guid userId)
    {
        try
        {
            var address = await _user.GetUserAddressesByIdAsync(userId);
            return Ok(address);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddUserAddress([FromBody] AddressBindingModel model)
    {
        try
        {
            await _user.AddUserAddressAsync(model);
            return Ok(new { message = "Успешно." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUserAddress([FromBody] AddressBindingModel model)
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

    [HttpDelete]
    public async Task<IActionResult> DeleteUserAddress([FromBody] Guid id)
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

    [HttpPut]
    public async Task<IActionResult> UpdateUserPassword([FromBody] UserUpdatePasswordBindingModel model)
    {
        try
        {
            await _user.UpdateUserPaswordAsync(model);
            return Ok(new { message = "Успешно." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
