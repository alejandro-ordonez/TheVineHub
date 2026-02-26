using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Features.Hierarchy.Queries.IsLeaderInHierarchy;
using JMMinistry.Application.Mappers;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.Discipleship;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace JMMinistry.Application.Features.Discipleship.Queries.GetDiscipleshipNoteById
{
    public class GetDiscipleshipNoteByIdHandler(IJmDbContext dbContext, AppMapper mapper, IMediator mediator, IMemoryCache cache)
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

            var note = await dbContext.DiscipleshipNotes
                .FirstOrDefaultAsync(n => n.Id == request.NoteId && n.DiscipleId == request.DiscipleId, cancellationToken)
                ?? throw new NotFoundException<DiscipleshipNoteDto>($"{request.NoteId}");

            var result = mapper.DiscipleshipNoteToDiscipleshipNoteDto(note);

            cache.Set(cacheKey, result, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(5)
            });

            return result;
        }
    }
}
