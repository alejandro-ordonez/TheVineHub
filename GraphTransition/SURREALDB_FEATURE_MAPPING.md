# SurrealDB Feature Mapping: JMMinistry

This document maps existing application features (C# Commands/Queries) to their corresponding SurrealDB operations, identifying the required Nodes (Tables) and Edges (Relationships).

## 1. User Management (`user`)

| Feature | Description | SurrealDB Operation |
| :--- | :--- | :--- |
| `Authenticate` | Login via SurrealDB Scope | `SIGNIN SCOPE user WITH { id: $id, pass: $pass }` (Returns JWT) |
| `CreateUser` | Register new person | `SIGNUP SCOPE user WITH { ... }` or `CREATE user ...` |
| `UpdateUser` | Edit profile | `UPDATE user SET ... WHERE id = $id` |
| `ImportUsers` | Bulk CSV import | Batch `CREATE user` operations |
| `GetUserInfo` | Fetch profile & access level | `SELECT *, (SELECT * FROM ->leads->cell) AS led_cells FROM user WHERE id = $id` |
| `MarryLeaders` | Link two users as spouses | `RELATE $user1->spouse->$user2` (Event handles symmetry) |
| `Photo Ops` | Upload/Delete profile pic | `UPDATE user SET photo_path = $path WHERE id = $id` |

## 2. Cell Groups (`cell`)

| Feature | Description | SurrealDB Operation |
| :--- | :--- | :--- |
| `UpsertCell` | Create or edit a cell | `CREATE cell CONTENT { ... }` or `UPDATE cell` |
| `AddDisciples` | Join users to cell | `RELATE $user->belongs_to->$cell SET since = time::now()` |
| `RemoveDisciple`| Leave cell | `DELETE belongs_to WHERE in = $user AND out = $cell` |
| `GetCell` | Details + Leaders | `SELECT *, (SELECT VALUE in FROM <-leads) AS leaders FROM cell WHERE id = $id` |
| `GetCells` | List cells for a leader | `SELECT out.* FROM leads WHERE in = $user` |
| `GetDisciples` | List members | `SELECT in.* FROM belongs_to WHERE out = $cell` |
| `RecordAttendance`| Log meeting & attendees | `CREATE cell_meeting CONTENT { ... }; RELATE $user->attended->$meeting` |
| `CheckAuthorized`| Recursive leader check | `SELECT count() FROM $user->leads->cell WHERE id = $cell OR ->(leads->cell)*.id CONTAINS $cell` |

## 3. Disciple Journey (`disciple_step`, `cycle`)

| Feature | Description | SurrealDB Operation |
| :--- | :--- | :--- |
| `CreateStep` | Define course/milestone | `CREATE disciple_step CONTENT { ... }` |
| `CreateCycle` | Create course instance | `CREATE cycle CONTENT { ... }; RELATE $step->has->$cycle` |
| `EnrollDisciples`| Register for course | `RELATE $user->enrolled->$cycle SET status = 'Enrolled'` |
| `AssignGuide` | Set teacher for student | `UPDATE enrolled SET guide = $teacher WHERE in = $user AND out = $cycle` |
| `CompleteStep` | Manual completion log | `RELATE $user->approved->$step SET on = time::now(), leader = $leader` |
| `RecordAttendance`| Log session attendance | `RELATE $user->attended->$session` |
| `EligibleQuery` | Find who can take a step| `SELECT * FROM user WHERE ->approved->disciple_step ALL INSIDE $step.requirements` |

## 4. Discipleship Notes (`journal_entry`)

| Feature | Description | SurrealDB Operation |
| :--- | :--- | :--- |
| `CreateNote` | Start a journal topic | `CREATE journal_entry CONTENT { ... }; RELATE $leader->authored->$entry; RELATE $entry->belongs_to->$disciple` |
| `CreateEntry` | Add response to note | `CREATE journal_entry CONTENT { parent: $note_id, ... }` |
| `GetNotes` | List for disciple | `SELECT * FROM journal_entry WHERE ->belongs_to->user CONTAINS $disciple` |

## 5. Metadata & Infrastructure

| Feature | Description | SurrealDB Operation |
| :--- | :--- | :--- |
| `LocationData` | Cities & Localities | Separate `city` and `locality` tables with `has` edges |
| `Roles/Perms` | Identity Roles | `RELATE $user->member_of->$role`; Fetch: `SELECT out.name FROM ->member_of` |
| `Auto Guide` | Auto-role for teachers | `DEFINE EVENT` on `guides` table to `RELATE $user->member_of->role:Guide` |
| `Guide Claims` | List guiding steps | `SIGNIN` scope fetches `->guides->cycle<-has<-disciple_step.name` |

---

## Recursive Hierarchy logic (Replaces `is_leader_in_hierarchy`)
The PostgreSQL recursive CTE for finding if User A is a leader of User B (through cells) can be expressed in SurrealQL as:
```surrealql
-- Check if $requestor is a leader of the cell that $disciple belongs to
-- OR if $requestor leads a cell that leads the $disciple's cell (recursive)
LET $is_leader = (
    SELECT count() > 0 AS value 
    FROM (
        SELECT VALUE out FROM belongs_to WHERE in = $disciple
    ) AS disciple_cells
    WHERE $requestor IN disciple_cells<-leads<-user 
       OR $requestor IN disciple_cells<-(leads<-user<-belongs_to<-cell)*<-leads<-user
)[0].value;
```
