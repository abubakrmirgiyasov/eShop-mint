using AutoMapper;
using Mint.Application.Interfaces;
using Mint.WebApp.Admin.Application.Operations.Dtos.Categories;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Queries.Categories;

public sealed record GetCommonCategoriesQuery(string? Search)
    : IQuery<List<CategorySampleViewModel>>;

internal sealed class GetCommonCategoriesQueryHandler(
    ICategoryRepository categoryRepository,
    IMapper mapper
) : IQueryHandler<GetCommonCategoriesQuery, List<CategorySampleViewModel>>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<CategorySampleViewModel>> Handle(GetCommonCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetCommonCategoriesAsync(request.Search, cancellationToken);

        return _mapper.Map<List<CategorySampleViewModel>>(categories);
    }
}
