using Mint.Domain.Models.Admin.Categories;
using Mint.Domain.Models;
using Mint.Infrastructure.Repositories.Admin.Interfaces;
using Mint.Infrastructure.Services.Interfaces;
using Mint.WebApp.Admin.Operations.Dtos.Categories;

namespace Mint.WebApp.Admin.Services;

public class CategoryService(
    ICategoryRepository categoryRepository,
    IStorageCloudService storageCloudService,
    ILogger<CategoryService> logger)
{
    private readonly ILogger<CategoryService> _logger = logger;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IStorageCloudService _storageCloudService = storageCloudService;

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

        await _categoryRepository.Context.AddAsync(category, cancellationToken);
        await _categoryRepository.Context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Создана новая категория с Id={Id}", category.Id);

        return category.Id;
    }
}
