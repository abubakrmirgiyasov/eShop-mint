using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Helpers;
using Mint.Infrastructure.Attributes;
using Mint.WebApp.Admin.Application.Operations.Commands.Categories;
using Mint.WebApp.Admin.Application.Operations.Dtos.Categories;
using Mint.WebApp.Admin.Application.Operations.Dtos.Common;
using Mint.WebApp.Admin.Application.Operations.Queries.Categories;

namespace Mint.WebApp.Admin.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResult<CategoryFullViewModel>>> GetCategories(
        [FromQuery] GetCategoriesQuery query,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(query, cancellationToken);
    }

    [HttpGet("links")]
    [Authorize(Roles = "admin")]
    public async Task<ActionResult<List<DefaultLinkDTO>>> GetCategoriesDefaultLinks(
        [FromQuery] string? search,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetCategoriesDefaultLinksQuery(search), cancellationToken);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CategoryFullViewModel>> GetCategoryById(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetCategoryByIdQuery(id), cancellationToken);
    }

    [HttpGet("common")]
    public async Task<ActionResult<List<CategorySampleViewModel>>> GetSampleCategories(
        [FromQuery] string? search,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetCommonCategoriesQuery(search), cancellationToken);
    }

    [HttpGet("{id:guid}/common")]
    [Authorize(Roles = "admin")]
    public async Task<ActionResult<List<CategorySampleViewModel>>> GetSampleCategoryById(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetSampleCategoryByIdQuery(id), cancellationToken);
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<ActionResult<Guid>> Create(
        [FromForm] CategoryFullBindingModel model,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new CreateCategoryCommand(model), cancellationToken);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> UpdateCategory(
        Guid id,
        [FromForm] CategoryFullBindingModel model,
        CancellationToken cancellationToken = default)
    {
        await mediator.Send(new UpdateCategoryCommand(
            id,
            model
        ), cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> DeleteCategory(Guid id, CancellationToken cancellationToken = default)
    {
        await mediator.Send(new DeleteCategoryCommand(id), cancellationToken);
        return NoContent();
    }
}
