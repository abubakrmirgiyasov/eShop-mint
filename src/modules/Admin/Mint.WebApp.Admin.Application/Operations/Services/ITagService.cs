using Mint.Domain.Helpers;
using Mint.Domain.Models.Admin.Tags;

namespace Mint.WebApp.Admin.Application.Operations.Services;

public interface ITagService
{
    Task<PaginatedResult<Tag>> GetTagsAsync(string key, int pageIndex, int pageSize, CancellationToken cancellationToken = default);
}
