using AutoMapper;
using Mint.Application.Interfaces;
using Mint.Domain.Common;
using Mint.Domain.Helpers;
using Mint.WebApp.Admin.Application.Operations.Dtos.SubCategories;
using Mint.WebApp.Admin.Application.Operations.Repositories;
using Mint.Domain.Extensions;

namespace Mint.WebApp.Admin.Application.Operations.Queries.SubCategories;

public sealed record GetSubCategoriesQuery(
    string? SearchPhrase,
    SubCategoryFilter? Filter,
    int PageIndex = 0,
    int PageSize = 50
) : IQuery<PaginatedResult<SubCategoryInfoViewModel>>;

public sealed class SubCategoryFilter
{
    public SortType? DisplayOrder { get; set; }

    public SortType? Name { get; set; }

    public SortType? DefaultLink { get; set; }

    public SortType? FullName { get; set; }
}

internal sealed class GetSubCategoriesQueryHandler(
    ISubCategoryRepository subCategoryRepository,
    IMapper mapper
) : IQueryHandler<GetSubCategoriesQuery, PaginatedResult<SubCategoryInfoViewModel>>
{
    private readonly ISubCategoryRepository _subCategoryRepository = subCategoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<PaginatedResult<SubCategoryInfoViewModel>> Handle(GetSubCategoriesQuery request, CancellationToken cancellationToken)
    {
        var (subCategories, totalCount) = await _subCategoryRepository.GetSubCategoriesAsync(
            searchPhrase: request.SearchPhrase,
            pageIndex: request.PageIndex,
            pageSize: request.PageSize,
            cancellationToken: cancellationToken
        );

        if (request.Filter != null)
        {
            if (request.Filter.FullName != null)
                subCategories = [.. subCategories.SortBy(x => x.FullName, request.Filter.FullName.Value)];
            else if (request.Filter.Name != null)
                subCategories = [.. subCategories.SortBy(x => x.Name, request.Filter.Name.Value)];
            else if (request.Filter.DefaultLink != null)
                subCategories = [.. subCategories.SortBy(x => x.DefaultLink, request.Filter.DefaultLink.Value)];
            else if (request.Filter.DisplayOrder != null)
                subCategories = [.. subCategories.SortBy(x => x.DisplayOrder, request.Filter.DisplayOrder.Value)];
        }

        return new PaginatedResult<SubCategoryInfoViewModel>
        {
            Items = _mapper.Map<List<SubCategoryInfoViewModel>>(subCategories),
            TotalCount = totalCount
        };
    }
}
