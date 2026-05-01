// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'cell_dto.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_CellDto _$CellDtoFromJson(Map<String, dynamic> json) => _CellDto(
  id: (json['id'] as num?)?.toInt(),
  name: json['name'] as String?,
  description: json['description'] as String?,
  mainCell: json['mainCell'] as bool,
  address: json['address'] as String?,
  city: json['city'] == null
      ? null
      : CityDto.fromJson(json['city'] as Map<String, dynamic>),
  locality: json['locality'] == null
      ? null
      : LocalityDto.fromJson(json['locality'] as Map<String, dynamic>),
  day: (json['day'] as num?)?.toInt(),
  openingDate: json['openingDate'] == null
      ? null
      : DateTime.parse(json['openingDate'] as String),
);

Map<String, dynamic> _$CellDtoToJson(_CellDto instance) => <String, dynamic>{
  'id': instance.id,
  'name': instance.name,
  'description': instance.description,
  'mainCell': instance.mainCell,
  'address': instance.address,
  'city': instance.city,
  'locality': instance.locality,
  'day': instance.day,
  'openingDate': instance.openingDate?.toIso8601String(),
};

_CityDto _$CityDtoFromJson(Map<String, dynamic> json) => _CityDto(
  id: (json['id'] as num).toInt(),
  name: json['name'] as String?,
  localities: (json['localities'] as List<dynamic>?)
      ?.map((e) => LocalityDto.fromJson(e as Map<String, dynamic>))
      .toList(),
);

Map<String, dynamic> _$CityDtoToJson(_CityDto instance) => <String, dynamic>{
  'id': instance.id,
  'name': instance.name,
  'localities': instance.localities,
};

_LocalityDto _$LocalityDtoFromJson(Map<String, dynamic> json) => _LocalityDto(
  id: (json['id'] as num).toInt(),
  name: json['name'] as String?,
);

Map<String, dynamic> _$LocalityDtoToJson(_LocalityDto instance) =>
    <String, dynamic>{'id': instance.id, 'name': instance.name};
