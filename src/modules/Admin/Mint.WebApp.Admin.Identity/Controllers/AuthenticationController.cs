using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Extensions;
using Mint.WebApp.Admin.Identity.Application.Operations.Commands;
using Mint.WebApp.Admin.Identity.Application.Operations.Dtos;

namespace Mint.WebApp.Admin.Identity.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthenticationController(IMediator mediator) : ControllerBase
{
    [HttpPost("signIn")]
    public async Task<ActionResult<AuthenticationAdminResponse>> SignIn(
        [FromBody] SignInRequest model,
        CancellationToken cancellationToken = default)
    {
        model.Ip = Request.GetIp();
        return await mediator.Send(new SignInCommand(model), cancellationToken);
    }
}
