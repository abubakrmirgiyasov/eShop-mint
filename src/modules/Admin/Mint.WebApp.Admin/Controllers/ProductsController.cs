using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Common;
using Mint.Domain.Helpers;
using Mint.Infrastructure.Attributes;
using Mint.WebApp.Admin.Application.Operations.Commands.Products;
using Mint.WebApp.Admin.Application.Operations.Dtos.Common;
using Mint.WebApp.Admin.Application.Operations.Dtos.Products;
using Mint.WebApp.Admin.Application.Operations.Queries.Products;

namespace Mint.WebApp.Admin.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IMediator mediator) : ControllerBase
{
    [HttpGet("user")]
    [Authorize(Roles = "admin,seller")]
    public async Task<ActionResult<PaginatedResult<ProductViewModel>>> GetProductsByUserId(
        [FromQuery] string? searchPhrase,
        [FromQuery] SortType sort,
        [FromQuery] int pageIndex,
        [FromQuery] int pageSize,
        CancellationToken cancellationToken = default)
    {
        var userId = User.FindFirst("id");

        if (userId is null)
            return Unauthorized();

        return await mediator.Send(
            new GetProductsQuery(
                UserId: Guid.Parse(userId.Value),
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

    [HttpGet("{id:guid}/price")]
    [Authorize(Roles = "admin,seller")]
    public async Task<ActionResult<ProductPriceViewModel>> GetProductPrice(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetProductPriceQuery(id), cancellationToken);
    }

    [HttpGet("{id:guid}/images")]
    [Authorize(Roles = "admin,seller")]
    public async Task<ActionResult<List<ImageLink>>> GetProductImages(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetProductImagesQuery(id), cancellationToken);
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
        await mediator.Send(new UpdateInfoProductCommand(id, productInfo), cancellationToken);
        return NoContent();
    }

    [HttpPut("{id:guid}/price")]
    [Authorize(Roles = "admin,seller")]
    public async Task<IActionResult> UpdatePrice(
        Guid id,
        [FromBody] ProductPriceBindingModel product,
        CancellationToken cancellationToken = default)
    {
        await mediator.Send(new UpdateProductPriceCommand(id, product), cancellationToken);
        return NoContent();
    }

    [HttpPut("{id:guid}/images")]
    [Authorize(Roles = "admin,seller")]
    public async Task<IActionResult> UpdateImages(
        Guid id,
        [FromForm] FileRequest images,
        CancellationToken cancellationToken = default)
    {
        await mediator.Send(new UpdateProductImagesCommand(id, images), cancellationToken);
        return NoContent();
    }

    [HttpPut("{id:guid}/categories")]
    [Authorize(Roles = "admin,seller")]
    public async Task<IActionResult> UpdateCategories(
        Guid id,
        [FromBody] List<ProductCategoryBindingModel> productCategories,
        CancellationToken cancellationToken = default)
    {
        await mediator.Send(
            new UpdateProductCategoryCommand(
                ProductId: id,
                ProductCategories: productCategories
            ), cancellationToken
        );
        return NoContent();
    }
}
