using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mint.Domain.Helpers;
using Mint.Infrastructure.MessageBrokers.Interfaces;
using Mint.WebApp.Admin.Operations.Dtos.SubCategories;
using Mint.WebApp.Admin.Repositories.Interfaces;

namespace Mint.WebApp.Admin.Operations.Commands.SubCategories;

public sealed record GetSubCategoriesCommand(
    string? Search,
    int PageIndex = 0,
    int PageSize = 50
) : ICommand<PaginatedResult<SubCategoryFullViewModel>>;

internal sealed class GetSubCategoriesCommandHandler(
    ISubCategoryRepository subCategoryRepository,
    IMapper mapper
) : ICommandHandler<GetSubCategoriesCommand, PaginatedResult<SubCategoryFullViewModel>>
{
    private readonly ISubCategoryRepository _subCategoryRepository = subCategoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<PaginatedResult<SubCategoryFullViewModel>> Handle(GetSubCategoriesCommand request, CancellationToken cancellationToken)
    {
        var query = _subCategoryRepository.Context.SubCategories.AsQueryable();

        if (!string.IsNullOrEmpty(request.Search))
            query = query.Where(x => x.Name.Contains(request.Search));

        var subCategories = await query
            .AsNoTracking()
            .Include(x => x.Category)
            .Skip(request.PageSize * request.PageIndex)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        var totalCount = await _subCategoryRepository
            .Context
            .Categories
            .AsNoTracking()
            .CountAsync(cancellationToken);

        return new PaginatedResult<SubCategoryFullViewModel>
        {
            Items = _mapper.Map<List<SubCategoryFullViewModel>>(subCategories),
            TotalCount = totalCount
        };
    }
}
