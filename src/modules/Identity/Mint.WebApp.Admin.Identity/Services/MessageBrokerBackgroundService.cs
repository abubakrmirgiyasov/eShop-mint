using Mint.Domain.DTO_s.MessageBroker;
using Mint.Infrastructure.MessageBrokers.Interfaces;

namespace Mint.WebApp.Admin.Identity.Services;

public class MessageBrokerBackgroundService(
    ILogger<MessageBrokerBackgroundService> logger,
    IMessageReceiver<UserImage> receiver
) : BackgroundService
{
    private readonly ILogger<MessageBrokerBackgroundService> _logger = logger;
    private readonly IMessageReceiver<UserImage> _receiver = receiver;

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        var task = _receiver?.ReceiveAsync(async (data, metaData) =>
        {
            _logger.LogInformation("Info: Id={Id}, Image={ImagePath}", data.Id, data.ImagePath);

            await Task.Delay(100);
        }, stoppingToken);

        return Task.CompletedTask;
    }
}
