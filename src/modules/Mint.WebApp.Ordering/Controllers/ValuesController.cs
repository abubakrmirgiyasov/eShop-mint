using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mint.WebApp.Ordering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            return Ok(new { Id = Guid.NewGuid() });
        }
    }
}
