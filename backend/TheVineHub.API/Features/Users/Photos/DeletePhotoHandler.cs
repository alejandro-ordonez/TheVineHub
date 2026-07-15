using TheVineHub.API.Configuration.Exceptions;
using TheVineHub.API.Features.Hierarchy.IsLeaderInHierarchy;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace TheVineHub.API.Features.Users.Photos;

public class DeletePhotoHandler(
    ISurrealDbSession session,
    IMediator mediator)
    : ICommandHandler<DeletePhotoCommand>
{
    public async ValueTask<Unit> Handle(DeletePhotoCommand request, CancellationToken cancellationToken)
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

        // In the new Presigned URL pattern, we might not need to manually delete from MinIO
        // if we just overwrite or use object lifecycle policies.
        // However, we should at least clear the reference in SurrealDB.

        var result = await session.Query(@$"
            UPDATE type::record('user', {request.Document}) SET photo_path = NONE;
        ", cancellationToken);

        return Unit.Value;
    }
}
