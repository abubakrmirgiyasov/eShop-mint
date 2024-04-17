using AutoMapper;
using Mint.Application.Interfaces;
using Mint.WebApp.Admin.Application.Operations.Dtos.Categories;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Queries.Categories;

public sealed record GetSampleCategoryByIdQuery(Guid Id) : IQuery<List<CategorySampleViewModel>>;

internal sealed class GetSampleCategoryByIdQueryHandler(
    ICategoryRepository categoryRepository,
    IMapper mapper
) : IQueryHandler<GetSampleCategoryByIdQuery, List<CategorySampleViewModel>>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<CategorySampleViewModel>> Handle(GetSampleCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetSampleCategoryById(request.Id, asNoTracking: true, cancellationToken: cancellationToken);

        var result = new List<CategorySampleViewModel>()
        {
            _mapper.Map<CategorySampleViewModel>(category)
        };

        return result;
    }
}