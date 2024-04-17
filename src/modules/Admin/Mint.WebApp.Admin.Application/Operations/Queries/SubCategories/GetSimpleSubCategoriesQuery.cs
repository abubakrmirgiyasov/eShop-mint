using AutoMapper;
using Mint.Application.Interfaces;
using Mint.WebApp.Admin.Application.Operations.Dtos.SubCategories;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Queries.SubCategories;

public sealed record GetSimpleSubCategoriesQuery(string? SearchPhrase = default) 
    : IQuery<List<SubCategorySimpleViewModel>>;

internal sealed class GetSimpleSubCategoriesQueryHandler(
    ISubCategoryRepository subCategoryRepository,
    IMapper mapper
) : IQueryHandler<GetSimpleSubCategoriesQuery, List<SubCategorySimpleViewModel>>
{
    private readonly ISubCategoryRepository _subCategoryRepository = subCategoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<SubCategorySimpleViewModel>> Handle(GetSimpleSubCategoriesQuery request, CancellationToken cancellationToken)
    {
        var subCategories = await _subCategoryRepository.GetSimpleSubCategoriesAsync(
            request.SearchPhrase,
            asNoTracking: true,
            cancellationToken: cancellationToken
        );

        return _mapper.Map<List<SubCategorySimpleViewModel>>(subCategories);
    }
}
