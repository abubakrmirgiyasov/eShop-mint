using Microsoft.Extensions.Logging;
using Mint.Domain.Models;
using Mint.Domain.Models.Admin.Manufactures;
using Mint.Infrastructure.Repositories.Admin;
using Mint.Infrastructure.Services.Interfaces;
using Mint.WebApp.Admin.Application.Common.Messaging;
using Mint.WebApp.Admin.Application.Operations.Dtos.Manufactures;
using Mint.WebApp.Extensions.Models;

namespace Mint.WebApp.Admin.Application.Operations.Commands.Manufactures;

public sealed record CreateManufactureCommand(ManufactureFullBindingModel Manufacture) : ICommand<Guid>;

internal sealed class CreateManufactureCommandHandler(
    IManufactureRepository manufactureRepository,
    IStorageCloudService storageCloudService,
    ILogger<CreateManufactureCommandHandler> logger
) : ICommandHandler<CreateManufactureCommand, Guid>
{
    private readonly IManufactureRepository _manufactureRepository = manufactureRepository;
    private readonly IStorageCloudService _storageCloudService = storageCloudService;
    private readonly ILogger<CreateManufactureCommandHandler> _logger = logger;

    public async Task<Guid> Handle(CreateManufactureCommand request, CancellationToken cancellationToken)
    {
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

        await _manufactureRepository.Context.AddAsync(manufacture, cancellationToken);
        await _manufactureRepository.Context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Новый производитель создан с Id={Id}", manufacture.Id);

        return manufacture.Id;
    }
}
