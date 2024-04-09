using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Helpers;
using Mint.WebApp.Admin.Application.Operations.Dtos.Tags;
using Mint.WebApp.Admin.Application.Operations.Queries.Tags;

namespace Mint.WebApp.Admin.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TagController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResult<TagFullViewModel>>> GetTags(
        [FromQuery] GetTagsQuery query,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(query, cancellationToken);
    }
}
