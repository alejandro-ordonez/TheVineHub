# .NET Backend Architecture Guidelines

## 1. Vertical Slice Architecture
The backend is structured around **features** rather than technical layers. Inside `Features/`, code is grouped by domain (e.g., `Cells`, `Discipleship`, `Users`).
- Each feature module contains its Endpoints, Commands, Queries, and Handlers.
- This keeps related code geographically close, ensuring that a change to a specific feature requires looking at only one directory.

## 2. CQRS with Mediator
- We utilize the CQRS (Command Query Responsibility Segregation) pattern via the `Mediator` library.
- **Endpoints (Minimal APIs):** Endpoints act only as routers. They receive HTTP requests, map them to a Command or Query, send them via Mediator, and return the result. They should contain **no** business logic.
- **Handlers:** Implement `ICommandHandler` or `IQueryHandler`. They encapsulate the core business logic, validation, and database interactions for a specific use case.

## 3. Data Access & SurrealDB
- Handlers act as the primary Data Access Layer, communicating directly with SurrealDB via `ISurrealDbSession`.
- **Query Guidelines:**
  - Minimize the use of dynamic string interpolation (`$"{variable}"`) in raw SurrealQL strings to prevent injection or syntax errors.
  - For complex or reusable queries, consider centralizing them or extracting query strings into constants.
  - Rely on SurrealDB graph relations to fetch nested data in a single request rather than making multiple sequential queries.

## 4. Exception Handling
- Use the central `GlobalExceptionHandler` to manage HTTP responses for errors.
- **Throw specific exceptions** (e.g., `NotFoundException`, `NotAuthorizedException`, `ValidationException`) from Handlers so the Global Handler can map them to appropriate HTTP status codes (404, 401, 400).
- **Avoid throwing generic `Exception` types:** Do not catch database errors and rethrow them as `new Exception("DB Error")`. Create custom typed exceptions (e.g., `DatabaseExecutionException`) so the Global Handler can intercept them properly, rather than defaulting to generic 500 Internal Server Error masks.
