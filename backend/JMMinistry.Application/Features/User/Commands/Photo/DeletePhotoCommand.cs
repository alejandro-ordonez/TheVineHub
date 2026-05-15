using Mediator;

namespace JMMinistry.Application.Features.User.Commands.Photo;

public class DeletePhotoCommand : ICommand
{
    public required string RequestorId { get; set; }
    public required string Document { get; set; }
}
