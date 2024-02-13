using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Helpers;
using Mint.Infrastructure.Attributes;
using Mint.WebApp.Admin.Operations.Commands.Categories;
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
        return Ok(await mediator.Send(command, cancellationToken));
    }

    [HttpGet("links")]
    [Authorize(Roles = "admin")]
    public async Task<ActionResult<IEnumerable<DefaultLinkDto>>> GetCategoriesDefaultLinks(
        [FromQuery] string? search,
        CancellationToken cancellationToken = default)
    {
        var links = await mediator.Send(new GetCategoriesDefaultLinksCommand(search), cancellationToken);
        return Ok(links);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryFullViewModel>> GetCategoryById(Guid id)
    {
        await Task.Delay(1000);
        return Ok();
    }

    [HttpPost("create")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Create(
        [FromForm] CategoryFullBindingModel model,
        CancellationToken cancellationToken = default)
    {
        var newCategory = await mediator.Send(new CreateCategoryCommand(model), cancellationToken);
        return Ok(newCategory);
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
