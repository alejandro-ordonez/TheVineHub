// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'partial_user_info_dto.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_PartialUserInfoDto _$PartialUserInfoDtoFromJson(Map<String, dynamic> json) =>
    _PartialUserInfoDto(
      document: json['document'] as String?,
      name: json['name'] as String?,
      lastName: json['lastName'] as String?,
      phone: json['phone'] as String?,
      gender: (json['gender'] as num?)?.toInt(),
      maritalStatus: (json['maritalStatus'] as num?)?.toInt(),
      photo: json['photo'] as String?,
      cellId: (json['cellId'] as num?)?.toInt(),
    );

Map<String, dynamic> _$PartialUserInfoDtoToJson(_PartialUserInfoDto instance) =>
    <String, dynamic>{
      'document': instance.document,
      'name': instance.name,
      'lastName': instance.lastName,
      'phone': instance.phone,
      'gender': instance.gender,
      'maritalStatus': instance.maritalStatus,
      'photo': instance.photo,
      'cellId': instance.cellId,
    };
