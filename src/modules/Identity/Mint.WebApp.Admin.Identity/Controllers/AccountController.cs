using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mint.Infrastructure.Attributes;
using Mint.WebApp.Admin.Identity.Operations.Commands.Admins;
using Mint.WebApp.Admin.Identity.Operations.Queries.Admins;
using Mint.WebApp.Identity.Application.Operations.Dtos;
using Mint.WebApp.Identity.Application.Operations.Dtos.Admins;
using Mint.WebApp.Identity.Application.Operations.Queries.Admins;

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
        return await mediator.Send(new GetAdminInfoQuery(id), cancellationToken);
    }

    [HttpGet("{id:guid}/image")]
    public async Task<ActionResult<UserPictureResponse>> GetPicture(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetUserPictureQuery(id), cancellationToken);
    }

    [HttpPut("settings")]
    public async Task<IActionResult> AdminSettings(
        [FromBody] AdminSettingsBindingModel settings,
        CancellationToken cancellationToken = default)
    {
        var userId = User.FindFirst("id");

        if (userId is null)
            return Unauthorized();

        await mediator.Send(new AdminSettingsCommand(Guid.Parse(userId.Value), settings), cancellationToken);
        return NoContent();
    }
}
