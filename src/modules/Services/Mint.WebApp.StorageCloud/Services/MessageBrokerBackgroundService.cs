using Mint.Infrastructure.MessageBrokers.Interfaces;
using Mint.WebApp.StorageCloud.Models;

namespace Mint.WebApp.StorageCloud.Services;

public class MessageBrokerBackgroundService(
    ILogger<MessageBrokerBackgroundService> logger,
    IMessageReceiver<StorageCloudDto> receiver
) : BackgroundService
{
    private readonly ILogger<MessageBrokerBackgroundService> _logger = logger;
    private readonly IMessageReceiver<StorageCloudDto> _receiver = receiver;

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        _receiver?.ReceiveAsync(async (data, metaData) =>
        {
            _logger.LogInformation("Message: {Message}", data.ToString());

            await Task.Delay(100);
        }, stoppingToken);

        return Task.CompletedTask;
    }
}
