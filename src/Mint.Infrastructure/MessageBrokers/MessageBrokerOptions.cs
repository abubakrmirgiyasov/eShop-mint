using Mint.Infrastructure.MessageBrokers.RabbitMQ;

namespace Mint.Infrastructure.MessageBrokers;

public class MessageBrokerOptions
{
    public string Provider { get; set; } = null!;

    public RabbitMQOptions RabbitMQ { get; set; } = null!;

    public bool UseRabbitMQ()
    {
        return Provider == "RabbitMQ";
    }
}
