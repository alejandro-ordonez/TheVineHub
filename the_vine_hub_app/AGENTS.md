# AI Agent Guidelines (Frontend)

These instructions apply when modifying the Flutter application located in the `the_vine_hub_app/` directory.

## Project Overview
This is a Flutter application named `the_vine_hub_app`. It is designed as a high-fidelity application adhering to Clean Architecture principles.

- **Main Technologies:** Flutter (Dart SDK ^3.11.4), Riverpod, GoRouter, Freezed.
- **Platforms:** Android, iOS, Web, Linux, macOS, Windows.
- **Theme:** "Kinetic Monolith" Design System.

## Architectural Patterns
This project adheres to **Clean Architecture** principles with a **Feature-First** directory structure.

### Core Layers
- **Data Layer:** Responsible for data fetching and persistence. Contains Models (DTOs), Repositories (implementations), and DataSources (API/Local).
- **Domain Layer:** The "Pure" heart of the application. Contains Entities (POJOs), Usecases (Business logic), and Repository Interfaces. No dependencies on other layers.
- **Presentation Layer:** UI and state management. Contains Widgets, Screens, and Notifiers (Riverpod).

### Directory Structure
```text
lib/
├── core/                 # App-wide infrastructure (Theme, Router, Network)
├── features/             # Business logic modules
│   └── <feature_name>/
│       ├── data/         # Models, Repositories, Data Sources
│       ├── domain/       # Entities, Usecases, Interfaces
│       └── presentation/ # Widgets, Providers, Screens
└── shared/               # Reusable UI components across features
```

## Tech Stack & Library Standards
- **State Management:** `flutter_riverpod` (v3+). Use `@riverpod` annotation for code generation.
- **Routing:** `go_router` with typed routes. Uses a `StatefulNavigationShell` for its main navigation layout.
- **Immutability:** `freezed` for all Entities and Models.
- **Networking:** `dio` for REST, managed via a singleton client in `core/network`.
    - The network/service layer maps 1:1 with the .NET backend feature domains (e.g., Cells, Discipleship, Meetings, Users, etc.).
    - Backend API responses are wrapped in an `ApiResponse` object that should be parsed on the client side. Throw exceptions only when `apiResponse.success == false`.
- **Visualization:** `syncfusion_flutter_charts` is the standard for all high-performance rendering and financial plotting.
- **UI Polish:** `skeletonizer` for loading states and `flutter_staggered_grid_view` for bento-style layouts.
    - When refactoring complex UI screens, divide them into smaller widgets while retaining Skeletonizer for loading states. Do not wrap entire screens in Skeletonizer if it causes layout shifts; wrap specific data-driven components instead.

## Building and Running
- **Get Dependencies:** `flutter pub get`
- **Run the App:** `flutter run`
- **Run Tests:** `flutter test`
- **Analyze Code:** `flutter analyze`
- **Code Generation:** `dart run build_runner build --delete-conflicting-outputs`

## Coding Conventions
### PowerShell Usage
- **Command Chaining:** When running multiple commands in a single `run_shell_command` call, use `;` as a separator instead of `&&`, as `&&` is not supported in the default PowerShell environment.

### Immutability & Code Generation (Freezed)
- **Abstract Classes:** Always use `abstract class` when defining Freezed models (e.g., `abstract class User with _$User`). This ensures the Dart analyzer correctly identifies the generated implementation and avoids "Missing concrete implementation" warnings.
- **Part Directives:** Import directives must always precede `part` directives.

### Naming Standards
- **Entities:** `Trade`, `User` (Domain).
- **Models:** `TradeModel`, `UserModel` (Data).
- **Notifiers:** `<Feature>Notifier` (Presentation).
- **Files:** snake_case for all files. Feature folders must be singular.

### Asynchronous Operations
Always return `AsyncValue` from providers to the UI. Use `.when()` or `Skeletonizer` to handle loading/error states consistently.

