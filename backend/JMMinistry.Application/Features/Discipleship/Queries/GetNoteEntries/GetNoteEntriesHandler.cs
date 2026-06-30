using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Features.Hierarchy.Queries.IsLeaderInHierarchy;
using JMMinistry.Application.Features.Discipleship.Dtos;
using JMMinistry.Application.Features.Discipleship.Commands.CreateNote;
using JMMinistry.Application.Features.Discipleship.Commands.CreateNoteEntry;
using JMMinistry.Application.Features.Discipleship.Enums;
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

            var rawNoteId = request.NoteId.StartsWith("journal_entry:") ? request.NoteId["journal_entry:".Length..] : request.NoteId;

            var result = await session.Query(@$"
                SELECT
                    type::string(id) AS id,
                    content,
                    created_at AS date,
                    created_at,
                    type::string(parent_entry) AS note_id,
                    type::string(author) AS author_id
                FROM journal_entry
                WHERE parent_entry = type::record('journal_entry', {rawNoteId})
                ORDER BY created_at DESC;
            ", cancellationToken);

            var entries = result.GetValue<List<DiscipleshipNoteEntryDto>>(0);

            return entries ?? new List<DiscipleshipNoteEntryDto>();
        }
    }
}
