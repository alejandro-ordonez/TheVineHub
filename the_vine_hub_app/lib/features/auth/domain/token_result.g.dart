// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'token_result.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_TokenResult _$TokenResultFromJson(Map<String, dynamic> json) => _TokenResult(
  isAuthenticated: json['isAuthenticated'] as bool,
  expiration: DateTime.parse(json['expiration'] as String),
  token: json['token'] as String,
  refreshToken: json['refreshToken'] as String,
);

Map<String, dynamic> _$TokenResultToJson(_TokenResult instance) =>
    <String, dynamic>{
      'isAuthenticated': instance.isAuthenticated,
      'expiration': instance.expiration.toIso8601String(),
      'token': instance.token,
      'refreshToken': instance.refreshToken,
    };
