using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Features.Hierarchy.Queries.IsLeaderInHierarchy;
using JMMinistry.Application.Features.Discipleship.Dtos;
using JMMinistry.Application.Features.Discipleship.Commands.CreateNote;
using JMMinistry.Application.Features.Discipleship.Commands.CreateNoteEntry;
using JMMinistry.Application.Features.Discipleship.Enums;
using Mediator;
using Microsoft.Extensions.Caching.Memory;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.Discipleship.Queries.GetDiscipleshipNotes
{
    public class GetDiscipleshipNotesHandler(ISurrealDbSession session, IMediator mediator, IMemoryCache cache)
        : IQueryHandler<GetDiscipleshipNotesQuery, IList<DiscipleshipNoteDto>>
    {
        public async ValueTask<IList<DiscipleshipNoteDto>> Handle(GetDiscipleshipNotesQuery request, CancellationToken cancellationToken)
        {
            var isLeader = await mediator.Send(new IsLeaderInHierarchyQuery
            {
                RequestorId = request.RequestorId,
                DiscipleId = request.DiscipleId
            }, cancellationToken);

            if (!isLeader)
                throw new NotAuthorizedException();

            var cacheKey = $"discipleship-notes:{request.DiscipleId}";

            if (cache.TryGetValue(cacheKey, out IList<DiscipleshipNoteDto>? cached) && cached is not null)
                return cached;

            var result = await session.Query(@$"
                SELECT
                    type::string(id) AS note_id,
                    title,
                    content AS description,
                    status AS note_status,
                    created_at,
                    categories,
                    type::string(target_disciple) AS disciple_id,
                    type::string(author) AS leader_id
                FROM journal_entry
                WHERE target_disciple = type::record('user', {request.DiscipleId})
                ORDER BY created_at DESC;
            ", cancellationToken);

            var notes = result.GetValue<List<DiscipleshipNoteDto>>(0);

            cache.Set(cacheKey, notes, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(5)
            });

            return notes ?? new List<DiscipleshipNoteDto>();
        }
    }
}
