using Microsoft.EntityFrameworkCore;
using Mint.Domain.Models.Admin.Categories;
using Mint.Infrastructure.Repositories.Admin.Interfaces;
using Mint.WebApp.Admin.DTO_s.Categories;
using Mint.WebApp.Admin.FormingModels.Categories;

namespace Mint.Infrastructure.Repositories.Admin;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<IEnumerable<CategoryFullViewModel>> GetCategoriesAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CategorySampleViewModel>> GetSampleCategoriesAsync()
    {
        try
        {
            var categories = await _context.Categories.ToListAsync();
            var extractedModels = CategoryFormingModel.FormingSampleViewModels(categories);
            return extractedModels;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<CategoryFullViewModel> GetCategoryByIdAsync(Guid id)
    {
        try
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new ArgumentNullException(nameof(Category), "Категория не найдена");

            return new CategoryFullViewModel();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public Task NewCategoryAsync(CategoryFullBindingModel model)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCategoryAsync(CategoryFullBindingModel model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCategoryAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
