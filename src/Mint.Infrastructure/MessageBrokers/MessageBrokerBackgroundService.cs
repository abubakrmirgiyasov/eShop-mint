using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Mint.Domain.Models;
using Mint.Infrastructure.MessageBrokers.Interfaces;

namespace Mint.Infrastructure.MessageBrokers;

public class MessageBrokerBackgroundService : BackgroundService
{
    private readonly ILogger<MessageBrokerBackgroundService> _logger;
    private readonly IMessageReceiver<Order> _receiver;

    public MessageBrokerBackgroundService(ILogger<MessageBrokerBackgroundService> logger, IMessageReceiver<Order> receiver)
    {
        _logger = logger;
        _receiver = receiver;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        _receiver?.ReceiveAsync(async (data, metaData) =>
        {
            string message = data.Description.ToString();

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