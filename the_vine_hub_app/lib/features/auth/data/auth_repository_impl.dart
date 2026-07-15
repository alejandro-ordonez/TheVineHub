import 'package:dio/dio.dart';
import '../domain/auth_repository.dart';
import '../domain/authenticate_command.dart';
import '../domain/token_result.dart';
import '../../../core/network/token_storage.dart';
import '../../../core/network/dio_provider.dart';
import '../../../shared/domain/api_response.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';

part 'auth_repository_impl.g.dart';

class AuthRepositoryImpl implements AuthRepository {
  final Dio _dio;
  final TokenStorage _tokenStorage;

  AuthRepositoryImpl(this._dio, this._tokenStorage);

  @override
  Future<TokenResult> login(AuthenticateCommand command) async {
    final response = await _dio.post('/api/User/auth', data: command.toJson());

    final apiResponse = ApiResponse<TokenResult>.fromJson(
      response.data,
      (json) => TokenResult.fromJson(json as Map<String, dynamic>),
    );

    if (apiResponse.success && apiResponse.data != null) {
      final result = apiResponse.data!;
      if (result.isAuthenticated) {
        await _tokenStorage.saveTokens(
          token: result.token,
          refreshToken: result.refreshToken,
        );
      }
      return result;
    } else {
      throw Exception(
        apiResponse.errors.isNotEmpty
            ? apiResponse.errors.join(', ')
            : 'Authentication failed',
      );
    }
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
    ref.watch(dioProvider),
    ref.watch(tokenStorageProvider),
  );
}
