using JMMinistry.Application.Exceptions;
using JMMinistry.Application.Features.Hierarchy.Queries.IsLeaderInHierarchy;
using JMMinistry.Common.Dtos.Discipleship;
using Mediator;
using Microsoft.Extensions.Caching.Memory;
using SurrealDb.Net;
using System.Linq;

namespace JMMinistry.Application.Features.Discipleship.Commands.CreateNote
{
    public class CreateNoteHandler(ISurrealDbSession session, IMediator mediator, IMemoryCache cache)
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

            var result = await session.Query(@$"
                BEGIN TRANSACTION;
                
                LET $note = (CREATE journal_entry SET 
                    title = {request.Title}, 
                    content = {request.Description}, 
                    status = 'New', 
                    categories = {request.Categories},
                    created_at = time::now())[0];
                
                RELATE type::thing('user', {request.RequestorId})->authored->$note.id;
                RELATE $note.id->concerning->type::thing('user', {request.DiscipleId});
                
                COMMIT TRANSACTION;
                
                RETURN {{
                    note_id: $note.id,
                    title: $note.title,
                    description: $note.content,
                    note_status: $note.status,
                    created_at: $note.created_at,
                    categories: $note.categories,
                    disciple_id: type::thing('user', {request.DiscipleId}),
                    leader_id: type::thing('user', {request.RequestorId}),
                    entries: []
                }};
            ", cancellationToken);

            var noteDto = result.GetValue<DiscipleshipNoteDto>(0);

            cache.Remove($"discipleship-notes:{request.DiscipleId}");

            return noteDto;
        }
    }
}
