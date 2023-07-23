using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mint.WebApp.Identity.DTO_s;
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
