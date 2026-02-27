using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JMMinistry.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddGetStepDisciplesFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION get_step_disciples(
                    p_leader_id TEXT,
                    p_step_id INTEGER,
                    p_cell_id INTEGER DEFAULT NULL
                )
                RETURNS TABLE (
                    disciple_id TEXT,
                    disciple_name TEXT,
                    disciple_last_name TEXT,
                    disciple_phone TEXT,
                    disciple_gender INTEGER,
                    disciple_cell_id INTEGER,
                    cell_name TEXT,
                    cell_leader_name TEXT
                )
                LANGUAGE plpgsql STABLE
                AS $$
                BEGIN
                    RETURN QUERY
                    WITH RECURSIVE leader_hierarchy AS (
                        SELECT p_leader_id AS leader_id

                        UNION

                        SELECT DISTINCT pi."Id" AS leader_id
                        FROM leader_hierarchy lh
                        INNER JOIN "CellPersonalInfo" cpi ON cpi."LeadersId" = lh.leader_id
                        INNER JOIN "PersonalInfo" pi ON pi."CellId" = cpi."CellsId"
                        WHERE p_cell_id IS NULL
                    ),
                    hierarchy_cells AS (
                        SELECT DISTINCT cpi."CellsId" AS cell_id
                        FROM leader_hierarchy lh
                        INNER JOIN "CellPersonalInfo" cpi ON cpi."LeadersId" = lh.leader_id
                        WHERE p_cell_id IS NULL OR cpi."CellsId" = p_cell_id
                    ),
                    hierarchy_disciples AS (
                        SELECT DISTINCT pi."Id" AS disciple_id
                        FROM "PersonalInfo" pi
                        INNER JOIN hierarchy_cells hc ON pi."CellId" = hc.cell_id

                        UNION

                        SELECT DISTINCT sc."DiscipleId" AS disciple_id
                        FROM "StepCompletions" sc
                        INNER JOIN leader_hierarchy lh ON sc."LeaderId" = lh.leader_id
                        WHERE sc."DiscipleStepId" = p_step_id
                          AND p_cell_id IS NULL
                    )
                    SELECT
                        pi."Id",
                        pi."Name",
                        pi."LastName",
                        COALESCE(pi."Phone", ''),
                        COALESCE(pi."Gender", 0),
                        pi."CellId",
                        COALESCE(c."Name", ''),
                        COALESCE(TRIM(COALESCE(ldr."Name", '') || ' ' || COALESCE(ldr."LastName", '')), '')
                    FROM hierarchy_disciples hd
                    INNER JOIN "PersonalInfo" pi ON pi."Id" = hd.disciple_id
                    LEFT JOIN "Cells" c ON c."Id" = pi."CellId"
                    LEFT JOIN "CellPersonalInfo" cpi ON cpi."CellsId" = pi."CellId"
                    LEFT JOIN "PersonalInfo" ldr ON ldr."Id" = cpi."LeadersId"
                    INNER JOIN "StepCompletions" sc
                        ON sc."DiscipleId" = pi."Id"
                        AND sc."DiscipleStepId" = p_step_id
                    ORDER BY c."Name" NULLS LAST, pi."Name";
                END;
                $$;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS get_step_disciples;");
        }
    }
}
