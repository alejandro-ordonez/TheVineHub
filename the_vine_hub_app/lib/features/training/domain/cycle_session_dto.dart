import 'package:freezed_annotation/freezed_annotation.dart';

part 'cycle_session_dto.freezed.dart';
part 'cycle_session_dto.g.dart';

@freezed
abstract class CycleSessionDto with _$CycleSessionDto {
  const factory CycleSessionDto({
    String? id,
    required String name,
    DateTime? date,
  }) = _CycleSessionDto;

  factory CycleSessionDto.fromJson(Map<String, dynamic> json) =>
      _$CycleSessionDtoFromJson(json);
}
