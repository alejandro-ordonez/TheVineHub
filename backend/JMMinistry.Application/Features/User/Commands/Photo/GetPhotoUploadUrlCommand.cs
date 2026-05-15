using Mediator;

namespace JMMinistry.Application.Features.User.Commands.Photo;

public class GetPhotoUploadUrlCommand : ICommand<string>
{
    public string FileName { get; set; } = string.Empty;
}
