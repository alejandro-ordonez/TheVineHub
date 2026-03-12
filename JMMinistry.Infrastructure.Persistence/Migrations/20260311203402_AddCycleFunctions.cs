using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JMMinistry.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCycleFunctions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // get_cycle_details: returns enrollments with disciple names, guide names, and attendance counts
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

            // get_cycle_attendance: cross join sessions × enrolled disciples, left join attendance
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

            // get_cycle_enrollments: guide-filtered view using leader_hierarchy CTE
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
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS get_cycle_details(INTEGER);");
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS get_cycle_attendance(INTEGER);");
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS get_cycle_enrollments(TEXT, INTEGER);");
        }
    }
}
