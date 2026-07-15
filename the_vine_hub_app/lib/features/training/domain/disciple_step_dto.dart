import 'package:freezed_annotation/freezed_annotation.dart';

part 'disciple_step_dto.freezed.dart';
part 'disciple_step_dto.g.dart';

@freezed
abstract class DiscipleStepDto with _$DiscipleStepDto {
  const factory DiscipleStepDto({
    required int id,
    String? name,
    String? description,
    required int stepCategory,
    required bool requiresCycle,
    required bool requiresAdminApproval,
    List<int>? requirementIds,
    int? parentStepId,
    List<DiscipleStepDto>? subSteps,
  }) = _DiscipleStepDto;

  factory DiscipleStepDto.fromJson(Map<String, dynamic> json) =>
      _$DiscipleStepDtoFromJson(json);
}
