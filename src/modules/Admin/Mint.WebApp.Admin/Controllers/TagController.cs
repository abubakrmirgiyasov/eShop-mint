using MediatR;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Helpers;
using Mint.WebApp.Admin.Operations.Commands;
using Mint.WebApp.Admin.Operations.Dtos;

namespace Mint.WebApp.Admin.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class TagController(IMediator mediator) : ControllerBase
{
    [HttpGet("index={pageIndex}&size={pageSize}")]
    [ProducesDefaultResponseType]
    [ProducesResponseType(200)]
    public async Task<ActionResult<PaginatedResult<TagFullViewModel>>> GetTags(
        int pageIndex,
        int pageSize,
        CancellationToken cancellationToken = default)
    {
        var tags = await mediator.Send(new GetTagsCommand(pageIndex, pageSize), cancellationToken);
        return tags;
    }

    //[HttpGet("{id}")]
    //public async Task<IActionResult> GetTagById(Guid id)
    //{
    //    try
    //    {
    //        var tag = await _tag.GetTagByIdAsync(id);
    //        return Ok(tag);
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(new { message = ex.Message });
    //    }
    //}

    //[HttpPost]
    //[Authorize(Roles = "ADMIN")]
    //public async Task<IActionResult> NewTag([FromBody] TagFullBindingModel model)
    //{
    //    try
    //    {
    //        await _tag.AddNewTagAsync(model);
    //        return Ok(new { message = "Created success." });
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(new { message = ex.Message });
    //    }
    //}

    //[HttpPut]
    //[Authorize(Roles = "ADMIN")]
    //public async Task<IActionResult> UpdateTag([FromBody] TagFullBindingModel model)
    //{
    //    try
    //    {
    //        await _tag.UpdateTagAsync(model);
    //        return Ok(new { message = "Updated success." });
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(new { message = ex.Message });
    //    }
    //}

    //[HttpDelete("{id}")]
    //[Authorize(Roles = "ADMIN")]
    //public async Task<IActionResult> DeleteTag(Guid id)
    //{
    //    try
    //    {
    //        await _tag.DeleteTagAsync(id);
    //        return Ok(new { message = "Deleted success." });
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(new { message = ex.Message });
    //    }
    //}
}
