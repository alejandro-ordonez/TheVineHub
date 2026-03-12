using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Extensions;
using JMMinistry.Application.Features.Hierarchy.Queries.IsLeaderInHierarchy;
using JMMinistry.Application.Services;
using JMMinistry.Domain;
using Mediator;
using Microsoft.AspNetCore.Identity;

namespace JMMinistry.Application.Features.User.Commands.Photo;

public class UploadPhotoHandler(
    IPhotoService photoService,
    UserManager<PersonalInfo> userManager,
    IMediator mediator)
    : ICommandHandler<UploadPhotoCommand, string>
{
    public async ValueTask<string> Handle(UploadPhotoCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Document)
            ?? throw new NotFoundException<PersonalInfo>(request.Document);

        if (request.RequestorId != request.Document)
        {
            var isLeader = await mediator.Send(new IsLeaderInHierarchyQuery
            {
                RequestorId = request.RequestorId,
                DiscipleId = request.Document
            }, cancellationToken);

            if (!isLeader)
                throw new NotAuthorizedException();
        }

        var photoPath = await photoService.SavePhotoAsync(request.Document, request.ImageStream);

        user.PhotoPath = photoPath;
        var result = await userManager.UpdateAsync(user);
        result.ThrowOnError();

        return photoPath;
    }
}
