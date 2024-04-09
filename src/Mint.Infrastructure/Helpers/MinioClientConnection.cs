using Microsoft.Extensions.Options;
using Minio;
using Mint.Domain.Common;

namespace Mint.Infrastructure.Helpers;

/// <summary>
/// Represents a connection to a MinIO server using the MinIO client.
/// </summary>
/// <param name="appSettings">The application settings, including MinIO configuration.</param>
/// <param name="isSecure">Flag indicating whether the connection should use SSL/TLS (default is false).</param>
public class MinioClientConnection(IOptions<AppSettings> appSettings)
{
    private readonly AppSettings _appSettings = appSettings.Value;

    /// <summary>
    /// Gets the expiration time (in seconds) for the MinIO presigned URL.
    /// </summary>
    public int Expiry
    {
        get => _appSettings.MinioSettings.Expiry;
    }

    public bool IsSecure
    {
        get => _appSettings.MinioSettings.Secure;
    }

    /// <summary>
    /// Gets the configured MinIO client for interacting with the MinIO server.
    /// </summary>
    public IMinioClient Client
    {
        get
        {
            var client = new MinioClient();

            if (!IsSecure)
            {
                client
                    .WithEndpoint("127.0.0.1:9000")
                    .WithCredentials("minioadmin", "minioadmin")
                    .Build();
            }
            else 
            {
                client
                    .WithEndpoint(_appSettings.MinioSettings.Endpoint)
                    .WithCredentials(_appSettings.MinioSettings.AccessKey, _appSettings.MinioSettings.SecretKey)
                    .WithSSL(IsSecure);
            }

            return client;
        }
    }
}
