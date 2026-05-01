import 'package:freezed_annotation/freezed_annotation.dart';

part 'cycle_session_dto.freezed.dart';
part 'cycle_session_dto.g.dart';

@freezed
abstract class CycleSessionDto with _$CycleSessionDto {
  const factory CycleSessionDto({
    required int id,
    required int stepCycleId,
    required DateTime date,
    String? topic,
  }) = _CycleSessionDto;

  factory CycleSessionDto.fromJson(Map<String, dynamic> json) =>
      _$CycleSessionDtoFromJson(json);
}
