using Mint.Domain.Helpers;
using Mint.Infrastructure.MessageBrokers.Interfaces;
using Mint.WebApp.Admin.DTO_s;
using Mint.WebApp.Admin.Services;

namespace Mint.WebApp.Admin.Commands;

public sealed record GetTagsCommand(int PageIndex, int PageSize)
    : ICommand<PaginatedResult<TagFullViewModel>>;

internal sealed class GetTagsCommandHandler(TagService tagService)
        : ICommandHandler<GetTagsCommand, PaginatedResult<TagFullViewModel>>
{
    private readonly TagService _tagService = tagService;

    public async Task<PaginatedResult<TagFullViewModel>> Handle(GetTagsCommand request, CancellationToken cancellationToken)
    {
		try
		{
			var tags = await _tagService.GetTagsAsync(request.PageIndex, request.PageSize, cancellationToken);
			return new PaginatedResult<TagFullViewModel>(tags.Items, tags.TotalCount);
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message, ex);
		}
    }
}