using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mint.WebApp.Ordering.Infrastructure.Repositories;
using Mint.WebApp.Ordering.Interfaces;
using Mint.WebApp.Ordering.Models;

namespace Mint.WebApp.Ordering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IOrderRepository _order;
        private readonly IUnitOfWork _uow;

        public ValuesController(IOrderRepository order, IUnitOfWork uow)
        {
            _order = order;
            _uow = uow;
        }

        [HttpGet("Get")]
        public IActionResult Get()
        {
            return Ok(new { Id = Guid.NewGuid() });
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            var products = await _order.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("GetById/{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _order.GetByIdAsync(Guid.NewGuid());
            return Ok(product);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(Order order)
        {
            var s = _order.Add(order);

            await _uow.Commit();

            return Ok(s);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(Order order)
        {
            var s = _order.Update(order);
            await _uow.Commit();
            return Ok(s);
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            _order.Delete(Guid.NewGuid());
            await _uow.Commit();
            return Ok();
        }
    }
}
