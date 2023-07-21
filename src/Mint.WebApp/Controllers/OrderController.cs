//using Microsoft.AspNetCore.Mvc;
//using Mint.Domain.BindingModels;
//using Mint.Domain.Common;
//using Mint.Domain.FormingModels;
//using Mint.Domain.Models;
//using Mint.Infrastructure.MessageBrokers.Interfaces;
//using Mint.Infrastructure.Repositories.Interfaces;
//using Mint.WebApp.Attributes;
//using System.Text.Json;

//namespace Mint.WebApp.Controllers;

//[ApiController]
//[Route("[controller]/[action]")]
//[Authorize(Roles = $"{Constants.ADMIN},{Constants.SELLER},{Constants.BUYER}")]
//public class OrderController : ControllerBase
//{
//	private readonly IOrderRepository _order;
//	private readonly IMessageSender<Order> _message;
//	private readonly ILogger<OrderController> _logger;

//	public OrderController(IOrderRepository order, IMessageSender<Order> message, ILogger<OrderController> logger)
//	{
//		_order = order;
//		_message = message;
//		_logger = logger;
//	}

//    [HttpGet]
//    [Authorize(Roles = Constants.ADMIN)]
//    public async Task<IActionResult> GetOrders()
//    {
//		try
//		{
//			var orders = await _order.GetOrdersAsync();
//			return Ok(orders);
//		}
//		catch (Exception ex)
//		{
//			return BadRequest(new { message = ex });
//		}
//    }

//	[HttpGet("{id}")]
//	public async Task<IActionResult> GetSellerOrdersById(Guid id)
//	{
//		try
//		{
//			var orders = await _order.GetSellerOrdersByIdAsync(id);
//            return Ok(orders);
//		}
//		catch (Exception ex)
//		{
//			return BadRequest(new { mesage = ex });
//		}
//	}

//	[HttpGet("{id}")]
//	public async Task<IActionResult> GetBuyerOrdersById(Guid id)
//	{
//		try
//		{
//			var orders = await _order.GetBuyerOrdersByIdAsync(id);
//            return Ok(orders);
//		}
//		catch (Exception ex)
//		{
//			return BadRequest(new { message = ex });
//		}
//	}

//	[HttpPost]
//	public async Task<IActionResult> CreateOrder([FromBody] OrderProductBindingModel model)
//	{
//		try
//		{
//            var newOrder = await _order.CreateOrder(model);

//			_logger.LogInformation(JsonSerializer.Serialize(model));
//			await _message.SendAsync(new OrderManager().FormingBindingModel(model));

//            return Ok(new { id = newOrder });
//		}
//		catch (Exception ex)
//		{
//			return BadRequest(new { message = ex });
//		}
//	}
//}
