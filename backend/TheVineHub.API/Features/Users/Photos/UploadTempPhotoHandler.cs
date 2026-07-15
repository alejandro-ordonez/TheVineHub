using TheVineHub.API.Infrastructure.Storage;
using Mediator;

namespace TheVineHub.API.Features.Users.Photos;

public class UploadTempPhotoHandler(IPhotoService photoService)
    : ICommandHandler<UploadTempPhotoCommand, string>
{
    public ValueTask<string> Handle(UploadTempPhotoCommand request, CancellationToken cancellationToken)
    {
        return ValueTask.FromResult("");
    }
}
