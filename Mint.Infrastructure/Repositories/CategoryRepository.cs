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

    public async Task<List<CategoryFullViewModel>> GetCategoriesAsync()
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

    public async Task<CategoryFullViewModel> GetCategoryById(Guid id)
    {
        try
        {
            var category = await _context.Categories
                .Include(x => x.SubCategory)
                .Include(x => x.Manufacture)
                .Include(x => x.Photo)
                .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new Exception("Не существует.");
            return new CategoryManager().FormingModel(category);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<List<CategoryOnlyViewModel>> GetCategoriesOnlyAsync()
    {
        try
        {
            var categories = await _context.Categories.ToListAsync();
            return new CategoryManager().FormingOnlyViewModels(categories);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<CategoryFullViewModel> AddCategoryAsync(CategoryFullBindingModel model)
    {
        try
        {
            var manager = new CategoryManager();

            var category = manager.FormingBindingModel(model);

            if (Guid.TryParse(model.SubCategoryId, out Guid subCategoryId))
            {
                var subcategory = await _context.SubCategories
                    .FirstOrDefaultAsync(x => x.Id == subCategoryId)
                    ?? throw new Exception("Не существует.");

                category.Name = model.Name!;
                subcategory.BadgeText = model.BadgeText ?? subcategory.BadgeText;
                subcategory.BadgeStyle = model.BadgeStyle ?? subcategory.BadgeStyle;

                if (model.FileType != null && model.Photo != null)
                    category.Photo = await PhotoManager.CopyPhotoAsync(model.Photo, category.Id, model.FileType);

                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
            }
            else
            {
                var subCategory = new SubCategory()
                {
                    DisplayOrder = model.DisplayOrder,
                    Name = model.Name!,
                };

                await _context.SubCategories.AddAsync(subCategory);
                await _context.SaveChangesAsync();
            }

            return manager.FormingModel(category);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task UpdateCategoryAsync(CategoryFullBindingModel model)
    {
        try
        {

            var category = await _context.Categories
                .Include(x => x.SubCategory)
                .Include(x => x.Photo)
                .FirstOrDefaultAsync(x => x.Id == Guid.Parse(model.Id!))
                ?? throw new Exception("Не существует.");

            string? filePath = category.Photo?.FilePath;

            category.Name = model.Name!;
            category.FullName = model.FullName ?? category.FullName;
            category.DefaultLink = model.DefaultLink ?? category.DefaultLink;
            category.DisplayOrder = model.DisplayOrder == 0 ? category.DisplayOrder : model.DisplayOrder;
            category.SubCategoryId = Guid.TryParse(model.SubCategoryId, out Guid id) ? id : category.SubCategoryId;

            if (category.SubCategory != null)
            {
                category.SubCategory.BadgeText = model.BadgeText ?? category.SubCategory?.BadgeText;
                category.SubCategory!.BadgeStyle = model.BadgeStyle ?? category.SubCategory?.BadgeStyle;
            }

            if (model.Photo != null && model.FileType != null)
                category.Photo = await PhotoManager.CopyPhotoAsync(model.Photo, category.Id, model.FileType);

            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

            if (model.FileType != null && model.Photo != null)
                PhotoManager.DeletePhoto(filePath);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task DeleteCategoryAsync(Guid id)
    {
        try
        {
            var category = await _context.Categories
                .Include(x => x.Photo)
                .Include(x => x.SubCategory)
                .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new Exception("Не существует.");

            if (category.SubCategory != null)
                _context.SubCategories.Remove(category.SubCategory);
    
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            if (category.Photo != null)
                PhotoManager.DeletePhoto(category.Photo.FilePath);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
