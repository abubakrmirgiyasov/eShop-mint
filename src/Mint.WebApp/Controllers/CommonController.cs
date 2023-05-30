using Microsoft.AspNetCore.Mvc;
using Mint.Infrastructure.Repositories.Interfaces;
using Mint.WebApp.Attributes;

namespace Mint.WebApp.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CommonController : ControllerBase
{
	private readonly ICommonRepository _common;

    public CommonController(ICommonRepository common)
    {
        _common = common;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Menu()
    {
		try
		{
            var menus = await _common.GetMenuAsync();
            return Ok(menus);
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex.Message });
		}
    }

    [HttpGet("{query}")]
    [AllowAnonymous]
    public async Task<IActionResult> Search(string query)
    {
        try
        {
            var products = await _common.SearchAsync(query);
            return Ok(products);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
