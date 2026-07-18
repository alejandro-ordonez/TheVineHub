using TheVineHub.API.Configuration.Exceptions;
using TheVineHub.API.Features.Hierarchy.IsLeaderInHierarchy;
using TheVineHub.API.Features.Discipleship;
using TheVineHub.API.Features.Discipleship.CreateNote;
using TheVineHub.API.Features.Discipleship.CreateNoteEntry;
using TheVineHub.API.Features.Discipleship;
using Mediator;
using Microsoft.Extensions.Caching.Memory;
using SurrealDb.Net;
using System.Linq;
using SurrealDb.Net.Models.Response;

namespace TheVineHub.API.Features.Discipleship.CreateNoteEntry
{
    public class CreateNoteEntryHandler(ISurrealDbSession session, IMediator mediator, IMemoryCache cache)
        : ICommandHandler<CreateNoteEntryCommand, DiscipleshipNoteEntryDto>
    {
        public async ValueTask<DiscipleshipNoteEntryDto> Handle(CreateNoteEntryCommand request, CancellationToken cancellationToken)
        {
            var isLeader = await mediator.Send(new IsLeaderInHierarchyQuery
            {
                RequestorId = request.RequestorId,
                DiscipleId = request.DiscipleId
            }, cancellationToken);

            if (!isLeader)
                throw new NotAuthorizedException();

            var rawNoteId = request.NoteId.StartsWith("journal_entry:") ? request.NoteId["journal_entry:".Length..] : request.NoteId;

            var result = await session.Query(@$"
                {{
                    -- Verify note exists and concerns the disciple
                    LET $note = (SELECT * FROM type::record('journal_entry', {rawNoteId}) WHERE target_disciple = type::record('user', {request.DiscipleId}))[0];
 
                    IF $note == NONE THEN
                        THROW 'Note not found or does not concern the given disciple';
                    END;
 
                    LET $entry = (CREATE journal_entry SET
                        title = '',
                        content = {request.Content},
                        status = $note.status,
                        categories = [],
                        author = type::record('user', {request.RequestorId}),
                        target_disciple = type::record('user', {request.DiscipleId}),
                        parent_entry = type::record('journal_entry', {rawNoteId}),
                        created_at = {request.Date.ToUniversalTime()})[0];
 
                    RETURN {{
                        id: type::string($entry.id),
                        content: $entry.content,
                        date: $entry.created_at,
                        created_at: $entry.created_at,
                        note_id: type::string(type::record('journal_entry', {rawNoteId})),
                        author_id: type::string(type::record('user', {request.RequestorId}))
                    }};
                }}
            ", cancellationToken);

            if (result.HasErrors)
            {
                var error = result.Errors.First();
                if (error is SurrealDbErrorResult errorRes)
                    throw new TheVineHub.API.Configuration.Exceptions.DatabaseExecutionException($"SurrealDB Error: {errorRes.Details}");

                throw new TheVineHub.API.Configuration.Exceptions.DatabaseExecutionException($"SurrealDB Error: {error}");
            }

            var entryDto = result.GetValue<DiscipleshipNoteEntryDto>(0) ?? throw new Exception("Unexpected null from DB");

            cache.Remove($"discipleship-notes:{request.DiscipleId}");

            return entryDto;
        }
    }
}
