import 'package:freezed_annotation/freezed_annotation.dart';

part 'meeting_dto.freezed.dart';
part 'meeting_dto.g.dart';

@freezed
abstract class MeetingDto with _$MeetingDto {
  const factory MeetingDto({
    String? name,
    required String start, // time format
    required String end,   // time format
    required int meetingTypes,
    required bool isRecurrent,
    int? dayOfWeek,
    DateTime? date,
    required int meetingId,
  }) = _MeetingDto;

  factory MeetingDto.fromJson(Map<String, dynamic> json) =>
      _$MeetingDtoFromJson(json);
}
