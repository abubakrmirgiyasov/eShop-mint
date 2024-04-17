using AutoMapper;
using Mint.Application.Interfaces;
using Mint.WebApp.Admin.Application.Operations.Dtos.Categories;
using Mint.WebApp.Admin.Application.Operations.Dtos.Common;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Queries.Categories;

public sealed record GetCategoryByIdQuery(Guid Id) : IQuery<CategoryFullViewModel>;

internal sealed class GetCategoryByIdIQueryHandler(
    ICategoryRepository categoryRepository,
    IMapper mapper
) : IQueryHandler<GetCategoryByIdQuery, CategoryFullViewModel>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<CategoryFullViewModel> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(request.Id, cancellationToken);

        var categoryDto = _mapper.Map<CategoryFullViewModel>(category);
        categoryDto.DefaultLink = new DefaultLinkDTO
        {
            Id = category.Id,
            DisplayOrder = category.DisplayOrder,
            DefaultLink = category.DefaultLink ?? ""
        };

        return categoryDto;
    }
}
