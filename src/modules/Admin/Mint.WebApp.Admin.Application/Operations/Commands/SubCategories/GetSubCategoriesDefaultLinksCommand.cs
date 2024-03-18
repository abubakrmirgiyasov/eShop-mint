using AutoMapper;
using Mint.Infrastructure.Repositories.Admin;
using Mint.WebApp.Admin.Application.Common.Messaging;
using Mint.WebApp.Admin.Application.Operations.Dtos.Common;

namespace Mint.WebApp.Admin.Application.Operations.Commands.SubCategories;

public sealed record GetSubCategoriesDefaultLinksCommand(string? Search)
    : ICommand<List<DefaultLinkDTO>>;

internal sealed class GetSubCategoriesDefaultLinksCommandHandler(
    ISubCategoryRepository subCategoryRepository,
    IMapper mapper
) : ICommandHandler<GetSubCategoriesDefaultLinksCommand, List<DefaultLinkDTO>>
{
    private readonly ISubCategoryRepository _categoryRepository = subCategoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<List<DefaultLinkDTO>> Handle(GetSubCategoriesDefaultLinksCommand request, CancellationToken cancellationToken)
    {
        var subCategories = await _categoryRepository.GetSubCategoriesLinkAsync(request.Search, cancellationToken);
        return _mapper.Map<List<DefaultLinkDTO>>(subCategories);
    }
}