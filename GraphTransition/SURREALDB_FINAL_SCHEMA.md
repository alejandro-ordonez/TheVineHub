# SurrealDB Final Schema: JMMinistry

This document provides the complete SurrealQL schema definition, including tables, fields, indexes, events, and permissions.

## 1. Core Tables (Nodes)

### User (`user`)
*Note: Record IDs for this table are explicit (e.g., `user:102030`) and correspond to the person's Document number.*

```surrealql
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
DEFINE FIELD password ON user TYPE string; -- Argon2 hashed

-- Role Management
DEFINE TABLE role SCHEMAFULL;
DEFINE FIELD name ON role TYPE string;
DEFINE FIELD description ON role TYPE string;

DEFINE TABLE member_of TYPE RELATION IN user OUT role SCHEMAFULL;

-- Indexes
DEFINE INDEX user_email ON user FIELDS email UNIQUE;
DEFINE INDEX user_names ON user FIELDS name, last_name;
DEFINE INDEX role_name ON role FIELDS name UNIQUE;
DEFINE INDEX cell_name ON cell FIELDS name;

-- Functions
DEFINE FUNCTION fn::is_leader($requestor: record<user>, $disciple: record<user>) {
    LET $disciple_cells = SELECT VALUE out FROM belongs_to WHERE in = $disciple;
    RETURN (
        SELECT count() > 0 AS value 
        FROM $disciple_cells
        WHERE $requestor IN <-leads<-user 
           OR $requestor IN <-(leads<-user<-belongs_to<-cell)*<-leads<-user
    )[0].value;
};

DEFINE FUNCTION fn::can_take_step($user: record<user>, $step: record<disciple_step>) {
    LET $requirements = (SELECT VALUE out FROM requires WHERE in = $step);
    LET $completed = (SELECT VALUE out FROM approved WHERE in = $user AND status == 'Completed');
    RETURN $requirements ALL INSIDE $completed;
};

-- Authentication Scope
-- Note: We align claims with Microsoft Identity expected names:
-- 'sub' and 'name' are standard. 'roles' and 'guiding_steps' will be extracted by the API middleware.
DEFINE SCOPE user SESSION 24h
    SIGNUP ( 
        CREATE type::thing("user", $id) SET 
            name = $name, 
            last_name = $last_name, 
            email = $email, 
            password = crypto::argon2::generate($pass) 
    )
    SIGNIN ( 
        SELECT *, 
            (SELECT VALUE out.name FROM ->member_of) AS roles,
            (SELECT VALUE out<-has<-disciple_step.name FROM ->guides) AS guiding_steps
        FROM user 
        WHERE id = type::thing("user", $id) AND crypto::argon2::compare(password, $pass) 
    );
```

### Cell Group (`cell`)
```surrealql
DEFINE TABLE cell SCHEMAFULL;

DEFINE FIELD name ON cell TYPE string ASSERT $value != NONE;
DEFINE FIELD description ON cell TYPE string;
DEFINE FIELD main_cell ON cell TYPE bool DEFAULT false;
DEFINE FIELD address ON cell TYPE string ASSERT $value != NONE;
DEFINE FIELD day ON cell TYPE string ASSERT $value INSIDE ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];
DEFINE FIELD opening_date ON cell TYPE datetime;
```

### Disciple Step (`disciple_step`)
```surrealql
DEFINE TABLE disciple_step SCHEMAFULL;

DEFINE FIELD name ON disciple_step TYPE string ASSERT $value != NONE;
DEFINE FIELD description ON disciple_step TYPE string;
DEFINE FIELD category ON disciple_step TYPE string;
DEFINE FIELD requires_cycle ON disciple_step TYPE bool DEFAULT false;
DEFINE FIELD requires_admin_approval ON disciple_step TYPE bool DEFAULT false;
```

