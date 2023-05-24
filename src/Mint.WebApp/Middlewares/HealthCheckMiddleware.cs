using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Mint.WebApp.Middlewares;

public class HealthCheckMiddleware : IHealthCheck
{
    private readonly Random _random = new();

    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        var response = _random.Next(1, 300);

        if (response < 100)
            return Task.FromResult(HealthCheckResult.Healthy("Healthy result from MyHealthCheck < 100"));
        else if (response < 200)
            return Task.FromResult(HealthCheckResult.Degraded("Degraded result from MyHealthCheck < 200"));
        else
            return Task.FromResult(HealthCheckResult.Unhealthy("Unhealthy result from MyHealthCheck"));
    }
}
