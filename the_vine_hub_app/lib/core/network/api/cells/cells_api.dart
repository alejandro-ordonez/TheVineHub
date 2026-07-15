import 'package:dio/dio.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';
import 'package:jm_ministry_app/core/network/dio_provider.dart';
import 'package:jm_ministry_app/shared/domain/api_response.dart';

part 'cells_api.g.dart';

class CellsApi {
  final Dio _dio;

  CellsApi(this._dio);

  Future<dynamic> getCells() async {
    final response = await _dio.get('/api/cells');
    final apiResponse = ApiResponse<dynamic>.fromJson(
      response.data,
      (json) => json,
    );

    if (apiResponse.success) {
      return apiResponse.data;
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  Future<dynamic> getCell(String id) async {
    final response = await _dio.get('/api/cells/$id');
    final apiResponse = ApiResponse<dynamic>.fromJson(
      response.data,
      (json) => json,
    );

    if (apiResponse.success) {
      return apiResponse.data;
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  Future<dynamic> upsertCell(Map<String, dynamic> cell) async {
    final response = await _dio.post('/api/cells', data: cell);
    final apiResponse = ApiResponse<dynamic>.fromJson(
      response.data,
      (json) => json,
    );

    if (apiResponse.success) {
      return apiResponse.data;
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  Future<dynamic> addDisciples(String cellId, Map<String, dynamic> command) async {
    final response = await _dio.post('/api/cells/$cellId/disciples', data: command);
    final apiResponse = ApiResponse<dynamic>.fromJson(
      response.data,
      (json) => json,
    );

    if (apiResponse.success) {
      return apiResponse.data;
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  Future<dynamic> getDisciples(String cellId) async {
    final response = await _dio.get('/api/cells/$cellId/disciples');
    final apiResponse = ApiResponse<dynamic>.fromJson(
      response.data,
      (json) => json,
    );

    if (apiResponse.success) {
      return apiResponse.data;
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  Future<dynamic> removeDisciple(String cellId, String discipleId) async {
    final response = await _dio.delete('/api/cells/$cellId/disciples/$discipleId');
    final apiResponse = ApiResponse<dynamic>.fromJson(
      response.data,
      (json) => json,
    );

    if (apiResponse.success) {
      return apiResponse.data;
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  Future<dynamic> recordAttendance(String cellId, Map<String, dynamic> command) async {
    final response = await _dio.post('/api/cells/$cellId/attendance', data: command);
    final apiResponse = ApiResponse<dynamic>.fromJson(
      response.data,
      (json) => json,
    );

    if (apiResponse.success) {
      return apiResponse.data;
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  Future<dynamic> updateAttendance(String cellId, String attendanceId, Map<String, dynamic> command) async {
    final response = await _dio.put('/api/cells/$cellId/attendance/$attendanceId', data: command);
    final apiResponse = ApiResponse<dynamic>.fromJson(
      response.data,
      (json) => json,
    );

    if (apiResponse.success) {
      return apiResponse.data;
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  Future<dynamic> getCellAttendances(String cellId) async {
    final response = await _dio.get('/api/cells/$cellId/attendance');
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
CellsApi cellsApi(Ref ref) {
  return CellsApi(ref.watch(dioProvider));
}
