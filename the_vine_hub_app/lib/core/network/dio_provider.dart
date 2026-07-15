import 'package:dio/dio.dart';
import 'package:flutter/foundation.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';
import 'package:jm_ministry_app/core/network/token_storage.dart';
import 'package:jm_ministry_app/features/auth/domain/auth_events.dart';
import 'package:jm_ministry_app/features/auth/domain/token_result.dart';
import 'package:jm_ministry_app/shared/domain/api_response.dart';

part 'dio_provider.g.dart';

@riverpod
Dio dio(Ref ref) {
  final tokenStorage = ref.watch(tokenStorageProvider);

  final dio = Dio(
    BaseOptions(
      baseUrl: const String.fromEnvironment(
        'API_BASE_URL',
        defaultValue: 'https://localhost:5001',
      ),
      connectTimeout: const Duration(seconds: 10),
      receiveTimeout: const Duration(seconds: 10),
    ),
  );

  dio.interceptors.add(
    InterceptorsWrapper(
      onRequest: (options, handler) async {
        // If the request already has an auth header (e.g. from retry), don't overwrite it
        if (options.headers.containsKey('Authorization')) {
          debugPrint(
            'Dio Interceptor: Request already has Authorization header',
          );
          return handler.next(options);
        }

        final token = await tokenStorage.getToken();
        if (token != null && token.isNotEmpty) {
          debugPrint(
            'Dio Interceptor: Adding Bearer token to request: ${options.path}',
          );
          options.headers['Authorization'] = 'Bearer $token';
        } else {
          debugPrint(
            'Dio Interceptor: No token found for request: ${options.path}',
          );
        }
        return handler.next(options);
      },
      onError: (DioException error, handler) async {
        // Prevent infinite loops for requests that have already been retried
        if (error.requestOptions.extra['retry'] == true) {
          debugPrint(
            'Dio Interceptor: Request already retried once, failing: ${error.requestOptions.path}',
          );
          return handler.next(error);
        }

        if (error.response?.statusCode == 401) {
          debugPrint(
            'Dio Interceptor: 401 Unauthorized detected for: ${error.requestOptions.path}',
          );

          final accessToken = await tokenStorage.getToken();
          final refreshToken = await tokenStorage.getRefreshToken();

          if (accessToken != null && refreshToken != null) {
            TokenResult? newTokenResult;
            try {
              debugPrint('Dio Interceptor: Attempting token refresh...');
              final refreshDio = Dio(BaseOptions(baseUrl: dio.options.baseUrl));
              final response = await refreshDio.post(
                '/api/User/refresh',
                data: {'token': accessToken, 'refreshToken': refreshToken},
              );

              final apiResponse = ApiResponse<TokenResult>.fromJson(
                response.data,
                (json) => TokenResult.fromJson(json as Map<String, dynamic>),
              );

              if (apiResponse.success && apiResponse.data != null) {
                newTokenResult = apiResponse.data!;
                await tokenStorage.saveTokens(
                  token: newTokenResult.token,
                  refreshToken: newTokenResult.refreshToken,
                );
                debugPrint('Dio Interceptor: Token refresh successful');
              } else {
                debugPrint(
                  'Dio Interceptor: Token refresh response indicated failure: ${apiResponse.errors.join(', ')}',
                );
              }
            } catch (e) {
              debugPrint('Dio Interceptor: Token refresh call failed: $e');
            }

            if (newTokenResult != null) {
              try {
                debugPrint('Dio Interceptor: Retrying original request...');
                // Mark the request as retried and execute it again
                error.requestOptions.extra['retry'] = true;
                error.requestOptions.headers['Authorization'] =
                    'Bearer ${newTokenResult.token}';

                final retryResponse = await dio.fetch(error.requestOptions);
                return handler.resolve(retryResponse);
              } catch (e) {
                debugPrint('Dio Interceptor: Retry failed: $e');
                return handler.next(error);
              }
            } else {
              debugPrint(
                'Dio Interceptor: Could not obtain new tokens, logging out',
              );
              await tokenStorage.deleteTokens();
              triggerGlobalLogout();
            }
          } else {
            debugPrint(
              'Dio Interceptor: No tokens available to refresh, signaling logout',
            );
            triggerGlobalLogout();
          }
        }
        return handler.next(error);
      },
    ),
  );

  return dio;
}
