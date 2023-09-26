using Mint.Domain.Common;
using Mint.Infrastructure.Redis.Interface;
using Mint.Infrastructure.Repositories.Admin.Interfaces;
using Mint.WebApp.Admin.DTO_s.Categories;
using System.Collections.Generic;

namespace Mint.WebApp.Admin.Services;

public class CategoryService
{
    private readonly IDistributedCacheManager _cacheManager;
    private readonly ILogger<CategoryService> _logger;
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository, IDistributedCacheManager cacheManager, ILogger<CategoryService> logger)
    {
        _categoryRepository = categoryRepository;
        _cacheManager = cacheManager;
        _logger = logger;
    }

    public async Task<IEnumerable<CategorySampleViewModel>> GetCategorySamplesAsync()
    {
        try
        {
            //var categories = _cacheManager.Get<IEnumerable<CategorySampleViewModel>>(Constants.REDIS_SAMPLE_CATEGORIES);

            //if (categories is null)
            //{
                var categories = await _categoryRepository.GetSampleCategoriesAsync();
                //_cacheManager.Set(
                //    key: Constants.REDIS_SAMPLE_CATEGORIES,
                //    value: categories);
                return categories;
            //}
            //return categories;
        }
        catch (Exception ex)
        {
            _logger.LogError("{Message},{Full}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }
}
