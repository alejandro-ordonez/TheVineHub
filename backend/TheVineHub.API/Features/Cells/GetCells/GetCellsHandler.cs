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
                RETURN {{
                    LET $user = type::record('user', {request.Document});
                    LET $level_map = [];
                    LET $current_level_cells = (SELECT VALUE out FROM leads WHERE in = $user);
                    LET $current_depth = 1;

                    WHILE array::len($current_level_cells) > 0 {{
                        LET $level_map = array::add($level_map, {{ depth: $current_depth, cells: $current_level_cells }});
                        LET $current_level_cells = (SELECT VALUE out FROM leads WHERE in IN (SELECT VALUE in FROM disciple_in WHERE out IN $current_level_cells));
                        LET $current_depth = $current_depth + 1;
                    }};

                    LET $all_relevant_cells = (SELECT VALUE cells FROM $level_map).flatten();

                    RETURN (
                        SELECT
                            *,
                            count(<-disciple_in) AS member_count,
                            <-leads.in.*.{{id, full_name, photo_path}} AS leaders,
                            (
                                LET $cell_id = id;
                                SELECT VALUE depth FROM $level_map WHERE $cell_id IN cells
                            )[0] AS level,
                            (
                                SELECT VALUE id FROM (SELECT VALUE out FROM <-leads.in->disciple_in) WHERE id INSIDE $all_relevant_cells
                            )[0] AS parent_cell_id
                        FROM cell
                        WHERE id INSIDE $all_relevant_cells
                        ORDER BY level ASC, name ASC
                    );
                }};
            ", cancellationToken);

            var cells = result.GetValue<IEnumerable<CellDto>>(0);

            return cells ?? [];
        }
    }
}
