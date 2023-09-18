using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Attributes;
using Mint.Domain.Common;
using Mint.WebApp.Admin.DTO_s.Categories;

namespace Mint.WebApp.Admin.Controllers;

[ApiController]
[Authorize(Roles = "ADMIN")]
[Route("api/[controller]/[action]")]
public class SubCategoryController : ControllerBase
{
    public SubCategoryController()
    {
        
    }

    [HttpPost]
    public async Task<IActionResult> NewSubCategory([FromBody] SubCategoryFullBindingModel model)
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
