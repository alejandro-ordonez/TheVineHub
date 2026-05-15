using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Features.Hierarchy.Queries.IsLeaderInHierarchy;
using JMMinistry.Common.Dtos.Discipleship;
using Mediator;
using Microsoft.Extensions.Caching.Memory;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.Discipleship.Queries.GetDiscipleshipNoteById
{
    public class GetDiscipleshipNoteByIdHandler(ISurrealDbSession session, IMediator mediator, IMemoryCache cache)
        : IQueryHandler<GetDiscipleshipNoteByIdQuery, DiscipleshipNoteDto>
    {
        public async ValueTask<DiscipleshipNoteDto> Handle(GetDiscipleshipNoteByIdQuery request, CancellationToken cancellationToken)
        {
            var isLeader = await mediator.Send(new IsLeaderInHierarchyQuery
            {
                RequestorId = request.RequestorId,
                DiscipleId = request.DiscipleId
            }, cancellationToken);

            if (!isLeader)
                throw new NotAuthorizedException();

            var cacheKey = $"discipleship-note:{request.DiscipleId}:{request.NoteId}";

            if (cache.TryGetValue(cacheKey, out DiscipleshipNoteDto? cached) && cached is not null)
                return cached;

            var noteId = request.NoteId.StartsWith("journal_entry:") ? request.NoteId : $"journal_entry:{request.NoteId}";

            var result = await session.Query(@$"
                SELECT 
                    id AS note_id,
                    title,
                    content AS description,
                    status AS note_status,
                    created_at,
                    categories,
                    (SELECT VALUE out FROM ->concerning)[0] AS disciple_id,
                    (SELECT VALUE in FROM <-authored)[0] AS leader_id,
                    (SELECT *, id AS id, author AS author_id FROM journal_entry_entry WHERE id IN (SELECT VALUE in FROM <-entry_of WHERE out = $parent.id)) AS entries
                FROM type::thing('journal_entry', {noteId})
                WHERE ->concerning->(user WHERE id = type::thing('user', {request.DiscipleId}));
            ", cancellationToken);


            var note = result.GetValue<List<DiscipleshipNoteDto>>(0)?.FirstOrDefault()
                ?? throw new NotFoundException<DiscipleshipNoteDto>(request.NoteId);

            cache.Set(cacheKey, note, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(5)
            });

            return note;
        }
    }
}
