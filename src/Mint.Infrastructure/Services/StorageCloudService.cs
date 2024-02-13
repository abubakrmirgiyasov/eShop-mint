﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Minio.DataModel.Args;
using Mint.Infrastructure.Helpers;
using Mint.Infrastructure.Services.Interfaces;

namespace Mint.Infrastructure.Services;

public class StorageCloudService(
    MinioClientConnection minioClient, 
    ILogger<StorageCloudService> logger) : IStorageCloudService
{
    private readonly MinioClientConnection _minio = minioClient;
    private readonly ILogger<StorageCloudService> _logger = logger;

    public Task<string[]> GetFilesLinkAsync(string[] names, string bucket, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<string> GetFileLinkAsync(string name, string bucket, CancellationToken cancellationToken = default)
    {
        if (cancellationToken.IsCancellationRequested)
            return "";

        try
        {
            var getObjectArgs = new PresignedGetObjectArgs()
                .WithObject(name)
                .WithExpiry(_minio.Expiry)
                .WithBucket(bucket);

            return await _minio.Client.PresignedGetObjectAsync(getObjectArgs);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }

    public Task<bool> CreateBucketAsync(string bucket, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<string> UploadFileAsync(IFormFile file, string bucket, CancellationToken cancellationToken = default)
    {
        try
        {
            using var stream = file.OpenReadStream();

            var putObjectArgs = new PutObjectArgs()
                .WithBucket(bucket)
                .WithObject(file.FileName)
                .WithObjectSize(file.Length)
                .WithContentType(file.ContentType)
                .WithStreamData(stream);

            var res = await _minio.Client.PutObjectAsync(putObjectArgs, cancellationToken);

            return res.ToString()!;
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception Message: {Message}. \n Inner Exception: {Inner}", ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }
    }

    public Task<string> UploadFileAsync(Stream stream, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteBucketAsync(string name, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteFileAsync(string name, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteFilesAsync(string[] names, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsBucketExist(string bucket, CancellationToken cancellationToken = default)
    {
        try
        {
            var args = new BucketExistsArgs().WithBucket(bucket);

            await _minio.Client.BucketExistsAsync(args, cancellationToken);
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message, ex);
        }
    }
}
