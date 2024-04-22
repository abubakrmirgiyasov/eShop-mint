using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mint.WebApp.Client.Application.Operations.Dtos.Categories;
using Mint.WebApp.Client.Application.Operations.Queries.Categories;

namespace Mint.WebApp.Client.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CatalogsController(IMediator mediator) : ControllerBase
{
    [HttpGet("menu")]
    public async Task<ActionResult<List<Catalog>>> GetMenu(CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetCatalogsQuery(), cancellationToken);
    }
}
