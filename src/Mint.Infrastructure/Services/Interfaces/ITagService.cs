using Mint.Domain.Helpers;
using Mint.Domain.Models.Admin;

namespace Mint.Infrastructure.Services.Interfaces;

public interface ITagService
{
    Task<PaginatedResult<Tag>>
        GetTagsAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default);
}
