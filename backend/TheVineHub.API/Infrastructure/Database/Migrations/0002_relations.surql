-- 0002_relations.surql
DEFINE TABLE member_of TYPE RELATION IN user OUT role SCHEMAFULL;

DEFINE TABLE leads TYPE RELATION IN user OUT cell SCHEMAFULL;
DEFINE FIELD since ON leads TYPE datetime;
DEFINE FIELD end ON leads TYPE option<datetime>;
DEFINE FIELD active ON leads TYPE bool DEFAULT true;
DEFINE INDEX idx_out ON leads FIELDS out;

DEFINE TABLE disciple_in TYPE RELATION IN user OUT cell SCHEMAFULL;
DEFINE FIELD since ON disciple_in TYPE datetime;
DEFINE FIELD end ON disciple_in TYPE option<datetime>;
DEFINE FIELD active ON disciple_in TYPE bool DEFAULT true;
DEFINE INDEX unique_disciple ON TABLE disciple_in FIELDS in UNIQUE;

DEFINE TABLE requires TYPE RELATION IN disciple_step OUT disciple_step SCHEMAFULL;

DEFINE TABLE completed TYPE RELATION IN user OUT disciple_step SCHEMAFULL;
DEFINE FIELD status ON completed TYPE string ASSERT $value INSIDE ["Abandoned", "InProgress", "Completed", "InPrayers", "Enrolled"];
DEFINE FIELD leader ON completed TYPE record<user>;
DEFINE FIELD date_created ON completed TYPE datetime DEFAULT time::now();
DEFINE FIELD last_updated ON completed TYPE datetime DEFAULT time::now();
DEFINE INDEX idx_user_step ON completed FIELDS in, out UNIQUE;

DEFINE TABLE enrolled TYPE RELATION IN user OUT cycle SCHEMAFULL;
DEFINE FIELD status ON enrolled TYPE string ASSERT $value INSIDE ["in_prayers", "enrolled", "completed", "failed"];
DEFINE FIELD guided_by ON enrolled TYPE option<record<user>> ASSERT $value == NONE OR (SELECT id FROM guides WHERE in = $value AND out = $parent.out).id[0] != NONE;
DEFINE FIELD date_created ON enrolled TYPE datetime DEFAULT time::now();
DEFINE FIELD last_updated ON enrolled TYPE datetime DEFAULT time::now();
DEFINE INDEX idx_status ON enrolled FIELDS status, out;

DEFINE TABLE guides TYPE RELATION IN user OUT cycle SCHEMAFULL;
DEFINE FIELD role ON guides TYPE string ASSERT $value INSIDE ["Guide", "Coordinator"];

DEFINE TABLE attended_to TYPE RELATION IN user OUT cell_meeting | cycle_session | meeting_occurrence SCHEMAFULL;
DEFINE INDEX unique_attendance ON TABLE attended_to FIELDS in, out UNIQUE;

DEFINE TABLE located_in TYPE RELATION IN cell OUT locality SCHEMAFULL;
DEFINE INDEX unique_located_in ON TABLE located_in FIELDS in, out UNIQUE;

DEFINE TABLE part_of TYPE RELATION IN locality OUT city SCHEMAFULL;
DEFINE INDEX unique_part_of ON TABLE part_of FIELDS in, out UNIQUE;
