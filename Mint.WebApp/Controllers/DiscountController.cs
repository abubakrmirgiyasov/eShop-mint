using Microsoft.AspNetCore.Mvc;
using Mint.Domain.BindingModels;
using Mint.Domain.Common;
using Mint.Infrastructure.Repositories.Interfaces;
using Mint.WebApp.Attributes;

namespace Mint.WebApp.Controllers;

[ApiController]
[AllowAnonymous]
[Route("[controller]/[action]")]
public class DiscountController : ControllerBase
{
    private readonly IDiscountRepository _discount;

    public DiscountController(IDiscountRepository discount)
    {
        _discount = discount;
    }

    [HttpGet]
    public async Task<IActionResult> GetPromotions()
    {
        try
        {
            var discounts = await _discount.GetDiscountsAsync();
            return Ok(discounts);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("{id}")]
    [Authorize(Roles = Constants.ADMIN)]
    public async Task<IActionResult> GetPromotionById(Guid id)
    {
        try
        {
            var discount = await _discount.GetDiscountByIdAsync(id);
            return Ok(discount);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost]
    [Authorize(Roles = Constants.ADMIN)]
    public async Task<IActionResult> AddPromotion([FromBody] DiscountBindingModel model)
    {
        try
        {
            var discount = await _discount.AddDiscountAsync(model);
            return Ok(discount);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut]
    [Authorize(Roles = Constants.ADMIN)]
    public async Task<IActionResult> UpdatePromotion([FromBody] DiscountBindingModel model)
    {
        try
        {
            await _discount.UpdateDiscountAsync(model);
            return Ok(new { message = "Успешно." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = Constants.ADMIN)]
    public async Task<IActionResult> DeletePromotion(Guid id)
    {
        try
        {
            await _discount.DeleteDiscountAsync(id);
            return Ok(new { message = "Успешно." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
