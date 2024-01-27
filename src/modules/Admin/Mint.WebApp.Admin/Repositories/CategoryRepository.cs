using Microsoft.EntityFrameworkCore;
using Mint.Domain.Exceptions;
using Mint.Domain.Models.Admin.Categories;
using Mint.Infrastructure.Repositories.Admin.Interfaces;
using Mint.WebApp.Admin.DTO_s.Categories;
using Mint.WebApp.Admin.FormingModels.Categories;

namespace Mint.Infrastructure.Repositories.Admin;

/// <inheritdoc cref="ICategoryRepository"/>
public class CategoryRepository(ApplicationDbContext context) : ICategoryRepository
{
    private readonly ApplicationDbContext _context = context;

    public ApplicationDbContext Context => _context;

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

    public async Task<IEnumerable<Category>> GetCategoriesLinkAsync(string? search = default, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrEmpty(search))
            return await _context.Categories.ToListAsync(cancellationToken);

        var categories = await _context.Categories
            .Where(x => x.DefaultLink!.Contains(search))
            .ToListAsync(cancellationToken);
        return categories;
    }

    public async Task<Category> FindByIdAsync(Guid id, CancellationToken cancellation = default)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id, cancellation)
            ?? throw new NotFoundException("Категория не найдена");

        return category;
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
