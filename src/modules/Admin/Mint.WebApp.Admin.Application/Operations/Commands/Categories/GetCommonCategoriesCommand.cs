using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mint.Infrastructure.Repositories.Admin;
using Mint.WebApp.Admin.Application.Common.Messaging;
using Mint.WebApp.Admin.Application.Operations.Dtos.Categories;

namespace Mint.WebApp.Admin.Application.Operations.Commands.Categories;

public sealed record GetCommonCategoriesCommand(string? Search)
    : ICommand<List<CategorySampleViewModel>>;

internal sealed class GetCommonCategoriesCommandHandler(
    ICategoryRepository categoryRepository,
    IMapper mapper
) : ICommandHandler<GetCommonCategoriesCommand, List<CategorySampleViewModel>>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<CategorySampleViewModel>> Handle(GetCommonCategoriesCommand request, CancellationToken cancellationToken)
    {
        var query = _categoryRepository.Context.Categories.AsQueryable();

        if (!string.IsNullOrEmpty(request.Search))
            query = query.Where(x => x.Name.Contains(request.Search));

        var categories = await query
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return _mapper.Map<List<CategorySampleViewModel>>(categories);
    }
}