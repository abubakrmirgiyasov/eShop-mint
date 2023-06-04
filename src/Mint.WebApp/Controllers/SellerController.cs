using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Common;
using Mint.Infrastructure.Repositories.Interfaces;
using Mint.WebApp.Attributes;

namespace Mint.WebApp.Controllers;

[ApiController]
[Route("[controller]/[action]")]
[Authorize(Roles = Constants.ADMIN)]
public class SellerController : ControllerBase
{
    private readonly ISellerRepository _seller;

    public SellerController(ISellerRepository seller)
    {
        _seller = seller;
    }

    [HttpGet]
    public async Task<IActionResult> GetSellers()
    {
        try
        {
            await _seller.Test();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
