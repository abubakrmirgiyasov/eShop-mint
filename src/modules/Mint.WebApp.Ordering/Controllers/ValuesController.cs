using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mint.Infrastructure.MessageBrokers.Interfaces;
using Mint.WebApp.Ordering.Infrastructure.Interfaces;
using Mint.WebApp.Ordering.Infrastructure.Repositories.Interfaces;
using Mint.WebApp.Ordering.Models;

namespace Mint.WebApp.Ordering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IRepository<Order> _repository;
        //private readonly IMessageReceiver<Order> _message;

        public ValuesController(IRepository<Order> repository) // , IMessageReceiver<Order> message
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
            //_message.ReceiveAsync()

            _repository.InsertOne(order);
            return Ok(new { message = "Add Success" });
        }
    }
}
