using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mint.Application.Dtos;
using Mint.Infrastructure.Attributes;
using Mint.WebApp.Admin.Identity.Application.Operations.Commands;
using Mint.WebApp.Admin.Identity.Application.Operations.Dtos;
using Mint.WebApp.Admin.Identity.Application.Operations.Queries;

namespace Mint.WebApp.Admin.Identity.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "admin,seller")]
public class AccountController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<AdminInfoViewModel>> GetInfoById(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetConsumerInfoQuery(id), cancellationToken);
    }

    [HttpGet("{id:guid}/image")]
    public async Task<ActionResult<ImageLink>> GetPicture(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetConsumerPictureQuery(id), cancellationToken);
    }

    [HttpPut("settings")]
    public async Task<IActionResult> AdminSettings(
        [FromBody] AdminSettingsBindingModel settings,
        CancellationToken cancellationToken = default)
    {
        var userId = User.FindFirst("id");

        if (userId is null)
            return Unauthorized();

        await mediator.Send(new SetConsumerInfoCommand(Guid.Parse(userId.Value), settings), cancellationToken);
        return NoContent();
    }
}
