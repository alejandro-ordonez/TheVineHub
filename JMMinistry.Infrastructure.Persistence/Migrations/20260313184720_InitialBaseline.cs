using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JMMinistry.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialBaseline : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // DB already has all tables. Only ensure PG functions are up to date.

            migrationBuilder.Sql("""DROP FUNCTION IF EXISTS get_step_disciples(TEXT, INTEGER, INTEGER);""");
            migrationBuilder.Sql("""
                CREATE FUNCTION get_step_disciples(
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
                    cell_leader_name TEXT,
                    step_status INTEGER,
                    last_updated DATE,
                    cycle_name TEXT,
                    enrollment_status INTEGER,
                    cycle_attendance_count INTEGER,
                    cycle_end_date DATE,
                    cycle_min_attendance INTEGER
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
                    ),
                    further_steps AS (
                        SELECT dsr."DiscipleStepId" AS step_id
                        FROM "DiscipleStepRequirement" dsr
                        WHERE dsr."DiscipleStepRequirementsId" = p_step_id
                    )
                    SELECT
                        pi."Id",
                        pi."Name",
                        pi."LastName",
                        COALESCE(pi."PhoneNumber", ''),
                        COALESCE(pi."Gender", 0),
                        pi."CellId",
                        COALESCE(c."Name", ''),
                        COALESCE(TRIM(COALESCE(ldr."Name", '') || ' ' || COALESCE(ldr."LastName", '')), ''),
                        sc."StepStatus",
                        sc."LastUpdated",
                        cyc."Name",
                        ce."Status",
                        COALESCE(att_count.cnt, 0)::INTEGER,
                        cyc."EndDate",
                        cyc."MinAttendanceRequired"
                    FROM hierarchy_disciples hd
                    INNER JOIN "PersonalInfo" pi ON pi."Id" = hd.disciple_id
                    LEFT JOIN "Cells" c ON c."Id" = pi."CellId"
                    LEFT JOIN "CellPersonalInfo" cpi ON cpi."CellsId" = pi."CellId"
                    LEFT JOIN "PersonalInfo" ldr ON ldr."Id" = cpi."LeadersId"
                    INNER JOIN "StepCompletions" sc
                        ON sc."DiscipleId" = pi."Id"
                        AND sc."DiscipleStepId" = p_step_id
                        AND sc."StepStatus" <> 0
                    LEFT JOIN "CycleEnrollments" ce
                        ON ce."DiscipleId" = pi."Id"
                        AND ce."StepCycleId" IN (
                            SELECT cyc2."Id" FROM "StepCycles" cyc2 WHERE cyc2."DiscipleStepId" = p_step_id
                        )
                        AND ce."Status" = 0 -- Active
                    LEFT JOIN "StepCycles" cyc ON cyc."Id" = ce."StepCycleId"
                    LEFT JOIN LATERAL (
                        SELECT COUNT(*)::INTEGER AS cnt
                        FROM "CycleAttendances" ca
                        INNER JOIN "CycleSessions" cs ON cs."Id" = ca."CycleSessionId"
                        WHERE ca."DiscipleId" = pi."Id"
                          AND cs."StepCycleId" = ce."StepCycleId"
                    ) att_count ON true
                    WHERE NOT EXISTS (
                        SELECT 1
                        FROM further_steps fs
                        INNER JOIN "StepCompletions" fsc
                            ON fsc."DiscipleId" = pi."Id"
                            AND fsc."DiscipleStepId" = fs.step_id
                            AND fsc."StepStatus" IN (1, 2)
                    )
                    ORDER BY sc."StepStatus" ASC, c."Name" NULLS LAST, pi."Name";
                END;
                $$;
                """);

            migrationBuilder.Sql("""DROP FUNCTION IF EXISTS get_eligible_step_disciples(TEXT, INTEGER);""");
            migrationBuilder.Sql("""
                CREATE FUNCTION get_eligible_step_disciples(
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
                    last_updated DATE,
                    cycle_name TEXT,
                    enrollment_status INTEGER,
                    cycle_attendance_count INTEGER,
                    cycle_end_date DATE,
                    cycle_min_attendance INTEGER
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

                        UNION

                        SELECT DISTINCT pi."Id" AS disciple_id
                        FROM "PersonalInfo" pi
                        WHERE pi."CellId" IS NULL
                          AND NOT EXISTS (
                              SELECT 1 FROM "DiscipleStepRequirement" dsr
                              WHERE dsr."DiscipleStepId" = p_step_id
                          )
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
                        COALESCE(pi."PhoneNumber", ''),
                        COALESCE(pi."Gender", 0),
                        pi."CellId",
                        COALESCE(c."Name", ''),
                        COALESCE(TRIM(COALESCE(ldr."Name", '') || ' ' || COALESCE(ldr."LastName", '')), ''),
                        0,
                        CURRENT_DATE,
                        NULL::TEXT,
                        NULL::INTEGER,
                        NULL::INTEGER,
                        NULL::DATE,
                        NULL::INTEGER
                    FROM disciples_with_all_requirements dar
                    INNER JOIN "PersonalInfo" pi ON pi."Id" = dar.disciple_id
                    LEFT JOIN "Cells" c ON c."Id" = pi."CellId"
                    LEFT JOIN "CellPersonalInfo" cpi ON cpi."CellsId" = pi."CellId"
                    LEFT JOIN "PersonalInfo" ldr ON ldr."Id" = cpi."LeadersId"
                    ORDER BY c."Name" NULLS LAST, pi."Name";
                END;
                $$;
                """);

            migrationBuilder.Sql(@"
CREATE OR REPLACE FUNCTION get_cycle_details(p_cycle_id INTEGER)
RETURNS TABLE (
    enrollment_id INTEGER,
    disciple_id TEXT,
    disciple_name TEXT,
    cycle_staff_id INTEGER,
    guide_name TEXT,
    status INTEGER,
    enrolled_at DATE,
    attendance_count BIGINT
)
LANGUAGE sql STABLE
AS $$
    SELECT
        ce.""Id"" AS enrollment_id,
        ce.""DiscipleId"" AS disciple_id,
        CONCAT(pi.""Name"", ' ', pi.""LastName"") AS disciple_name,
        ce.""CycleStaffId"" AS cycle_staff_id,
        CONCAT(gp.""Name"", ' ', gp.""LastName"") AS guide_name,
        ce.""Status"" AS status,
        ce.""EnrolledAt"" AS enrolled_at,
        COALESCE(att.cnt, 0) AS attendance_count
    FROM ""CycleEnrollments"" ce
    INNER JOIN ""PersonalInfo"" pi ON pi.""Id"" = ce.""DiscipleId""
    LEFT JOIN ""CycleStaff"" cs ON cs.""Id"" = ce.""CycleStaffId""
    LEFT JOIN ""PersonalInfo"" gp ON gp.""Id"" = cs.""PersonId""
    LEFT JOIN LATERAL (
        SELECT COUNT(*) AS cnt
        FROM ""CycleAttendances"" ca
        INNER JOIN ""CycleSessions"" sess ON sess.""Id"" = ca.""CycleSessionId""
        WHERE ca.""DiscipleId"" = ce.""DiscipleId""
          AND sess.""StepCycleId"" = p_cycle_id
    ) att ON TRUE
    WHERE ce.""StepCycleId"" = p_cycle_id
    ORDER BY pi.""Name"", pi.""LastName"";
$$;
");

            migrationBuilder.Sql(@"
CREATE OR REPLACE FUNCTION get_cycle_attendance(p_cycle_id INTEGER)
RETURNS TABLE (
    session_id INTEGER,
    session_date DATE,
    session_topic TEXT,
    disciple_id TEXT,
    disciple_name TEXT,
    attended BOOLEAN
)
LANGUAGE sql STABLE
AS $$
    SELECT
        sess.""Id"" AS session_id,
        sess.""Date"" AS session_date,
        sess.""Topic"" AS session_topic,
        ce.""DiscipleId"" AS disciple_id,
        CONCAT(pi.""Name"", ' ', pi.""LastName"") AS disciple_name,
        (ca.""Id"" IS NOT NULL) AS attended
    FROM ""CycleSessions"" sess
    CROSS JOIN ""CycleEnrollments"" ce
    INNER JOIN ""PersonalInfo"" pi ON pi.""Id"" = ce.""DiscipleId""
    LEFT JOIN ""CycleAttendances"" ca
        ON ca.""CycleSessionId"" = sess.""Id""
        AND ca.""DiscipleId"" = ce.""DiscipleId""
    WHERE sess.""StepCycleId"" = p_cycle_id
      AND ce.""StepCycleId"" = p_cycle_id
      AND ce.""Status"" = 0  -- Active only
    ORDER BY sess.""Date"", pi.""Name"", pi.""LastName"";
$$;
");

            migrationBuilder.Sql(@"
CREATE OR REPLACE FUNCTION get_cycle_enrollments(p_leader_id TEXT, p_cycle_id INTEGER)
RETURNS TABLE (
    enrollment_id INTEGER,
    disciple_id TEXT,
    disciple_name TEXT,
    cycle_staff_id INTEGER,
    guide_name TEXT,
    status INTEGER,
    enrolled_at DATE,
    attendance_count BIGINT
)
LANGUAGE sql STABLE
AS $$
    WITH RECURSIVE leader_hierarchy AS (
        SELECT p_leader_id AS leader_id

        UNION

        SELECT DISTINCT pi.""Id"" AS leader_id
        FROM leader_hierarchy lh
        INNER JOIN ""CellPersonalInfo"" cpi ON cpi.""LeadersId"" = lh.leader_id
        INNER JOIN ""PersonalInfo"" pi ON pi.""CellId"" = cpi.""CellsId""
    ),
    hierarchy_cells AS (
        SELECT DISTINCT cpi.""CellsId"" AS cell_id
        FROM leader_hierarchy lh
        INNER JOIN ""CellPersonalInfo"" cpi ON cpi.""LeadersId"" = lh.leader_id
    ),
    visible_disciples AS (
        -- Disciples in leader's hierarchy cells
        SELECT pi.""Id""
        FROM ""PersonalInfo"" pi
        INNER JOIN hierarchy_cells hc ON pi.""CellId"" = hc.cell_id
        UNION
        -- Disciples assigned to leader as guide
        SELECT ce2.""DiscipleId""
        FROM ""CycleEnrollments"" ce2
        INNER JOIN ""CycleStaff"" cs2 ON cs2.""Id"" = ce2.""CycleStaffId""
        WHERE cs2.""PersonId"" = p_leader_id
          AND ce2.""StepCycleId"" = p_cycle_id
    )
    SELECT
        ce.""Id"" AS enrollment_id,
        ce.""DiscipleId"" AS disciple_id,
        CONCAT(pi.""Name"", ' ', pi.""LastName"") AS disciple_name,
        ce.""CycleStaffId"" AS cycle_staff_id,
        CONCAT(gp.""Name"", ' ', gp.""LastName"") AS guide_name,
        ce.""Status"" AS status,
        ce.""EnrolledAt"" AS enrolled_at,
        COALESCE(att.cnt, 0) AS attendance_count
    FROM ""CycleEnrollments"" ce
    INNER JOIN ""PersonalInfo"" pi ON pi.""Id"" = ce.""DiscipleId""
    LEFT JOIN ""CycleStaff"" cs ON cs.""Id"" = ce.""CycleStaffId""
    LEFT JOIN ""PersonalInfo"" gp ON gp.""Id"" = cs.""PersonId""
    LEFT JOIN LATERAL (
        SELECT COUNT(*) AS cnt
        FROM ""CycleAttendances"" ca
        INNER JOIN ""CycleSessions"" sess ON sess.""Id"" = ca.""CycleSessionId""
        WHERE ca.""DiscipleId"" = ce.""DiscipleId""
          AND sess.""StepCycleId"" = p_cycle_id
    ) att ON TRUE
    WHERE ce.""StepCycleId"" = p_cycle_id
      AND ce.""DiscipleId"" IN (SELECT ""Id"" FROM visible_disciples)
    ORDER BY pi.""Name"", pi.""LastName"";
$$;
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
