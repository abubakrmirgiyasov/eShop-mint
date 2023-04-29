using Microsoft.EntityFrameworkCore;
using Mint.Domain.FormingModels;
using Mint.Domain.ViewModels;
using Mint.Infrastructure.Repositories.Interfaces;

namespace Mint.Infrastructure.Repositories;

public class CommonRepository : ICommonRepository
{
    private readonly ApplicationDbContext _context;

    public CommonRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<MenuParentViewModel>> GetMenuAsync()
    {
        try
        {
            var menus = await _context.SubCategories
                .Include(x => x.Categories!)
                .ThenInclude(x => x.Photo!)
                .Include(x => x.Categories!.OrderBy(x => x.DisplayOrder))
                .ThenInclude(x => x.Manufacture)
                .ThenInclude(x => x!.Photo)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();
            return new MenuManager().FormingModel(menus);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
