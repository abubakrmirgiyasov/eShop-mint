using AutoMapper;
using Mint.Domain.Helpers;
using Mint.Infrastructure.Services.Interfaces;
using Mint.WebApp.Admin.Application.Common.Messaging;
using Mint.WebApp.Admin.Application.Operations.Dtos.Tags;

namespace Mint.WebApp.Admin.Application.Operations.Commands;

public sealed record GetTagsCommand(int PageIndex, int PageSize)
    : ICommand<PaginatedResult<TagFullViewModel>>;

internal sealed class GetTagsCommandHandler(ITagService tagService, IMapper mapper)
    : ICommandHandler<GetTagsCommand, PaginatedResult<TagFullViewModel>>
{
    private readonly ITagService _tagService = tagService;
    private readonly IMapper _mapper = mapper;

    public async Task<PaginatedResult<TagFullViewModel>> Handle(GetTagsCommand request, CancellationToken cancellationToken)
    {
        var tags = await _tagService.GetTagsAsync(request.PageIndex, request.PageSize, cancellationToken);

        return new PaginatedResult<TagFullViewModel>
        {
            Items = _mapper.Map<List<TagFullViewModel>>(tags.Items),
            TotalCount = tags.TotalCount,
        };
    }
}