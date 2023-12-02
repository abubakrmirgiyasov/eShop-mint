using Mint.Domain.Common;
using Mint.Infrastructure.Redis.Interface;
using Mint.Infrastructure.Repositories.Admin.Interfaces;
using Mint.WebApp.Admin.DTO_s.Categories;
using System.Collections.Generic;

namespace Mint.WebApp.Admin.Services;

public class CategoryService(ICategoryRepository categoryRepository, IDistributedCacheManager cacheManager, ILogger<CategoryService> logger)
{
    private readonly IDistributedCacheManager _cacheManager = cacheManager;
    private readonly ILogger<CategoryService> _logger = logger;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<IEnumerable<CategorySampleViewModel>> GetCategorySamplesAsync()
    {
        try
        {
            var categories = _cacheManager.Get<IEnumerable<CategorySampleViewModel>>(Constants.REDIS_SAMPLE_CATEGORIES);

            if (categories is null)
            {
                var categoriesRepository = await _categoryRepository.GetSampleCategoriesAsync();
                _cacheManager.Set(
                    key: Constants.REDIS_SAMPLE_CATEGORIES,
                    value: categoriesRepository);
                return categoriesRepository;
            }
            return categories;
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }
}
