using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Extensions;
using JMMinistry.Application.Features.Hierarchy.Queries.IsLeaderInHierarchy;
using JMMinistry.Application.Services;
using JMMinistry.Domain;
using Mediator;
using Microsoft.AspNetCore.Identity;

namespace JMMinistry.Application.Features.User.Commands.Photo;

public class DeletePhotoHandler(
    IPhotoService photoService,
    UserManager<PersonalInfo> userManager,
    IMediator mediator)
    : ICommandHandler<DeletePhotoCommand>
{
    public async ValueTask<Unit> Handle(DeletePhotoCommand request, CancellationToken cancellationToken)
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

        photoService.DeletePhoto(request.Document);

        user.PhotoPath = null;
        var result = await userManager.UpdateAsync(user);
        result.ThrowOnError();

        return Unit.Value;
    }
}
