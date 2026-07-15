import 'package:freezed_annotation/freezed_annotation.dart';

part 'authenticate_command.freezed.dart';
part 'authenticate_command.g.dart';

@freezed
abstract class AuthenticateCommand with _$AuthenticateCommand {
  const factory AuthenticateCommand({
    String? document,
    String? password,
  }) = _AuthenticateCommand;

  factory AuthenticateCommand.fromJson(Map<String, dynamic> json) => _$AuthenticateCommandFromJson(json);
}
