using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Attributes;
using Mint.Domain.Models.Admin.Manufactures;
using Mint.WebApp.Admin.DTO_s.Manufactures;

namespace Mint.WebApp.Admin.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ManufactureController : ControllerBase
{
    public ManufactureController()
    {

    }

    [HttpGet]
    public async Task<IActionResult> GetManufactures()
    {
        return Ok();

    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetManufactureById(Guid id)
    {
        return Ok();

    }

    [HttpPost]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> NewManufacture([FromBody] ManufactureFullBindingModel model)
    {
        return Ok();

    }

    [HttpPut]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> UpdateManufacture([FromBody] ManufactureFullBindingModel model)
    {
        return Ok();

    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> DeleteManufactureById(Guid id)
    {
        return Ok();
    }
}
