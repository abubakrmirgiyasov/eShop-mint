using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Helpers;
using Mint.Infrastructure.Attributes;
using Mint.WebApp.Admin.Operations.Commands.Categories;
using Mint.WebApp.Admin.Operations.Dtos;
using Mint.WebApp.Admin.Operations.Dtos.Categories;

namespace Mint.WebApp.Admin.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResult<CategoryFullViewModel>>> GetCategories(
        [FromQuery] GetCategoriesCommand command,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(command, cancellationToken);
    }

    [HttpGet("links")]
    [Authorize(Roles = "admin")]
    public async Task<ActionResult<List<DefaultLinkDTO>>> GetCategoriesDefaultLinks(
        [FromQuery] string? search,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetCategoriesDefaultLinksCommand(search), cancellationToken);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryFullViewModel>> GetCategoryById(Guid id)
    {
        await Task.Delay(1000);
        return Ok();
    }

    [HttpGet("common")]
    public async Task<ActionResult<List<CategorySampleViewModel>>> GetSampleCategories(
        [FromQuery] string? search,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetCommonCategoriesCommand(search), cancellationToken);
    }

    [HttpGet("{id:guid}/common")]
    [Authorize(Roles = "admin")]
    public async Task<ActionResult<List<CategorySampleViewModel>>> GetSampleCategoryById(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetSampleCategoryByIdCommand(id), cancellationToken);
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<ActionResult<Guid>> Create(
        [FromForm] CategoryFullBindingModel model,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new CreateCategoryCommand(model), cancellationToken);
    }

    [HttpPut]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> UpdateCategory(
        [FromForm] CategoryFullBindingModel model,
        CancellationToken cancellationToken = default)
    {
        await mediator.Send(new UpdateCategoryCommand(model), cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> DeleteCategory(Guid id, CancellationToken cancellationToken = default)
    {
        await mediator.Send(new RemoveCategoryCommand(id), cancellationToken);
        return NoContent();
    }
}
