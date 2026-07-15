// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'user_info_dto.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_UserInfoDto _$UserInfoDtoFromJson(Map<String, dynamic> json) => _UserInfoDto(
      document: json['document'] as String?,
      name: json['name'] as String?,
      lastName: json['lastName'] as String?,
      phone: json['phone'] as String?,
      gender: (json['gender'] as num?)?.toInt(),
      maritalStatus: (json['maritalStatus'] as num?)?.toInt(),
      photo: json['photo'] as String?,
      cellId: (json['cellId'] as num?)?.toInt(),
      email: json['email'] as String?,
      address: json['address'] as String?,
      city: json['city'] as String?,
      locality: json['locality'] as String?,
      neighborhood: json['neighborhood'] as String?,
      profession: json['profession'] as String?,
      occupation: json['occupation'] as String?,
      birthday: json['birthday'] == null
          ? null
          : DateTime.parse(json['birthday'] as String),
      educationalLevel: (json['educationalLevel'] as num?)?.toInt(),
      accessType: (json['accessType'] as num?)?.toInt(),
      leaders: (json['leaders'] as List<dynamic>?)
          ?.map((e) => PartialUserInfoDto.fromJson(e as Map<String, dynamic>))
          .toList(),
    );

Map<String, dynamic> _$UserInfoDtoToJson(_UserInfoDto instance) =>
    <String, dynamic>{
      'document': instance.document,
      'name': instance.name,
      'lastName': instance.lastName,
      'phone': instance.phone,
      'gender': instance.gender,
      'maritalStatus': instance.maritalStatus,
      'photo': instance.photo,
      'cellId': instance.cellId,
      'email': instance.email,
      'address': instance.address,
      'city': instance.city,
      'locality': instance.locality,
      'neighborhood': instance.neighborhood,
      'profession': instance.profession,
      'occupation': instance.occupation,
      'birthday': instance.birthday?.toIso8601String(),
      'educationalLevel': instance.educationalLevel,
      'accessType': instance.accessType,
      'leaders': instance.leaders,
    };
