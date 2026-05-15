using JMMinistry.Common.Dtos.User;
using Mediator;
using SurrealDb.Net;

namespace JMMinistry.Application.Features.Cells.Commands.AddDisciples;

public class AddDisciplesHandler(ISurrealDbSession session) :
    ICommandHandler<AddDisciplesCommand, List<DiscipleDto>>
{
    public async ValueTask<List<DiscipleDto>> Handle(AddDisciplesCommand request, CancellationToken cancellationToken)
    {
        var result = await session.Query(@$"
            BEGIN TRANSACTION;
            
            FOR $doc IN {request.Documents} {{
                LET $user = type::thing('user', $doc);
                -- Remove from existing cells first if necessary (optional based on business rule)
                DELETE disciple_in WHERE in = $user;
                RELATE $user->disciple_in->type::thing('cell', {request.CellId}) SET since = time::now();
            }};
            
            COMMIT TRANSACTION;
            
            -- Return the updated list of disciples for this cell
            RETURN(SELECT in.* FROM disciple_in WHERE out = type::thing('cell', {request.CellId}));
        ", cancellationToken);

        var disciples = result.GetValue<List<DiscipleDto>>(0);

        return disciples ?? [];
    }
}
