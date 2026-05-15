using JMMinistry.Application.Services;
using Mediator;

namespace JMMinistry.Application.Features.User.Commands.Photo;

public class UploadTempPhotoHandler(IPhotoService photoService)
    : ICommandHandler<UploadTempPhotoCommand, string>
{
    public ValueTask<string> Handle(UploadTempPhotoCommand request, CancellationToken cancellationToken)
    {
        return ValueTask.FromResult("");
    }
}
