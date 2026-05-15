using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Features.Hierarchy.Queries.IsLeaderInHierarchy;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.User.Commands.Photo;

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
            UPDATE type::thing('user', {request.Document}) SET photo_path = NONE;
        ", cancellationToken);

        return Unit.Value;
    }
}
