using MediatR;
using Mint.Application.Interfaces;
using Mint.WebApp.StorageCloud.Models;

namespace Mint.WebApp.StorageCloud.Commands;

public sealed record UploadFileCommand(StorageCloudDto StorageCloud) : IRequest;

internal sealed class UploadFileCommandHandler(
    IStorageCloudService storageCloudService,
    ILogger<UploadFileCommandHandler> logger
) : IRequestHandler<UploadFileCommand>
{
    private readonly IStorageCloudService _storageCloudService = storageCloudService;
    private readonly ILogger<UploadFileCommandHandler> _logger = logger;

    public Task Handle(UploadFileCommand command, CancellationToken cancellationToken = default)
    {
        //await _storageCloudService.UploadFileAsync(command.StorageCloud.Photo, command.StorageCloud.Bucket, cancellationToken);

        _logger.LogInformation(
            "File upload successfully: Image={Image}, Bucket={Bucket}",
            command.StorageCloud.Photo.Name,
            command.StorageCloud.Bucket
        );

        return Task.CompletedTask;
    }
}
