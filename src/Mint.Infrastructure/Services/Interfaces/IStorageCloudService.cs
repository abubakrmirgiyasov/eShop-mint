using Microsoft.AspNetCore.Http;

namespace Mint.Infrastructure.Services.Interfaces;

/// <summary>
/// Base Interface to work with MinIO
/// </summary>
public interface IStorageCloudService
{
    Task<string> GetFileLinkAsync(string name, string bucket, CancellationToken cancellationToken = default);

    Task<string[]> GetFilesLinkAsync(string[] names, string bucket, CancellationToken cancellationToken = default);

    Task<bool> CreateBucketAsync(string bucket, CancellationToken cancellationToken = default);

    Task<string> UploadFileAsync(IFormFile file, string bucket,  CancellationToken cancellationToken = default);

    Task<string> UploadFileAsync(Stream stream, CancellationToken cancellationToken = default);

    Task<bool> DeleteFileAsync(string name, CancellationToken cancellationToken = default);

    Task<bool> DeleteFilesAsync(string[] names, CancellationToken cancellationToken = default);

    Task<bool> DeleteBucketAsync(string name, CancellationToken cancellationToken = default);
}
