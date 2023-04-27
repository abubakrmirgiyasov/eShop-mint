using Microsoft.AspNetCore.Mvc;
using Mint.Domain.BindingModels;
using Mint.Infrastructure.Repositories.Interfaces;

namespace Mint.WebApp.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _category;

    public CategoryController(ICategoryRepository category)
    {
        _category = category;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        try
        {
            var categories = await _category.GetCategoriesAsync();
            return Ok(categories);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
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
    public async Task<IActionResult> AddCategory([FromForm] CategoryFullBindingModel model)
    {
        try
        {
            var category = await _category.AddCategoryAsync(model);
            return Ok(category);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategory([FromForm] CategoryFullBindingModel model)
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
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        try
        {
            await _category.DeleteCategoryAsync(id);
            return Ok(new { message = "Успешно." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
