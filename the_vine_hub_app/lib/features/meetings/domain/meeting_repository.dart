import 'meeting_dto.dart';

abstract class MeetingRepository {
  Future<List<MeetingDto>> getMeetings();
  Future<MeetingDto> createMeeting(Map<String, dynamic> command);
  Future<void> updateMeeting(int id, String name);
  Future<void> deleteMeeting(int id);
}
