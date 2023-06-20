using Microsoft.AspNetCore.Mvc;
using Mint.Infrastructure.MongoDb.Interfaces;
using Mint.WebApp.Ordering.Models;

namespace Mint.WebApp.Ordering.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IRepository<Order> _repository;
    //private readonly IMessageReceiver<Order> _message;

    public OrderController(IRepository<Order> repository)//, IMessageReceiver<Order> message)
    {
        _repository = repository;
        //_message = message;
    }

    [HttpGet("Get")]
    public IActionResult Get()
    {
        var get = _repository.FilterBy(
            filter => filter.FirstName != "{}",
            projection => projection.FirstName);
        return Ok(get);
    }

    [HttpPost("Add")]
    public IActionResult Add(Order order)
    {
        _repository.InsertOne(order);
        return Ok(new { message = "Add Success" });
    }
}
