using AutoMapper;
using Mint.Infrastructure.MessageBrokers.Interfaces;
using Mint.Infrastructure.Repositories.Admin.Interfaces;
using Mint.WebApp.Admin.Operations.Dtos.Categories;

namespace Mint.WebApp.Admin.Operations.Commands.Categories;

public sealed record GetCategoriesDefaultLinksCommand(string? Search) : ICommand<IEnumerable<DefaultLinkDTO>>;

internal sealed class GetCategoriesDefaultLinksCommandHandler(
    IMapper mapper,
    ICategoryRepository categoryRepository
) : ICommandHandler<GetCategoriesDefaultLinksCommand, IEnumerable<DefaultLinkDTO>>
{
    private readonly IMapper _mapper = mapper;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<IEnumerable<DefaultLinkDTO>> Handle(GetCategoriesDefaultLinksCommand request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetCategoriesLinkAsync(request.Search, cancellationToken);

        return _mapper.Map<IEnumerable<DefaultLinkDTO>>(categories);
    }
}
