using Mint.Domain.Common;
using Mint.Domain.Models.Identity;
using Mint.Infrastructure.MessageBrokers.Interfaces;
using Mint.WebApp.Email.Interfaces;
using Mint.WebApp.Email.Models;

namespace Mint.WebApp.Email.Services;

public class MessageBrokerBackgroundService : BackgroundService
{
    private readonly ILogger<MessageBrokerBackgroundService> _logger;
    private readonly IMessageReceiver<User> _receiver;
    private readonly IEmailRepository _email;
    private readonly IMessageSender<User> _sender;

    public MessageBrokerBackgroundService(
        ILogger<MessageBrokerBackgroundService> logger, 
        IMessageReceiver<User> receiver, 
        IMessageSender<User> sender, 
        IEmailRepository email)
    {
        _logger = logger;
        _receiver = receiver;
        _email = email;
        _sender = sender;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        _receiver?.ReceiveAsync(async (data, metaData) =>
        {
            _logger.LogInformation("Message: {Message}", data.ToString());

            var email = new EmailOptions()
            {
                ToEmails = new List<string>() { data.Email },
                Placeholders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{Login}}", data.Email),
                },
            };

            var isSent = _email.SendTestEmail(email);

            if (isSent.IsCompleted)
                await _sender.SendAsync(data, metaData, Constants.IdentityKey);

            await Task.Delay(1);
        }, stoppingToken);

        return Task.CompletedTask;
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}
