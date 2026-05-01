// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'step_cycle_dto.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_StepCycleDto _$StepCycleDtoFromJson(Map<String, dynamic> json) =>
    _StepCycleDto(
      id: (json['id'] as num).toInt(),
      discipleStepId: (json['discipleStepId'] as num).toInt(),
      name: json['name'] as String?,
      startDate: DateTime.parse(json['startDate'] as String),
      endDate: DateTime.parse(json['endDate'] as String),
      minAttendanceRequired: (json['minAttendanceRequired'] as num).toInt(),
      isOpen: json['isOpen'] as bool,
      enrollmentDeadline: json['enrollmentDeadline'] == null
          ? null
          : DateTime.parse(json['enrollmentDeadline'] as String),
      sessionCount: (json['sessionCount'] as num).toInt(),
      enrolledCount: (json['enrolledCount'] as num).toInt(),
    );

Map<String, dynamic> _$StepCycleDtoToJson(_StepCycleDto instance) =>
    <String, dynamic>{
      'id': instance.id,
      'discipleStepId': instance.discipleStepId,
      'name': instance.name,
      'startDate': instance.startDate.toIso8601String(),
      'endDate': instance.endDate.toIso8601String(),
      'minAttendanceRequired': instance.minAttendanceRequired,
      'isOpen': instance.isOpen,
      'enrollmentDeadline': instance.enrollmentDeadline?.toIso8601String(),
      'sessionCount': instance.sessionCount,
      'enrolledCount': instance.enrolledCount,
    };
