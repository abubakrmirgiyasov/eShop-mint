using Microsoft.EntityFrameworkCore;
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

    public Task<TagFullViewModel> GetTagByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task NewTagAsync(TagFullBindingModel model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateTagAsync(TagFullBindingModel model, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteTagAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
