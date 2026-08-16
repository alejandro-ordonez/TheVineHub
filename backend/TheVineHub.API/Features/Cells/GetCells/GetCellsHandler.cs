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
                LET $user = type::record('user', {request.Document});

                -- Level 1
                LET $l1 = (SELECT VALUE out FROM leads WHERE in = $user);

                -- Level 2
                LET $l2 = (SELECT VALUE out FROM leads WHERE in IN (SELECT VALUE in FROM disciple_in WHERE out IN $l1));

                -- Level 3
                LET $l3 = (SELECT VALUE out FROM leads WHERE in IN (SELECT VALUE in FROM disciple_in WHERE out IN $l2));

                -- Level 4
                LET $l4 = (SELECT VALUE out FROM leads WHERE in IN (SELECT VALUE in FROM disciple_in WHERE out IN $l3));

                -- Level 5
                LET $l5 = (SELECT VALUE out FROM leads WHERE in IN (SELECT VALUE in FROM disciple_in WHERE out IN $l4));

                LET $all_relevant_cells = array::flatten([$l1, $l2, $l3, $l4, $l5]);

                RETURN (
                    SELECT
                        *,
                        count(<-disciple_in) AS member_count,
                        <-leads.in.*.{{id, full_name, photo_path}} AS leaders,
                        (IF id INSIDE $l1 THEN 1
                         ELSE IF id INSIDE $l2 THEN 2
                         ELSE IF id INSIDE $l3 THEN 3
                         ELSE IF id INSIDE $l4 THEN 4
                         ELSE IF id INSIDE $l5 THEN 5
                         ELSE 6 END) AS level,
                        (
                            SELECT VALUE id FROM (SELECT VALUE out FROM <-leads.in->disciple_in) WHERE id INSIDE $all_relevant_cells
                        )[0] AS parent_cell_id
                    FROM cell
                    WHERE id INSIDE $all_relevant_cells
                    ORDER BY level ASC, name ASC
                );
            ", cancellationToken);

            var cells = result.GetValue<IEnumerable<CellDto>>(7);

            return cells ?? [];
        }
    }
}
