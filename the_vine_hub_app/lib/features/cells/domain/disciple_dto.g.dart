// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'disciple_dto.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_DiscipleDto _$DiscipleDtoFromJson(Map<String, dynamic> json) => _DiscipleDto(
  id: json['id'] as String?,
  fullName: json['fullName'] as String,
  phone: json['phone'] as String?,
  gender: (json['gender'] as num?)?.toInt(),
  photoPath: json['photoPath'] as String?,
  memberSince: DateTime.parse(json['memberSince'] as String),
  cellId: json['cellId'] as String?,
  discipleStep: json['discipleStep'] as String?,
);

Map<String, dynamic> _$DiscipleDtoToJson(_DiscipleDto instance) =>
    <String, dynamic>{
      'id': instance.id,
      'fullName': instance.fullName,
      'phone': instance.phone,
      'gender': instance.gender,
      'photoPath': instance.photoPath,
      'memberSince': instance.memberSince.toIso8601String(),
      'cellId': instance.cellId,
      'discipleStep': instance.discipleStep,
    };
