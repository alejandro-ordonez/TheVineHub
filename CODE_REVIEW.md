# Code Review — JMMinistry

**Date:** 2026-02-21

---

## Critical Bugs

### 1. Missing `return` after `FailedAction` dispatch in Fluxor effects

In `MinistryUseCase/Effects.cs`, `CellUseCase/Effects.cs`, and `DisciplesUseCase/Effects.cs`, after dispatching `FailedAction`, execution falls through and dispatches the success action too.

```csharp
// Example from MinistryUseCase/Effects.cs (HandleFetchCellsAction)
if (response is null || response.Data is null || !response.Success)
    dispatcher.Dispatch(new FailedAction<FetchCellsAction>());
// BUG: Missing return — falls through to dispatch success action anyway
dispatcher.Dispatch(new FetchCellsResultAction { Cells = response?.Data ?? [] });
```

Only `CellAttendances/Effects.cs` does it correctly with a `return` after dispatching failure.

Additionally, `DisciplesUseCase/Effects.cs` → `HandleRemoveDiscipleAction` dispatches `FailedAction<AddDisciplesAction>` (wrong action type — should be `FailedAction<RemoveDiscipleAction>`).

### 2. Global exception handler returns HTTP 200 for unhandled exceptions

**File:** `JMMinistry.API/GlobalExceptionHandler.cs`

The fallback case sets `response.Errors` but never sets `httpContext.Response.StatusCode`, so unhandled exceptions are returned as 200 OK with error content in the body.

```csharp
else
    response.Errors = [exception.Message]; // StatusCode left as default (200)
```

### 3. `CreateUserValidator` is dead/broken

**File:** `JMMinistry.Application/Features/User/Commands/CreateUser/CreateUserValidator.cs`

- Empty class with a legacy namespace (`JMMinistry.CQRS.Users.Commands.CreateUser`)
- Doesn't extend `AbstractValidator<CreateUserCommand>`
- Never registered, never fires
- **User creation has zero server-side validation**

---

## Security Concerns

### 4. Predictable default password

**Files:** `CreateUserHandler.cs`, `ImportUsersHandler.cs`

```csharp
request.Password = $"User.{request.Document}";
```

Every created/imported user with no explicit password gets `User.{documentNumber}`. Document numbers are semi-public national IDs — any attacker who knows a user's document can authenticate immediately.

### 5. Database password hardcoded in `appsettings.json`

```json
"DefaultConnection": "Host=database;Database=jm-db;Username=jm-db;Password=jm-ministry-2024"
```

This credential is committed to source control. Should be in environment variables or a secrets manager.

### 6. Open registration endpoint

