using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mint.Infrastructure.Attributes;
using Mint.WebApp.Admin.Application.Operations.Dtos.Discounts;
using Mint.WebApp.Admin.Application.Operations.Queries.Discounts;

namespace Mint.WebApp.Admin.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DiscountsController(IMediator mediator) : ControllerBase
{
    [HttpGet("user")]
    [Authorize(Roles = "admin,seller")]
    public async Task<ActionResult<List<SimpleDiscountViewModel>>> 
        GetDiscountsByUserId(CancellationToken cancellationToken = default)
    {
        var userId = User.FindFirst("id");

        if (userId is null)
            return Unauthorized();

        return await mediator.Send(new GetDiscountsByUserIdQuery(Guid.Parse(userId.Value)), cancellationToken);
    }
}
