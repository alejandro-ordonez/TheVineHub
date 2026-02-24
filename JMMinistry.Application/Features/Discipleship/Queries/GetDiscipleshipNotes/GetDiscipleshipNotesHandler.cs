using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Features.Hierarchy.Queries.IsLeaderInHierarchy;
using JMMinistry.Application.Mappers;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.Discipleship;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace JMMinistry.Application.Features.Discipleship.Queries.GetDiscipleshipNotes
{
    public class GetDiscipleshipNotesHandler(IJmDbContext dbContext, AppMapper mapper, IMediator mediator, IMemoryCache cache)
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

            var notes = await dbContext.DiscipleshipNotes
                .Where(n => n.DiscipleId == request.DiscipleId)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync(cancellationToken);

            var result = mapper.DiscipleshipNoteListToDiscipleshipNoteDtoList(notes);

            cache.Set(cacheKey, result, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(5)
            });

            return result;
        }
    }
}
