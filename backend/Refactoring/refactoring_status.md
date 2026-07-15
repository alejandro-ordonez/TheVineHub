# Refactoring and Migration Status Report: TheVineHub.API

We have successfully migrated the backend code from the clean/slice hybrid structure in the legacy `JMMinistry` project to a pure **Vertical Slice Architecture** (VSA) under the name **TheVineHub.API** (target namespaces starting with `TheVineHub.API`).

In this phase, we also completed the decoupling refactoring to ensure the cleanest possible architecture when using SurrealDB and Vertical Slices.

---

## 1. Migration Completion Status
All Use Cases and Features are 100% migrated and mapped to Minimal API endpoints:

| Feature Area | Legacy Controllers | New VSA Slice Folder | Status |
|---|---|---|---|
| **Cells** | `MinistryController` | `Features/Cells/` (10 Slices) | Completed & Refactored |
| **Meetings** | `MeetingsController` | `Features/Meetings/` (2 Slices) | Completed & Refactored |
| **Locations** | `LocationController` | `Features/Locations/` (1 Slice) | Completed & Refactored |
| **Hierarchy** | `UserController` | `Features/Hierarchy/` (1 Slice) | Completed & Refactored |
| **Discipleship** | `DiscipleshipController` | `Features/Discipleship/` (5 Slices) | Completed & Refactored |
| **DiscipleJourney** | `DiscipleJourneyController` | `Features/DiscipleJourney/` (6 consolidated sub-groups) | Completed & Refactored |
| **Users** | `UserController` | `Features/Users/` (9 Slices) | Completed & Refactored |

---

## 2. Refactoring Design Decisions Applied

### A. Removed Database Attribute Leakage from Mediator Input Messages
Commands and Queries are mediator messages and not database table rows. We stripped all `[Column(...)]` attributes from every single `*Command` and `*Query` class in the application, converting them to clean, init-only properties:
*   Before: properties used `[Column("...")]` and mutable `{ get; set; }`.
*   After: clean `sealed class` or `sealed record` with `public required string Prop { get; init; }` (for enriched values from route/JWT) or positional constructors.

### B. Renamed HTTP Body Input DTOs to Requests
DTO classes that serve solely as the HTTP request body were renamed to `*Request` and moved into their respective slice folder's models:
*   Before: `CreateDiscipleStepDto` containing `[Column]` properties.
*   After: `CreateDiscipleStepRequest` clean record containing only the properties mapped from the incoming JSON.
*   The endpoints now bind to these clean `*Request` records and construct the `*Command` from route variables, claims, and request bodies.

Here is a partial map of renamed request DTOs:
- `AddCellAttendanceDto` → `RecordAttendanceRequest`
- `UpdateCellAttendanceDto` → `UpdateAttendanceRequest`
- `CreateMeetingDto` → `CreateMeetingRequest`
- `CreateDiscipleshipNoteDto` → `CreateNoteRequest`
- `CreateDiscipleshipNoteEntryDto` → `CreateNoteEntryRequest`
- `CreateDiscipleStepDto` → `CreateDiscipleStepRequest`
- `UpdateDiscipleStepDto` → `UpdateDiscipleStepRequest`
- `CreateStepCycleDto` → `CreateStepCycleRequest`
- `UpdateStepCycleDto` → `UpdateStepCycleRequest`
- `CreateCycleSessionDto` → `CreateCycleSessionRequest`
- `CreateCycleStaffDto` → `CreateCycleStaffRequest`
- `EnrollDisciplesDto` → `EnrollDisciplesRequest`
- `UpdateEnrollmentStatusDto` → `UpdateEnrollmentStatusRequest`
- `AssignGuideDto` → `AssignGuideRequest`
- `UpdateStepCompletionDto` → `UpdateStepCompletionRequest`
- `CompleteStepDto` → `CompleteStepRequest`
- `RecordCycleAttendanceDto` → `RecordCycleAttendanceRequest`
- `AuthenticateDto` → `AuthenticateRequest`
- `MarryLeadersDto` → `MarryLeadersRequest`

