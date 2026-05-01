# JM Ministry App - Project Context

## Project Overview
This is a Flutter application named `jm_ministry_app`. It is designed as a high-fidelity application adhering to Clean Architecture principles.

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
- **Routing:** `go_router` with typed routes.
- **Immutability:** `freezed` for all Entities and Models.
- **Networking:** `dio` for REST, managed via a singleton client in `core/network`.
- **Visualization:** `syncfusion_flutter_charts` is the standard for all high-performance rendering and financial plotting.
- **UI Polish:** `skeletonizer` for loading states and `flutter_staggered_grid_view` for bento-style layouts.

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
