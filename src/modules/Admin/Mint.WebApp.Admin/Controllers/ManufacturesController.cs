using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Helpers;
using Mint.Infrastructure.Attributes;
using Mint.WebApp.Admin.Operations.Commands.Manufactures;
using Mint.WebApp.Admin.Operations.Dtos.Manufactures;

namespace Mint.WebApp.Admin.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ManufacturesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResult<ManufactureFullViewModel>>> GetManufactures(
        [FromQuery] GetManufacturesCommand command,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(command, cancellationToken);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ManufactureFullViewModel>> GetManufactureById(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetManufactureByIdCommand(id), cancellationToken);
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<ActionResult<Guid>> Create(
        [FromForm] ManufactureFullBindingModel model,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new CreateManufactureCommand(model), cancellationToken);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Update(
        [FromRoute] Guid id,
        [FromForm] ManufactureFullBindingModel model,
        CancellationToken cancellationToken = default)
    {
        await mediator.Send(new UpdateManufactureCommand(id, model), cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Delete(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        await mediator.Send(new DeleteManufactureCommand(id), cancellationToken);
        return NoContent();
    }
}
