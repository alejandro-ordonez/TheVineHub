// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'api_response.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_ApiResponse<T> _$ApiResponseFromJson<T>(
  Map<String, dynamic> json,
  T Function(Object? json) fromJsonT,
) => _ApiResponse<T>(
  details: json['Details'] as String,
  errors: (json['Errors'] as List<dynamic>).map((e) => e as String).toList(),
  success: json['Success'] as bool,
  data: _$nullableGenericFromJson(json['Data'], fromJsonT),
  statusCode: (json['StatusCode'] as num).toInt(),
);

Map<String, dynamic> _$ApiResponseToJson<T>(
  _ApiResponse<T> instance,
  Object? Function(T value) toJsonT,
) => <String, dynamic>{
  'Details': instance.details,
  'Errors': instance.errors,
  'Success': instance.success,
  'Data': _$nullableGenericToJson(instance.data, toJsonT),
  'StatusCode': instance.statusCode,
};

T? _$nullableGenericFromJson<T>(
  Object? input,
  T Function(Object? json) fromJson,
) => input == null ? null : fromJson(input);

Object? _$nullableGenericToJson<T>(
  T? input,
  Object? Function(T value) toJson,
) => input == null ? null : toJson(input);