### C. Decoupled DB Projection Row Models from API Responses
For complex SurrealDB queries returning custom projected columns (aliases, `LET` statements, authorization query results), we created internal database row classes inside the slices and returned clean, immutable response records.

#### Example: `GetUserInfo`
*   **Legacy**: The handler projected complex attributes into `UserInfoDto` and then directly mutated the `AccessType` property on it depending on recursive authorization checks, making `UserInfoDto` dirty and mutating the object state in place.
*   **Refactored**: 
    1.  We created an internal `GetUserInfoDbResult` mapping only the fields returned by SurrealDB (including `[Column]` tags).
    2.  We removed `AccessType` property from the shared `UserInfoDto` class (making it a pure user table row representation).
    3.  We defined `GetUserInfoResponse` as an immutable record that contains:
        ```csharp
        public sealed record GetUserInfoResponse(
            UserInfoDto User,
            AccessType? AccessType,
            List<LeaderInfoDto> Leaders
        );
        ```
    4.  The handler maps `GetUserInfoDbResult` → `GetUserInfoResponse`, determining authorization inside the handler and returning an immutable result.

---

## 3. Integration Tests Status

The project `TheVineHub.IntegrationTests` was created and covers all major feature areas.

### Current Test Run Results: **21 Passed / 22 Total — 1 Failing** *(as of 2026-07-05)*

| Test | Status | Notes |
|---|---|---|
| `CreateUser_ShouldSuccessfullyCreateUser` | ✅ Pass | |
| `UpdateUser_ShouldSuccessfullyModifyFields` | ✅ Pass | |
| `Authenticate_ShouldReturnToken_WhenCredentialsAreValid` | ✅ Pass | |
| `Authenticate_ShouldThrowAuthenticationException_WhenPasswordIsInvalid` | ✅ Pass | |
| `CheckDocumentExists_ShouldReturnCorrectResult` | ✅ Pass | |
| `MarryLeaders_ShouldSuccessfullyRelateSpouses` | ✅ Pass | |
| `GetLocationData_ShouldReturnSeededCitiesAndLocalities` | ✅ Pass | |
| `CreateAndGetMeetings_ShouldSuccessfullyManageMeetings` | ✅ Pass | |
| `UpsertCell_ShouldSuccessfullyCreateCell` | ✅ Pass | |
| `GetCells_ShouldReturnCellsWhereUserIsLeader` | ✅ Pass | |
| `AddDisciples_ShouldSuccessfullyAddDisciplesToCell` | ✅ Pass | |
| `RemoveDisciple_ShouldSuccessfullyRemoveDiscipleFromCell` | ✅ Pass | |
| `ManageAttendance_ShouldSuccessfullyRecordGetAndUpdateCellMeetings` | ✅ Pass | Fixed in this session |
| `CreateNoteEntry_ShouldSuccessfullyAddEntryToNote` | ✅ Pass | |
| `ManageNotesAndEntries_ShouldSuccessfullyQueryDetailsAndListEntries` | ✅ Pass | |
| `CreateNote_ShouldSuccessfullyCreateNote_WhenRequestorIsLeader` | ✅ Pass | |
| `CreateDiscipleStep_ShouldSuccessfullyCreateStep` | ✅ Pass | |
| `CreateStepCycle_ShouldSuccessfullyCreateCycle` | ✅ Pass | |
| `ManageStaff_ShouldSuccessfullyAddGetAndRemoveStaff` | ✅ Pass | |
| `ManageSessions_ShouldSuccessfullyCreateGetAndDeleteSessions` | ✅ Pass | |
| `EnrollDisciples_ShouldSuccessfullyEnrollDisciplesInCycle` | ✅ Pass | |
| `ManageEnrollmentAndAttendance_ShouldSuccessfullyPerformActions` | ❌ Fail | See section 4 |

---

## 4. Remaining Issue — IN PROGRESS

### `ManageEnrollmentAndAttendance` — `GetCycleAttendanceHandler` query error

