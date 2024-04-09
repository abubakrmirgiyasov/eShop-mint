using FluentValidation;
using Microsoft.Extensions.Logging;
using Mint.Application.Interfaces;
using Mint.Domain.Extensions;
using Mint.Domain.Models;
using Mint.Domain.Models.Admin.Manufactures;
using Mint.WebApp.Admin.Application.Operations.Dtos.Manufactures;
using Mint.WebApp.Admin.Application.Operations.Repositories;
using Mint.WebApp.Admin.Application.Operations.Validations.Manufactures;

namespace Mint.WebApp.Admin.Application.Operations.Commands.Manufactures;

public sealed record CreateManufactureCommand(ManufactureFullBindingModel Manufacture) : ICommand<Guid>;

internal sealed class CreateManufactureCommandHandler(
    IManufactureRepository manufactureRepository,
    IStorageCloudService storageCloudService,
    IUnitOfWork unitOfWork,
    ILogger<CreateManufactureCommandHandler> logger
) : ICommandHandler<CreateManufactureCommand, Guid>
{
    private readonly IManufactureRepository _manufactureRepository = manufactureRepository;
    private readonly IStorageCloudService _storageCloudService = storageCloudService;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<CreateManufactureCommandHandler> _logger = logger;

    public async Task<Guid> Handle(CreateManufactureCommand request, CancellationToken cancellationToken)
    {
        var validation = new CreateManufactureCommandValidation();
        var validationValidator = validation.Validate(request.Manufacture);

        if (!validationValidator.IsValid)
            throw new ValidationException(validationValidator.Errors);

        var manufacture = new Manufacture
        {
            Id = Guid.NewGuid(),
            Name = request.Manufacture.Name,
            DisplayOrder = request.Manufacture.DisplayOrder,
            Description = request.Manufacture.Description,
            FullAddress = request.Manufacture.FullAddress,
            Country = request.Manufacture.Country,
            Website = request.Manufacture.Website,
        };

        if (request.Manufacture.Photo is not null)
        {
            var bucket = request.Manufacture.Folder ?? "manufactures";

            var photoName = request.Manufacture.Photo.FileName.GeneratePhotoName(manufacture.Id);

            var file = await _storageCloudService.UploadFileAsync(request.Manufacture.Photo, photoName, bucket, cancellationToken);

            manufacture.Photo = new Photo
            {
                Id = Guid.NewGuid(),
                FileExtension = request.Manufacture.Photo.ContentType,
                FileName = photoName,
                FilePath = file,
                FileSize = request.Manufacture.Photo.Length,
                FileType = bucket,
            };
        }

        try
        {
            await _manufactureRepository.AddAsync(manufacture, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Новый производитель создан с Id={Id}", manufacture.Id);

            return manufacture.Id;
        }
        catch (Exception ex)
        {
            if (request.Manufacture.Photo is not null)
                await _storageCloudService.DeleteFileAsync(manufacture.Photo!.FileName, manufacture.Photo.FileType, cancellationToken);

            _logger.LogError(ex, "{Message}", ex.Message);
            throw new Exception(ex.Message, ex);
        }
    }
}
