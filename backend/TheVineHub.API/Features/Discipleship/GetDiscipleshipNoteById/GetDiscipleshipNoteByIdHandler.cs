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

namespace TheVineHub.API.Features.Discipleship.GetDiscipleshipNoteById
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

            var rawNoteId = request.NoteId.StartsWith("journal_entry:") ? request.NoteId["journal_entry:".Length..] : request.NoteId;

            var result = await session.Query(@$"
                SELECT
                    type::string(id) AS note_id,
                    title,
                    content AS description,
                    status AS note_status,
                    created_at,
                    categories,
                    type::string(target_disciple) AS disciple_id,
                    type::string(author) AS leader_id,
                    (SELECT type::string(id) AS id, content, created_at AS date, created_at, type::string(parent_entry) AS note_id, type::string(author) AS author_id FROM journal_entry WHERE parent_entry = $parent.id) AS entries
                FROM type::record('journal_entry', {rawNoteId})
                WHERE target_disciple = type::record('user', {request.DiscipleId});
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
