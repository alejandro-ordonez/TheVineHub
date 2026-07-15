// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'meeting_dto.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_MeetingDto _$MeetingDtoFromJson(Map<String, dynamic> json) => _MeetingDto(
      name: json['name'] as String?,
      start: json['start'] as String,
      end: json['end'] as String,
      meetingTypes: (json['meetingTypes'] as num).toInt(),
      isRecurrent: json['isRecurrent'] as bool,
      dayOfWeek: (json['dayOfWeek'] as num?)?.toInt(),
      date:
          json['date'] == null ? null : DateTime.parse(json['date'] as String),
      meetingId: (json['meetingId'] as num).toInt(),
    );

Map<String, dynamic> _$MeetingDtoToJson(_MeetingDto instance) =>
    <String, dynamic>{
      'name': instance.name,
      'start': instance.start,
      'end': instance.end,
      'meetingTypes': instance.meetingTypes,
      'isRecurrent': instance.isRecurrent,
      'dayOfWeek': instance.dayOfWeek,
      'date': instance.date?.toIso8601String(),
      'meetingId': instance.meetingId,
    };
