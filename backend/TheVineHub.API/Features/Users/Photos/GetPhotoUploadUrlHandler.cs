using TheVineHub.API.Infrastructure.Storage;
using Mediator;

namespace TheVineHub.API.Features.Users.Photos;

public class GetPhotoUploadUrlHandler(IPhotoService photoService) : ICommandHandler<GetPhotoUploadUrlCommand, string>
{
    public async ValueTask<string> Handle(GetPhotoUploadUrlCommand request, CancellationToken cancellationToken)
    {
        // We could generate a unique name here or use the one provided
        var uniqueFileName = $"photos/{Guid.NewGuid():N}_{request.FileName}";
        return await photoService.GetUploadUrlAsync(uniqueFileName);
    }
}
