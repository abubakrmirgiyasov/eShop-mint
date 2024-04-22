using AutoMapper;
using Mint.Application.Interfaces;
using Mint.Domain.Common;
using Mint.WebApp.Client.Application.Operations.Dtos.Categories;
using Mint.WebApp.Client.Application.Operations.Repositories;

namespace Mint.WebApp.Client.Application.Operations.Queries.Categories;

/// <summary>
/// Retrieves a list of catalogs in main page - MENU
/// </summary>
public sealed class GetCatalogsQuery : IQuery<List<Catalog>>;

internal sealed class GetCategoriesQueryHandler(
    IClientCategoryRepository categoryRepository,
    IRedisCacheService redisCacheService,
    IMapper mapper
) : IQueryHandler<GetCatalogsQuery, List<Catalog>>
{
    private readonly IClientCategoryRepository _categoryRepository = categoryRepository;
    private readonly IRedisCacheService _redisCacheService = redisCacheService;
    private readonly IMapper _mapper = mapper;

    public async Task<List<Catalog>> Handle(GetCatalogsQuery request, CancellationToken cancellationToken)
    {
        if (!_redisCacheService.Exists(Constants.REDIS_CATEGORIES))
        {
            var categories = await _categoryRepository.GetCategoriesAsync(cancellationToken);

            var mappedCategories = _mapper.Map<List<Catalog>>(categories);

            _redisCacheService.Set(Constants.REDIS_CATEGORIES, mappedCategories);

            return mappedCategories;
        }

        return _redisCacheService.Get<List<Catalog>>(Constants.REDIS_CATEGORIES);
    }
}