**Current error** (as of last run):
```
System.NotSupportedException: Cannot get value from a result of type SurrealDbErrorResult
  at GetCycleAttendanceHandler.Handle (line 70)
  at DiscipleJourneyIntegrationTests.cs:line 385
```

**What the test does** (abbreviated):
1. Creates cycle, enrolls disciple, adds leader as Coordinator ✅
2. Calls `GetCycleEnrollmentsQuery` → expects disciple with `Status = InProgress` ✅
3. Calls `UpdateEnrollmentStatusCommand` (Status = Completed) ✅
4. Calls `GetCycleEnrollmentsQuery` → expects `Status = Completed` ✅
5. Creates session, records attendance ✅
6. Calls `GetCycleAttendanceQuery` → **FAILS** with a SurrealDB error inside the query

**Root Cause**: The original `GetCycleAttendanceHandler` used unsupported SurrealQL syntax:
- `FOR $d IN $disciples { RETURN {...} }` nested inside an **object literal field** — not valid in SurrealQL
- `(SELECT VALUE name + ' ' + last_name FROM in)[0]` — `in` is a RecordId field, not a table identifier

**Fix Applied** (`GetCycleAttendanceHandler.cs`): Rewrote to use a flat `SELECT ... FROM $disciples` subquery inside the outer session projection:
```surql
LET $disciples = (SELECT type::string(in) AS disciple_id, ... FROM enrolled WHERE out = {cycleId});

SELECT
    type::string(id) AS session_id,
    date             AS session_date,
    topic            AS session_topic,
    (SELECT disciple_id, disciple_name, is_abandoned,
        ((SELECT count() > 0 FROM attended_to WHERE in = type::record(disciple_id) AND out = $parent.id)[0] ?? false) AS attended
    FROM $disciples) AS attendees
FROM cycle_session WHERE cycle = {cycleId} ORDER BY date ASC;
```

**Status**: Fix submitted, test running now.

---

## 5. All Fixes Applied in This Session

| File | Fix |
|---|---|
| `GetCycleEnrollmentsHandler.cs` | `FROM attended` → `FROM attended_to` |
| `GetCycleEnrollmentsHandler.cs` | `guide.name + ' '` → `(guide.name ?? '') + ' '` (NONE guard) |
| `GetCycleEnrollmentsHandler.cs` | `enrolled_at` → `date_created AS enrolled_at` (field name fix) |
| `GetCycleEnrollmentsHandler.cs` | `attendance_count` subquery → added `?? 0` guard |
| `GetCycleEnrollmentsHandler.cs` | `GetValue(0)` → `GetValue(1)` (LET occupies index 0) |
| `GetCycleDetailsHandler.cs` | Same guide null, enrolled_at, attendance_count, index fixes |
| `GetCycleAttendanceHandler.cs` | `FROM attended` → `FROM attended_to` |
| `GetCycleAttendanceHandler.cs` | Rewrote unsupported `FOR…RETURN` nesting to flat `SELECT FROM $disciples` |
| `GetCycleAttendanceHandler.cs` | `GetValue(2)` → `GetValue(1)` (only 1 LET now) |
| `GetStepDisciplesHandler.cs` | `FROM attended` → `FROM attended_to` |
| `GetCellAttendancesHandler.cs` | `<-attended_to` arrow syntax → `SELECT VALUE in FROM attended_to WHERE out = $parent.id` |
| `GetCellAttendancesHandler.cs` | `type::string(id) AS id` in user subquery → raw `id` (RecordId type match) |
| `GetCellAttendancesHandler.cs` | `name, last_name` → `full_name, phone, gender, photo_path` (BasicUserInfoDto fields) |
| `GetCellAttendancesHandler.cs` | `GetValue(1)` → `GetValue(3)` (2 LETs + 1 IF + SELECT) |
| `UpdateAttendanceModels.cs` | Removed `NotEmpty` validator on `Attendees` (zero attendees is valid) |
| `EnrollDisciplesHandler.cs` | Default `completed.status` changed from `'Enrolled'` to `'InProgress'` |
| `EnrollDisciplesHandler.cs` | Replaced SurrealQL `IF…THEN…ELSE 'Enrolled' END` with C# pre-computed strings (fixes `$p5` SDK parameterization bug) |
| `UpdateEnrollmentStatusHandler.cs` | Fixed `type::record('enrolled', "enrolled:xxxx")` double-prefix bug → use `RecordId.From(...)` |
| `UpdateEnrollmentStatusHandler.cs` | Fixed `<-has WHERE out = type::record(...)` → `{cycleRecordId}<-has` |
| `UpdateEnrollmentStatusHandler.cs` | Added `result.HasErrors` check (was silently swallowing DB errors) |

