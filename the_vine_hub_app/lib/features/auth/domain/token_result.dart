import 'package:freezed_annotation/freezed_annotation.dart';

part 'token_result.freezed.dart';
part 'token_result.g.dart';

@freezed
abstract class TokenResult with _$TokenResult {
  const factory TokenResult({
    required bool isAuthenticated,
    required DateTime expiration,
    required String token,
    required String refreshToken,
  }) = _TokenResult;

  factory TokenResult.fromJson(Map<String, dynamic> json) =>
      _$TokenResultFromJson(json);
}
