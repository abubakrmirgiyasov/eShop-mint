using Mint.Domain.Helpers;
using Mint.Domain.Models.Admin.Tags;

namespace Mint.Infrastructure.Services.Interfaces;

public interface ITagService
{
    Task<PaginatedResult<Tag>>
        GetTagsAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default);
}
