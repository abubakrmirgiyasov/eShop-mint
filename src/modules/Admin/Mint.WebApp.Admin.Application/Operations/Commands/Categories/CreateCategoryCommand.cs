using Microsoft.Extensions.Logging;
using Mint.Application.Interfaces;
using Mint.Domain.Models;
using Mint.Domain.Models.Admin.Categories;
using Mint.WebApp.Admin.Application.Operations.Dtos.Categories;
using Mint.WebApp.Admin.Application.Operations.Repositories;
using Mint.WebApp.Admin.Application.Operations.Validations.Categories;
using System.Text.Json;
using Mint.Domain.Extensions;

namespace Mint.WebApp.Admin.Application.Operations.Commands.Categories;

public sealed record CreateCategoryCommand(CategoryFullBindingModel Category) : ICommand<Guid>;

internal sealed class CreateCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IStorageCloudService storageCloudService,
    IUnitOfWork unitOfWork,
    ILogger<CreateCategoryCommandHandler> logger
) : ICommandHandler<CreateCategoryCommand, Guid>
{
    private readonly ILogger<CreateCategoryCommandHandler> _logger = logger;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IStorageCloudService _storageCloudService = storageCloudService;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var createCategoryValidator = new CreateCategoryCommandValidation();
        var validatorValidate = createCategoryValidator.Validate(request.Category);

        if (validatorValidate.IsValid)
            throw new Exception(JsonSerializer.Serialize(validatorValidate.Errors));

        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = request.Category.Name,
            DisplayOrder = request.Category.DisplayOrder,
            BadgeText = request.Category.BadgeText,
            BadgeStyle = request.Category.BadgeStyle,
            DefaultLink = request.Category.DefaultLink,
            Description = request.Category.DefaultLink,
            Ico = request.Category.Ico,
            IsPublished = request.Category.IsPublished,
            ShowOnHomePage = request.Category.ShowOnHomePage,
        };

        if (request.Category.Photo is not null)
        {
            var bucket = request.Category.Folder ?? "categories";

            var photoName = request.Category.Photo.FileName.GeneratePhotoName(category.Id);

            var file = await _storageCloudService.UploadFileAsync(request.Category.Photo, photoName, bucket, cancellationToken);

            category.Photo = new Photo
            {
                Id = Guid.NewGuid(),
                FileExtension = request.Category.Photo.ContentType,
                FileName = photoName,
                FilePath = file,
                FileSize = request.Category.Photo.Length,
                FileType = bucket,
            };
        }

        try
        {
            await _categoryRepository.AddAsync(category, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Создана новая категория с Id={Id}", category.Id);
            return category.Id;
        }
        catch (Exception ex)
        {
            if (request.Category.Photo is not null)
                await _storageCloudService.DeleteFileAsync(category.Photo!.FileName, category.Photo.FileType, cancellationToken);

            _logger.LogError(ex, "{Message}", ex.Message);
            throw new Exception(ex.Message, ex);
        }
    }
}
