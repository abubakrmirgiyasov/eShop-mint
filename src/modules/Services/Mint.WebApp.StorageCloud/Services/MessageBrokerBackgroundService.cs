using Mint.Infrastructure.MessageBrokers.Interfaces;
using Mint.WebApp.StorageCloud.Models;

namespace Mint.WebApp.StorageCloud.Services;

public class MessageBrokerBackgroundService : BackgroundService
{
    private readonly ILogger<MessageBrokerBackgroundService> _logger;
    private readonly IMessageReceiver<Models.StorageCloud> _receiver;

    public MessageBrokerBackgroundService(
        ILogger<MessageBrokerBackgroundService> logger, 
        IMessageReceiver<Models.StorageCloud> receiver)
    {
        _logger = logger;
        _receiver = receiver;
    }

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
