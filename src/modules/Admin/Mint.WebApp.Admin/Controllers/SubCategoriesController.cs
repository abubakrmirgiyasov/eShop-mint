using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Helpers;
using Mint.WebApp.Admin.Operations.Commands.SubCategories;
using Mint.WebApp.Admin.Operations.Dtos.SubCategories;

namespace Mint.WebApp.Admin.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubCategoriesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResult<SubCategoryDTO>>> Get(
        [FromQuery] GetSubCategoriesCommand command,
        CancellationToken cancellationToken = default) 
    {
        return await mediator.Send(command, cancellationToken);
    }
}
