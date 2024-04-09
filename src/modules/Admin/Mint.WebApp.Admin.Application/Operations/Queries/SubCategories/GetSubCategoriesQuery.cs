using AutoMapper;
using Mint.Application.Interfaces;
using Mint.Domain.Helpers;
using Mint.WebApp.Admin.Application.Operations.Dtos.SubCategories;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Queries.SubCategories;

public sealed record GetSubCategoriesQuery(
    string? SearchPhrase,
    int PageIndex = 0,
    int PageSize = 50
) : IQuery<PaginatedResult<SubCategoryFullViewModel>>;

internal sealed class GetSubCategoriesQueryHandler(
    ISubCategoryRepository subCategoryRepository,
    IMapper mapper
) : IQueryHandler<GetSubCategoriesQuery, PaginatedResult<SubCategoryFullViewModel>>
{
    private readonly ISubCategoryRepository _subCategoryRepository = subCategoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<PaginatedResult<SubCategoryFullViewModel>> Handle(GetSubCategoriesQuery request, CancellationToken cancellationToken)
    {
        var (subCategories, totalCount) = await _subCategoryRepository.GetSubCategoriesAsync(
            searchPhrase: request.SearchPhrase,
            pageIndex: request.PageIndex,
            pageSize: request.PageSize,
            cancellationToken: cancellationToken
        );

        return new PaginatedResult<SubCategoryFullViewModel>
        {
            Items = _mapper.Map<List<SubCategoryFullViewModel>>(subCategories),
            TotalCount = totalCount
        };
    }
}
