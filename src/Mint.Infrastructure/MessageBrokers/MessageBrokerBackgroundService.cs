using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Mint.Infrastructure.MessageBrokers.Interfaces;

namespace Mint.Infrastructure.MessageBrokers;

public class MessageBrokerBackgroundService<T>(
    ILogger<MessageBrokerBackgroundService<T>> logger,
    IMessageReceiver<T> receiver
) : BackgroundService
{
    private readonly ILogger<MessageBrokerBackgroundService<T>> _logger = logger;
    private readonly IMessageReceiver<T> _receiver = receiver;

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        _receiver?.ReceiveAsync(async (data, metaData) =>
        {
            string message = $"{data}";

            _logger.LogInformation("Message: {Message}", message);

            await Task.Delay(1000);
        }, stoppingToken);

        return Task.CompletedTask;
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}