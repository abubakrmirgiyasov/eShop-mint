using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Mint.WebApp.HealthChecker;

public class ServiceHealthCheck(string url) : IHealthCheck
{
    private readonly string _url = url;

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        var http = new HttpClient();
        var result = await http.GetFromJsonAsync<ServiceHealthResult>(_url, cancellationToken);

        if (result is not null)
            return HealthCheckResult.Healthy(result.Message);

        return HealthCheckResult.Unhealthy("Failed");
    }
}

public static class ServiceHealthCheckExtensions
{
    public static  IHealthChecksBuilder AddServicesHealthCheck(
        this IHealthChecksBuilder builder, 
        string name, 
        string url, 
        HealthStatus failureStatus = HealthStatus.Unhealthy,
        IEnumerable<string>? tags = null,
        TimeSpan? timeout = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);

        return builder.Add(new HealthCheckRegistration(
            name: name,
            factory: _ => CreateHealthCheck(url),
            failureStatus: failureStatus,
            tags: tags,
            timeout: timeout));
    }

    private static ServiceHealthCheck CreateHealthCheck(string url)
    {
        return new ServiceHealthCheck(url);
    }
}

internal sealed class ServiceHealthResult
{
    public string Message { get; set; } = default!;
}
