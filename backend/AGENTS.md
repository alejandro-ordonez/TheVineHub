# AI Agent Guidelines (Backend)

These instructions apply when modifying the `.NET 10` backend located in the `backend/` directory.

## Framework & Architecture
- **Target Framework:** The API targets `.NET 10`.
- **Minimal APIs & CQRS:** The backend uses Minimal APIs alongside the `Mediator` pattern.
  - Endpoints act exclusively as routers. They map HTTP requests to Commands or Queries via Mediator. They must contain **zero business logic**.
  - Handlers (via Mediator CQRS) encapsulate the core business logic.
- **No Repository Layer:** Do not use a separate Repository layer. Handlers act directly as the data access layer and should contain the SurrealDB queries.

## Database (SurrealDB)
- **Driver:** The backend uses the `SurrealDb.Net` driver to execute SurrealQL queries and manage graph connections.
- **IDs:** Because it uses SurrealDB, database IDs are typically formatted as **Strings** (e.g., `user:12345`), not integers. Keep this in mind when designing DTOs and database models.
- **Graph First:** Utilize SurrealDB's graph relation capabilities (e.g., `->leads->`, `->member_of->`) heavily for access control and nested data fetching, avoiding N+1 query problems.

## Error Handling
- **Global Exception Handler:** The backend utilizes a centralized `GlobalExceptionHandler` to surface errors occurring in handlers.
- Prefer relying on this centralized handler by throwing specific domain exceptions (e.g., `NotFoundException`) rather than throwing generic `Exception` manually inside features or returning HTTP codes manually in handlers.

## API Responses
- Backend API responses are typically wrapped in an `ApiResponse` wrapper object that will be parsed on the client side.

## Testing
- API integration tests utilize `DotNet.Testcontainers` to automatically provision a SurrealDB instance for testing.
- **Ryuk Issue:** When running .NET integration tests locally with `DotNet.Testcontainers`, you must set the environment variable `TESTCONTAINERS_RYUK_DISABLED=true` to prevent volume mounting errors in sandboxed Docker-in-Docker environments.
