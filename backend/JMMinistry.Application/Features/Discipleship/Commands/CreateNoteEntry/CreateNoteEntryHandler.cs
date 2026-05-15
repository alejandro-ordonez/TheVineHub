using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Features.Hierarchy.Queries.IsLeaderInHierarchy;
using JMMinistry.Common.Dtos.Discipleship;
using Mediator;
using Microsoft.Extensions.Caching.Memory;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.Discipleship.Commands.CreateNoteEntry
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

            var noteId = request.NoteId.StartsWith("journal_entry:") ? request.NoteId : $"journal_entry:{request.NoteId}";

            var result = await session.Query(@$"
                -- Verify note exists and concerns the disciple
                LET $note = (SELECT * FROM type::thing('journal_entry', {noteId}) WHERE ->concerning->(user WHERE id = type::thing('user', {request.DiscipleId})))[0];
                
                IF $note == NONE THEN
                    THROW 'Note not found or does not concern the given disciple';
                END;

                BEGIN TRANSACTION;
                
                LET $entry = (CREATE journal_entry_entry SET 
                    content = {request.Content}, 
                    date = {request.Date.ToUniversalTime()})[0];
                
                RELATE type::thing('user', {request.RequestorId})->authored->$entry.id;
                RELATE $entry.id->entry_of->type::thing('journal_entry', {noteId});
                
                COMMIT TRANSACTION;
                
                RETURN {{
                    id: $entry.id,
                    content: $entry.content,
                    date: $entry.date,
                    created_at: $entry.date, -- Or use a separate field if needed
                    note_id: type::thing('journal_entry', {noteId}),
                    author_id: type::thing('user', {request.RequestorId})
                }};
            ", cancellationToken);

            var entryDto = result.GetValue<DiscipleshipNoteEntryDto>(0);

            cache.Remove($"discipleship-notes:{request.DiscipleId}");

            return entryDto;
        }
    }
}
