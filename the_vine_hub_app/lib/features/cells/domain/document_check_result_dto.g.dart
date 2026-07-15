// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'document_check_result_dto.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_DocumentCheckResultDto _$DocumentCheckResultDtoFromJson(
        Map<String, dynamic> json) =>
    _DocumentCheckResultDto(
      exists: json['exists'] as bool,
      hasCell: json['hasCell'] as bool,
      name: json['name'] as String?,
      lastName: json['lastName'] as String?,
    );

Map<String, dynamic> _$DocumentCheckResultDtoToJson(
        _DocumentCheckResultDto instance) =>
    <String, dynamic>{
      'exists': instance.exists,
      'hasCell': instance.hasCell,
      'name': instance.name,
      'lastName': instance.lastName,
    };
