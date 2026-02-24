using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Features.Hierarchy.Queries.IsLeaderInHierarchy;
using JMMinistry.Application.Mappers;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.Discipleship;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace JMMinistry.Application.Features.Discipleship.Queries.GetNoteEntries
{
    public class GetNoteEntriesHandler(IJmDbContext dbContext, AppMapper mapper, IMediator mediator)
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

            var entries = await dbContext.DiscipleshipNoteEntries
                .Where(e => e.NoteId == request.NoteId)
                .OrderByDescending(e => e.Date)
                .ToListAsync(cancellationToken);

            return mapper.DiscipleshipNoteEntryListToDtoList(entries);
        }
    }
}
