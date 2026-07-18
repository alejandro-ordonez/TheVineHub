import 'package:freezed_annotation/freezed_annotation.dart';

part 'step_cycle_dto.freezed.dart';
part 'step_cycle_dto.g.dart';

@freezed
abstract class StepCycleDto with _$StepCycleDto {
  const factory StepCycleDto({
    String? id,
    required String name,
  }) = _StepCycleDto;

  factory StepCycleDto.fromJson(Map<String, dynamic> json) =>
      _$StepCycleDtoFromJson(json);
}
