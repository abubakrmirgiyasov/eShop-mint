using AutoMapper;
using Mint.Infrastructure.MessageBrokers.Interfaces;
using Mint.Infrastructure.Repositories.Admin.Interfaces;
using Mint.WebApp.Admin.Operations.Dtos;

namespace Mint.WebApp.Admin.Operations.Commands.Categories;

public sealed record GetCategoriesDefaultLinksCommand(string? Search) : ICommand<List<DefaultLinkDTO>>;

internal sealed class GetCategoriesDefaultLinksCommandHandler(
    IMapper mapper,
    ICategoryRepository categoryRepository
) : ICommandHandler<GetCategoriesDefaultLinksCommand, List<DefaultLinkDTO>>
{
    private readonly IMapper _mapper = mapper;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<List<DefaultLinkDTO>> Handle(GetCategoriesDefaultLinksCommand request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetCategoriesLinkAsync(request.Search, cancellationToken);
        return _mapper.Map<List<DefaultLinkDTO>>(categories);
    }
}
