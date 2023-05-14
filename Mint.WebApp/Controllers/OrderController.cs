using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.BindingModels;
using Mint.Domain.Common;
using Mint.Infrastructure.Repositories.Interfaces;
using Mint.WebApp.Attributes;

namespace Mint.WebApp.Controllers;

[ApiController]
[Route("[controller]/[action]")]
[Authorize(Roles = $"{Constants.ADMIN},{Constants.SELLER},{Constants.BUYER}")]
public class OrderController : ControllerBase
{
	private readonly IOrderRepository _order;

	public OrderController(IOrderRepository order)
	{
		_order = order;
	}

    [HttpGet]
    [Authorize(Roles = Constants.ADMIN)]
    public async Task<IActionResult> GetOrders()
    {
		try
		{
			return Ok();
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex });
		}
    }

	[HttpGet("{id}")]
	public async Task<IActionResult> GetSellerOrdersById(Guid id)
	{
		try
		{
			return Ok();
		}
		catch (Exception ex)
		{
			return BadRequest(new { mesage = ex });
		}
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetBuyerOrdersById(Guid id)
	{
		try
		{
			return Ok();
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex });
		}
	}

	public async Task<IActionResult> CreateOrder([FromBody] OrderProductBindingModel model)
	{
		try
		{
            var newOrder = await _order.CreateOrder(model);
            return Ok(new { id = newOrder });
		}
		catch (Exception ex)
		{
			return BadRequest(new { message = ex });
		}
	}
}
