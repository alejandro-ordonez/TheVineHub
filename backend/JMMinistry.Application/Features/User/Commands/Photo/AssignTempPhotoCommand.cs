using Mediator;

namespace JMMinistry.Application.Features.User.Commands.Photo;

public class AssignTempPhotoCommand : ICommand<string>
{
    public required string RequestorId { get; set; }
    public required string Document { get; set; }
    public required string TempId { get; set; }
}