`POST /api/User/register` has no `[Authorize]`, no validation (see bug #3), and no rate-limiting. Anyone can register accounts with any document number.

### 7. Username enumeration

**File:** `AuthenticateHandler.cs`

Returns different error messages for "user not found" vs "wrong password", allowing attackers to determine which document numbers have accounts.

### 8. CSV import has no sanitization

**File:** `ImportUsersHandler.cs`

- No handling for quoted fields containing commas
- No CSV injection protection
- No file size limits
- `Enum.Parse` throws on invalid values, aborting the entire import
- `Extract` method silently swallows exceptions with `catch (Exception) { return null; }`

### 9. Other security notes

- `RequireHttpsMetadata = false` in JWT configuration is not gated on environment
- JWT token parsing on the client (`ApiExtensions.ParseClaimsFromJwt`) uses `payload.Split('.')[1]` with no bounds checking
- `LocationController` has no `[Authorize]` — location data is publicly accessible
- Frontend pages `SchoolDetails.razor`, `UserDetails.razor`, `ClassDetails.razor`, `Settings.razor` are missing `[Authorize]` attributes (mitigated by `AuthorizeRouteView` at the router level but not enforced at component level)

---

## Inconsistency: State Management (Fluxor vs Direct API Calls)

### Current state

| Page/Component | Fluxor? | Notes |
|---|---|---|
| `Cells.razor.cs` | Yes | `IState<MinistryState>` + `IDispatcher` |
| `CellDetails.razor.cs` | Yes | `IState<CellState>` + `IDispatcher` |
| `CellAttendances.razor.cs` | Yes | `IState<CellAttendancesState>` + `IDispatcher` |
| `Disciples.razor.cs` | Mixed | Fluxor for disciple fetch/remove, but injects `IUserApi` directly for create/update |
| `UsersTable.razor.cs` | No | Direct `IUserApi` injection |
| `Gained.razor` | No | Direct `IGainedUsersApi` injection |
| `Meetings.razor` | No | Direct `IMeetingApi` injection |
| `Schools.razor` | No | Direct `ISchoolApi` injection |
| `UserDetails.razor` | No | Direct `IUserApi` + `IMinistryApi` injection |
| `Users.razor` | No | Direct `IUserApi` injection |
| `Ministry.razor` | Partial | Uses `IDispatcher` only to set page title via `SetTitleAction` |

### Recommendation

Either:
- **Pick one pattern** and be consistent across the app, or
- **Use Fluxor only where shared state matters** (cells/disciples make sense since multiple components observe the same state) and document that convention explicitly

---

## Code Quality

### 10. Duplicated patterns

**Controller boilerplate:** `GetDocumentClaim()` + null check repeated in every controller action → extract to a base controller or action filter.

**`FetchUsers` delegate logic** duplicated identically in `Users.razor` and `AddDisciplesDialog.razor`.

**Mapper verbosity:** `MapperProfile.cs` has 20+ `[MapperIgnoreSource]`/`[MapperIgnoreTarget]` attributes repeated 4+ times for the same Identity fields across different `PersonalInfo` mappings.

### 11. Inconsistent error handling in API layer

| API Client | Error Handling |
|---|---|
| `UserApi.cs` | Logs errors via `ILogger` |
| `SchoolApi.cs` | Returns `null` on failure (checks `IsSuccessStatusCode`) |
| `MinistryApi.cs` | No error logging, returns response as-is |
| `GainedUserApi.cs` | No error logging, returns response as-is |
| `MeetingApi.cs` | No error logging, returns response as-is |

No API client catches network-level exceptions. If `HttpClient` throws (network failure, deserialization error), the exception propagates unhandled to the component.

Additional notes:
- `MeetingApi.cs` defines its interface in the same file (all others use separate files)
- `SchoolApi` doesn't use `using` for `HttpClient` (potential connection leak)
- Hardcoded debug URL in `ApiExtensions.cs` (`http://localhost:5217`)

### 12. Naming inconsistencies

**`IStringLocalizer` injection naming** varies by file:
- `translator` — Gained, Meetings, Disciples, Cells, AddUserDialog, CellDialog
- `_translator` — SchoolDetails, Schools, LogIn, UserForm, UsersTable, NavMenu, Dialog
- `localizer` — LanguageSelector

**CQRS naming violations:**
- `GetSchoolByIdCommand` and `GetSchoolsCommand` implement `IQuery<T>` but are named "Command"
- `UpsertCellCommand` lives in a folder called `CreateCell/`

**Mixed code-behind patterns:**
- `CellDetails.razor.cs` uses both `DialogService` (injected via `[Inject]` in `.cs`) and `dialogService` (injected via `@inject` in `.razor`) for the same service — redundant dual injection
- Some components mix `@inject` in `.razor` with `[Inject]` in `.razor.cs` for different services in the same component

### 13. Miscellaneous code quality issues

- `AddMudServices()` registered twice in `Program.cs`
- `System.Reflection.Metadata` unused import in `CreateUserHandler.cs`
- `Blazored.FluentValidation` imported in `_Imports.razor` but appears unused
- `AddDisciplesDialog.razor` reads auth state in `OnAfterRenderAsync` instead of `OnInitializedAsync`, meaning `UserId` is null on first render
- Raw `throw new Exception(...)` in `RemoveDiscipleHandler.cs` and `Extensions.cs::ThrowOnError()` bypasses the domain exception hierarchy (results in 500 instead of 400)
- `NotAuthorizedException` has no message — returns empty string to client
- `GetUserInfoHandler` uses `ArgumentException` for "user not assigned to cell" — should be `NotFoundException` or a domain-specific exception

### 14. Validation coverage

**Validators present:**
- `AuthenticateValidator` — document + password
- `UpsertSchoolValidator` — name + description
- `GetUserInfoValidator` — requestor document
- `CreateCellValidator` — document + name

**Validators missing:**
- `CreateUserCommand` (broken validator, see bug #3)
- `UpdateUserCommand`
- `ImportUsersCommand`
- `AddDisciplesCommand`
- `RecordAttendanceCommand`
- `RegisterGainedCommand`
- `CreateMeetingCommand`

---

## Dead Code

| Item | Location | Notes |
|---|---|---|
| `CreateUserValidator` | `Features/User/Commands/CreateUser/` | Empty class, wrong namespace |
| `CreateCellResultAction` reducer | `MinistryUseCase/Reducers.cs` | Action is never dispatched; effect dispatches `FetchCellsAction` instead |
| `PageUseCase` store | `Store/PageUseCase/` | Sets a title via `SetTitleAction` but nothing reads `PageState` |
| `CellsUseCase/Actions/` folder | `Store/CellsUseCase/` | Empty folder |
| `DbDefaultSeed.cs` | `Infrastructure.Persistence/` | Empty class |
| `Classes/CreateClass` feature | `Features/Classes/CreateClass/` | Handler + command exist but no controller endpoint, no API client, no UI |
| `MeetingsController.Get(id)` | `Controllers/MeetingsController.cs` | Returns hardcoded `"value"` |
| `MeetingsController.Put` / `Delete` | `Controllers/MeetingsController.cs` | Empty scaffolded methods |
| `RecordCellAttendanceDialog.razor` | `Pages/Ministry/Cells/` | Stub: `<h3>RecordCellAttendanceDialog</h3>` |
| `ClassDetails.razor` | `Pages/Schools/` | Stub: `<h3>ClassDetails</h3>` |
| `NotFound.razor` | `Pages/` | Stub: `<h3>NotFound</h3>` |
| `Schools.razor` / `SchoolDetails.razor` | `Pages/Schools/` | Have UI shells but empty `foreach` loops |
| `GetClickHandler()` in `UserDetails.razor` | `Pages/User/` | Defined but never called |

---

## Prioritized Action Items

| Priority | Item | Effort |
|----------|------|--------|
| **P0** | Fix Fluxor effects: add missing `return` after `FailedAction` dispatch | Small |
| **P0** | Fix `GlobalExceptionHandler` to set proper HTTP status on unhandled exceptions | Small |
| **P1** | Implement real `CreateUserValidator` + `UpdateUserValidator` | Medium |
| **P1** | Move DB credentials out of `appsettings.json` to env vars / secrets manager | Small |
| **P1** | Secure or rate-limit the `Register` endpoint | Medium |
| **P1** | Fix default password pattern (generate random, force change on first login) | Medium |
| **P2** | Standardize API client error handling (consistent logging + exception catching) | Medium |
| **P2** | Decide on a Fluxor convention and document it | Small |
| **P2** | Unify `IStringLocalizer` injection naming convention | Small |
| **P2** | Fix CQRS naming (rename query classes from "Command" to "Query") | Small |
| **P3** | Clean up dead code (empty validators, unused stores, scaffolded methods) | Medium |
| **P3** | Extract controller boilerplate to base class or action filter | Medium |
| **P3** | Reduce mapper attribute duplication | Medium |
