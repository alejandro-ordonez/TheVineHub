using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JMMinistry.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddGetEligibleStepDisciplesFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                CREATE OR REPLACE FUNCTION get_eligible_step_disciples(
                    p_leader_id TEXT,
                    p_step_id INTEGER
                )
                RETURNS TABLE (
                    disciple_id TEXT,
                    disciple_name TEXT,
                    disciple_last_name TEXT,
                    disciple_phone TEXT,
                    disciple_gender INTEGER,
                    disciple_cell_id INTEGER,
                    cell_name TEXT,
                    cell_leader_name TEXT,
                    step_status INTEGER,
                    last_updated DATE
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
                    ),
                    hierarchy_cells AS (
                        SELECT DISTINCT cpi."CellsId" AS cell_id
                        FROM leader_hierarchy lh
                        INNER JOIN "CellPersonalInfo" cpi ON cpi."LeadersId" = lh.leader_id
                    ),
                    hierarchy_disciples AS (
                        SELECT DISTINCT pi."Id" AS disciple_id
                        FROM "PersonalInfo" pi
                        INNER JOIN hierarchy_cells hc ON pi."CellId" = hc.cell_id
                    ),
                    already_completed AS (
                        SELECT sc."DiscipleId"
                        FROM "StepCompletions" sc
                        WHERE sc."DiscipleStepId" = p_step_id
                          AND sc."StepStatus" IN (1, 2)
                    ),
                    step_requirements AS (
                        SELECT dsr."DiscipleStepRequirementsId" AS required_step_id
                        FROM "DiscipleStepRequirement" dsr
                        WHERE dsr."DiscipleStepId" = p_step_id
                    ),
                    requirement_count AS (
                        SELECT COUNT(*) AS cnt FROM step_requirements
                    ),
                    disciples_with_all_requirements AS (
                        SELECT hd.disciple_id
                        FROM hierarchy_disciples hd
                        CROSS JOIN requirement_count rc
                        LEFT JOIN step_requirements sr ON TRUE
                        LEFT JOIN "StepCompletions" sc
                            ON sc."DiscipleId" = hd.disciple_id
                            AND sc."DiscipleStepId" = sr.required_step_id
                            AND sc."StepStatus" = 2
                        WHERE hd.disciple_id NOT IN (SELECT "DiscipleId" FROM already_completed)
                        GROUP BY hd.disciple_id, rc.cnt
                        HAVING rc.cnt = 0 OR COUNT(sc."Id") = rc.cnt
                    )
                    SELECT
                        pi."Id",
                        pi."Name",
                        pi."LastName",
                        COALESCE(pi."Phone", ''),
                        COALESCE(pi."Gender", 0),
                        pi."CellId",
                        COALESCE(c."Name", ''),
                        COALESCE(TRIM(COALESCE(ldr."Name", '') || ' ' || COALESCE(ldr."LastName", '')), ''),
                        0,
                        CURRENT_DATE
                    FROM disciples_with_all_requirements dar
                    INNER JOIN "PersonalInfo" pi ON pi."Id" = dar.disciple_id
                    LEFT JOIN "Cells" c ON c."Id" = pi."CellId"
                    LEFT JOIN "CellPersonalInfo" cpi ON cpi."CellsId" = pi."CellId"
                    LEFT JOIN "PersonalInfo" ldr ON ldr."Id" = cpi."LeadersId"
                    ORDER BY c."Name" NULLS LAST, pi."Name";
                END;
                $$;
                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS get_eligible_step_disciples;");
        }
    }
}
