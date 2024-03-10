using Microsoft.EntityFrameworkCore;
using Mint.Domain.Exceptions;
using Mint.Infrastructure.MessageBrokers.Interfaces;
using Mint.Infrastructure.Services.Interfaces;
using Mint.WebApp.Admin.Repositories.Interfaces;

namespace Mint.WebApp.Admin.Operations.Commands.Manufactures;

public sealed record DeleteManufactureCommand(Guid Id) : ICommand;

internal sealed class DeleteManufactureCommandHandler(
    IManufactureRepository manufactureRepository,
    IStorageCloudService storageCloudService,
    ILogger<DeleteManufactureCommandHandler> logger
) : ICommandHandler<DeleteManufactureCommand>
{
    private readonly IManufactureRepository _manufactureRepository = manufactureRepository;
    private readonly IStorageCloudService _storageCloudService = storageCloudService;
    private readonly ILogger<DeleteManufactureCommandHandler> _logger = logger;

    public async Task Handle(DeleteManufactureCommand request, CancellationToken cancellationToken)
    {
        var manufacture = await _manufactureRepository
            .Context
            .Manufactures
            .Include(x => x.Photo)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
            ?? throw new NotFoundException($"Производитель с Id={request.Id} не найден.");

        if (manufacture.Photo is not null)
        {
            await _storageCloudService.DeleteFileAsync(
                name: manufacture.Photo.FileName,
                bucket: manufacture.Photo.FileType,
                cancellationToken: cancellationToken
            );
        }

        _manufactureRepository.Context.Remove(manufacture);
        await _manufactureRepository.Context.SaveChangesAsync(cancellationToken);

        _logger.LogWarning("Удалено успешно! Id={Id}", manufacture.Id);
    }
}
