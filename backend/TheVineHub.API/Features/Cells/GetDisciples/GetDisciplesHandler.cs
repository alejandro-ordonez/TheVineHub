using TheVineHub.API.Features.Users;
using TheVineHub.API.Features.Users.Authenticate;
using TheVineHub.API.Features.Users.CreateUser;
using TheVineHub.API.Features.Users.MarryLeaders;
using TheVineHub.API.Configuration.Exceptions;
using Mediator;
using SurrealDb.Net;
using System.Linq;

using TheVineHub.API.Features.Users;

namespace TheVineHub.API.Features.Cells.GetDisciples
{
    public class GetDisciplesHandler(ISurrealDbSession session)
        : IQueryHandler<GetDisciplesQuery, IEnumerable<DiscipleDto>>
    {
        public async ValueTask<IEnumerable<DiscipleDto>> Handle(GetDisciplesQuery request, CancellationToken cancellationToken)
        {
            var cellId = request.CellId.StartsWith("cell:") ? request.CellId : $"cell:{request.CellId}";
            var requestorId = request.RequestorId.StartsWith("user:") ? request.RequestorId : $"user:{request.RequestorId}";

            // Optimization: check authorization and fetch disciples in one go
            // Inside GetDisciplesHandler.cs
            var result = await session.Query(@$"
                -- Corrected test with string-ID matching
                LET $me = type::record('user', {request.RequestorId});
                LET $target_cell = type::record('cell', {request.CellId});

                IF !fn::can_view_cell_disciples($me, $target_cell) THEN
                    THROW 'Not authorized to view disciples of this cell';
                END;

                RETURN (
                    SELECT 
                        id, 
                        full_name, 
                        phone,
                        gender,
                        photo_path,
                        $target_cell as cell_id,
                        (->disciple_in[WHERE out = $target_cell].since)[0] AS member_since
                    FROM user 
                    WHERE ->disciple_in.out CONTAINS $target_cell
                );
            ", cancellationToken);


            var disciples = result.GetValue<IEnumerable<DiscipleDto>>(3);

            return disciples ?? [];
        }
    }
}
