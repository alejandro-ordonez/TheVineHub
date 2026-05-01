import 'package:dio/dio.dart';
import '../domain/auth_repository.dart';
import '../domain/authenticate_command.dart';
import '../domain/token_result.dart';
import '../../../core/network/token_storage.dart';
import '../../../core/network/dio_provider.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';

part 'auth_repository_impl.g.dart';

class AuthRepositoryImpl implements AuthRepository {
  final Dio _dio;
  final TokenStorage _tokenStorage;

  AuthRepositoryImpl(this._dio, this._tokenStorage);

  @override
  Future<TokenResult> login(AuthenticateCommand command) async {
    final response = await _dio.post(
      '/api/User/auth',
      data: command.toJson(),
    );
    
    final result = TokenResult.fromJson(response.data);
    if (result.isAuthenticated && result.token != null) {
      await _tokenStorage.saveToken(result.token!);
    }
    return result;
  }

  @override
  Future<void> logout() async {
    await _tokenStorage.deleteToken();
  }

  @override
  Future<String?> getStoredToken() async {
    return await _tokenStorage.getToken();
  }
}

@riverpod
AuthRepository authRepository(Ref ref) {
  return AuthRepositoryImpl(
    ref.watch(dioProvider),
    ref.watch(tokenStorageProvider),
  );
}
