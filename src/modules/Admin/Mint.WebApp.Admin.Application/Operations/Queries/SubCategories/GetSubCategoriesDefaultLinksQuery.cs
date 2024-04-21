using Mint.Application.Interfaces;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Queries.SubCategories;

public sealed record GetSubCategoriesDefaultLinksQuery(string? Search) : IQuery<List<string>>;

internal sealed class GetSubCategoriesDefaultLinksQueryHandler(ISubCategoryRepository subCategoryRepository)
    : IQueryHandler<GetSubCategoriesDefaultLinksQuery, List<string>>
{
    private readonly ISubCategoryRepository _categoryRepository = subCategoryRepository;

    public async Task<List<string>> Handle(GetSubCategoriesDefaultLinksQuery request, CancellationToken cancellationToken)
    {
        var subCategories = await _categoryRepository.GetSubCategoriesLinkAsync(request.Search, cancellationToken);
        return subCategories;
    }
}
