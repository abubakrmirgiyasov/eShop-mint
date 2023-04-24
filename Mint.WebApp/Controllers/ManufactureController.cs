using Microsoft.AspNetCore.Mvc;
using Mint.Domain.BindingModels;
using Mint.Domain.Common;
using Mint.Infrastructure.Repositories.Interfaces;
using Mint.WebApp.Attributes;

namespace Mint.WebApp.Controllers;

[ApiController]
[Route("[controller]/[action]")]
[Authorize(Roles = Constants.ADMIN)]
public class ManufactureController : ControllerBase
{
    private readonly IManufactureRepository _manufacture;

    public ManufactureController(IManufactureRepository manufacture)
    {
        _manufacture = manufacture;
    }

    [HttpGet]
    [Authorize(Roles = $"{Constants.ADMIN},{Constants.SELLER}")]
    public async Task<IActionResult> GetManufactures()
    {
        try
        {
            var manufactures = await _manufacture.GetManufacturesAsync();
            return Ok(manufactures);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetManufactureById(Guid id)
    {
        try
        {
            var manufacture = await _manufacture.GetManufactureByIdAsync(id);
            return Ok(manufacture);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddManufacture([FromForm] ManufactureBindingModel model)
    {
        try
        {
            await _manufacture.AddManufactureAsync(model);
            return Ok(new { message = "Успешно." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateManufacture([FromForm] ManufactureBindingModel model)
    {
        try
        {
            await _manufacture.UpdateManufactureAsync(model);
            return Ok(new { message = "Успешно." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteManufacture(Guid id)
    {
        try
        {
            await _manufacture.DeleteManufactureAsync(id);
            return Ok(new { message = "Успешно." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
