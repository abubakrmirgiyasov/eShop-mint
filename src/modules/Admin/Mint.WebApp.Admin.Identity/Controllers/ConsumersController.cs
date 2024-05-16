using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mint.Infrastructure.Attributes;

namespace Mint.WebApp.Admin.Identity.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "admin,seller")]
public class ConsumersController : ControllerBase
{

}
