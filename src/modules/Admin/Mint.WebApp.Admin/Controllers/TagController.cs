using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Helpers;
using Mint.WebApp.Admin.Application.Operations.Commands;
using Mint.WebApp.Admin.Application.Operations.Dtos.Tags;

namespace Mint.WebApp.Admin.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class TagController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesDefaultResponseType]
    [ProducesResponseType(200)]
    public async Task<ActionResult<PaginatedResult<TagFullViewModel>>> GetTags(
        [FromQuery] GetTagsCommand command,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(command, cancellationToken);
    }
}
