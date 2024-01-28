using Mint.Infrastructure.MessageBrokers.Interfaces;
using Mint.WebApp.StorageCloud.Models;
using Mint.WebApp.StorageCloud.Services.Interfaces;

namespace Mint.WebApp.StorageCloud.Commands;

public sealed record UploadFileCommand(StorageCloudDto StorageCloud) : ICommand;

internal sealed class UploadFileCommandHandler(
    IStorageCloudService storageCloudService,
    ILogger<GetImageLinkCommandHandler> logger
) : ICommandHandler<UploadFileCommand>
{
    private readonly IStorageCloudService _storageCloudService = storageCloudService;
    private readonly ILogger<GetImageLinkCommandHandler> _logger = logger;

    public async Task Handle(UploadFileCommand command, CancellationToken cancellationToken = default)
    {
        await _storageCloudService.UploadFileAsync(command.StorageCloud.Photo, command.StorageCloud.Bucket, cancellationToken);

        _logger.LogInformation(
            "File upload successfully: Image={Image}, Bucket={Bucket}", 
            command.StorageCloud.Photo.Name, 
            command.StorageCloud.Bucket
        );
    }
}
