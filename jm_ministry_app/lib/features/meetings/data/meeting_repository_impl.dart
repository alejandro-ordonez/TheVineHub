import 'package:dio/dio.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';
import '../domain/meeting_repository.dart';
import '../domain/meeting_dto.dart';
import '../../../core/network/dio_provider.dart';

part 'meeting_repository_impl.g.dart';

class MeetingRepositoryImpl implements MeetingRepository {
  final Dio _dio;

  MeetingRepositoryImpl(this._dio);

  @override
  Future<List<MeetingDto>> getMeetings() async {
    final response = await _dio.get('/api/Meetings');
    return (response.data as List)
        .map((e) => MeetingDto.fromJson(e as Map<String, dynamic>))
        .toList();
  }

  @override
  Future<MeetingDto> createMeeting(Map<String, dynamic> command) async {
    final response = await _dio.post('/api/Meetings', data: command);
    return MeetingDto.fromJson(response.data as Map<String, dynamic>);
  }

  @override
  Future<void> updateMeeting(int id, String name) async {
    await _dio.put('/api/Meetings/$id', data: name);
  }

  @override
  Future<void> deleteMeeting(int id) async {
    await _dio.delete('/api/Meetings/$id');
  }
}

@riverpod
MeetingRepository meetingRepository(Ref ref) {
  return MeetingRepositoryImpl(ref.watch(dioProvider));
}
