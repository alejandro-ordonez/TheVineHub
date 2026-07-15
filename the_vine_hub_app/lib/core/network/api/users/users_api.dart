import 'package:dio/dio.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';
import '../../dio_provider.dart';
import '../../../../shared/domain/api_response.dart';

part 'users_api.g.dart';

class UsersApi {
  final Dio _dio;

  UsersApi(this._dio);

  Future<dynamic> checkDocument(String document) async {
    final response = await _dio.get('/api/users/Check/$document');
    final apiResponse = ApiResponse<dynamic>.fromJson(
      response.data,
      (json) => json,
    );

    if (apiResponse.success) {
      return apiResponse.data;
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  Future<dynamic> createUser(Map<String, dynamic> userInfo) async {
    final response = await _dio.post('/api/users', data: userInfo);
    final apiResponse = ApiResponse<dynamic>.fromJson(
      response.data,
      (json) => json,
    );

    if (apiResponse.success) {
      return apiResponse.data;
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  Future<dynamic> updateUser(Map<String, dynamic> userInfo) async {
    final response = await _dio.put('/api/users', data: userInfo);
    final apiResponse = ApiResponse<dynamic>.fromJson(
      response.data,
      (json) => json,
    );

    if (apiResponse.success) {
      return apiResponse.data;
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  Future<dynamic> getUserInfo(String document) async {
    final response = await _dio.get('/api/users/$document');
    final apiResponse = ApiResponse<dynamic>.fromJson(
      response.data,
      (json) => json,
    );

    if (apiResponse.success) {
      return apiResponse.data;
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  Future<dynamic> authenticate(Map<String, dynamic> credentials) async {
    final response = await _dio.post('/api/users/auth', data: credentials);
    final apiResponse = ApiResponse<dynamic>.fromJson(
      response.data,
      (json) => json,
    );

    if (apiResponse.success) {
      return apiResponse.data;
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  Future<dynamic> getUserInfoByCriteria(String name, String phone) async {
    final response = await _dio.get('/api/users/criteria?name=$name&phone=$phone');
    final apiResponse = ApiResponse<dynamic>.fromJson(
      response.data,
      (json) => json,
    );

    if (apiResponse.success) {
      return apiResponse.data;
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  Future<dynamic> importUsers(FormData formData) async {
    final response = await _dio.post('/api/users/import', data: formData);
    final apiResponse = ApiResponse<dynamic>.fromJson(
      response.data,
      (json) => json,
    );

    if (apiResponse.success) {
      return apiResponse.data;
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  Future<dynamic> uploadPhoto(String document, FormData formData) async {
    final response = await _dio.post('/api/users/$document/photo', data: formData);
    final apiResponse = ApiResponse<dynamic>.fromJson(
      response.data,
      (json) => json,
    );

    if (apiResponse.success) {
      return apiResponse.data;
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  Future<dynamic> marryLeaders(String leaderId, String spouseId) async {
    final response = await _dio.post('/api/users/marry', data: {'leaderId': leaderId, 'spouseId': spouseId});
    final apiResponse = ApiResponse<dynamic>.fromJson(
      response.data,
      (json) => json,
    );

    if (apiResponse.success) {
      return apiResponse.data;
    }
    throw Exception(apiResponse.errors.join(', '));
  }
}

@riverpod
UsersApi usersApi(Ref ref) {
  return UsersApi(ref.watch(dioProvider));
}
