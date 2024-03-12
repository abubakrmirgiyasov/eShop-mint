namespace Mint.Infrastructure.MessageBrokers.RabbitMQ;

public class RabbitMQReceiverOptions
{
    public required string HostName { get; set; }

    public required string UserName { get; set; }

    public required string Password { get; set; }

    public required string QueueName { get; set; }

    public required string ExchangeName { get; set; }

    public required string RoutingKey { get; set; }

    public required bool AutomaticCreateEnable { get; set; }
}
