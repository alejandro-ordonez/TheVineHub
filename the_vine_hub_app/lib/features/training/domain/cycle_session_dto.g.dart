// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'cycle_session_dto.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_CycleSessionDto _$CycleSessionDtoFromJson(Map<String, dynamic> json) =>
    _CycleSessionDto(
      id: json['id'] as String?,
      name: json['name'] as String,
      date: json['date'] == null
          ? null
          : DateTime.parse(json['date'] as String),
    );

Map<String, dynamic> _$CycleSessionDtoToJson(_CycleSessionDto instance) =>
    <String, dynamic>{
      'id': instance.id,
      'name': instance.name,
      'date': instance.date?.toIso8601String(),
    };
