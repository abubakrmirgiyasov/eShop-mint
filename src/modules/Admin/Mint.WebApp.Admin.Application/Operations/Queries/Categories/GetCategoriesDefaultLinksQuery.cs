using AutoMapper;
using Mint.Application.Interfaces;
using Mint.WebApp.Admin.Application.Operations.Dtos.Common;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Queries.Categories;

public sealed record GetCategoriesDefaultLinksQuery(string? Search) : IQuery<List<DefaultLinkDTO>>;

internal sealed class GetCategoriesDefaultLinksQueryHandler(
    IMapper mapper,
    ICategoryRepository categoryRepository
) : IQueryHandler<GetCategoriesDefaultLinksQuery, List<DefaultLinkDTO>>
{
    private readonly IMapper _mapper = mapper;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<List<DefaultLinkDTO>> Handle(GetCategoriesDefaultLinksQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetCategoriesLinkAsync(request.Search, cancellationToken);
        return _mapper.Map<List<DefaultLinkDTO>>(categories);
    }
}
