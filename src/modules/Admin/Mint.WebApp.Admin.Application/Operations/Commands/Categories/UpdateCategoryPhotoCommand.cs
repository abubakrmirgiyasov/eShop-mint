using FluentValidation;
using Microsoft.Extensions.Logging;
using Mint.Application.Interfaces;
using Mint.Domain.Exceptions;
using Mint.Domain.Extensions;
using Mint.Domain.Models;
using Mint.WebApp.Admin.Application.Operations.Dtos.Categories;
using Mint.WebApp.Admin.Application.Operations.Repositories;
using Mint.WebApp.Admin.Application.Operations.Validations.Categories;

namespace Mint.WebApp.Admin.Application.Operations.Commands.Categories;

public sealed record UpdateCategoryPhotoCommand(
    Guid Id,
    CategoryPhotoDto CategoryPhoto
) : ICommand;

internal sealed class UpdateCategoryPhotoCommandHandler(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork,
    IStorageCloudService storageCloudService,
    ILogger<UpdateCategoryPhotoCommandHandler> logger
) : ICommandHandler<UpdateCategoryPhotoCommand>
{
    private const long PhotoMaxSize = 5 * 1024 * 1024;
    private const string Bucket = "categories";

    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IStorageCloudService _storageCloudService = storageCloudService;
    private readonly ILogger<UpdateCategoryPhotoCommandHandler> _logger = logger;

    public async Task Handle(UpdateCategoryPhotoCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateCategoryPhotoCommandValidator();
        var validatorValidation = validator.Validate(request);

        if (!validatorValidation.IsValid)
            throw new ValidationException(validatorValidation.Errors);

        if (request.CategoryPhoto.Photo.Length > PhotoMaxSize)
            throw new LogicException("Размер файла перевешает 5МБ.");

        var category = await _categoryRepository.GetCategoryWithPhotoAsync(request.Id, cancellationToken: cancellationToken)
            ?? throw new NotFoundException("Категория не найдена.");

        var photoName = request.CategoryPhoto.Photo.FileName.GeneratePhotoName(category.Id);

        if (category.Photo is null)
        {
            var file = await _storageCloudService.UploadFileAsync(
                file: request.CategoryPhoto.Photo, 
                name: photoName, 
                bucket: Bucket, 
                cancellationToken: cancellationToken
            );
            var photoId = Guid.NewGuid();

            category.PhotoId = photoId;
            category.Photo = new Photo
            {
                FileExtension = request.CategoryPhoto.Photo.ContentType,
                FileName = photoName,
                FilePath = file,
                FileSize = request.CategoryPhoto.Photo.Length,
                Bucket = Bucket,
            };
        }
        else
        {
            var newPhotoPath = await _storageCloudService.UpdateFileAsync(
                file: request.CategoryPhoto.Photo,
                currentFileName: category.Photo.FileName,
                newFileName: photoName,
                bucket: Bucket,
                cancellationToken: cancellationToken
            );

            category.Photo.FileName = photoName;
            category.Photo.FilePath = newPhotoPath;
            category.Photo.Bucket = Bucket;
            category.Photo.FileExtension = request.CategoryPhoto.Photo.ContentType;
            category.Photo.UpdateDateTime = DateTimeOffset.Now;
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