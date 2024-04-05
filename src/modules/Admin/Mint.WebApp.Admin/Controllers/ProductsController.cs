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
    [HttpGet("user/{userId:guid}")]
    [Authorize(Roles = "admin,seller")]
    public async Task<ActionResult<PaginatedResult<ProductFullViewModel>>> GetProductsByUserId(
        Guid userId,
        [FromQuery] string? searchPhrase,
        [FromQuery] int sort,
        [FromQuery] int pageIndex,
        [FromQuery] int pageSize,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(
            new GetProductsQuery(
                UserId: userId,
                SearchPhrase: searchPhrase,
                Sort: sort,
                PageIndex: pageIndex,
                PageSize: pageSize
            ), cancellationToken
        );
    }

    [HttpGet("{id:guid}/info")]
    [Authorize(Roles = "admin,seller")]
    public async Task<ActionResult<ProductInfoViewModel>> GetProductInfo(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetProductInfoQuery(id), cancellationToken);
    }

    [HttpPost]
    [Authorize(Roles = "admin,seller")]
    public async Task<ActionResult<Guid>> CreateInfo(
        [FromBody] ProductInfoBindingModel productInfo,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new CreateInfoProductCommand(productInfo), cancellationToken);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "admin,seller")]
    public async Task<IActionResult> UpdateInfo(
        Guid id,
        [FromBody] ProductInfoBindingModel productInfo,
        CancellationToken cancellationToken = default)
    {
        await mediator.Send(new UpdateInfoProductCommand(productInfo), cancellationToken);
        return NoContent();
    }

    [HttpPut("{id:guid}/price")]
    [Authorize(Roles = "admin,seller")]
    public IActionResult UpdatePrice(
        Guid id,
        [FromBody] ProductPriceBindingModel product,
        CancellationToken cancellationToken = default)
    {
        return NoContent();
    }

    [HttpPut("{id:guid}/images")]
    [Authorize(Roles = "admin,seller")]
    public IActionResult UpdateImages(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return NoContent();
    }

    [HttpPut("{id:guid}/categories")]
    [Authorize(Roles = "admin,seller")]
    public async Task<IActionResult> UpdateCategories(
        Guid id,
        [FromBody] List<ProductCategoryBindingModel> productCategory,
        CancellationToken cancellationToken = default)
    {
        await mediator.Send(
            new UpdateProductCategoryCommand(
                ProductId: id,
                CategoriesIds: productCategory
            ), cancellationToken
        );
        return NoContent();
    }
}
