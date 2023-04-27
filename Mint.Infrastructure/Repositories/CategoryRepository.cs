using Microsoft.EntityFrameworkCore;
using Mint.Domain.BindingModels;
using Mint.Domain.FormingModels;
using Mint.Domain.Models;
using Mint.Domain.ViewModels;
using Mint.Infrastructure.Repositories.Interfaces;

namespace Mint.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<CategoryViewModel>> GetCategoriesAsync()
    {
        try
        {
            var categories = await _context.Categories
                .Include(x => x.Manufacture)
                .Include(x => x.Photo)
                .Include(x => x.SubCategory)
                .ToListAsync();
            return new CategoryManager().FormingViewModels(categories);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<CategoryViewModel> GetCategoryById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<CategoryViewModel> AddCategoryAsync(CategoryFullBindingModel model)
    {
        try
        {
            var manager = new CategoryManager();

            var category = manager.FormingBindingModel(model);

            if (Guid.TryParse(model.SubCategoryId, out Guid subCategoryId))
            {
                var subcategory = _context.SubCategories
                    .FirstOrDefaultAsync(x => x.Id == subCategoryId)
                    ?? throw new Exception("Не существует.");

                category.SubCategoryId = subCategoryId;
                category.Name = model.Name!;
            }
            else
            {
                category.SubCategory = new SubCategory()
                {
                    Id = Guid.NewGuid(),
                    DisplayOrder = 0,
                    Ico = null,
                    Name = model.Name!,
                };
            }

            if (model.FileType != null && model.Photo != null)
                category.Photo = await PhotoManager.CopyPhotoAsync(model.Photo, category.Id, model.FileType);

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return manager.FormingModel(category);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task UpdateCategoryAsync(CategoryFullBindingModel model)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteCategoryAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