### Dependency Injection
Dependencies are managed via Riverpod Providers. Never instantiate repositories or data sources directly inside widgets. Use `ref.watch(repositoryProvider)` within the domain usecases.

## Design System: Kinetic Monolith
The application uses a high-fidelity editorial design system.

- **Surface Hierarchy:** Depth is achieved via tonal shifts (`surface`, `surfaceLow`, `surfaceHigh`) rather than borders.
- **Signal Colors:** Use specific semantic tokens for status (e.g., primary for positive/buy, secondary for negative/sell).
- **Typography (Tri-Font System):**
    1. **Display:** High-weight (800+) for headlines and primary values.
    2. **Body:** Medium/Regular weight for UI labels and content.
    3. **Data:** Monospaced/High-readability fonts for technical data and timestamps.

## Key Files
- `lib/main.dart`: The entry point of the application.
- `pubspec.yaml`: Project configuration and dependencies.
- `analysis_options.yaml`: Linting and analyzer rules.

## API Features Roadmap

### 1. User & Authentication (`UserController`)
- [x] **Login:** `POST /api/User/auth`
- [ ] **Token Refresh:** `POST /api/User/refresh`
- [ ] **Registration:** `POST /api/User/register`
- [ ] **Profile Management:** `GET /api/User/{document?}`, `PUT /api/User`
- [ ] **User Search:** `POST /api/User/Search`
- [ ] **Hierarchy:** `GET /api/User/{discipleId}/is-leader`
- [ ] **Photo Management:** `GET /api/User/photo/upload-url`, `DELETE /api/User/{document}/photo`

### 2. Ministry & Cells (`MinistryController`)
- [ ] **Cell Management:** `GET /api/Ministry`, `POST /api/Ministry`, `PUT /api/Ministry`
- [ ] **Disciples:** `GET /api/Ministry/disciples/{cellId}`, `POST /api/Ministry/disciples/{cellId}`, `DELETE /api/Ministry/disciples/{cellId}/{discipleId}`
- [ ] **Attendance:** `GET /api/Ministry/attendances/{cellId}`, `POST /api/Ministry/attendances/{cellId}`, `PUT /api/Ministry/attendances/{cellId}/{attendanceId}`

### 3. Disciple Journey & Training (`DiscipleJourneyController`)
- [ ] **Steps:** `GET /api/DiscipleJourney/steps`, `GET /api/DiscipleJourney/steps/{stepId}/disciples`
- [ ] **Completions:** `PUT /api/DiscipleJourney/steps/{stepId}/completions/{discipleId}`, `POST /api/DiscipleJourney/steps/{stepId}/completions`
- [ ] **Cycles:** `GET /api/DiscipleJourney/steps/{stepId}/cycles/active`, `GET /api/DiscipleJourney/cycles/{cycleId}/enrollments`
- [ ] **Enrollment:** `POST /api/DiscipleJourney/cycles/{cycleId}/enrollments`, `PUT /api/DiscipleJourney/cycles/{cycleId}/enrollments/{enrollmentId}/status`
- [ ] **Cycle Attendance:** `GET /api/DiscipleJourney/cycles/{cycleId}/attendance`, `POST /api/DiscipleJourney/cycles/{cycleId}/sessions/{sessionId}/attendance`

### 4. Discipleship Notes (`DiscipleshipController`)
- [ ] **Notes:** `GET /api/Discipleship/{discipleId}/notes`, `POST /api/Discipleship/{discipleId}/notes`
- [ ] **Entries:** `GET /api/Discipleship/{discipleId}/notes/{noteId}/entries`, `POST /api/Discipleship/{discipleId}/notes/{noteId}/entries`

### 5. Meetings & Events (`MeetingsController`)
- [ ] **Meetings:** `GET /api/Meetings`, `POST /api/Meetings`

### 6. Infrastructure (`LocationController`)
- [ ] **Location Data:** `GET /api/Location`
