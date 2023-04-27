using Microsoft.AspNetCore.Mvc;
using Mint.Domain.BindingModels;
using Mint.Domain.Common;
using Mint.Infrastructure.Repositories.Interfaces;
using Mint.WebApp.Attributes;

namespace Mint.WebApp.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class SubCategoryController : ControllerBase
{
    private readonly ISubCategoryRepository _subCategory;

    public SubCategoryController(ISubCategoryRepository subCategory)
    {
        _subCategory = subCategory;
    }

    [HttpGet]
    public async Task<IActionResult> GetSubCategories()
    {
        try
        {
            var subCategories = await _subCategory.GetSubCategoriesAsync();
            return Ok(subCategories);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetSubCategoriesOnly()
    {
        try
        {
            var subCategoriesModel = await _subCategory.GetSubCategoriesOnlyAsync();
            return Ok(subCategoriesModel);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSubCategoryById(Guid id)
    {
        try
        {
            var subCategory = await _subCategory.GetSubCategoryByIdAsync(id);
            return Ok(subCategory);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost]
    [Authorize(Roles = Constants.ADMIN)]
    public async Task<IActionResult> AddSubCategory([FromBody] SubCategoryBindingModel model)
    {
        try
        {
            var subCateory = await _subCategory.AddSubCategoryAsync(model);
            return Ok(subCateory);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut]
    [Authorize(Roles = Constants.ADMIN)]
    public async Task<IActionResult> UpdateSubCategory([FromBody] SubCategoryBindingModel model)
    {
        try
        {
            await _subCategory.UpdateSubCategoryAsync(model);
            return Ok(new { message = "Успешно." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = Constants.ADMIN)]
    public async Task<IActionResult> DeleteSubCategory(Guid id)
    {
        try
        {
            await _subCategory.DeleteSubCategoryAsync(id);
            return Ok(new { message = "Успешно." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { ex.Message });
        }
    }
}
