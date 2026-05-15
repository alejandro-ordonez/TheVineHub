-- 0001_core_tables.surql
DEFINE TABLE user SCHEMAFULL;
DEFINE FIELD name ON user TYPE string ASSERT $value != NONE;
DEFINE FIELD last_name ON user TYPE string ASSERT $value != NONE;
DEFINE FIELD email ON user TYPE string VALUE string::lowercase($value) ASSERT string::is_email($value);
DEFINE FIELD phone ON user TYPE string;
DEFINE FIELD birthday ON user TYPE datetime;
DEFINE FIELD gender ON user TYPE string ASSERT $value INSIDE ["Male", "Female", "Other"];
DEFINE FIELD marital_status ON user TYPE string ASSERT $value INSIDE ["Single", "Married", "Divorced", "Widowed"];
DEFINE FIELD photo_path ON user TYPE string;
DEFINE FIELD educational_level ON user TYPE string;
DEFINE FIELD profession ON user TYPE string;
DEFINE FIELD occupation ON user TYPE string;
DEFINE FIELD address ON user TYPE string;
DEFINE FIELD neighborhood ON user TYPE string;
DEFINE FIELD last_access ON user TYPE datetime;
DEFINE FIELD password ON user TYPE string;
DEFINE FIELD spouse ON user TYPE option<record<user>>;
DEFINE FIELD married_since ON user TYPE option<datetime>;
DEFINE FIELD last_updated ON user TYPE datetime DEFAULT time::now();
DEFINE INDEX idx_marital ON user FIELDS marital_status;
DEFINE FIELD full_name ON TABLE user VALUE name + " " + last_name;
DEFINE INDEX idx_full_name ON user FIELDS full_name;
DEFINE FIELD age ON TABLE user VALUE IF birthday != NONE THEN (time::now() - birthday).years() ELSE NONE END;
DEFINE INDEX user_email ON user FIELDS email UNIQUE;
DEFINE INDEX user_names ON user FIELDS name, last_name;

DEFINE TABLE role SCHEMAFULL;
DEFINE FIELD name ON role TYPE string;
DEFINE FIELD description ON role TYPE string;
DEFINE INDEX role_name ON role FIELDS name UNIQUE;

DEFINE TABLE cell SCHEMAFULL;
DEFINE FIELD name ON cell TYPE string ASSERT $value != NONE;
DEFINE FIELD description ON cell TYPE string;
DEFINE FIELD main_cell ON cell TYPE bool DEFAULT false;
DEFINE FIELD address ON cell TYPE string ASSERT $value != NONE;
DEFINE FIELD day ON cell TYPE string ASSERT $value INSIDE ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];
DEFINE FIELD opening_date ON cell TYPE datetime;
DEFINE INDEX cell_name ON cell FIELDS name;

DEFINE TABLE disciple_step SCHEMAFULL;
DEFINE FIELD name ON disciple_step TYPE string ASSERT $value != NONE;
DEFINE FIELD description ON disciple_step TYPE string;
DEFINE FIELD category ON disciple_step TYPE string;
DEFINE FIELD requires_cycle ON disciple_step TYPE bool DEFAULT false;
DEFINE FIELD requires_admin_approval ON disciple_step TYPE bool DEFAULT false;
DEFINE FIELD parent_step ON disciple_step TYPE option<record<disciple_step>>
    ASSERT $value == NONE OR (SELECT VALUE id FROM disciple_step WHERE id = $value AND parent_step = NONE)[0] != NONE;
DEFINE INDEX idx_parent_step ON disciple_step FIELDS parent_step;

DEFINE TABLE cycle SCHEMAFULL;
DEFINE FIELD name ON cycle TYPE string;
DEFINE FIELD start_date ON cycle TYPE datetime;
DEFINE FIELD end_date ON cycle TYPE datetime;
DEFINE FIELD min_attendance ON cycle TYPE int DEFAULT 0;
DEFINE FIELD is_open ON cycle TYPE bool DEFAULT true;
DEFINE FIELD enrollment_deadline ON cycle TYPE datetime;
DEFINE FIELD enrolled_count ON cycle TYPE int DEFAULT 0;
DEFINE FIELD disciple_step ON cycle TYPE record<disciple_step>;

DEFINE TABLE cycle_session SCHEMAFULL;
DEFINE FIELD date ON cycle_session TYPE datetime DEFAULT time::now();
DEFINE FIELD topic ON cycle_session TYPE string;
DEFINE FIELD cycle ON cycle_session TYPE record<cycle>;
DEFINE INDEX idx_cycle ON cycle_session FIELDS cycle;

DEFINE TABLE journal_entry SCHEMAFULL;
DEFINE FIELD title ON journal_entry TYPE string;
DEFINE FIELD content ON journal_entry TYPE string;
DEFINE FIELD categories ON journal_entry TYPE array<string> DEFAULT [];
DEFINE FIELD status ON journal_entry TYPE string ASSERT $value INSIDE ["New", "UnderRevision", "Abandoned", "Resolved"];
DEFINE FIELD created_at ON journal_entry TYPE datetime DEFAULT time::now();
DEFINE FIELD parent_entry ON journal_entry TYPE option<record<journal_entry>>;
DEFINE FIELD author ON journal_entry TYPE record<user>;
DEFINE FIELD target_disciple ON journal_entry TYPE record<user>;
DEFINE INDEX idx_created ON journal_entry FIELDS created_at;
DEFINE INDEX idx_author ON journal_entry FIELDS author;
DEFINE INDEX idx_target_disciple ON journal_entry FIELDS target_disciple;

DEFINE TABLE cell_meeting SCHEMAFULL;
DEFINE FIELD date ON cell_meeting TYPE datetime DEFAULT time::now();
DEFINE FIELD topic ON cell_meeting TYPE string;
DEFINE FIELD cell ON cell_meeting TYPE record<cell>;
DEFINE INDEX idx_cell ON cell_meeting FIELDS cell;

DEFINE TABLE church_meeting SCHEMAFULL;
DEFINE FIELD name ON church_meeting TYPE string ASSERT $value != NONE;
DEFINE FIELD start ON church_meeting TYPE string;
DEFINE FIELD end ON church_meeting TYPE string;
DEFINE FIELD meeting_type ON church_meeting TYPE string ASSERT $value INSIDE ["WeAreOne", "Rocks", "Family", "Other"];
DEFINE FIELD is_recurrent ON church_meeting TYPE bool DEFAULT false;
DEFINE FIELD day_of_week ON church_meeting TYPE string;
DEFINE FIELD date ON church_meeting TYPE datetime;

DEFINE TABLE meeting_occurrence SCHEMAFULL;
DEFINE FIELD date ON meeting_occurrence TYPE datetime;
DEFINE FIELD church_meeting ON meeting_occurrence TYPE record<church_meeting>;
DEFINE INDEX idx_church_meeting ON meeting_occurrence FIELDS church_meeting;

DEFINE TABLE city SCHEMAFULL;
DEFINE FIELD name ON city TYPE string ASSERT $value != NONE;

DEFINE TABLE locality SCHEMAFULL;
DEFINE FIELD name ON locality TYPE string ASSERT $value != NONE;

DEFINE TABLE refresh_token SCHEMAFULL;
DEFINE FIELD token ON refresh_token TYPE string;
DEFINE FIELD user ON refresh_token TYPE record<user>;
DEFINE FIELD expires_at ON refresh_token TYPE datetime;
DEFINE FIELD revoked ON refresh_token TYPE bool DEFAULT false;
DEFINE INDEX idx_token ON refresh_token FIELDS token;
DEFINE INDEX idx_user ON refresh_token FIELDS user;
