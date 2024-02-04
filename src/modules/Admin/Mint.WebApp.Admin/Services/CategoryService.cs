using Mint.Domain.Common;
using Mint.Domain.Models.Admin.Categories;
using Mint.Domain.Models;
using Mint.Infrastructure.Redis.Interface;
using Mint.Infrastructure.Repositories.Admin.Interfaces;
using Mint.WebApp.Admin.DTO_s.Categories;
using Mint.Infrastructure.Services.Interfaces;

namespace Mint.WebApp.Admin.Services;

public class CategoryService(
    ICategoryRepository categoryRepository, 
    IDistributedCacheManager cacheManager,
    IStorageCloudService storageCloudService,
    ILogger<CategoryService> logger)
{
    private readonly IDistributedCacheManager _cacheManager = cacheManager;
    private readonly ILogger<CategoryService> _logger = logger;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IStorageCloudService _storageCloudService = storageCloudService;

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

    public async Task<Guid> Create(CategoryFullBindingModel model, CancellationToken cancellationToken = default)
    {
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = model.Name,
            DisplayOrder = model.DisplayOrder,
            BadgeText = model.BadgeText,
            BadgeStyle = model.BadgeStyle,
            DefaultLink = model.DefaultLink,
            Description = model.DefaultLink,
            Ico = model.Ico,
            IsPublished = model.IsPublished,
            ShowOnHomePage = model.ShowOnHomePage,
        };

        if (model.Photo is not null)
        {
            var bucket = model.Folder ?? "categories";

            var file = await _storageCloudService.UploadFileAsync(model.Photo, bucket, cancellationToken);

            category.Photo = new Photo
            {
                Id = Guid.NewGuid(),
                FileExtension = model.Photo.ContentType,
                FileName = model.Photo.FileName,
                FilePath = file,
                FileSize = model.Photo.Length,
                FileType = bucket,
            };
        }

        return category.Id;
    }
}
