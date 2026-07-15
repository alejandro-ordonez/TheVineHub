import 'package:riverpod_annotation/riverpod_annotation.dart';
import 'package:jm_ministry_app/features/auth/data/auth_repository_impl.dart';
import 'package:jm_ministry_app/features/auth/domain/authenticate_command.dart';
import 'package:jm_ministry_app/features/auth/domain/auth_events.dart';
import 'package:flutter/foundation.dart';

part 'auth_notifier.g.dart';

@riverpod
class AuthNotifier extends _$AuthNotifier {
  @override
  FutureOr<String?> build() async {
    // Listen for global logout events (e.g. from network layer)
    ref.listen(authEventStreamProvider, (previous, next) {
      next.whenData((event) {
        if (event == AuthEvent.logout) {
          debugPrint('AuthNotifier: Received global logout event');
          logout();
        }
      });
    });

    try {
      final token = await ref.read(authRepositoryProvider).getStoredToken();
      debugPrint(
        'AuthNotifier: Initialized with token: ${token != null ? 'Present' : 'None'}',
      );
      return token;
    } catch (e) {
      debugPrint('AuthNotifier: Error during build: $e');
      return null;
    }
  }

  Future<void> login(String document, String password) async {
    state = const AsyncLoading();
    debugPrint('AuthNotifier: Attempting login for $document');

    final result = await AsyncValue.guard(() async {
      final authRepo = ref.read(authRepositoryProvider);
      return await authRepo.login(
        AuthenticateCommand(document: document, password: password),
      );
    });

    if (result.hasValue) {
      final tokenResult = result.value!;
      debugPrint(
        'AuthNotifier: Login successful. Authenticated: ${tokenResult.isAuthenticated}',
      );

      if (tokenResult.isAuthenticated) {
        state = AsyncData(tokenResult.token);
      } else {
        debugPrint('AuthNotifier: Server returned isAuthenticated=false');
        state = AsyncError('Invalid credentials', StackTrace.current);
      }
    } else {
      debugPrint('AuthNotifier: Login failed with error: ${result.error}');
      state = AsyncError(result.error!, result.stackTrace!);
    }
  }

  Future<void> logout() async {
    state = const AsyncLoading();
    await ref.read(authRepositoryProvider).logout();
    state = const AsyncData(null);
  }
}
