using Amazon.Runtime.Internal.Endpoints.StandardLibrary;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Mint.Domain.Attributes;
using Mint.Infrastructure.Redis;
using Mint.Infrastructure.Redis.Interface;
using Mint.WebApp.Admin.DTO_s;
using Mint.WebApp.Admin.Repositories.Interfaces;
using StackExchange.Redis;

namespace Mint.WebApp.Admin.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class TagController : ControllerBase
{
    private readonly ITagRepository _tag;
    private readonly IDistributedCacheManager _redis;

    public TagController(ITagRepository tag, IDistributedCacheManager redis)
    {
        _tag = tag;
        _redis = redis;
    }

    [HttpGet]
    public IActionResult TestRedis()
    {
        var rr = _redis.Get<string>("test");
        return Ok(rr);
    }

    [HttpPost]
    public IActionResult TestRedis(string test)
    {
        _redis.Set("test", test);
        return Ok();
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
            await _tag.NewTagAsync(model);
            return Ok(new { message = "Added successfully" });
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
            return Ok(new { message = "Updated successfully" });
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
            return Ok(new { message = "Deleted successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
