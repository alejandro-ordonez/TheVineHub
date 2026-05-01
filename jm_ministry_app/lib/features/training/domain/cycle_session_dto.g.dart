// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'cycle_session_dto.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_CycleSessionDto _$CycleSessionDtoFromJson(Map<String, dynamic> json) =>
    _CycleSessionDto(
      id: (json['id'] as num).toInt(),
      stepCycleId: (json['stepCycleId'] as num).toInt(),
      date: DateTime.parse(json['date'] as String),
      topic: json['topic'] as String?,
    );

Map<String, dynamic> _$CycleSessionDtoToJson(_CycleSessionDto instance) =>
    <String, dynamic>{
      'id': instance.id,
      'stepCycleId': instance.stepCycleId,
      'date': instance.date.toIso8601String(),
      'topic': instance.topic,
    };
