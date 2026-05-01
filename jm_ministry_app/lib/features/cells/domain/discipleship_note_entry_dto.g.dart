// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'discipleship_note_entry_dto.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_DiscipleshipNoteEntryDto _$DiscipleshipNoteEntryDtoFromJson(
  Map<String, dynamic> json,
) => _DiscipleshipNoteEntryDto(
  id: (json['id'] as num).toInt(),
  content: json['content'] as String?,
  date: DateTime.parse(json['date'] as String),
  createdAt: DateTime.parse(json['createdAt'] as String),
  noteId: (json['noteId'] as num).toInt(),
  authorId: json['authorId'] as String?,
);

Map<String, dynamic> _$DiscipleshipNoteEntryDtoToJson(
  _DiscipleshipNoteEntryDto instance,
) => <String, dynamic>{
  'id': instance.id,
  'content': instance.content,
  'date': instance.date.toIso8601String(),
  'createdAt': instance.createdAt.toIso8601String(),
  'noteId': instance.noteId,
  'authorId': instance.authorId,
};
