# SurrealDB Architecture Proposal: JMMinistry

This document outlines the proposed SurrealDB schema, mapping existing .NET domain entities to a Graph-Relational model with strict constraints.

## 1. Architectural Strategy
In this model, SurrealDB acts as the **Multi-Model Source of Truth**. 
- **Nodes (Tables):** Store core data (User info, Cell details, Course content).
- **Edges (Relations):** Store the "Wiring" (Genealogy, Prerequisites, Permissions).
- **Schema:** SCHEMAFULL to ensure data integrity and strict typing.

---

## 2. Table Definitions (Nodes)

### User (`user`)
Core profile data for every person in the ministry.
| Field | Type | Constraint |
| :--- | :--- | :--- |
| `name` | string | Required |
| `last_name` | string | Required |
| `email` | string | `string::is_email($value)` |
| `phone` | string | |
| `birthday` | datetime | |
| `gender` | string | `["Male", "Female"]` |
| `marital_status` | string | `["Single", "Married", "Divorced", "Widowed"]` |
| `photo_path` | string | |
| `educational_level`| string | |
| `profession` | string | |
| `last_access` | datetime | |

### Cell (`cell`)
A small group or cell meeting definition.
| Field | Type | Constraint |
| :--- | :--- | :--- |
| `name` | string | Required |
| `description` | string | |
| `main_cell` | bool | Default: `false` |
| `day` | string | `["Monday", "Tuesday", ...]` |
| `address` | string | Required |
| `opening_date` | datetime | |

### Disciple Step (`disciple_step`)
A course, lesson, or milestone in the journey.
| Field | Type | Constraint |
| :--- | :--- | :--- |
| `name` | string | Required |
| `description` | string | |
| `category` | string | |
| `requires_cycle` | bool | Default: `false` |
| `requires_approval`| bool | Default: `false` |

### Step Cycle (`cycle`)
A specific instance/occurrence of a Disciple Step.
| Field | Type | Constraint |
| :--- | :--- | :--- |
| `name` | string | Required |
| `start_date` | datetime | |
| `end_date` | datetime | |
| `min_attendance` | int | Default: `0` |
| `is_open` | bool | Default: `true` |

### Journal Entry (`journal_entry`)
Formerly `DiscipleshipNoteEntry`.
| Field | Type | Constraint |
| :--- | :--- | :--- |
| `content` | string | Required |
| `category` | string | |
| `datetime` | datetime | Default: `time::now()` |

---

## 3. Relationship Definitions (Edges)

| Relation | In (From) | Out (To) | Description |
| :--- | :--- | :--- | :--- |
| `leads` | `user` | `cell` | A leader responsible for a cell. |
| `belongs_to` | `user` | `cell` | A disciple membership in a cell. |
| `belongs_to` | `journal_entry` | `user` | Links an entry to the **Disciple** it concerns. |
| `authored` | `user` | `journal_entry` | Links an entry to the **Leader** who wrote it. |
| `spouse` | `user` | `user` | Married relationship (Symmetric). |
| `requires` | `disciple_step`| `disciple_step`| Prerequisite course mapping (DAG). |
| `attended` | `user` | `cell_meeting` | Attendance log. |
| `enrolled` | `user` | `cycle` | Student enrollment in a course cycle. |
| `guides` | `user` | `cycle` | Teacher/Guide for a specific cycle. |

---

## 4. Logical Constraints & Permissions

### A. Leader-Only Journaling
**Rule:** A user can only create a `journal_entry` if they are the leader of the disciple.
**SurrealQL Implementation:**
```surrealql
DEFINE TABLE journal_entry SCHEMAFULL
    PERMISSIONS 
        FOR create WHERE (
            -- The logged in user must have a 'leads' path to the cell 
            -- where the target disciple 'belongs_to'.
            $auth.id IN (
                SELECT VALUE in FROM leads WHERE out == (
                    SELECT VALUE out FROM belongs_to WHERE in == $after.disciple_id
                )
            )
        );
```

### B. Spouse Symmetry (Automation)
**Rule:** If A is married to B, B is married to A.
**SurrealQL Implementation:**
```surrealql
DEFINE EVENT spouse_symmetry ON TABLE spouse WHEN $event == "CREATE" THEN (
    CREATE spouse SET in = $value.out, out = $value.in
        WHERE (SELECT * FROM spouse WHERE in = $value.out AND out = $value.in).len() == 0
);
```

### C. Automatic "Co-Leadership" for Spouses
**Rule:** When a user is assigned as a leader to a cell, their spouse is automatically added.
**SurrealQL Implementation:**
```surrealql
DEFINE EVENT lead_sync ON TABLE leads WHEN $event == "CREATE" THEN (
    LET $spouse = (SELECT VALUE out FROM spouse WHERE in = $value.in)[0];
    IF $spouse != NONE THEN (
        CREATE leads SET in = $spouse, out = $value.out, since = time::now()
    ) END
);
```

---

## 5. Summary of Pending Items
1.  **Enums:** Define specific `marital_status`, `gender`, and `day` enums within SurrealDB to match .NET DTOs.
2.  **Locations:** Determine if Cities/Localities should be separate tables or simple strings on the `cell` table.
3.  **Migration:** Map existing UUIDs from PostgreSQL to SurrealDB record IDs to preserve identity links.
