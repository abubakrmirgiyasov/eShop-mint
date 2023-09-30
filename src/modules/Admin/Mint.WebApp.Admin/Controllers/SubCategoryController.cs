using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mint.Domain.Attributes;
using Mint.Domain.Common;
using Mint.Infrastructure.MessageBrokers.Models;
using Mint.WebApp.Admin.DTO_s.Categories;
using Mint.WebApp.Admin.Repositories.Interfaces;

namespace Mint.WebApp.Admin.Controllers;

[ApiController]
[Authorize(Roles = "ADMIN")]
[Route("api/[controller]/[action]")]
public class SubCategoryController : ControllerBase
{
    private readonly ISubCategoryRepository _subCategory;

    public SubCategoryController(ISubCategoryRepository subCategory)
    {
        _subCategory = subCategory;
    }

    [HttpGet]
    public async Task<IActionResult> GetSampleSubCategories()
    {
        try
        {
            var subCategories = await _subCategory.GetSampleSubCategoriesAsync();
            return Ok(subCategories);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    [HttpPost]
    public async Task<IActionResult> NewSubCategory([FromBody] SubCategoryFullBindingModel model)
    {
        try
        {
            await _subCategory.CreateAsync(model);
            return Ok(new { message = "success" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
