using JMMinistry.Application.Features.User.Dtos;
using Mediator;
using SurrealDb.Net;
using SurrealDb.Net.Models.Response;
using System.Linq;
using SurrealDb.Net.Models;

namespace JMMinistry.Application.Features.Cells.Commands.AddDisciples;

public class AddDisciplesHandler(ISurrealDbSession session) :
    ICommandHandler<AddDisciplesCommand, List<DiscipleDto>>
{
    public async ValueTask<List<DiscipleDto>> Handle(AddDisciplesCommand request, CancellationToken cancellationToken)
    {
        var cellId = RecordId.From("cell", request.CellId);

        var result = await session.Query(@$"
            {{
                LET $target_cell = {cellId};
                FOR $doc IN {request.Documents} {{
                    LET $user = type::record('user', $doc);
                    -- Remove from existing cells first if necessary (optional based on business rule)
                    DELETE disciple_in WHERE in = $user;
                    RELATE $user->disciple_in->$target_cell SET since = time::now();
                }};

                -- Return the updated list of disciples for this cell
                RETURN (SELECT *, (name + ' ' + last_name) AS full_name FROM user WHERE ->disciple_in.out CONTAINS $target_cell);
            }}
        ", cancellationToken);

        if (result.HasErrors)
        {
            var error = result.Errors.First();
            if (error is SurrealDbErrorResult errorRes)
                throw new Exception($"SurrealDB Error: {errorRes.Details}");

            throw new Exception($"SurrealDB Error: {error}");
        }

        var disciples = result.GetValue<List<DiscipleDto>>(0);

        return disciples ?? [];
    }
}
