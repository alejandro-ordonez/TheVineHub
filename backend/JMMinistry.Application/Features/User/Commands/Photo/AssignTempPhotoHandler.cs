using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Features.Hierarchy.Queries.IsLeaderInHierarchy;
using JMMinistry.Application.Services;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.User.Commands.Photo;

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
            UPDATE type::thing('user', {request.Document}) SET photo_path = {photoPath};
        ", cancellationToken);

        return photoPath;
    }
}
