using AutoMapper;
using Mint.Domain.Exceptions;
using Mint.Infrastructure.MessageBrokers.Interfaces;
using Mint.Infrastructure.Repositories.Admin.Interfaces;
using Mint.WebApp.Admin.Commands.Dtos.Categories;

namespace Mint.WebApp.Admin.Commands.Categories;

public sealed record GetCategoriesDefaultLinksCommand(string? Search) : ICommand<IEnumerable<DefaultLinkDto>>;

internal sealed class GetCategoriesDefaultLinksCommandHandler(
    IMapper mapper,
    ICategoryRepository categoryRepository
) : ICommandHandler<GetCategoriesDefaultLinksCommand, IEnumerable<DefaultLinkDto>>
{
    private readonly IMapper _mapper = mapper;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<IEnumerable<DefaultLinkDto>> Handle(GetCategoriesDefaultLinksCommand request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetCategoriesLinkAsync(request.Search, cancellationToken);

        return _mapper.Map<IEnumerable<DefaultLinkDto>>(categories);
    }
}
