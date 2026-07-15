// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'authenticate_command.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_AuthenticateCommand _$AuthenticateCommandFromJson(Map<String, dynamic> json) =>
    _AuthenticateCommand(
      document: json['document'] as String?,
      password: json['password'] as String?,
    );

Map<String, dynamic> _$AuthenticateCommandToJson(
        _AuthenticateCommand instance) =>
    <String, dynamic>{
      'document': instance.document,
      'password': instance.password,
    };
