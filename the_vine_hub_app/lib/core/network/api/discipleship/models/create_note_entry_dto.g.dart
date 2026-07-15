// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'create_note_entry_dto.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_CreateNoteEntryDto _$CreateNoteEntryDtoFromJson(Map<String, dynamic> json) =>
    _CreateNoteEntryDto(
      content: json['content'] as String,
      date: DateTime.parse(json['date'] as String),
    );

Map<String, dynamic> _$CreateNoteEntryDtoToJson(_CreateNoteEntryDto instance) =>
    <String, dynamic>{
      'content': instance.content,
      'date': instance.date.toIso8601String(),
    };
