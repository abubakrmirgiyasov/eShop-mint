using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Mint.Domain.Common;
using Mint.Infrastructure.HealthChekcs;
using Mint.Infrastructure.MessageBrokers.Interfaces;
using Mint.Infrastructure.MessageBrokers.RabbitMQ;

namespace Mint.Infrastructure.MessageBrokers;

public static class MessageBrokersCollectionExtensions
{
    public static IServiceCollection AddRabbitMQSender<T>(this IServiceCollection services, RabbitMQOptions options)
    {
        services.AddSingleton<IMessageSender<T>>(new RabbitMQSender<T>(new RabbitMQSenderOptions
        {
            HostName = options.HostName,
            UserName = options.UserName,
            Password = options.Password,
            ExchangeName = options.ExchangeName,
            RoutingKey = options.RoutingKeys[typeof(T).Name],
        }));
        return services;
    }

    public static IServiceCollection AddRabbitMQReceiver<T>(this IServiceCollection services, RabbitMQOptions options)
    {
        services.AddTransient<IMessageReceiver<T>>(x => new RabbitMQReceiver<T>(new RabbitMQReceiverOptions()
        {
            HostName = options.HostName,
            UserName = options.UserName,
            Password = options.Password,
            ExchangeName = options.ExchangeName,
            RoutingKey = options.RoutingKeys[typeof(T).Name],
            QueueName = options.QueueNames[typeof(T).Name],
            AutomaticCreateEnable = true,
        }));
        return services;
    }

    public static IServiceCollection AddMessageBusSender<T>(this IServiceCollection services, MessageBrokerOptions? options = null, IHealthChecksBuilder? healthChecksBuilder = null, HashSet<string>? checkDuplicated = null)
    {
        if (options != null && options.UseRabbitMQ())
        {
            services.AddRabbitMQSender<T>(options.RabbitMQ);

            if (healthChecksBuilder != null)
            {
                var name = "Message Broker (RabbitMQ)";

                healthChecksBuilder.AddRabbitMQ(new RabbitMQHealthCheckOptions()
                {
                    HostName = options.RabbitMQ.HostName,
                    UserName = options.RabbitMQ.UserName,
                    Password = options.RabbitMQ.Password,
                },
                name: name,
                failureStatus: HealthStatus.Degraded);

                checkDuplicated?.Add(name);
            }
        }

        return services;
    }

    public static IServiceCollection AddMessageBusReceiver<T>(this IServiceCollection services, MessageBrokerOptions? options = null)
    {
        if (options != null && options.UseRabbitMQ())
        {
            services.AddRabbitMQReceiver<T>(options.RabbitMQ);
        }

        return services;
    }
}
