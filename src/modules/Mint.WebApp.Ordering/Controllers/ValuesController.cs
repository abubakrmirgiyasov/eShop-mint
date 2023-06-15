using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public ValuesController(IRepository<Order> repository)
        {
            _repository = repository;
        }

        //private readonly IOrderRepository _order;
        //private readonly IUnitOfWork _uow;

        //public ValuesController(IOrderRepository order, IUnitOfWork uow)
        //{
        //    _order = order;
        //    _uow = uow;
        //}

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var get = await _repository.GetAllAsync();
            return Ok(get);
        }

        [HttpPost("Add")]
        public IActionResult Add(Order order)
        {
            var s = _repository.Add(order);
            return Ok(s);
        }

        //[HttpGet("All")]
        //public async Task<IActionResult> GetAll()
        //{
        //    var products = await _order.GetAllAsync();
        //    return Ok(products);
        //}

        //[HttpGet("GetById/{id:int}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var product = await _order.GetByIdAsync(Guid.NewGuid());
        //    return Ok(product);
        //}



        //[HttpPut("Update")]
        //public async Task<IActionResult> Update(Order order)
        //{
        //    var s = _order.Update(order);
        //    await _uow.Commit();
        //    return Ok(s);
        //}

        //[HttpDelete("Delete/{id:int}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    _order.Delete(Guid.NewGuid());
        //    await _uow.Commit();
        //    return Ok();
        //}
    }
}
