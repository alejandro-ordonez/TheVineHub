// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'create_note_dto.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_CreateNoteDto _$CreateNoteDtoFromJson(Map<String, dynamic> json) =>
    _CreateNoteDto(
      title: json['title'] as String,
      description: json['description'] as String? ?? '',
      categories: (json['categories'] as List<dynamic>?)
              ?.map((e) => e as String)
              .toList() ??
          const [],
    );

Map<String, dynamic> _$CreateNoteDtoToJson(_CreateNoteDto instance) =>
    <String, dynamic>{
      'title': instance.title,
      'description': instance.description,
      'categories': instance.categories,
    };
