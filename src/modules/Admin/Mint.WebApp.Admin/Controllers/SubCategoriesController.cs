using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Helpers;
using Mint.Infrastructure.Attributes;
using Mint.WebApp.Admin.Operations.Commands.SubCategories;
using Mint.WebApp.Admin.Operations.Dtos;
using Mint.WebApp.Admin.Operations.Dtos.SubCategories;

namespace Mint.WebApp.Admin.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubCategoriesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResult<SubCategoryFullViewModel>>> Get(
        [FromQuery] GetSubCategoriesCommand command,
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
        var links = await mediator.Send(new GetSubCategoriesDefaultLinksCommand(search), cancellationToken);
        return Ok(links);
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<ActionResult<SubCategoryFullViewModel>> Create(
        [FromBody] SubCategoryFullBindingModel subCategory,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new CreateSubCategoryCommand(subCategory), cancellationToken);
    }
}
