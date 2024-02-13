using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mint.Domain.Models.Admin;
using Mint.Infrastructure;
using Mint.WebApp.Admin.Operations.Dtos;
using Mint.WebApp.Admin.Repositories.Interfaces;

namespace Mint.WebApp.Admin.Repositories;

/// <inheritdoc cref="ITagRepository"/>
public class TagRepository(ApplicationDbContext context, IMapper mapper) : ITagRepository
{
    private readonly ApplicationDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    /// <inheritdoc />
    public async Task<IEnumerable<TagFullViewModel>> GetTagsAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var tags = await _context.Tags
                .ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<TagFullViewModel>>(tags);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    /// <inheritdoc />
    public async Task<IEnumerable<TagFullViewModel>> GetTagsAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default)
    {
        try
        {
            var tags = await _context.Tags
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
            return _mapper.Map<IEnumerable<TagFullViewModel>>(tags);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    /// <inheritdoc />
    public async Task<TagFullViewModel> GetTagByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
                ?? throw new ArgumentNullException(nameof(id), "Атрибут не найден");
            return _mapper.Map<TagFullViewModel>(tag);
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

    /// <inheritdoc />
    public async Task NewTagAsync(TagFullBindingModel model, CancellationToken cancellationToken = default)
    {
        try
        {
            var tag = _mapper.Map<Tag>(model);

            await _context.Tags.AddAsync(tag, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    /// <inheritdoc />
    public async Task UpdateTagAsync(TagFullBindingModel model, CancellationToken cancellationToken = default)
    {
        try
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == model.Value, cancellationToken)
                ?? throw new ArgumentNullException(nameof(model), "Атрибут не найден");

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

    /// <inheritdoc />
    public async Task DeleteTagAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var tag = await _context.Tags.FirstOrDefaultAsync(x => x.Id == id, cancellationToken)
                ?? throw new ArgumentNullException(nameof(id), "Атрибут не найден");

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
