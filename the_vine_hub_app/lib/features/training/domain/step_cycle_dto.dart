import 'package:freezed_annotation/freezed_annotation.dart';

part 'step_cycle_dto.freezed.dart';
part 'step_cycle_dto.g.dart';

@freezed
abstract class StepCycleDto with _$StepCycleDto {
  const factory StepCycleDto({
    required int id,
    required int discipleStepId,
    String? name,
    required DateTime startDate,
    required DateTime endDate,
    required int minAttendanceRequired,
    required bool isOpen,
    DateTime? enrollmentDeadline,
    required int sessionCount,
    required int enrolledCount,
  }) = _StepCycleDto;

  factory StepCycleDto.fromJson(Map<String, dynamic> json) =>
      _$StepCycleDtoFromJson(json);
}
