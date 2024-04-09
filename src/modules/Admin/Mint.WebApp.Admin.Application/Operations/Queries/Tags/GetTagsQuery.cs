using AutoMapper;
using Mint.Application.Interfaces;
using Mint.Domain.Helpers;
using Mint.WebApp.Admin.Application.Operations.Dtos.Tags;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Queries.Tags;

public sealed record GetTagsQuery(
    string? SearchPhrase,
    int PageIndex = 0,
    int PageSize = 50
) : IQuery<PaginatedResult<TagFullViewModel>>;

internal sealed class GetTagsQueryHandler(ITagRepository tagRepository, IMapper mapper)
    : IQueryHandler<GetTagsQuery, PaginatedResult<TagFullViewModel>>
{
    private readonly ITagRepository _tagRepository = tagRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<PaginatedResult<TagFullViewModel>> Handle(GetTagsQuery request, CancellationToken cancellationToken)
    {
        var (tags, totalCount) = await _tagRepository.GetTagsAsync(
            searchPhrase: request.SearchPhrase, 
            pageIndex: request.PageIndex, 
            pageSize: request.PageSize, 
            cancellationToken: cancellationToken
        );

        return new PaginatedResult<TagFullViewModel>
        {
            Items = _mapper.Map<List<TagFullViewModel>>(tags),
            TotalCount = totalCount,
        };
    }
}