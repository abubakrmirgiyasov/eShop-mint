using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Minio.DataModel.Args;
using Minio.Exceptions;
using Mint.Application.Interfaces;
using Mint.Domain.Common;
using Mint.Domain.Extensions;
using Mint.Domain.Models;
using Mint.Infrastructure.Helpers;

namespace Mint.Infrastructure.Services;

/// <inheritdoc cref="IStorageCloudService" />
public class StorageCloudService(
    IOptions<AppSettings> appSettings, 
    ILogger<StorageCloudService> logger
) : IStorageCloudService
{
    private readonly MinioClientConnection _minio = new(appSettings);
    private readonly ILogger<StorageCloudService> _logger = logger;

    /// <inheritdoc />
    public async Task<string[]> GetFilesLinkAsync(string[] names, string bucket, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        if (await IsBucketExists(bucket, cancellationToken))
        {
            var result = new List<string>();

            foreach (var name in names)
            {
                var link = await GetFileLinkAsync(name, bucket, cancellationToken);

                if (string.IsNullOrWhiteSpace(link))
                    continue;

                result.Add(link);
            }

            return [.. result];
        }

        return [];
    }

    /// <inheritdoc />
    public async Task<string?> GetFileLinkAsync(string name, string bucket, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            var getObjectArgs = new PresignedGetObjectArgs()
                .WithObject(name)
                .WithExpiry(_minio.Expiry)
                .WithBucket(bucket);

            return await _minio.Client.PresignedGetObjectAsync(getObjectArgs);
        }
        catch (ObjectNotFoundException)
        {
            return null;
        }
    }

    /// <inheritdoc />
    public async Task<bool> CreateBucketAsync(string bucket, CancellationToken cancellationToken = default)
    {
        try
        {
            var makeBucketArgs = new MakeBucketArgs().WithBucket(bucket);

            await _minio.Client.MakeBucketAsync(makeBucketArgs, cancellationToken);

            _logger.LogInformation("Bucket created successfully: {Bucket}", bucket);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }

    /// <inheritdoc />
    public async Task<string> UploadFileAsync(IFormFile file, string name, string bucket, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        try
        {
            if (await IsBucketExists(bucket, cancellationToken))
            {
                using var stream = file.OpenReadStream();

                var putObjectArgs = new PutObjectArgs()
                    .WithBucket(bucket)
                    .WithObject(name)
                    .WithObjectSize(file.Length)
                    .WithContentType(file.ContentType)
                    .WithStreamData(stream);

                var res = await _minio.Client.PutObjectAsync(putObjectArgs, cancellationToken);

                return res.ObjectName;
            }
            else
            {
                await CreateBucketAsync(bucket, cancellationToken);

                await UploadFileAsync(file, name, bucket, cancellationToken);

                return default!;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }

    /// <inheritdoc />
    public Task<string> UploadFileAsync(Stream stream, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task<List<Photo>> UploadFilesAsync(IFormFileCollection fileCollection, Guid id, string bucket, CancellationToken cancellationToken = default)
    {
        var res = new List<Photo>();

        foreach (var file in fileCollection)
        {
            var photoName = file.FileName.GeneratePhotoName(id);

            var link = await UploadFileAsync(file, photoName, bucket, cancellationToken);

            var photo = new Photo
            {
                Bucket = bucket,
                FileExtension = file.ContentType,
                FileName = photoName,
                FilePath = link,
                FileSize = file.Length,
            };

            res.Add(photo);
        }

        _logger.LogInformation("Добавлен список файлов в MinIO: " +
            "\n\t Bucket - {Bucket}," +
            "\n\t Names - {Names}", 
            bucket, 
            string.Format("\n\t", res.ToArray())
        );

        return res;
    }

    /// <inheritdoc />
    public async Task<string> UpdateFileAsync(IFormFile file, string currentFileName, string newFileName, string bucket, CancellationToken cancellationToken = default)
    {
        try
        {
            var isFileExists = await IsFileExists(bucket, currentFileName, cancellationToken);

            string res = "";
            if (isFileExists)
            {
                await DeleteFileAsync(currentFileName, bucket, cancellationToken);

                res = await UploadFileAsync(file, newFileName, bucket, cancellationToken);
            }
            else
            {
                res = await UploadFileAsync(file, newFileName, bucket, cancellationToken);
            }

            return res;
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }

    /// <inheritdoc />
    public Task<bool> DeleteBucketAsync(string name, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task<bool> DeleteFileAsync(string name, string bucket, CancellationToken cancellationToken = default)
    {
        try
        {
            var removeObjectArgs = new RemoveObjectArgs()
                .WithBucket(bucket)
                .WithObject(name);

            await _minio.Client.RemoveObjectAsync(removeObjectArgs, cancellationToken);

            _logger.LogInformation("Successfully Removed: {Bucket}/{Name}", bucket, name);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }

    /// <inheritdoc />
    public Task<bool> DeleteFilesAsync(string[] names, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public async Task<bool> IsFileExists(string bucket, string name, CancellationToken cancellationToken = default)
    {
        try
        {
            var file = await GetFileLinkAsync(name, bucket, cancellationToken);
            return !string.IsNullOrEmpty(file);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }

    /// <inheritdoc />
    public async Task<bool> IsBucketExists(string bucket, CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
            return false;

        try
        {
            var args = new BucketExistsArgs().WithBucket(bucket);
            return await _minio.Client.BucketExistsAsync(args, cancellationToken);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
