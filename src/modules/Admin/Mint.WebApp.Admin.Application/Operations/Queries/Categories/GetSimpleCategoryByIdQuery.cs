using AutoMapper;
using Mint.Application.Interfaces;
using Mint.Domain.Exceptions;
using Mint.WebApp.Admin.Application.Operations.Dtos.Categories;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Queries.Categories;

public sealed record GetSimpleCategoryByIdQuery(Guid Id) : IQuery<CategorySimpleViewModel>;

internal sealed class GetSimpleCategoryByIdQueryHandler(
    ICategoryRepository categoryRepository,
    IMapper mapper
) : IQueryHandler<GetSimpleCategoryByIdQuery, CategorySimpleViewModel>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<CategorySimpleViewModel> Handle(GetSimpleCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException("Категория не найдена.");

        return _mapper.Map<CategorySimpleViewModel>(category);
    }
}