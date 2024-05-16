using Microsoft.Extensions.Logging;
using Mint.Application.Interfaces;
using Mint.Domain.Exceptions;
using Mint.WebApp.Admin.Application.Operations.Repositories;

namespace Mint.WebApp.Admin.Application.Operations.Commands.Manufactures;

public sealed record DeleteManufactureCommand(Guid Id) : ICommand;

internal sealed class DeleteManufactureCommandHandler(
    IManufactureRepository manufactureRepository,
    IStorageCloudService storageCloudService,
    IUnitOfWork unitOfWork,
    ILogger<DeleteManufactureCommandHandler> logger
) : ICommandHandler<DeleteManufactureCommand>
{
    private readonly IManufactureRepository _manufactureRepository = manufactureRepository;
    private readonly IStorageCloudService _storageCloudService = storageCloudService;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<DeleteManufactureCommandHandler> _logger = logger;

    public async Task Handle(DeleteManufactureCommand request, CancellationToken cancellationToken)
    {
        var manufacture = await _manufactureRepository.GetManufactureWithPhotoAsync(request.Id, cancellationToken);

        if (manufacture is null)
            throw new NotFoundException("Производитель не найден.");

        try
        {
            _manufactureRepository.Remove(manufacture);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (manufacture.Photo is not null)
                await _storageCloudService.DeleteFileAsync(manufacture.Photo.FileName, manufacture.Photo.Bucket, cancellationToken);

            _logger.LogWarning("Удалено успешно! Id={Id}", manufacture.Id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Message}", ex.Message);
        }
    }
}
