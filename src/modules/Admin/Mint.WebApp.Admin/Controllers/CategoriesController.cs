using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Helpers;
using Mint.Infrastructure.Attributes;
using Mint.WebApp.Admin.Application.Operations.Commands.Categories;
using Mint.WebApp.Admin.Application.Operations.Dtos.Categories;
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
    public async Task<ActionResult<List<string>>> GetCategoriesDefaultLinks(
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

    [HttpGet("simple")]
    [Authorize(Roles = "admin")]
    public async Task<ActionResult<List<CategorySimpleViewModel>>> GetSimpleCategories(
        [FromQuery] string? search,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetCommonCategoriesQuery(search), cancellationToken);
    }

    [HttpGet("{id:guid}/simple")]
    [Authorize(Roles = "admin")]
    public async Task<ActionResult<CategorySimpleViewModel>> GetSimpleCategoryById(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetSimpleCategoryByIdQuery(id), cancellationToken);
    }

    [HttpGet("{id:guid}/info")]
    [Authorize(Roles = "admin")]
    public async Task<ActionResult<CategoryInfoViewModel>> GetCategoryInfo(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetCategoryInfoQuery(id), cancellationToken);
    }

    [HttpGet("{id:guid}/photo")]
    [Authorize(Roles = "admin")]
    public async Task<ActionResult<CategoryPhotoResponse?>> GetCategoryPhoto(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetCategoryPhotoQuery(id), cancellationToken);
    }

    [HttpGet("{id:guid}/subCategories")]
    public async Task<ActionResult<List<CategoryWithSubCategoryResponse>>> GetSubCategories(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetCategoryWithSubCategoriesQuery(id), cancellationToken);
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<ActionResult<Guid>> Create(
        [FromBody] CategoryInfoBindingModel model,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new CreateCategoryCommand(model), cancellationToken);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> UpdateCategory(
        Guid id,
        [FromBody] CategoryInfoBindingModel model,
        CancellationToken cancellationToken = default)
    {
        await mediator.Send(new UpdateCategoryCommand(id, model), cancellationToken);
        return NoContent();
    }

    [HttpPut("{id:guid}/photo")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> UpdateCategoryPhoto(
        Guid id,
        [FromForm] CategoryPhotoDto photo,
        CancellationToken cancellationToken = default)
    {
        await mediator.Send(new UpdateCategoryPhotoCommand(id, photo), cancellationToken);
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
