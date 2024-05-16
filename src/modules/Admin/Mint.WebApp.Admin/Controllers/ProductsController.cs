using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mint.Application.Dtos;
using Mint.Domain.Common;
using Mint.Domain.Helpers;
using Mint.Infrastructure.Attributes;
using Mint.WebApp.Admin.Application.Operations.Commands.Products;
using Mint.WebApp.Admin.Application.Operations.Dtos.Common;
using Mint.WebApp.Admin.Application.Operations.Dtos.Products;
using Mint.WebApp.Admin.Application.Operations.Queries.Products;
using System.ComponentModel.DataAnnotations;

namespace Mint.WebApp.Admin.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "admin,seller")]
public class ProductsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResult<ProductViewModel>>> GetProductsByUserId(
        [FromQuery] string? searchPhrase,
        [FromQuery] string? sortBy,
        [FromQuery] SortDirection? sortDir,
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
                SortBy: sortBy,
                SortDir: sortDir,
                PageIndex: pageIndex,
                PageSize: pageSize
            ), cancellationToken
        );
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ProductViewModel>> GetProductById(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetProductByIdQuery(id), cancellationToken);
    }

    [HttpGet("{id:guid}/info")]
    public async Task<ActionResult<ProductInfoViewModel>> GetProductInfo(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetProductInfoQuery(id), cancellationToken);
    }

    [HttpGet("{id:guid}/price")]
    public async Task<ActionResult<ProductPriceViewModel>> GetProductPrice(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetProductPriceQuery(id), cancellationToken);
    }

    [HttpGet("{id:guid}/images")]
    public async Task<ActionResult<List<ImageLink>>> GetProductImages(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetProductImagesQuery(id), cancellationToken);
    }

    [HttpGet("images")]
    public async Task<ActionResult<Dictionary<Guid, IEnumerable<ImageLink>>>> GetProductsImagesByCount(
        [FromQuery][Required] List<Guid> productsIds,
        [FromQuery][Required] int count,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetProductsImagesQuery(productsIds, count), cancellationToken);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateInfo(
        [FromBody] ProductInfoBindingModel productInfo,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new CreateInfoProductCommand(productInfo), cancellationToken);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateInfo(
        Guid id,
        [FromBody] ProductInfoBindingModel productInfo,
        CancellationToken cancellationToken = default)
    {
        await mediator.Send(new UpdateProductInfoCommand(id, productInfo), cancellationToken);
        return NoContent();
    }

    [HttpPut("{id:guid}/price")]
    public async Task<IActionResult> UpdatePrice(
        Guid id,
        [FromBody] ProductPriceBindingModel product,
        CancellationToken cancellationToken = default)
    {
        await mediator.Send(new UpdateProductPriceCommand(id, product), cancellationToken);
        return NoContent();
    }

    [HttpPut("{id:guid}/images")]
    public async Task<IActionResult> UpdateImages(
        Guid id,
        [FromForm] FileRequest images,
        CancellationToken cancellationToken = default)
    {
        await mediator.Send(new UpdateProductImagesCommand(id, images), cancellationToken);
        return NoContent();
    }

    [HttpPut("{id:guid}/categories")]
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
