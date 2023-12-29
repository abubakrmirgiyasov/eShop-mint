using Microsoft.Extensions.Options;
using Minio;
using Mint.Domain.Common;

namespace Mint.WebApp.StorageCloud.Services;

/// <summary>
/// Represents a connection to a MinIO server using the MinIO client.
/// </summary>
/// <param name="appSettings">The application settings, including MinIO configuration.</param>
/// <param name="isSecure">Flag indicating whether the connection should use SSL/TLS (default is false).</param>
public class MinioClientConnection(IOptions<AppSettings> appSettings, bool isSecure = false)
{
    private readonly AppSettings _appSettings = appSettings.Value;

    /// <summary>
    /// Gets the expiration time (in seconds) for the MinIO presigned URL.
    /// </summary>
    public int Expiry
    {
        get => _appSettings.MinioSettings.Expiry;
    }

    /// <summary>
    /// Gets the configured MinIO client for interacting with the MinIO server.
    /// </summary>
    public IMinioClient Client
    {
        get
        {
            var client = new MinioClient()
                .WithEndpoint(_appSettings.MinioSettings.Endpoint)
                .WithCredentials(_appSettings.MinioSettings.AccessKey, _appSettings.MinioSettings.SecretKey);

            if (isSecure)
                client.WithSSL(isSecure);

            return client;
        }
    }
}
