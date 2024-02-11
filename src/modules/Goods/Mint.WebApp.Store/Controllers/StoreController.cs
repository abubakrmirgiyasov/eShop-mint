using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Attributes;
using Mint.Domain.DTO_s.Store;
using Mint.Infrastructure;

namespace Mint.WebApp.Store.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class StoreController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public StoreController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetStores()
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetStoreById(Guid id)
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetMyStore(Guid id)
    {
        return Ok();
    }

    [HttpPost]
    public IActionResult CreateStore([FromBody] StoreAddressFullBindingModel model)
    {
        return Ok();
    }

    [HttpPut]
    public IActionResult UpdateStore([FromBody] StoreAddressFullBindingModel model)
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStore([FromBody] Guid id)
    {
        return Ok();
    }
}
