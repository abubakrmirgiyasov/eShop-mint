using Microsoft.EntityFrameworkCore;
using Mint.Domain.Models.Admin;
using Mint.Infrastructure;
using Mint.WebApp.Admin.DTO_s;
using Mint.WebApp.Admin.FormingModels;
using Mint.WebApp.Admin.Repositories.Interfaces;

namespace Mint.WebApp.Admin.Repositories;

public class TagRepository : ITagRepository
{
    private readonly ApplicationDbContext _context;

    public TagRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TagFullViewModel>> GetTagsAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var tags = await _context.Tags.ToListAsync(cancellationToken);
            return TagDTOConverter.FormingMultiViewModels(tags);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task<TagFullViewModel> GetTagByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
                ?? throw new ArgumentNullException(nameof(Tag), "Атрибут не найден");
            return TagDTOConverter.FormingSingleViewModel(tag);
        }
        catch (ArgumentNullException ex)
        {
            throw new ArgumentNullException(ex.Message, ex);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task NewTagAsync(TagFullBindingModel model, CancellationToken cancellationToken = default)
    {
        try
        {
            var tag = TagDTOConverter.FormingSingleBindingModel(model);

            await _context.Tags.AddAsync(tag, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task UpdateTagAsync(TagFullBindingModel model, CancellationToken cancellationToken = default)
    {
        try
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == model.Value, cancellationToken)
                ?? throw new ArgumentNullException(nameof(Tag), "Атрибут не найден");

            tag.Name = model.Label!;
            tag.Translate = model.Translate;
            tag.UpdateDateTime = DateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (ArgumentNullException ex)
        {
            throw new ArgumentNullException(ex.Message, ex);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    public async Task DeleteTagAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
                ?? throw new ArgumentNullException(nameof(Tag), "Атрибут не найден");

            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (ArgumentNullException ex)
        {
            throw new ArgumentNullException(ex.Message, ex);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
