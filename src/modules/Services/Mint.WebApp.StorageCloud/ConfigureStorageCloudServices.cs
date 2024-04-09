using Microsoft.Extensions.Diagnostics.HealthChecks;
using Mint.Application.Interfaces;
using Mint.WebApp.StorageCloud.Services;

namespace Mint.WebApp.StorageCloud;

public static class ConfigureStorageCloudServices
{
    public static IHealthChecksBuilder AddMinio(
        this IHealthChecksBuilder builder,
        string name,
        string bucket,
        HealthStatus failureStatus = HealthStatus.Unhealthy,
        IEnumerable<string>? tags = null,
        TimeSpan? timeout = null)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);

        return builder.Add(new HealthCheckRegistration(
            name: name,
            factory: options => CreateHealthCheck(options, bucket),
            failureStatus: failureStatus,
            tags: tags,
            timeout: timeout));
    }

    private static MinioHealthCheckService CreateHealthCheck(IServiceProvider serviceProvider, string bucket)
    {
        return new MinioHealthCheckService(
            logger: serviceProvider.GetRequiredService<ILogger<MinioHealthCheckService>>(),
            storageCloudService: serviceProvider.GetRequiredService<IStorageCloudService>(),
            bucket: bucket);
    }
}
