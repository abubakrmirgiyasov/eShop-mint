using Mint.Domain.Models;
using Mint.Domain.Models.Admin.Categories;
using Mint.Infrastructure.MessageBrokers.Interfaces;
using Mint.Infrastructure.Repositories.Admin.Interfaces;
using Mint.Infrastructure.Services.Interfaces;
using Mint.WebApp.Admin.Operations.Dtos.Categories;

namespace Mint.WebApp.Admin.Operations.Commands.Categories;

public sealed record CreateCategoryCommand(CategoryFullBindingModel Category) : ICommand<Guid>;

internal sealed class CreateCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IStorageCloudService storageCloudService,
    ILogger<CreateCategoryCommandHandler> logger
) : ICommandHandler<CreateCategoryCommand, Guid>
{
    private readonly ILogger<CreateCategoryCommandHandler> _logger = logger;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IStorageCloudService _storageCloudService = storageCloudService;

    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = request.Category.Name,
            DisplayOrder = request.Category.DisplayOrder,
            BadgeText = request.Category.BadgeText,
            BadgeStyle = request.Category.BadgeStyle,
            DefaultLink = request.Category.DefaultLink,
            Description = request.Category.Description,
            Ico = request.Category.Ico,
            IsPublished = request.Category.IsPublished,
            ShowOnHomePage = request.Category.ShowOnHomePage,
        };

        if (request.Category.Photo is not null)
        {
            var bucket = request.Category.Folder ?? "categories";

            var file = await _storageCloudService.UploadFileAsync(request.Category.Photo, bucket, cancellationToken);

            category.Photo = new Photo
            {
                Id = Guid.NewGuid(),
                FileExtension = request.Category.Photo.ContentType,
                FileName = request.Category.Photo.FileName,
                FilePath = file,
                FileSize = request.Category.Photo.Length,
                FileType = bucket,
            };
        }

        await _categoryRepository.Context.AddAsync(category, cancellationToken);
        await _categoryRepository.Context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Создана новая категория с Id={Id}", category.Id);

        return category.Id;
    }
}
