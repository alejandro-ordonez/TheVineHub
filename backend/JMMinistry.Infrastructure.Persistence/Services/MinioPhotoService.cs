using JMMinistry.Application.Services;
using Microsoft.Extensions.Configuration;
using Minio;
using Minio.DataModel.Args;

namespace JMMinistry.Infrastructure.Persistence.Services;

public class MinioPhotoService : IPhotoService
{
    private readonly IMinioClient _minioClient;
    private readonly string _bucketName;

    public MinioPhotoService(IConfiguration configuration)
    {
        var endpoint = configuration["Minio:Endpoint"] ?? "localhost:9000";
        var accessKey = configuration["Minio:AccessKey"] ?? "minioadmin";
        var secretKey = configuration["Minio:SecretKey"] ?? "minioadmin";
        _bucketName = configuration["Minio:BucketName"] ?? "jm-ministry";

        _minioClient = new MinioClient()
            .WithEndpoint(endpoint)
            .WithCredentials(accessKey, secretKey)
            .Build();
    }

    public async Task<string> GetUploadUrlAsync(string objectName)
    {
        await EnsureBucketExistsAsync();

        var args = new PresignedPutObjectArgs()
            .WithBucket(_bucketName)
            .WithObject(objectName)
            .WithExpiry(600); // 10 minutes

        return await _minioClient.PresignedPutObjectAsync(args);
    }

    public async Task<string> GetDownloadUrlAsync(string objectName)
    {
        var args = new PresignedGetObjectArgs()
            .WithBucket(_bucketName)
            .WithObject(objectName)
            .WithExpiry(3600); // 1 hour

        return await _minioClient.PresignedGetObjectAsync(args);
    }

    private async Task EnsureBucketExistsAsync()
    {
        var beArgs = new BucketExistsArgs().WithBucket(_bucketName);
        bool found = await _minioClient.BucketExistsAsync(beArgs);
        if (!found)
        {
            var mbArgs = new MakeBucketArgs().WithBucket(_bucketName);
            await _minioClient.MakeBucketAsync(mbArgs);
        }
    }
}
