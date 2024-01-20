using Mint.Domain.DTO_s.MessageBroker;
using Mint.Infrastructure.MessageBrokers.Interfaces;
using Mint.WebApp.StorageCloud.Services.Interfaces;

namespace Mint.WebApp.StorageCloud.Commands;

public sealed record GetImageLinkCommand(string Bucket, string Name)
    : ICommand<UserImage>;

internal sealed class GetImageLinkCommandHandler(
    IMessageSender<UserImage> messageSender,
    IStorageCloudService storageCloudService,
    ILogger<GetImageLinkCommandHandler> logger
) : ICommandHandler<GetImageLinkCommand, UserImage>
{
    private readonly IMessageSender<UserImage> _messageSender = messageSender;
    private readonly IStorageCloudService _storageCloudService = storageCloudService;
    private readonly ILogger<GetImageLinkCommandHandler> _logger = logger;

    public async Task<UserImage> Handle(GetImageLinkCommand request, CancellationToken cancellationToken)
    {
        var image = await _storageCloudService.GetFileLinkAsync(request.Name, request.Bucket, cancellationToken);
        var userImage = new UserImage(Guid.NewGuid(), image);

        _logger.LogInformation("Send: Id={Id} Path={Path}", userImage.Id, image);

        await _messageSender.SendAsync(userImage, cancellationToken: cancellationToken);

        return userImage;
    }
}
