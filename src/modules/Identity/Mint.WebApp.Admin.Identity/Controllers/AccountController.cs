﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mint.WebApp.Admin.Identity.Operations.Commands.Admins;
using Mint.WebApp.Admin.Identity.Operations.Dtos;
using Mint.WebApp.Admin.Identity.Operations.Queries.Admins;

namespace Mint.WebApp.Admin.Identity.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AccountController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<AdminInfoDto>> GetInfoById(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new AdminInfoCommand(id), cancellationToken);
    }

    [HttpGet("{id:guid}/image")]
    [AllowAnonymous]
    public async Task<ActionResult<object>> GetPicture(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetUserPictureQuery(id), cancellationToken);
    }

    [HttpPut("settings")]
    public async Task<IActionResult> AdminSettings(
        [FromBody] AdminSettingsDto settings,
        CancellationToken cancellationToken = default)
    {
        var userId = User.FindFirst("id");
        if (userId is null)
            return Unauthorized();

        await mediator.Send(new AdminSettingsCommand(Guid.Parse(userId.Value), settings), cancellationToken);
        return NoContent();
    }
}
