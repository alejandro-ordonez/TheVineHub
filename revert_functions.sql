-- Revert the two function migrations so they get re-applied on next app startup.
-- Run this against your jm-db database.

DELETE FROM "__EFMigrationsHistory"
WHERE "MigrationId" IN (
    '20260227203056_AddGetStepDisciplesFunction',
    '20260227210000_AddGetEligibleStepDisciplesFunction'
);

DROP FUNCTION IF EXISTS get_step_disciples;
DROP FUNCTION IF EXISTS get_eligible_step_disciples;
