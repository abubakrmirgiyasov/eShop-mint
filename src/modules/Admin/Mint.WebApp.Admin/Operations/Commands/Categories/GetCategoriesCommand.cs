using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mint.Domain.Helpers;
using Mint.Infrastructure.MessageBrokers.Interfaces;
using Mint.Infrastructure.Repositories.Admin.Interfaces;
using Mint.WebApp.Admin.Operations.Dtos.Categories;

namespace Mint.WebApp.Admin.Operations.Commands.Categories;

public sealed record GetCategoriesCommand(
    string? Search,
    int PageIndex = 0,
    int PageSize = 50
) : ICommand<PaginatedResult<CategoryFullViewModel>>;

internal sealed class GetCategoriesCommandHandler(
    ICategoryRepository categoryRepository,
    IMapper mapper
) : ICommandHandler<GetCategoriesCommand, PaginatedResult<CategoryFullViewModel>>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<PaginatedResult<CategoryFullViewModel>> Handle(GetCategoriesCommand request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.Context.Categories
            .Where(x => x.Name.Contains(request.Search!))
            .Skip(request.PageSize * request.PageIndex)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        var totalCount = await _categoryRepository.Context.Categories.CountAsync(cancellationToken);

        return new PaginatedResult<CategoryFullViewModel>
        {
            Items = _mapper.Map<List<CategoryFullViewModel>>(categories),
            TotalCount = totalCount,
        };
    }
}