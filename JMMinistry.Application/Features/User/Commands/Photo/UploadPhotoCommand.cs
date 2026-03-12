using Mediator;

namespace JMMinistry.Application.Features.User.Commands.Photo;

public class UploadPhotoCommand : ICommand<string>
{
    public required string RequestorId { get; set; }
    public required string Document { get; set; }
    public required Stream ImageStream { get; set; }
}
