# The Vine Hub - General Architecture

This repository holds the full stack solution for The Vine Hub. It consists of a Flutter frontend, a .NET backend, and a SurrealDB database.

## High-Level Interactions

1. **Frontend (Flutter):** Serves as the user interface on web, iOS, and Android. It handles local state, navigation, internationalization, and speaks exclusively to the .NET backend API.
2. **Backend (.NET 10):** Acts as the API Gateway and business logic layer. It enforces authentication, authorization (roles and hierarchy), domain rules, and orchestrates database transactions.
3. **Database (SurrealDB):** A multi-model database handling document, graph, and relational paradigms. The .NET backend uses the `SurrealDb.Net` driver to execute SurrealQL queries and manage graph connections (e.g., cell hierarchy, discipleship paths).

## Core Principles

- **Separation of Concerns:** The frontend knows nothing about the database schema; it relies strictly on DTOs provided by the backend.
- **Vertical Slice Architecture:** Both the frontend and backend group code by **features** (e.g., Cells, Users, Discipleship, Meetings) rather than technical layers (e.g., Controllers, Models, Views).
- **Graph-First Data:** The backend leverages SurrealDB's graph relation capabilities (`->leads->`, `->member_of->`, `->disciple_in->`) heavily for access control and deeply nested data fetching, minimizing N+1 query problems.

For detailed guidelines, see the specific architecture documents:
- [Flutter Architecture (the_vine_hub_app/ARCHITECTURE.md)](the_vine_hub_app/ARCHITECTURE.md)
- [.NET Backend Architecture (backend/ARCHITECTURE.md)](backend/ARCHITECTURE.md)