---

## 6. Key Architecture Discoveries (Critical Learnings)

### SurrealDB SDK: `FormattableString` Parameterization
`session.Query(@$"...")` takes a `FormattableString`. Every `{expression}` is captured as a typed parameter and sent as `$p1`, `$p2`, etc. **Never wrap interpolations in SurrealQL string quotes** like `'{expr}'` — SurrealDB receives the literal text `'$p1'` instead of the value. Always pass values unquoted and let the SDK serialize them.

### SurrealDB `type::record()` Double-Prefix Bug
When a C# `string` already contains the table prefix (e.g. `"cycle:xxxxx"`), wrapping it in `type::record('cycle', {str})` doubles it to `cycle:cycle:xxxxx`. Fix: build a `RecordId` in C# via `RecordId.From(table, id_part)` and interpolate the object directly.

```csharp
private static RecordId ParseRecordId(string table, string val)
{
    var parts = val.Split(':', 2);
    return parts.Length == 2 ? RecordId.From(parts[0], parts[1]) : RecordId.From(table, val);
}
```

### SurrealDB SDK Result Index Counting
Every `LET`, `IF`, or top-level `RETURN`/`SELECT` statement in a `session.Query()` block produces a result entry. The index passed to `GetValue<T>(index)` must account for each preceding statement:
- `LET $a = ...` → index 0
- `LET $b = ...` → index 1
- `SELECT ...` → index 2

### `FROM attended` → `FROM attended_to`
The relation table is `attended_to` (defined in `0002_relations.surql`). The legacy code used `FROM attended` in multiple handlers which is a non-existent table.

### `FOR…RETURN` Inside Object Literals (Invalid SurrealQL)
`FOR $x IN $arr { RETURN { field: FOR $y IN ... } }` — using `FOR` as an expression inside an object literal field value is not supported. Rewrite as a `SELECT ... FROM $arr` subquery instead.

### `NONE` Guards for Optional Fields
Any field that may be `NONE` in a SurrealDB result that maps to a non-nullable C# type (e.g. `int`, `bool`) will cause a CBOR deserialization exception. Always add `?? 0` or `?? false` coalescing in the SurrealQL projection.

### Schema Field Names
- Relation for cycle enrollment: `enrolled` (not `enrolled_to`)
- Relation for attendance: `attended_to` (not `attended`)
- Guide field on `enrolled` relation: set by `AssignGuideHandler` as `guide` — but schema defines `guided_by`. Both reference it in queries as `guide`.
- `enrolled` table date field: `date_created` (not `enrolled_at`) → aliased as `date_created AS enrolled_at`

---

## 7. Next Steps
1. ✅ ~~Fix `FROM attended` → `FROM attended_to`~~ — Done
2. ✅ ~~Fix cell attendance query~~ — Done  
3. **Verify** `GetCycleAttendanceHandler` rewrite passes the last failing test (running now)
4. **Run full suite**: `dotnet test TheVineHub.IntegrationTests/` — target 22/22 ✅
5. **Smoke Test**: Launch API locally (`dotnet run` inside `TheVineHub.API/`) and verify `/api/users/auth` via the Scalar UI.
6. **Delete Legacy Projects**: Once verified, remove `JMMinistry.API/`, `JMMinistry.Application/`, `JMMinistry.Infrastructure.Persistence/` from the solution.
