using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.DTO_s.Identity;
using Mint.Domain.Extensions;
using Mint.WebApp.Admin.Identity.Commands.Authentications;

namespace Mint.WebApp.Admin.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class AuthenticationController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> SignIn(
        [FromBody] SignInRequest model,
        CancellationToken cancellationToken = default)
    {
        try
        {
            model.Ip = Request.GetIp();
            var response = await mediator.Send(new SignInCommand(model), cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
