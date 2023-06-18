using Mint.Infrastructure.MessageBrokers.Interfaces;
using Mint.Infrastructure.MessageBrokers.Models;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Mint.Infrastructure.MessageBrokers.RabbitMQ;

public class RabbitMQSender<T> : IMessageSender<T>
{
    private readonly IConnectionFactory _connectionFactory;
    private readonly string _exchangeName;
    private readonly string _routingKey;

    public RabbitMQSender(RabbitMQSenderOptions options)
    {
        _connectionFactory = new ConnectionFactory()
        {
            HostName = options.HostName,
            UserName = options.UserName,
            Password = options.Password,
        };

        _exchangeName = options.ExchangeName;
        _routingKey = options.RoutingKey;
    }

    public async Task SendAsync(T message, MetaData? metaData = null, CancellationToken cancellationToken = default)
    {
        await Task.Run(() => 
        {
            using var connection = _connectionFactory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: _routingKey,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(new Message<T>()
            {
                Data = message,
                MetaData = metaData,
            }));

            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;

            channel.BasicPublish(
                exchange: "", // _exchangeName
                routingKey: _routingKey,
                basicProperties: properties,
                body: body);
        }, cancellationToken);
    }
}
