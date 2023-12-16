using Mint.Domain.Common;
using Mint.Domain.Models.Identity;
using Mint.Infrastructure.MessageBrokers.Interfaces;
using Mint.Domain.Models.Email;
using Mint.Infrastructure.Repositories.Email;

namespace Mint.WebApp.Email.Services;

public class MessageBrokerBackgroundService : BackgroundService
{
    private readonly ILogger<MessageBrokerBackgroundService> _logger;
    private readonly IMessageReceiver<User> _receiver;
    private readonly IMessageSender<User> _sender;
    private readonly IServiceProvider _scope;

    private IEmailRepository _email = default!;

    public MessageBrokerBackgroundService(
        ILogger<MessageBrokerBackgroundService> logger,
        IMessageReceiver<User> receiver,
        IMessageSender<User> sender,
        IServiceProvider scope)
    {
        _logger = logger;
        _receiver = receiver;
        _sender = sender;
        _scope = scope;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        using var scope = _scope.CreateScope();
        _email = scope.ServiceProvider.GetRequiredService<IEmailRepository>();

         User? u = null;

        var task = _receiver?.ReceiveAsync(async (data, metaData) =>
        {
            _logger.LogInformation("Message: {Message}", data.ToString());

            await Task.Delay(100);

            u = data;

        }, stoppingToken);

        if (task != null && task.IsCompleted)
        {
            var email = new EmailOptions()
            {
                //ToEmails = new List<string>() { u?.Email!, u?.ConfirmationCode.ToString()! },
                //Placeholders = new List<KeyValuePair<string, string>>()
                //{
                //    new KeyValuePair<string, string>("{{Login}} testset", u?.Email!),
                //},
            };

            _email.SendTestEmailAsync(email);
        }

        return Task.CompletedTask;
    }
}
