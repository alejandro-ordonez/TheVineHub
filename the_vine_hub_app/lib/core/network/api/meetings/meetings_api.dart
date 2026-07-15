import 'package:dio/dio.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';
import '../../dio_provider.dart';
import '../../../../shared/domain/api_response.dart';

part 'meetings_api.g.dart';

class MeetingsApi {
  final Dio _dio;

  MeetingsApi(this._dio);

  Future<List<dynamic>> getMeetings() async {
    final response = await _dio.get('/api/meetings');
    final apiResponse = ApiResponse<List<dynamic>>.fromJson(
      response.data,
      (json) => json as List<dynamic>,
    );

    if (apiResponse.success) {
      return apiResponse.data!;
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  Future<dynamic> createMeeting(Map<String, dynamic> command) async {
    final response = await _dio.post(
      '/api/meetings',
      data: command,
    );
    final apiResponse = ApiResponse<dynamic>.fromJson(
      response.data,
      (json) => json,
    );

    if (apiResponse.success) {
      return apiResponse.data!;
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  Future<void> updateMeeting(int id, String name) async {
    await _dio.put('/api/Meetings/$id', data: name);
    // Legacy fallback behavior
  }

  Future<void> deleteMeeting(int id) async {
    await _dio.delete('/api/Meetings/$id');
    // Legacy fallback behavior
  }
}

@riverpod
MeetingsApi meetingsApi(Ref ref) {
  return MeetingsApi(ref.watch(dioProvider));
}
