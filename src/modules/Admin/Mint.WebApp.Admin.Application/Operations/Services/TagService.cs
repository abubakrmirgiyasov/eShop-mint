using Microsoft.Extensions.Logging;
using Mint.Domain.Common;
using Mint.Domain.Helpers;
using Mint.Domain.Models.Admin.Tags;
using Mint.Infrastructure.Redis.Interface;
using Mint.Infrastructure.Repositories.Admin;
using Mint.Infrastructure.Services.Interfaces;

namespace Mint.WebApp.Admin.Services;

public class TagService(
    IDistributedCacheManager cacheManager,
    ITagRepository tagRepository,
    ILogger<TagService> logger
) : ITagService
{
    private readonly IDistributedCacheManager _cacheManager = cacheManager;
    private readonly ITagRepository _tagRepository = tagRepository;
    private readonly ILogger<TagService> _logger = logger;

    public async Task<PaginatedResult<Tag>> GetTagsAsync(int pageIndex, int pageSize, CancellationToken cancellationToken = default)
    {
        try
        {
            var tags = _cacheManager.Get<IEnumerable<Tag>>(Constants.REDIS_SAMPLE_TAGS);

            if (tags is null)
            {
                var tagsRepository = await _tagRepository.GetTagsAsync(cancellationToken);

                _cacheManager.Set(
                    key: Constants.REDIS_SAMPLE_TAGS,
                    value: tagsRepository
                );

                var res = tagsRepository
                    .Skip(pageSize * pageIndex)
                    .Take(pageSize)
                    .ToList();

                return new PaginatedResult<Tag>
                {
                    Items = res,
                    TotalCount = tagsRepository.Count
                };
            }

            var items = tags
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToList();

            return new PaginatedResult<Tag>
            {
                Items = items,
                TotalCount = tags.Count()
            };
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }
}
