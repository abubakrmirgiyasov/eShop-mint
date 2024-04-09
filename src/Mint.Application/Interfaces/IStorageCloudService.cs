using Microsoft.AspNetCore.Http;

namespace Mint.Application.Interfaces;

/// <summary>
/// Service for interacting with MinIO storage service.
/// </summary>
public interface IStorageCloudService
{
    /// <summary>
    /// Retrieves a pre-signed URL for downloading a file from the specified bucket.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="bucket"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<string?> GetFileLinkAsync(string name, string bucket, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves an array of pre-signed URLs for downloading multiple files from the specified bucket.
    /// </summary>
    /// <param name="names"></param>
    /// <param name="bucket"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<string[]> GetFilesLinkAsync(string[] names, string bucket, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new bucket with the specified name
    /// </summary>
    /// <param name="bucket"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> CreateBucketAsync(string bucket, CancellationToken cancellationToken = default);

    /// <summary>
    /// Uploads a file to the specified bucket.
    /// </summary>
    /// <param name="file"></param>
    /// <param name="name"></param>
    /// <param name="bucket"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<string> UploadFileAsync(IFormFile file, string name, string bucket, CancellationToken cancellationToken = default);

    /// <summary>
    /// Uploads a file from the provided stream.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<string> UploadFileAsync(Stream stream, CancellationToken cancellationToken = default);

    /// <summary>
    /// Uploads a file from the provided stream.
    /// </summary>
    /// <param name="file"></param>
    /// <param name="currentFileName"></param>
    /// <param name="newFileName"></param>
    /// <param name="bucket"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<string> UpdateFileAsync(IFormFile file, string currentFileName, string newFileName, string bucket, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a file from the specified bucket.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="bucket"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> DeleteFileAsync(string name, string bucket, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes multiple files from their respective buckets.
    /// </summary>
    /// <param name="names"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> DeleteFilesAsync(string[] names, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a bucket with the specified name.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> DeleteBucketAsync(string name, CancellationToken cancellationToken = default);

    /// <summary>
    /// Checks if a file with the specified name exists.
    /// </summary>
    /// <param name="bucket"></param>
    /// <param name="name"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> IsFileExists(string bucket, string name, CancellationToken cancellationToken = default);

    /// <summary>
    /// Checks if a bucket with the specified name exists.
    /// </summary>
    /// <param name="bucket"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<bool> IsBucketExists(string bucket, CancellationToken cancellationToken = default);
}
