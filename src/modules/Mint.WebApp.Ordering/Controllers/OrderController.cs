using Microsoft.AspNetCore.Mvc;
using Mint.Infrastructure.MessageBrokers.Interfaces;
using Mint.Infrastructure.MongoDb.Interfaces;
using Mint.WebApp.Ordering.Models;

namespace Mint.WebApp.Ordering.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IRepository<Order> _repository;
    //private readonly IMessageSender<Order> _sender;
    //private readonly IMessageReceiver<Order> _receive;

    public OrderController(IRepository<Order> repository/*, IMessageSender<Order> sender, IMessageReceiver<Order> receive*/)
    {
        _repository = repository;
        //_sender = sender;
        //_receive = receive;
    }

    [HttpGet("Get")]
    public IActionResult Get()
    {
        var get = _repository.FilterBy(
            filter => filter.FirstName != "{}",
            projection => projection);
        return Ok(get);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add(Order order)
    {
        _repository.InsertOne(order);

        //await _sender.SendAsync(order);

        return Ok(new { message = "Add Success" });
    }
}
