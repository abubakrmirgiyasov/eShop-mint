﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mint.WebApp.Admin.Commands.Categories;
using Mint.WebApp.Admin.Commands.Dtos.Categories;
using Mint.WebApp.Admin.DTO_s.Categories;

namespace Mint.WebApp.Admin.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(IMediator mediator) : ControllerBase
{
    //private readonly CategoryService _service;

    //public CategoriesController(CategoryService service)
    //{
    //    _service = service;
    //}

    //[HttpGet]
    //public async Task<IActionResult> GetCategories()
    //{
    //    try
    //    {
    //        return Ok();
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(new { message = ex.Message });
    //    }
    //}

    //[HttpGet]
    //public async Task<IActionResult> GetSampleCategories()
    //{
    //    try
    //    {
    //        //var categories = await _service.GetCategorySamplesAsync();
    //        return Ok(); //categories
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(new { message = ex.Message });
    //    }
    //}

    [HttpGet("links")]
    //[Authorize(Roles = "ADMIN")]
    public async Task<ActionResult<IEnumerable<DefaultLinkDto>>> GetCategoriesDefaultLinks(
        [FromQuery] string? search,
        CancellationToken cancellationToken = default)
    {
        var links = await mediator.Send(new GetCategoriesDefaultLinksCommand(search), cancellationToken);
        return Ok(links);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(Guid id)
    {
        try
        {
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> NewCategory([FromForm] CategoryFullBindingModel model)
    {
        try
        {
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> UpdateCategory([FromBody] CategoryFullBindingModel model)
    {
        try
        {
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        try
        {
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
