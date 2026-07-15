import 'package:dio/dio.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';
import 'package:jm_ministry_app/core/network/dio_provider.dart';
import 'package:jm_ministry_app/shared/domain/api_response.dart';

part 'disciple_journey_api.g.dart';

class DiscipleJourneyApi {
  final Dio _dio;

  DiscipleJourneyApi(this._dio);

  Future<dynamic> getSteps() async {
    final response = await _dio.get('/api/disciplejourney/steps');
    final apiResponse = ApiResponse<dynamic>.fromJson(
      response.data,
      (json) => json,
    );

    if (apiResponse.success) {
      return apiResponse.data;
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  Future<dynamic> getCycles(String stepId) async {
    final response = await _dio.get('/api/disciplejourney/steps/$stepId/cycles');
    final apiResponse = ApiResponse<dynamic>.fromJson(
      response.data,
      (json) => json,
    );

    if (apiResponse.success) {
      return apiResponse.data;
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  Future<dynamic> getEnrollments(String cycleId) async {
    final response = await _dio.get('/api/disciplejourney/cycles/$cycleId/enrollments');
    final apiResponse = ApiResponse<dynamic>.fromJson(
      response.data,
      (json) => json,
    );

    if (apiResponse.success) {
      return apiResponse.data;
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  Future<dynamic> getSessions(String cycleId) async {
    final response = await _dio.get('/api/disciplejourney/cycles/$cycleId/sessions');
    final apiResponse = ApiResponse<dynamic>.fromJson(
      response.data,
      (json) => json,
    );

    if (apiResponse.success) {
      return apiResponse.data;
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  Future<dynamic> getStaff(String cycleId) async {
    final response = await _dio.get('/api/disciplejourney/cycles/$cycleId/staff');
    final apiResponse = ApiResponse<dynamic>.fromJson(
      response.data,
      (json) => json,
    );

    if (apiResponse.success) {
      return apiResponse.data;
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  Future<dynamic> recordAttendance(String cycleId, String sessionId, Map<String, dynamic> command) async {
    final response = await _dio.post('/api/disciplejourney/cycles/$cycleId/sessions/$sessionId/attendance', data: command);
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
DiscipleJourneyApi discipleJourneyApi(Ref ref) {
  return DiscipleJourneyApi(ref.watch(dioProvider));
}
