namespace TheVineHub.API.Infrastructure.Storage;

public interface IPhotoService
{
    Task<string> GetUploadUrlAsync(string objectName);
    Task<string> GetDownloadUrlAsync(string objectName);
}
