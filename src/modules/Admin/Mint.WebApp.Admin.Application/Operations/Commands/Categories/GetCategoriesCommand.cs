using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mint.Domain.Helpers;
using Mint.Infrastructure.Repositories.Admin;
using Mint.WebApp.Admin.Application.Common.Messaging;
using Mint.WebApp.Admin.Application.Operations.Dtos.Categories;

namespace Mint.WebApp.Admin.Application.Operations.Commands.Categories;

public sealed record GetCategoriesCommand(
    string? Search,
    int PageIndex = 0,
    int PageSize = 50
) : ICommand<PaginatedResult<CategoryFullViewModel>>;

internal sealed class GetCategoriesCommandHandler(
    ICategoryRepository categoryRepository,
    IMapper mapper
) : ICommandHandler<GetCategoriesCommand, PaginatedResult<CategoryFullViewModel>>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<PaginatedResult<CategoryFullViewModel>> Handle(GetCategoriesCommand request, CancellationToken cancellationToken)
    {
        var query = _categoryRepository.Context.Categories.AsQueryable();

        if (!string.IsNullOrEmpty(request.Search))
            query = query.Where(x => x.Name.Contains(request.Search));

        var categories = await query
            .AsNoTracking()
            .Skip(request.PageSize * request.PageIndex)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        var totalCount = await _categoryRepository
            .Context
            .Categories
            .AsNoTracking()
            .CountAsync(cancellationToken);

        return new PaginatedResult<CategoryFullViewModel>
        {
            Items = _mapper.Map<List<CategoryFullViewModel>>(categories),
            TotalCount = totalCount,
        };
    }
}