using AutoMapper;
using Mint.Application.Interfaces;
using Mint.Domain.Exceptions;
using Mint.WebApp.Admin.Application.Operations.Dtos.Categories;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Queries.Categories;

public sealed record GetCategoryInfoQuery(Guid Id) : IQuery<CategoryInfoViewModel>;

internal sealed class GetCategoryInfoQueryHandler(
    ICategoryRepository categoryRepository,
    IMapper mapper
) : IQueryHandler<GetCategoryInfoQuery, CategoryInfoViewModel>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<CategoryInfoViewModel> Handle(GetCategoryInfoQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException("Категория не найдена.");

        return _mapper.Map<CategoryInfoViewModel>(category);
    }
}