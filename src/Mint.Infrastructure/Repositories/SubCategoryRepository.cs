using Microsoft.EntityFrameworkCore;
using Mint.Domain.BindingModels;
using Mint.Domain.FormingModels;
using Mint.Domain.ViewModels;
using Mint.Infrastructure.Repositories.Interfaces;

namespace Mint.Infrastructure.Repositories;

public class SubCategoryRepository : ISubCategoryRepository
{
    private readonly ApplicationDbContext _context;

    public SubCategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<SubCategoryFullViewModel>> GetSubCategoriesAsync()
    {
        try
        {
            var subCategories = await _context.SubCategories.ToListAsync();
            return new SubCategoryManager().FormingViewModels(subCategories);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<List<SubCategoryOnlylViewModel>> GetSubCategoriesOnlyAsync()
    {
        try
        {
            var subCategories = await _context.SubCategories.ToListAsync();
            return new SubCategoryManager().FormingOnlyViewModels(subCategories);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<SubCategoryFullViewModel> GetSubCategoryByIdAsync(Guid id)
    {
        try
        {
            var subCagory = await _context.SubCategories
                .FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Не существует.");
            return new SubCategoryManager().FormingSingleViewModel(subCagory);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<SubCategoryFullViewModel> AddSubCategoryAsync(SubCategoryBindingModel model)
    {
        try
        {
            var subCategory = new SubCategoryManager().FormingBindingModel(model);
            await _context.SubCategories.AddAsync(subCategory);
            await _context.SaveChangesAsync();
            return new SubCategoryManager().FormingSingleViewModel(subCategory);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task UpdateSubCategoryAsync(SubCategoryBindingModel model)
    {
        try
        {
            var subCategory = await _context.SubCategories
                .FirstOrDefaultAsync(x => x.Id == Guid.Parse(model.Id!))
                ?? throw new Exception("Не существует.");

            subCategory.Name = model.Name!;
            subCategory.DisplayOrder = model.DisplayOrder == 0 ? subCategory.DisplayOrder : model.DisplayOrder;
            subCategory.Ico = model.Ico ?? subCategory.Ico;
            
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task DeleteSubCategoryAsync(Guid id)
    {
        try
        {
            var subCategory = await _context.SubCategories
                .FirstOrDefaultAsync(x => x.Id == id) ?? throw new Exception("Не существует.");
            _context.SubCategories.Remove(subCategory);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