### Course Cycle (`cycle`)
```surrealql
DEFINE TABLE cycle SCHEMAFULL;

DEFINE FIELD name ON cycle TYPE string;
DEFINE FIELD start_date ON cycle TYPE datetime;
DEFINE FIELD end_date ON cycle TYPE datetime;
DEFINE FIELD min_attendance ON cycle TYPE int DEFAULT 0;
DEFINE FIELD is_open ON cycle TYPE bool DEFAULT true;
DEFINE FIELD enrollment_deadline ON cycle TYPE datetime;
```

### Journal Entry (`journal_entry`)
```surrealql
DEFINE TABLE journal_entry SCHEMAFULL;

DEFINE FIELD title ON journal_entry TYPE string;
DEFINE FIELD content ON journal_entry TYPE string;
DEFINE FIELD categories ON journal_entry TYPE array<string> DEFAULT [];
DEFINE FIELD status ON journal_entry TYPE string ASSERT $value INSIDE ["New", "UnderRevision", "Abandoned", "Resolved"];
DEFINE FIELD created_at ON journal_entry TYPE datetime DEFAULT time::now();
```

## 2. Relationships (Edges)

| Relation | From (IN) | To (OUT) | Description |
| :--- | :--- | :--- | :--- |
| `leads` | `user` | `cell` | Leadership role in a cell. |
| `belongs_to` | `user` | `cell` | Disciple membership in a cell. |
| `spouse` | `user` | `user` | Married relationship (Symmetric). |
| `requires` | `disciple_step`| `disciple_step`| Prerequisite courses. |
| `has` | `disciple_step`| `cycle` | Link between step definition and instance. |
| `enrolled` | `user` | `cycle` | Student enrollment. |
| `guides` | `user` | `cycle` | Teacher/Guide assignment. |
| `attended` | `user` | `cell_meeting` | Attendance log. |
| `authored` | `user` | `journal_entry` | Author of a note/entry. |
| `concerning` | `journal_entry`| `user` | Disciple the note is about. |

## 3. Automation & Business Rules

### A. Spouse Symmetry
```surrealql
DEFINE EVENT spouse_symmetry ON TABLE spouse WHEN $event == "CREATE" THEN (
    CREATE spouse SET in = $value.out, out = $value.in
        WHERE (SELECT * FROM spouse WHERE in = $value.out AND out = $value.in).len() == 0
);
```

### B. Automatic Co-Leadership
```surrealql
DEFINE EVENT spouse_leads_sync ON TABLE leads WHEN $event == "CREATE" THEN (
    LET $spouse = (SELECT VALUE out FROM spouse WHERE in = $value.in)[0];
    IF $spouse != NONE THEN (
        CREATE leads SET in = $spouse, out = $value.out, since = time::now()
            WHERE (SELECT * FROM leads WHERE in = $spouse AND out = $value.out).len() == 0
    ) END
);
```

### C. Automatic Guide Role
```surrealql
DEFINE EVENT auto_guide_role ON TABLE guides WHEN $event == "CREATE" THEN (
    -- Automatically link user to the 'Guide' role
    LET $role_id = (SELECT VALUE id FROM role WHERE name == "Guide")[0];
    IF $role_id != NONE THEN (
        RELATE $value.in->member_of->$role_id
            WHERE (SELECT * FROM member_of WHERE in == $value.in AND out == $role_id).len() == 0
    ) END
);
```

### D. Permissions: Journaling
```surrealql
DEFINE TABLE journal_entry 
    PERMISSIONS 
        FOR create WHERE (
            -- Leader can only create notes for their disciples
            $auth.id IN (
                SELECT VALUE in FROM leads WHERE out == (
                    SELECT VALUE out FROM belongs_to WHERE in == $after.disciple_id
                )
            )
        );
```

## 4. Location Data

```surrealql
DEFINE TABLE city SCHEMAFULL;
DEFINE FIELD name ON city TYPE string;

DEFINE TABLE locality SCHEMAFULL;
DEFINE FIELD name ON locality TYPE string;

DEFINE TABLE located_in TYPE RELATION IN cell OUT locality SCHEMAFULL;
DEFINE TABLE part_of TYPE RELATION IN locality OUT city SCHEMAFULL;
```
