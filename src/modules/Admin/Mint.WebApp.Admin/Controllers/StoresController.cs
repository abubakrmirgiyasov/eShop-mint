using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mint.WebApp.Admin.Application.Operations.Dtos.Stores;
using Mint.WebApp.Admin.Application.Operations.Queries.Stores;

namespace Mint.WebApp.Admin.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StoresController(IMediator mediator) : ControllerBase
{
    [HttpGet("userStore/{userId:guid}")]
    public async Task<ActionResult<List<SimpleStoreViewModel>>> GetMyStores(
        Guid userId,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetSimpleStoreQuery(userId), cancellationToken);
    }
}
