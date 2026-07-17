using TheVineHub.API.Configuration.Exceptions;
using TheVineHub.API.Features.Hierarchy.IsLeaderInHierarchy;
using TheVineHub.API.Features.Discipleship;
using TheVineHub.API.Features.Discipleship.CreateNote;
using TheVineHub.API.Features.Discipleship.CreateNoteEntry;
using TheVineHub.API.Features.Discipleship;
using Mediator;
using Microsoft.Extensions.Caching.Memory;
using SurrealDb.Net;
using SurrealDb.Net.Models.Response;
using System.Linq;
using SurrealDb.Net.Models;

namespace TheVineHub.API.Features.Discipleship.CreateNote
{
    public class CreateNoteHandler(ISurrealDbSession session, IMediator mediator, IMemoryCache cache)
        : ICommandHandler<CreateNoteCommand, DiscipleshipNoteDto>
    {
        public async ValueTask<DiscipleshipNoteDto> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var isLeader = await mediator.Send(new IsLeaderInHierarchyQuery
            {
                RequestorId = request.RequestorId,
                DiscipleId = request.DiscipleId
            }, cancellationToken);

            if (!isLeader)
                throw new NotAuthorizedException();

            var requestorId = RecordId.From("user", request.RequestorId);
            var discipleId = RecordId.From("user", request.DiscipleId);

            var result = await session.Query(@$"
                {{
                    LET $note = (CREATE journal_entry SET
                        title = {request.Title},
                        content = {request.Description},
                        status = 'New',
                        categories = {request.Categories},
                        author = {requestorId},
                        target_disciple = {discipleId},
                        created_at = time::now())[0];

                    RETURN {{
                        note_id: type::string($note.id),
                        title: $note.title,
                        description: $note.content,
                        note_status: $note.status,
                        created_at: $note.created_at,
                        categories: $note.categories,
                        disciple_id: type::string({discipleId}),
                        leader_id: type::string({requestorId}),
                        entries: []
                    }};
                }}
            ", cancellationToken);

            if (result.HasErrors)
            {
                var error = result.Errors.First();
                if (error is SurrealDbErrorResult errorRes)
                    throw new Exception($"SurrealDB Error: {errorRes.Details}");

                throw new Exception($"SurrealDB Error: {error}");
            }

            var noteDto = result.GetValue<DiscipleshipNoteDto>(0) ?? throw new Exception("Unexpected null from DB");

            cache.Remove($"discipleship-notes:{request.DiscipleId}");

            return noteDto;
        }
    }
}
