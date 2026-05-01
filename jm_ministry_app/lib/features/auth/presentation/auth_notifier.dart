import 'package:riverpod_annotation/riverpod_annotation.dart';
import '../data/auth_repository_impl.dart';
import '../domain/authenticate_command.dart';

part 'auth_notifier.g.dart';

@riverpod
class AuthNotifier extends _$AuthNotifier {
  @override
  FutureOr<String?> build() async {
    return await ref.read(authRepositoryProvider).getStoredToken();
  }

  Future<void> login(String document, String password) async {
    state = const AsyncLoading();
    final result = await AsyncValue.guard(() => 
      ref.read(authRepositoryProvider).login(
        AuthenticateCommand(document: document, password: password),
      )
    );
    
    if (result.hasValue) {
      state = AsyncData(result.value?.token);
    } else {
      state = AsyncError(result.error!, result.stackTrace!);
    }
  }

  Future<void> logout() async {
    state = const AsyncLoading();
    await ref.read(authRepositoryProvider).logout();
    state = const AsyncData(null);
  }
}
