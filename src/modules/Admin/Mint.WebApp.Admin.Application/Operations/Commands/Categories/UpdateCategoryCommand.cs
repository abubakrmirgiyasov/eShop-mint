using Microsoft.Extensions.Logging;
using Mint.Application.Interfaces;
using Mint.Domain.Exceptions;
using Mint.Domain.Extensions;
using Mint.Domain.Models;
using Mint.Domain.Models.Admin.Manufactures;
using Mint.WebApp.Admin.Application.Operations.Dtos.Categories;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Commands.Categories;

public sealed record UpdateCategoryCommand(
    Guid Id,
    CategoryFullBindingModel Category
) : ICommand;

internal sealed class UpdateCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    IStorageCloudService storageCloudService,
    IUnitOfWork unitOfWork,
    ILogger<UpdateCategoryCommandHandler> logger
) : ICommandHandler<UpdateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IStorageCloudService _storageCloudService = storageCloudService;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<UpdateCategoryCommandHandler> _logger = logger;

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetCategoryWithPhotoAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException("Категория не найдена.");

        category.Name = request.Category.Name;
        category.DisplayOrder = request.Category.DisplayOrder;
        category.IsPublished = request.Category.IsPublished;
        category.ShowOnHomePage = request.Category.ShowOnHomePage;
        category.BadgeText = request.Category.BadgeText;
        category.BadgeStyle = request.Category.BadgeStyle;
        category.Ico = request.Category.Ico;
        category.DefaultLink = request.Category.DefaultLink;
        category.Description = request.Category.Description;
        category.UpdateDateTime = DateTimeOffset.Now;

        if (request.Category.Photo is not null)
        {
            var bucket = request.Category.Folder ?? "categories";
            var photoName = request.Category.Photo.FileName.GeneratePhotoName(category.Id);

            if (category.Photo is not null)
            {
                var newPhotoPath = await _storageCloudService.UpdateFileAsync(
                    file: request.Category.Photo, 
                    currentFileName: category.Photo.FileName, 
                    newFileName: photoName, 
                    bucket: bucket, 
                    cancellationToken: cancellationToken
                );

                category.Photo.FileName = photoName;
                category.Photo.FilePath = newPhotoPath;
                category.Photo.FileType = bucket;
                category.Photo.FileExtension = request.Category.Photo.ContentType;
                category.Photo.UpdateDateTime = DateTimeOffset.Now;
            }
            else
            {
                var newPhotoPath = await _storageCloudService.UploadFileAsync(
                    file: request.Category.Photo,
                    name: photoName,
                    bucket: bucket,
                    cancellationToken: cancellationToken
                );

                category.Photo = new Photo
                {
                    Id = Guid.NewGuid(),
                    FileExtension = request.Category.Photo.ContentType,
                    FileName = photoName,
                    FilePath = newPhotoPath,
                    FileSize = request.Category.Photo.Length,
                    FileType = bucket,
                };
            }
        }

        try
        {
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Успешно обновлено! Id={Id}", category.Id);
        }
        catch (Exception ex)
        {
            //await _storageCloudService.DeleteFileAsync(category.Photo!.FileName, category.Photo.FileType, cancellationToken);

            throw new Exception(ex.Message, ex);
        }
    }
}
