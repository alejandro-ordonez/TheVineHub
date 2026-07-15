import '../domain/auth_repository.dart';
import '../domain/authenticate_command.dart';
import '../domain/token_result.dart';
import '../../../core/network/token_storage.dart';
import '../../../core/network/api/users/users_api.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';

part 'auth_repository_impl.g.dart';

class AuthRepositoryImpl implements AuthRepository {
  final UsersApi _usersApi;
  final TokenStorage _tokenStorage;

  AuthRepositoryImpl(this._usersApi, this._tokenStorage);

  @override
  Future<TokenResult> login(AuthenticateCommand command) async {
    final response = await _usersApi.authenticate(command.toJson());

    final result = TokenResult.fromJson(response as Map<String, dynamic>);

    if (result.isAuthenticated) {
      await _tokenStorage.saveTokens(
        token: result.token,
        refreshToken: result.refreshToken,
      );
    }
    return result;
  }

  @override
  Future<void> logout() async {
    await _tokenStorage.deleteTokens();
  }

  @override
  Future<String?> getStoredToken() async {
    return await _tokenStorage.getToken();
  }
}

@riverpod
AuthRepository authRepository(Ref ref) {
  return AuthRepositoryImpl(
    ref.watch(usersApiProvider),
    ref.watch(tokenStorageProvider),
  );
}
