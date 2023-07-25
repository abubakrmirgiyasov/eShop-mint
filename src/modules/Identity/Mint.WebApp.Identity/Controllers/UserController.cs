using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mint.WebApp.Identity.DTO_s;
using Mint.WebApp.Identity.Extensions;
using Mint.WebApp.Identity.Repositories.Interfaces;

namespace Mint.WebApp.Identity.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _user;

    public UserController(IUserRepository user)
    {
        _user = user;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserAddresses(Guid id)
    {
        try
        {
            var addresses = await _user.GetUserAddressesAsync(id);
            return Ok(addresses);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> SendEmailConfirmationCode([FromBody] UserFullBindingModel model)
    {
		try
		{
            var code = await _user.SendEmailConfirmationCodeAsync(model.Email!);
            Response.SetConfirmationCode(code);
            return Ok(code);
		}
		catch (Exception ex)
		{
            return BadRequest(new { message = ex.Message });
		}
    }

    [HttpPost]
    public async Task<IActionResult> CreateUserAddress([FromBody] UserAddressFullBindingModel model)
    {
        try
        {
            var address = await _user.CreateUserAddressAsync(model);
            return Ok(address);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser([FromBody] UserFullBindingModel model)
    {
		try
		{
            var user = await _user.UpdateUserAsync(model);
			return Ok(user);
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
    }
}
