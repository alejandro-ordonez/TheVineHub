using TheVineHub.API.Configuration.Exceptions;
using TheVineHub.API.Features.Hierarchy.IsLeaderInHierarchy;
using TheVineHub.API.Infrastructure.Storage;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace TheVineHub.API.Features.Users.Photos;

public class AssignTempPhotoHandler(
    IPhotoService photoService,
    ISurrealDbSession session,
    IMediator mediator)
    : ICommandHandler<AssignTempPhotoCommand, string>
{
    public async ValueTask<string> Handle(AssignTempPhotoCommand request, CancellationToken cancellationToken)
    {
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

        string photoPath = string.Empty;

        var result = await session.Query(@$"
            UPDATE type::record('user', {request.Document}) SET photo_path = {photoPath};
        ", cancellationToken);

        return photoPath;
    }
}
