using Microsoft.EntityFrameworkCore;
using Mint.Domain.BindingModels;
using Mint.Domain.FormingModels;
using Mint.Domain.ViewModels;
using Mint.Infrastructure.Repositories.Interfaces;

namespace Mint.Infrastructure.Repositories;

public class ManufactureRepository : IManufactureRepository
{
    private readonly ApplicationDbContext _context;

    public ManufactureRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ManufactureViewModel>> GetManufacturesAsync()
    {
        try
        {
            var manufactures = await _context.Manufactures
                .Include(x => x.Photo)
                .Include(x => x.Categories)
                .ToListAsync();
            return new ManufactureManager().FormingViewModels(manufactures);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<ManufactureViewModel> GetManufactureByIdAsync(Guid id)
    {
        try
        {
            var manufacture = await _context.Manufactures
                .Include(x => x.Photo)
                .FirstOrDefaultAsync(x => x.Id == id) 
                ?? throw new Exception("Производитель не существует.");
            return new ManufactureManager().FormingSingleViewModel(manufacture);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task AddManufactureAsync(ManufactureBindingModel model)
    {
        try
        {
            var manufacture = await new ManufactureManager().FormingBindingModel(model);
            await _context.Manufactures.AddAsync(manufacture);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task UpdateManufactureAsync(ManufactureBindingModel model)
    {
        try
        {
            var manufacture = await _context.Manufactures
                .Include(x => x.Photo)
                .FirstOrDefaultAsync(x => x.Id == model.Id)
                ?? throw new Exception("Производитель не существует.");
            string? filePath = manufacture.Photo?.FilePath;

            manufacture.Name = model.Name ?? manufacture.Name;
            manufacture.DisplayOrder = model.DisplayOrder != 0 ? model.DisplayOrder : manufacture.DisplayOrder;
            manufacture.Description = model.Description ?? manufacture.Name;
            
            if (model.Folder != null && model.Photo != null)
                manufacture.Photo = await PhotoManager.CopyPhotoAsync(model.Photo, manufacture.Id, model.Folder);

            _context.Update(manufacture);
            await _context.SaveChangesAsync();

            if (model.Folder != null && model.Photo != null)
                PhotoManager.DeletePhoto(filePath);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task DeleteManufactureAsync(Guid id)
    {
        try
        {
            var manufacture = await _context.Manufactures
                .Include(x => x.Photo)
                .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new Exception("Производитель не существует.");

            if (manufacture.Photo != null)
                _context.Photos.Remove(manufacture.Photo);
            _context.Manufactures.Remove(manufacture);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
