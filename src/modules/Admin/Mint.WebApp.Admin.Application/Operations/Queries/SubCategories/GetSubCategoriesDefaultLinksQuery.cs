using AutoMapper;
using Mint.Application.Interfaces;
using Mint.WebApp.Admin.Application.Operations.Dtos.Common;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Queries.SubCategories;

public sealed record GetSubCategoriesDefaultLinksQuery(string? Search)
    : IQuery<List<DefaultLinkDTO>>;

internal sealed class GetSubCategoriesDefaultLinksQueryHandler(
    ISubCategoryRepository subCategoryRepository,
    IMapper mapper
) : IQueryHandler<GetSubCategoriesDefaultLinksQuery, List<DefaultLinkDTO>>
{
    private readonly ISubCategoryRepository _categoryRepository = subCategoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<DefaultLinkDTO>> Handle(GetSubCategoriesDefaultLinksQuery request, CancellationToken cancellationToken)
    {
        var subCategories = await _categoryRepository.GetSubCategoriesLinkAsync(request.Search, cancellationToken);
        return _mapper.Map<List<DefaultLinkDTO>>(subCategories);
    }
}
