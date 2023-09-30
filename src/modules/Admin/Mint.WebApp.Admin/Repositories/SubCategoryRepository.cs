using Microsoft.EntityFrameworkCore;
using Mint.Domain.Models.Admin.Categories;
using Mint.Infrastructure;
using Mint.WebApp.Admin.DTO_s.Categories;
using Mint.WebApp.Admin.FormingModels.Categories;
using Mint.WebApp.Admin.Repositories.Interfaces;
using System.Data;

namespace Mint.WebApp.Admin.Repositories;

public class SubCategoryRepository : ISubCategoryRepository
{
    private readonly ApplicationDbContext _context;

    public SubCategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SubCategoryFullViewModel>> GetSubCategoriesAsync()
    {
        try
        {
            var subcategories = await _context.SubCategories.ToListAsync();
            var extractedList = SubCategoryFormingModel.FormingFullViewModels(subcategories);
            return extractedList;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<IEnumerable<SubCategorySampleViewModel>> GetSampleSubCategoriesAsync()
    {
        try
        {
            var subCategories = await _context.SubCategories.ToListAsync();
            var extractedList = SubCategoryFormingModel.FormingSampleModels(subCategories);
            return extractedList;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public Task<SubCategoryFullViewModel> GetSubCategoryByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task CreateAsync(SubCategoryFullBindingModel model)
    {
        try
        {
            var extractedModel = SubCategoryFormingModel.FormingSingleBindingModel(model);
            await _context.SubCategories.AddAsync(extractedModel);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public Task UpdateAsync(SubCategoryFullBindingModel model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
