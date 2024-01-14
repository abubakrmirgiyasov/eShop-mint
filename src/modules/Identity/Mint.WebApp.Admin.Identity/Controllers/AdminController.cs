using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Common;
using Mint.WebApp.Admin.Identity.Commands.Admins;
using Mint.WebApp.Admin.Identity.Commands.Dtos;

namespace Mint.WebApp.Admin.Identity.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = nameof(Constants.ADMIN))]
public class AdminController(IMediator mediator) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<AdminInfoDto>> GetInfoById(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new AdminInfoCommand(id), cancellationToken);
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
