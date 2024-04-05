using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mint.Infrastructure.Attributes;
using Mint.WebApp.Admin.Application.Operations.Dtos.Stores;
using Mint.WebApp.Admin.Application.Operations.Queries.Stores;

namespace Mint.WebApp.Admin.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "admin,seller")]
public class StoresController(IMediator mediator) : ControllerBase
{
    [HttpGet("{userId:guid}/userStores")]
    public async Task<ActionResult<List<SimpleStoreViewModel>>> GetMyStores(
        Guid userId,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetSimpleStoreQuery(userId), cancellationToken);
    }
}
