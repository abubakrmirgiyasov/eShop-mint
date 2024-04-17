using Mint.Application.Interfaces;
using Mint.WebApp.Admin.Application.Operations.Dtos.SubCategories;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Queries.Categories;

public sealed record GetCategoryWithSubCategoriesQuery(Guid Id) : IQuery<List<CategoryWithSubCategoryResponse>>;

public sealed class CategoryWithSubCategoryResponse
{
    public required int DisplayOrder { get; set; }

    public required SubCategorySimpleViewModel SubCategory { get; set; }
}

internal sealed class GetCategoryWithSubCategoriesQueryHandler(
    ICategoryRepository categoryRepository
) : IQueryHandler<GetCategoryWithSubCategoriesQuery, List<CategoryWithSubCategoryResponse>>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<List<CategoryWithSubCategoryResponse>> Handle(GetCategoryWithSubCategoriesQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetCategoryWithSubCategoriesAsync(
            request.Id,
            asNoTracking: true,
            cancellationToken: cancellationToken
        );

        if (category.SubCategories is null)
            return [];

        var subCategories = category.SubCategories.Select(
            x => new CategoryWithSubCategoryResponse
            {
                DisplayOrder = x.DisplayOrder,
                SubCategory = new SubCategorySimpleViewModel
                {
                    Label = x.Name,
                    Value = x.Id
                }
            })
            .OrderBy(x => x.DisplayOrder)
            .ToList();

        return subCategories;
    }
}