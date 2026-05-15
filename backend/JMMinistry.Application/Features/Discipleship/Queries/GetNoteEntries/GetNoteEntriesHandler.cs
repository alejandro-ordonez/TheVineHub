using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Features.Hierarchy.Queries.IsLeaderInHierarchy;
using JMMinistry.Common.Dtos.Discipleship;
using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.Discipleship.Queries.GetNoteEntries
{
    public class GetNoteEntriesHandler(ISurrealDbSession session, IMediator mediator)
        : IQueryHandler<GetNoteEntriesQuery, IList<DiscipleshipNoteEntryDto>>
    {
        public async ValueTask<IList<DiscipleshipNoteEntryDto>> Handle(GetNoteEntriesQuery request, CancellationToken cancellationToken)
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
                SELECT 
                    id,
                    content,
                    date,
                    date AS created_at,
                    (SELECT VALUE out FROM ->entry_of)[0] AS note_id,
                    (SELECT VALUE in FROM <-authored)[0] AS author_id
                FROM journal_entry_entry 
                WHERE id IN (SELECT VALUE in FROM entry_of WHERE out = type::thing('journal_entry', {noteId}))
                ORDER BY date DESC;
            ", cancellationToken);

            var entries = result.GetValue<List<DiscipleshipNoteEntryDto>>(0);

            return entries ?? new List<DiscipleshipNoteEntryDto>();
        }
    }
}
