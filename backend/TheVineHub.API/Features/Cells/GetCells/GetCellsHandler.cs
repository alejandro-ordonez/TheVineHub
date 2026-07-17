using TheVineHub.API.Features.Cells;
using TheVineHub.API.Features.Cells.AddDisciples;

using Mediator;
using SurrealDb.Net;
using System.Linq;

namespace TheVineHub.API.Features.Cells.GetCells
{
    public class GetCellsHandler(ISurrealDbSession session) : IQueryHandler<GetCellsQuery, IEnumerable<CellDto>>
    {
        public async ValueTask<IEnumerable<CellDto>> Handle(GetCellsQuery request, CancellationToken cancellationToken)
        {
            var result = await session.Query(@$"
                -- 1. Setup variables (these will return NONE)
                LET $user = type::record('user', {request.Document});

                LET $my_cells = (SELECT VALUE out FROM leads WHERE in = $user);

                LET $daughter_cells = (SELECT VALUE out FROM leads WHERE in IN (SELECT VALUE in FROM disciple_in WHERE out IN $my_cells));

                LET $all_relevant_cells = array::add($my_cells, $daughter_cells);

                -- 2. Return ONLY the final result
                RETURN (
                    SELECT 
                        *,
                        count(<-disciple_in) AS member_count,
                        <-leads.in.*.{{id, full_name, photo_path}} AS leaders,
                        (IF id INSIDE $my_cells THEN 1 ELSE 2 END) AS level,
                        (SELECT VALUE id FROM (SELECT VALUE out FROM <-leads.in->disciple_in) WHERE id INSIDE $my_cells)[0] AS parent_cell_id
                    FROM cell 
                    WHERE id INSIDE $all_relevant_cells
                    ORDER BY level ASC, name ASC
                );

            ", cancellationToken);

            var cells = result.GetValue<IEnumerable<CellDto>>(4);

            return cells ?? [];
        }
    }
}
