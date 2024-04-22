using Microsoft.Extensions.Logging;
using Mint.Application.Interfaces;
using Mint.Domain.Helpers;
using Mint.Domain.Models.Admin.Tags;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.Infrastructure.Services.Admin;

//public class TagService(
//    IRedisCacheService redisCacheService,
//    ITagRepository tagRepository,
//    ILogger<TagService> logger
//) : ITagService
//{
//    private readonly IRedisCacheService _redisCacheService = redisCacheService;
//    private readonly ITagRepository _tagRepository = tagRepository;
//    private readonly ILogger<TagService> _logger = logger;

//    public Task<PaginatedResult<Tag>> GetTagsAsync(string key, int pageIndex, int pageSize, CancellationToken cancellationToken = default)
//    {
//        throw new NotImplementedException();
//    }
//}
