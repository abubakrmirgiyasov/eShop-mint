using Mint.Application.Interfaces;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Queries.Categories;

public sealed record GetCategoriesDefaultLinksQuery(string? Search) : IQuery<List<string>>;

internal sealed class GetCategoriesDefaultLinksQueryHandler(ICategoryRepository categoryRepository)
    : IQueryHandler<GetCategoriesDefaultLinksQuery, List<string>>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<List<string>> Handle(GetCategoriesDefaultLinksQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetCategoriesLinkAsync(request.Search, cancellationToken);
        return categories;
    }
}
