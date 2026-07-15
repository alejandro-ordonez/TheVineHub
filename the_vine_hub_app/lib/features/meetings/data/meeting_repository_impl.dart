import 'package:riverpod_annotation/riverpod_annotation.dart';
import '../domain/meeting_repository.dart';
import '../domain/meeting_dto.dart';
import '../../../core/network/api/meetings/meetings_api.dart';

part 'meeting_repository_impl.g.dart';

class MeetingRepositoryImpl implements MeetingRepository {
  final MeetingsApi _meetingsApi;

  MeetingRepositoryImpl(this._meetingsApi);

  @override
  Future<List<MeetingDto>> getMeetings() async {
    final response = await _meetingsApi.getMeetings();
    return response.map((e) => MeetingDto.fromJson(e as Map<String, dynamic>)).toList();
  }

  @override
  Future<MeetingDto> createMeeting(Map<String, dynamic> command) async {
    final response = await _meetingsApi.createMeeting(command);
    return MeetingDto.fromJson(response as Map<String, dynamic>);
  }

  @override
  Future<void> updateMeeting(int id, String name) async {
    await _meetingsApi.updateMeeting(id, name);
  }

  @override
  Future<void> deleteMeeting(int id) async {
    await _meetingsApi.deleteMeeting(id);
  }
}

@riverpod
MeetingRepository meetingRepository(Ref ref) {
  return MeetingRepositoryImpl(ref.watch(meetingsApiProvider));
}
