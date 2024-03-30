using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Helpers;
using Mint.Infrastructure.Attributes;
using Mint.WebApp.Admin.Application.Operations.Commands.Products;
using Mint.WebApp.Admin.Application.Operations.Dtos.Products;
using Mint.WebApp.Admin.Application.Operations.Queries.Products;

namespace Mint.WebApp.Admin.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResult<ProductFullViewModel>>> GetProducts(
        [FromQuery] GetProductsQuery query,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(query, cancellationToken);
    }

    [HttpPost]
    [Authorize(Roles = "admin,seller")]
    public async Task<ActionResult<Guid>> CreateInfo(
        [FromBody] ProductInfoBindingModel productInfo,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new CreateInfoProductCommand(productInfo), cancellationToken);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateInfo(
        [FromBody] ProductInfoBindingModel productInfo,
        CancellationToken cancellationToken = default)
    {
        await mediator.Send(new UpdateInfoProductCommand(productInfo), cancellationToken);
        return NoContent();
    }
}
