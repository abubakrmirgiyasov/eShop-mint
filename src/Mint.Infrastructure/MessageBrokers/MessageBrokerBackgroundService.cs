using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Mint.Infrastructure.MessageBrokers.Interfaces;

namespace Mint.Infrastructure.MessageBrokers;

public class MessageBrokerBackgroundService : BackgroundService
{
    private readonly ILogger<MessageBrokerBackgroundService> _logger;
    private readonly IMessageReceiver<Test> _receiver;

    public MessageBrokerBackgroundService(ILogger<MessageBrokerBackgroundService> logger, IMessageReceiver<Test> receiver)
    {
        _logger = logger;
        _receiver = receiver;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        _receiver?.ReceiveAsync(async (data, metaData) =>
        {
            string message = data.Name;

            _logger.LogInformation(message);

            await Task.Delay(5000);
        }, stoppingToken);

        return Task.CompletedTask;
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}

public class Test
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name => Id.ToString().ToLower()[..10].Replace("-", "");
}