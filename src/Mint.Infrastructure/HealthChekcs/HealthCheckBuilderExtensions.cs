using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Mint.Infrastructure.MessageBrokers.RabbitMQ;

namespace Mint.Infrastructure.HealthChekcs;

public static class HealthCheckBuilderExtensions
{
    public static IHealthChecksBuilder AddRabbitMQ(
        this IHealthChecksBuilder builder,
        RabbitMQHealthCheckOptions options,
        string name,
        HealthStatus? failureStatus = default,
        IEnumerable<string>? tags = default,
        TimeSpan? timeout = default)
    {
        return builder.Add(new HealthCheckRegistration(
            name: name,
            instance: new RabbitMQHealthCheck(options),
            failureStatus: failureStatus,
            tags: tags,
            timeout: timeout));
    }
}
