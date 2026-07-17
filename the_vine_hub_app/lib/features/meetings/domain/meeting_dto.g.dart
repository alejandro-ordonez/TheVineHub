// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'meeting_dto.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_MeetingDto _$MeetingDtoFromJson(Map<String, dynamic> json) => _MeetingDto(
  id: (json['id'] as num?)?.toInt(),
  name: json['name'] as String,
);

Map<String, dynamic> _$MeetingDtoToJson(_MeetingDto instance) =>
    <String, dynamic>{'id': instance.id, 'name': instance.name};
