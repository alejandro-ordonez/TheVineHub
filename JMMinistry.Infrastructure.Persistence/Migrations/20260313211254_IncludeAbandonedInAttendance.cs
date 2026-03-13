using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JMMinistry.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class IncludeAbandonedInAttendance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
DROP FUNCTION IF EXISTS get_cycle_attendance(INTEGER);
CREATE FUNCTION get_cycle_attendance(p_cycle_id INTEGER)
RETURNS TABLE (
    session_id INTEGER,
    session_date DATE,
    session_topic TEXT,
    disciple_id TEXT,
    disciple_name TEXT,
    attended BOOLEAN,
    is_abandoned BOOLEAN
)
LANGUAGE sql STABLE
AS $$
    SELECT
        sess.""Id"" AS session_id,
        sess.""Date"" AS session_date,
        sess.""Topic"" AS session_topic,
        ce.""DiscipleId"" AS disciple_id,
        CONCAT(pi.""Name"", ' ', pi.""LastName"") AS disciple_name,
        (ca.""Id"" IS NOT NULL) AS attended,
        (sc.""StepStatus"" = 0) AS is_abandoned
    FROM ""CycleSessions"" sess
    CROSS JOIN ""CycleEnrollments"" ce
    INNER JOIN ""StepCompletions"" sc ON sc.""Id"" = ce.""StepCompletionId""
    INNER JOIN ""PersonalInfo"" pi ON pi.""Id"" = ce.""DiscipleId""
    LEFT JOIN ""CycleAttendances"" ca
        ON ca.""CycleSessionId"" = sess.""Id""
        AND ca.""DiscipleId"" = ce.""DiscipleId""
    WHERE sess.""StepCycleId"" = p_cycle_id
      AND ce.""StepCycleId"" = p_cycle_id
      AND sc.""StepStatus"" IN (0, 4)  -- Enrolled + Abandoned
    ORDER BY sess.""Date"", (sc.""StepStatus"" = 0), pi.""Name"", pi.""LastName"";
$$;
");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    INNER JOIN ""StepCompletions"" sc ON sc.""Id"" = ce.""StepCompletionId""
    INNER JOIN ""PersonalInfo"" pi ON pi.""Id"" = ce.""DiscipleId""
    LEFT JOIN ""CycleAttendances"" ca
        ON ca.""CycleSessionId"" = sess.""Id""
        AND ca.""DiscipleId"" = ce.""DiscipleId""
    WHERE sess.""StepCycleId"" = p_cycle_id
      AND ce.""StepCycleId"" = p_cycle_id
      AND sc.""StepStatus"" = 4
    ORDER BY sess.""Date"", pi.""Name"", pi.""LastName"";
$$;
");
        }
    }
}
