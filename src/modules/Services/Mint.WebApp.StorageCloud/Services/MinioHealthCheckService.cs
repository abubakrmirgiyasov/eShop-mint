using Microsoft.Extensions.Diagnostics.HealthChecks;
using Mint.Infrastructure.Services.Interfaces;

namespace Mint.WebApp.StorageCloud.Services;

public class MinioHealthCheckService(
    ILogger<MinioHealthCheckService> logger,
    IStorageCloudService storageCloudService,
    string bucket
) : IHealthCheck
{
    private readonly ILogger<MinioHealthCheckService> _logger = logger;
    private readonly IStorageCloudService _storageCloudService = storageCloudService;
    private readonly string _bucket = bucket;

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            await _storageCloudService.IsBucketExist(_bucket, cancellationToken);

            return HealthCheckResult.Healthy("MINIO is working");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "MinIO health check {HealthCheckName} failed", context.Registration.Name);
            return new HealthCheckResult(HealthStatus.Unhealthy, ex.Message, ex);
        }
    }
}
