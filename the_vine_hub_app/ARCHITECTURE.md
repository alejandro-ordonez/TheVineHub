# Flutter Architecture Guidelines

## 1. Feature-First Structure
The application code inside `lib/` is organized by features (e.g., `lib/features/cells`, `lib/features/auth`).
Each feature module must contain its own:
- `presentation/`: UI widgets, screens, and Riverpod notifiers.
- `domain/`: Models (Freezed/JsonSerializable), DTOs, and abstract repository interfaces.
- `data/`: Repository implementations that interact with the network layer.

Shared code or generic UI components belong in `lib/shared/` or `lib/core/`.

## 2. State Management & Dependency Injection (Riverpod)
- We use **Riverpod** (specifically with `@riverpod` code generation) for all state management and dependency injection.
- **Do not** hold complex business logic or data fetching inside `StatefulWidget` states. Instead, delegate to `Notifier` or `AsyncNotifier` classes.
- UI should merely listen to state changes (`ref.watch`) and dispatch user events to the Notifiers.

## 3. Data Models (Freezed)
- All Data Transfer Objects (DTOs) and models must be immutable.
- Use the `freezed_annotation` and `json_serializable` packages.
- Run `dart run build_runner build -d` whenever modifying models.

## 4. UI Best Practices & Widget Splitting
- **Keep Widgets Small:** Avoid widgets that span hundreds of lines (e.g., heavily nested `CustomScrollView` or massive Forms). If a widget exceeds ~150 lines, it is likely doing too much. Break it down into smaller, private or shared sub-widgets with single responsibilities.
- **Skeletonizer Usage:** Use the `Skeletonizer` package to provide smooth loading states.
  - *Rule of thumb:* Do not wrap entire screens at the top level with `Skeletonizer`, as this causes jarring layout shifts. Wrap specific data-driven components (like lists, grids, or cards) instead.
  - Combine Skeletonizer with Riverpod's `AsyncValue.when` or mock data lists while `isLoading` is true.

## 5. Networking (Dio)
- Use `Dio` for HTTP requests, configured in `dio_provider.dart`.
- All endpoints map 1:1 to the .NET backend API endpoints.
- Parse all backend responses using the standard `ApiResponse<T>` Freezed wrapper. Throw exceptions only when `apiResponse.success == false`.
