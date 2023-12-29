using Mint.Infrastructure.MessageBrokers.Interfaces;

namespace Mint.WebApp.StorageCloud.Services;

public class MessageBrokerBackgroundService(
    ILogger<MessageBrokerBackgroundService> logger,
    IMessageReceiver<Models.StorageCloud> receiver) : BackgroundService
{
    private readonly ILogger<MessageBrokerBackgroundService> _logger = logger;
    private readonly IMessageReceiver<Models.StorageCloud> _receiver = receiver;

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        var task = _receiver?.ReceiveAsync(async (data, metaData) =>
        {
            _logger.LogInformation("Message: {Message}", data.ToString());

            await Task.Delay(100);
        }, stoppingToken);

        return Task.CompletedTask;
    }
}
