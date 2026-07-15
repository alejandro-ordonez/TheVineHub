// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'create_user_info_dto.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_CreateUserInfoDto _$CreateUserInfoDtoFromJson(Map<String, dynamic> json) =>
    _CreateUserInfoDto(
      document: json['document'] as String,
      name: json['name'] as String,
      lastName: json['lastName'] as String,
      password: json['password'] as String?,
      isUpdate: json['isUpdate'] as bool? ?? false,
      phone: json['phone'] as String,
      gender: (json['gender'] as num).toInt(),
      city: json['city'] as String,
      locality: json['locality'] as String?,
      neighborhood: json['neighborhood'] as String,
      address: json['address'] as String,
      email: json['email'] as String? ?? '',
      profession: json['profession'] as String? ?? '',
      occupation: json['occupation'] as String? ?? '',
      birthday: json['birthday'] == null
          ? null
          : DateTime.parse(json['birthday'] as String),
      maritalStatus: (json['maritalStatus'] as num?)?.toInt(),
      educationalLevel: (json['educationalLevel'] as num?)?.toInt(),
      accessType: (json['accessType'] as num?)?.toInt() ?? 0,
    );

Map<String, dynamic> _$CreateUserInfoDtoToJson(_CreateUserInfoDto instance) =>
    <String, dynamic>{
      'document': instance.document,
      'name': instance.name,
      'lastName': instance.lastName,
      'password': instance.password,
      'isUpdate': instance.isUpdate,
      'phone': instance.phone,
      'gender': instance.gender,
      'city': instance.city,
      'locality': instance.locality,
      'neighborhood': instance.neighborhood,
      'address': instance.address,
      'email': instance.email,
      'profession': instance.profession,
      'occupation': instance.occupation,
      'birthday': instance.birthday?.toIso8601String(),
      'maritalStatus': instance.maritalStatus,
      'educationalLevel': instance.educationalLevel,
      'accessType': instance.accessType,
    };
