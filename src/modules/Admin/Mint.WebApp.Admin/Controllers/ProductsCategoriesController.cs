using Microsoft.AspNetCore.Mvc;
using Mint.Infrastructure.Attributes;

namespace Mint.WebApp.Admin.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "admin,seller")]
public class ProductsCategoriesController : ControllerBase
{
    //[HttpGet("byProduct/{productId:guid}")]
    //public async Task<ActionResult<ProductCategoryViewModel>> GetProductCategories(
    //    Guid productId,
    //    CancellationToken cancellationToken = default)
    //{

    //}
}
