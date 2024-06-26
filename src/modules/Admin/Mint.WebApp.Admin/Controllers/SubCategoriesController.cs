﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Helpers;
using Mint.Infrastructure.Attributes;
using Mint.WebApp.Admin.Application.Operations.Commands.SubCategories;
using Mint.WebApp.Admin.Application.Operations.Dtos.SubCategories;
using Mint.WebApp.Admin.Application.Operations.Queries.SubCategories;

namespace Mint.WebApp.Admin.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubCategoriesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedResult<SubCategoryInfoViewModel>>> Get(
        [FromQuery] GetSubCategoriesQuery command,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(command, cancellationToken);
    }

    [HttpGet("{id:guid}/info")]
    [Authorize(Roles = "admin")]
    public async Task<ActionResult<SubCategoryInfoViewModel>> GetSubCategoryInfoById(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetSubCategoryInfoQuery(id), cancellationToken);
    }

    [HttpGet("links")]
    [Authorize(Roles = "admin")]
    public async Task<ActionResult<List<string>>> GetSubCategoriesDefaultLinks(
        [FromQuery] string? search,
        CancellationToken cancellationToken = default)
    {
        var links = await mediator.Send(new GetSubCategoriesDefaultLinksQuery(search), cancellationToken);
        return Ok(links);
    }

    [HttpGet("simple")]
    [Authorize(Roles = "admin")]
    public async Task<ActionResult<List<SubCategorySimpleViewModel>>> GetSimpleSubCategories(
        [FromQuery] string? search,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetSimpleSubCategoriesQuery(search), cancellationToken);
    }

    [HttpPost]
    [Authorize(Roles = "admin")]
    public async Task<ActionResult<SubCategoryInfoViewModel>> Create(
        [FromBody] SubCategoryInfoBindingModel subCategory,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new CreateSubCategoryCommand(subCategory), cancellationToken);
    }
}
