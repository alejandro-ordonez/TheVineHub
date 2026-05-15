namespace JMMinistry.Application.Services;

public interface IPhotoService
{
    Task<string> GetUploadUrlAsync(string objectName);
    Task<string> GetDownloadUrlAsync(string objectName);
}
