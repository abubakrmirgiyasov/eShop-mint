//using Microsoft.AspNetCore.Mvc;
//using Mint.Domain.BindingModels;
//using Mint.Domain.Common;
//using Mint.Infrastructure.Repositories.Interfaces;
//using Mint.WebApp.Attributes;

//namespace Mint.WebApp.Controllers;

//[Authorize]
//[ApiController]
//[Route("[controller]/[action]")]
//public class ReviewController : ControllerBase
//{
//    private readonly IReviewRepository _review;

//    public ReviewController(IReviewRepository review)
//    {
//        _review = review;
//    }

//    [HttpGet]
//    [Authorize(Roles = Constants.ADMIN)]
//    public async Task<IActionResult> GetReviews()
//    {
//        try
//        {
//            var reviews = await _review.GetReviewsAsync();
//            return Ok(reviews);
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(new { message = ex.Message });
//        }
//    }

//    [HttpGet("{id}")]
//    [AllowAnonymous]
//    public async Task<IActionResult> GetProductReviewsById(Guid id)
//    {
//        try
//        {
//            var reviews = await _review.GetProductReviewsByIdAsync(id);
//            return Ok(reviews);
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(new { message = ex.Message });
//        }
//    }

//    [HttpPost]
//    public async Task<IActionResult> NewReview([FromForm] ReviewBindingModel model)
//    {
//        try
//        {
//            model.Files = Request.Form.Files;

//            var reviews = await _review.NewReviewAsync(model);
//            return Ok(reviews);
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(new { message = ex.Message });
//        }
//    }

//    [HttpPut]
//    public async Task<IActionResult> UpdateReview([FromForm] ReviewBindingModel model)
//    {
//        try
//        {
//            var reviews = await _review.UpdateReviewAsync(model);
//            return Ok(reviews);
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(new { message = ex.Message });
//        }
//    }

//    [HttpDelete("{id}")]
//    public async Task<IActionResult> DeleteReview(Guid id)
//    {
//        try
//        {
//            await _review.DeleteReviewAsync(id);
//            return Ok(new { message = "Удалено успешно." });
//        }
//        catch (Exception ex)
//        {
//            return BadRequest(new { message = ex.Message });
//        }
//    }
//}
