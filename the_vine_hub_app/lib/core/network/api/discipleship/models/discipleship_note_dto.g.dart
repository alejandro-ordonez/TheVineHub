// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'discipleship_note_dto.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_DiscipleshipNoteDto _$DiscipleshipNoteDtoFromJson(Map<String, dynamic> json) =>
    _DiscipleshipNoteDto(
      noteId: json['noteId'] as String,
      title: json['title'] as String?,
      description: json['description'] as String?,
      noteStatus: (json['noteStatus'] as num?)?.toInt(),
      createdAt: DateTime.parse(json['createdAt'] as String),
      categories: (json['categories'] as List<dynamic>?)
          ?.map((e) => e as String)
          .toList(),
      discipleId: json['discipleId'] as String?,
      leaderId: json['leaderId'] as String?,
      entries: (json['entries'] as List<dynamic>?)
          ?.map(
            (e) => DiscipleshipNoteEntryDto.fromJson(e as Map<String, dynamic>),
          )
          .toList(),
    );

Map<String, dynamic> _$DiscipleshipNoteDtoToJson(
  _DiscipleshipNoteDto instance,
) => <String, dynamic>{
  'noteId': instance.noteId,
  'title': instance.title,
  'description': instance.description,
  'noteStatus': instance.noteStatus,
  'createdAt': instance.createdAt.toIso8601String(),
  'categories': instance.categories,
  'discipleId': instance.discipleId,
  'leaderId': instance.leaderId,
  'entries': instance.entries,
};
