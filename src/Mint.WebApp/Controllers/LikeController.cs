//using Microsoft.AspNetCore.Mvc;
//using Mint.Domain.BindingModels;
//using Mint.Infrastructure.Repositories.Interfaces;
//using Mint.WebApp.Attributes;

//namespace Mint.WebApp.Controllers;

//[Authorize]
//[ApiController]
//[Route("[controller]/[action]")]
//public class LikeController : ControllerBase
//{
//    private readonly ICommonRepository _common;

//    public LikeController(ICommonRepository common)
//    {
//        _common = common;
//    }

//    [HttpGet("{id}")]
//    public async Task<IActionResult> GetMyLikes(Guid id)
//    {
//        try
//        {
//            var likes = await _common.GetMyLikesAsync(id);
//            return Ok(likes);
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(new { message = ex.Message });
//        }
//    }

//    [HttpPost]
//    public async Task<IActionResult> NewLike([FromBody] LikeBindingModel model)
//    {
//        try
//        {
//            var likes = await _common.NewLikeAsync(model);
//            return Ok(likes);
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(new { message = ex.Message });
//        }
//    }

//    [HttpDelete]
//    public async Task<IActionResult> RemoveLike([FromBody] LikeBindingModel model)
//    {
//        try
//        {
//            await _common.RemoveLike(model);
//            return Ok(new { message = "Удалено, успешно!" });
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(new { message = ex.Message });
//        }
//    }
//}
