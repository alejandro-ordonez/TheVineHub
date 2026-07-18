import 'package:freezed_annotation/freezed_annotation.dart';

part 'meeting_dto.freezed.dart';
part 'meeting_dto.g.dart';

@freezed
abstract class MeetingDto with _$MeetingDto {
  const factory MeetingDto({
    int? id,
    required String name,
  }) = _MeetingDto;

  factory MeetingDto.fromJson(Map<String, dynamic> json) =>
      _$MeetingDtoFromJson(json);
}
