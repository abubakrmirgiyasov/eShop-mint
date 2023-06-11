#nullable disable

using Mint.Infrastructure.MessageBrokers.Interfaces;
using Mint.Infrastructure.MessageBrokers.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace Mint.Infrastructure.MessageBrokers.RabbitMQ;

public class RabbitMQReceiver<T> : IMessageReceiver<T>, IDisposable
{
    private readonly RabbitMQReceiverOptions _options;
    private readonly IConnection _connection;
    private readonly string _queueName;
    private IModel _channel;

    public RabbitMQReceiver(RabbitMQReceiverOptions options)
    {
        _options = options;

        _connection = new ConnectionFactory()
        {
            HostName = options.HostName,
            UserName = options.UserName,
            Password = options.Password,
            AutomaticRecoveryEnabled = true,
            DispatchConsumersAsync = true,
        }.CreateConnection();

        _queueName = options.QueueName;

        _connection.ConnectionShutdown += Connection_ConnectionShutdown;
    }

    private void Connection_ConnectionShutdown(object sender, ShutdownEventArgs e)
    {
        // TODO: Add log here

        Console.WriteLine("Connection_ConnectionShutdown. RabbitMQReceiver:41", ConsoleColor.DarkYellow);
    }

    public Task ReceiveAsync(Func<T, MetaData, Task> action, CancellationToken cancellationToken)
    {
        _channel = _connection.CreateModel();

        if (_options.AutomaticCreateEnable)
        {
            _channel.QueueDeclare(_options.QueueName, true, false, false, null);
            _channel.QueueBind(_options.QueueName, _options.ExchangeName, _options.RoutingKey, null);
        }

        _channel.BasicQos(0, 1, false);

        var consumer = new AsyncEventingBasicConsumer(_channel);
        consumer.Received += async (sender, e) =>
        {
            var body = Encoding.UTF8.GetString(e.Body.Span);
            var message = JsonSerializer.Deserialize<Message<T>>(body);

            Console.WriteLine(message);

            await action(message.Data, message.MetaData);
            _channel.BasicAck(deliveryTag: e.DeliveryTag, multiple: false);
        };

        _channel.BasicConsume(
            queue: _queueName,
            autoAck: false,
            consumer: consumer);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _channel.Dispose();
        _connection.Dispose();
    }
}
