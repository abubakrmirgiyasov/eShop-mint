using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Attributes;
using Mint.WebApp.Admin.DTO_s;
using Mint.WebApp.Admin.Services;

namespace Mint.WebApp.Admin.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class TagController : ControllerBase
{
    private readonly TagService _tag;

    public TagController(TagService tag)
    {
        _tag = tag;
    }

    [HttpGet]
    public async Task<IActionResult> GetTags()
    {
        try
        {
            var tags = await _tag.GetTagsAsync();
            return Ok(tags);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTagById(Guid id)
    {
        try
        {
            var tag = await _tag.GetTagByIdAsync(id);
            return Ok(tag);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> NewTag([FromBody] TagFullBindingModel model)
    {
        try
        {
            await _tag.AddNewTagAsync(model);
            return Ok(new { message = "Created success." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> UpdateTag([FromBody] TagFullBindingModel model)
    {
        try
        {
            await _tag.UpdateTagAsync(model);
            return Ok(new { message = "Updated success." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "ADMIN")]
    public async Task<IActionResult> DeleteTag(Guid id)
    {
        try
        {
            await _tag.DeleteTagAsync(id);
            return Ok(new { message = "Deleted success." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
