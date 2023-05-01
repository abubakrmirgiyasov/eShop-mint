using Microsoft.AspNetCore.Mvc;
using Mint.Domain.BindingModels;
using Mint.Domain.Common;
using Mint.Infrastructure.Repositories.Interfaces;
using Mint.WebApp.Attributes;

namespace Mint.WebApp.Controllers;

[ApiController]
[Route("[controller]/[action]")]
[Authorize(Roles = $"{Constants.ADMIN},{Constants.SELLER},{Constants.BUYER}")]
public class StoreController : ControllerBase
{
    private readonly IStoreRepository _store;

    public StoreController(IStoreRepository store)
    {
        _store = store;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetStores()
    {
        try
        {
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMyStore(Guid id)
    {
        try
        {
            var store = await _store.GetMyStoreAsync(id);
            return Ok(store);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateStore([FromForm] StoreFullBindingModel model)
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
