using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Common;
using Mint.Domain.Helpers;
using Mint.Infrastructure.Attributes;
using Mint.WebApp.Admin.Application.Operations.Dtos.Products.ProductReviews;
using Mint.WebApp.Admin.Application.Operations.Queries.Products.ProductReviews;
using System.ComponentModel.DataAnnotations;

namespace Mint.WebApp.Admin.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "admin,seller")]
public class ProductReviewsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResult<ProductReviewViewModel>>> GetProductReviews(
        [FromQuery] [Required] DateOnly from,
        [FromQuery] [Required] DateOnly to,
        [FromQuery] string? searchPhrase,
        [FromQuery] string? sortBy,
        [FromQuery] SortDirection? sortDir,
        [FromQuery] int[] rating,
        [FromQuery] bool onlyPluses,
        [FromQuery] bool onlyMinuses,
        [FromQuery] int pageIndex,
        [FromQuery] int pageSize,
        CancellationToken cancellationToken = default)
    {
        var sellerId = User.FindFirst("id");

        if (sellerId is null)
            return Unauthorized();

        return await mediator.Send(
            new GetProductReviewsQuery(
                From: from,
                To: to,
                SellerId: Guid.Parse(sellerId.Value),
                SearchPhrase: searchPhrase,
                SortBy: sortBy,
                SortDir: sortDir,
                Rating: rating,
                OnlyPluses: onlyPluses,
                OnlyMinuses: onlyMinuses,
                PageIndex: pageIndex,
                PageSize: pageSize
            ), cancellationToken
        );
    }
}
