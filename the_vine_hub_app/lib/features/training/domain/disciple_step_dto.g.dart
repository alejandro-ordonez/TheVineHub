// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'disciple_step_dto.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_DiscipleStepDto _$DiscipleStepDtoFromJson(Map<String, dynamic> json) =>
    _DiscipleStepDto(
      id: (json['id'] as num).toInt(),
      name: json['name'] as String?,
      description: json['description'] as String?,
      stepCategory: (json['stepCategory'] as num).toInt(),
      requiresCycle: json['requiresCycle'] as bool,
      requiresAdminApproval: json['requiresAdminApproval'] as bool,
      requirementIds: (json['requirementIds'] as List<dynamic>?)
          ?.map((e) => (e as num).toInt())
          .toList(),
      parentStepId: (json['parentStepId'] as num?)?.toInt(),
      subSteps: (json['subSteps'] as List<dynamic>?)
          ?.map((e) => DiscipleStepDto.fromJson(e as Map<String, dynamic>))
          .toList(),
    );

Map<String, dynamic> _$DiscipleStepDtoToJson(_DiscipleStepDto instance) =>
    <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'description': instance.description,
      'stepCategory': instance.stepCategory,
      'requiresCycle': instance.requiresCycle,
      'requiresAdminApproval': instance.requiresAdminApproval,
      'requirementIds': instance.requirementIds,
      'parentStepId': instance.parentStepId,
      'subSteps': instance.subSteps,
    };
