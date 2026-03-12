using Mediator;

namespace JMMinistry.Application.Features.User.Commands.Photo;

public class UploadTempPhotoCommand : ICommand<string>
{
    public required Stream ImageStream { get; set; }
}
