using System.Text.Json;
using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Features.Hierarchy.Queries.IsLeaderInHierarchy;
using JMMinistry.Application.Mappers;
using JMMinistry.Application.Services;
using JMMinistry.Common.Dtos.Discipleship;
using JMMinistry.Domain.Discipleship;
using Mediator;
using Microsoft.Extensions.Caching.Memory;

namespace JMMinistry.Application.Features.Discipleship.Commands.CreateNote
{
    public class CreateNoteHandler(IJmDbContext dbContext, AppMapper mapper, IMediator mediator, IMemoryCache cache)
        : ICommandHandler<CreateNoteCommand, DiscipleshipNoteDto>
    {
        public async ValueTask<DiscipleshipNoteDto> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var isLeader = await mediator.Send(new IsLeaderInHierarchyQuery
            {
                RequestorId = request.RequestorId,
                DiscipleId = request.DiscipleId
            }, cancellationToken);

            if (!isLeader)
                throw new NotAuthorizedException();

            var note = new DiscipleshipNote
            {
                Title = request.Title,
                Description = request.Description,
                Status = Domain.Discipleship.NoteStatus.New,
                Categories = JsonSerializer.Serialize(request.Categories),
                DiscipleId = request.DiscipleId,
                LeaderId = request.RequestorId
            };

            dbContext.DiscipleshipNotes.Add(note);
            await dbContext.SaveChangesAsync(cancellationToken);

            cache.Remove($"discipleship-notes:{request.DiscipleId}");

            return mapper.DiscipleshipNoteToDiscipleshipNoteDto(note);
        }
    }
}
