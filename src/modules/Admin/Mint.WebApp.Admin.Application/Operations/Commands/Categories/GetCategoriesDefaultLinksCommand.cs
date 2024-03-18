using AutoMapper;
using Mint.Infrastructure.Repositories.Admin;
using Mint.WebApp.Admin.Application.Common.Messaging;
using Mint.WebApp.Admin.Application.Operations.Dtos.Common;

namespace Mint.WebApp.Admin.Application.Operations.Commands.Categories;

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
