using Microsoft.Extensions.Logging;
using Mint.Domain.Models.Admin.Categories;
using Mint.Infrastructure.Redis.Interface;
using Mint.WebApp.Admin.Application.Operations.Repositories;
using Mint.WebApp.Admin.Application.Operations.Services;

namespace Mint.Infrastructure.Services.Admin;

internal sealed class CategoryService(
    ICategoryRepository categoryRepository,
    IRedisCacheService redisCacheService,
    ILogger<CategoryService> logger
) : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IRedisCacheService _redisCacheService = redisCacheService;
    private readonly ILogger<CategoryService> _logger = logger;

    public Task<List<Category>> GetCategoriesFromRedisAsync(string key)
    {
        throw new NotImplementedException();
    }
}
