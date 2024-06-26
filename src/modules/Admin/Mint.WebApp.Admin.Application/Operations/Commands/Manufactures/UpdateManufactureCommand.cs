﻿using Microsoft.Extensions.Logging;
using Mint.Application.Interfaces;
using Mint.Domain.Exceptions;
using Mint.Domain.Models;
using Mint.WebApp.Admin.Application.Operations.Dtos.Manufactures;
using Mint.WebApp.Admin.Application.Operations.Repositories;
using Mint.Domain.Extensions;

namespace Mint.WebApp.Admin.Application.Operations.Commands.Manufactures;

public sealed record UpdateManufactureCommand(Guid Id, ManufactureFullBindingModel Manufacture) : ICommand;

internal sealed class UpdateManufactureCommandHandler(
    IManufactureRepository manufactureRepository,
    IStorageCloudService storageCloudService,
    IUnitOfWork unitOfWork,
    ILogger<UpdateManufactureCommandHandler> logger
) : ICommandHandler<UpdateManufactureCommand>
{
    private readonly IManufactureRepository _manufactureRepository = manufactureRepository;
    private readonly IStorageCloudService _storageCloudService = storageCloudService;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<UpdateManufactureCommandHandler> _logger = logger;

    public async Task Handle(UpdateManufactureCommand request, CancellationToken cancellationToken)
    {
        var manufacture = await _manufactureRepository.GetManufactureWithPhotoAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException($"Производитель с Id={request.Id} не найден.");

        manufacture.Name = request.Manufacture.Name;
        manufacture.DisplayOrder = request.Manufacture.DisplayOrder;
        manufacture.FullAddress = request.Manufacture.FullAddress;
        manufacture.Description = request.Manufacture.Description;
        manufacture.Country = request.Manufacture.Country;
        manufacture.Website = request.Manufacture.Website;
        manufacture.UpdateDateTime = DateTimeOffset.Now;

        var bucket = request.Manufacture.Folder ?? "manufactures";

        if (manufacture.Photo is not null)
        {
            if (request.Manufacture.Photo is not null)
            {
                await _storageCloudService.DeleteFileAsync(
                    name: manufacture.Photo.FileName,
                    bucket: manufacture.Photo.Bucket,
                    cancellationToken: cancellationToken
                );

                var photoName = request.Manufacture.Photo.FileName.GeneratePhotoName(manufacture.Id);

                var file = await _storageCloudService.UploadFileAsync(request.Manufacture.Photo, photoName, bucket, cancellationToken);

                manufacture.Photo.FileExtension = request.Manufacture.Photo.ContentType;
                manufacture.Photo.FileName = photoName;
                manufacture.Photo.FilePath = file;
                manufacture.Photo.FileSize = request.Manufacture.Photo.Length;
                manufacture.Photo.Bucket = bucket;
                manufacture.Photo.UpdateDateTime = DateTimeOffset.Now;
            }
        }
        else
        {
            if (request.Manufacture.Photo is not null)
            {
                var photoName = request.Manufacture.Photo.FileName.GeneratePhotoName(manufacture.Id);

                var file = await _storageCloudService.UploadFileAsync(request.Manufacture.Photo, photoName, bucket, cancellationToken);

                manufacture.Photo = new Photo
                {
                    Id = Guid.NewGuid(),
                    FileExtension = request.Manufacture.Photo.ContentType,
                    FileName = photoName,
                    FilePath = file,
                    FileSize = request.Manufacture.Photo.Length,
                    Bucket = bucket,
                };
            }
        }

        try
        {
            await _unitOfWork.SaveChangesAsync(cancellationToken);

           _logger.LogInformation("Успешно обновлено! Id={Id}", manufacture.Id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
