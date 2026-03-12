using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Extensions;
using JMMinistry.Application.Features.Hierarchy.Queries.IsLeaderInHierarchy;
using JMMinistry.Application.Services;
using JMMinistry.Domain;
using Mediator;
using Microsoft.AspNetCore.Identity;

namespace JMMinistry.Application.Features.User.Commands.Photo;

public class AssignTempPhotoHandler(
    IPhotoService photoService,
    UserManager<PersonalInfo> userManager,
    IMediator mediator)
    : ICommandHandler<AssignTempPhotoCommand, string>
{
    public async ValueTask<string> Handle(AssignTempPhotoCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Document)
            ?? throw new NotFoundException<PersonalInfo>(request.Document);

        if (request.RequestorId != request.Document && user.CellId is not null)
        {
            var isLeader = await mediator.Send(new IsLeaderInHierarchyQuery
            {
                RequestorId = request.RequestorId,
                DiscipleId = request.Document
            }, cancellationToken);

            if (!isLeader)
                throw new NotAuthorizedException();
        }

        var photoPath = photoService.AssignTempPhoto(request.TempId, request.Document);

        user.PhotoPath = photoPath;
        var result = await userManager.UpdateAsync(user);
        result.ThrowOnError();

        return photoPath;
    }
}
