using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Features.Hierarchy.Queries.IsLeaderInHierarchy;
using JMMinistry.Application.Mappers;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.Discipleship;
using JMMinistry.Domain.Discipleship;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace JMMinistry.Application.Features.Discipleship.Commands.CreateNoteEntry
{
    public class CreateNoteEntryHandler(IJmDbContext dbContext, AppMapper mapper, IMediator mediator, IMemoryCache cache)
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

            var noteExists = await dbContext.DiscipleshipNotes
                .AnyAsync(n => n.Id == request.NoteId && n.DiscipleId == request.DiscipleId, cancellationToken);

            if (!noteExists)
                throw new NotFoundException<DiscipleshipNoteDto>($"{request.NoteId}");

            var entry = new DiscipleshipNoteEntry
            {
                Content = request.Content,
                Date = DateTime.SpecifyKind(request.Date, DateTimeKind.Utc),
                NoteId = request.NoteId,
                AuthorId = request.RequestorId
            };

            dbContext.DiscipleshipNoteEntries.Add(entry);
            await dbContext.SaveChangesAsync(cancellationToken);

            cache.Remove($"discipleship-notes:{request.DiscipleId}");

            return mapper.DiscipleshipNoteEntryToDto(entry);
        }
    }
}
