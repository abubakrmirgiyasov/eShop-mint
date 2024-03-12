namespace Mint.Infrastructure.MessageBrokers.RabbitMQ;

public class RabbitMQSenderOptions
{
    public required string HostName { get; set; }

    public required string UserName { get; set; }

    public required string Password { get; set; }

    public required string ExchangeName { get; set; }

    public required string RoutingKey { get; set; }
}
