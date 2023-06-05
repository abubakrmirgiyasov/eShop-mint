namespace Mint.Infrastructure.MessageBrokers.RabbitMQ;

public class RabbitMQSenderOptions
{
    public string HostName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string ExchangeName { get; set; } = null!;

    public string RoutingKey { get; set; } = null!;
}
