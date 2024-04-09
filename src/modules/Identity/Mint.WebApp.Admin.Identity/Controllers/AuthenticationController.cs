using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.DTO_s.Identity;
using Mint.Domain.Extensions;
using Mint.WebApp.Identity.Application.Operations.Commands.Admins;

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
