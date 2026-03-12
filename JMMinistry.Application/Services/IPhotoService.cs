namespace JMMinistry.Application.Services;

public interface IPhotoService
{
    Task<string> SavePhotoAsync(string document, Stream imageStream);
    Task<string> SaveTempPhotoAsync(Stream imageStream);
    string AssignTempPhoto(string tempId, string document);
    void DeletePhoto(string document);
}
