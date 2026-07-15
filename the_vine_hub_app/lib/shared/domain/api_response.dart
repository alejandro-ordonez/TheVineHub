import 'package:freezed_annotation/freezed_annotation.dart';

part 'api_response.freezed.dart';
part 'api_response.g.dart';

@Freezed(genericArgumentFactories: true)
abstract class ApiResponse<T> with _$ApiResponse<T> {
  const factory ApiResponse({
    @JsonKey(name: 'Details') required String details,
    @JsonKey(name: 'Errors') required List<String> errors,
    @JsonKey(name: 'Success') required bool success,
    @JsonKey(name: 'Data') T? data,
    @JsonKey(name: 'StatusCode') required int statusCode,
  }) = _ApiResponse<T>;

  factory ApiResponse.fromJson(
    Map<String, dynamic> json,
    T Function(Object?) fromJsonT,
  ) => _$ApiResponseFromJson(json, fromJsonT);
}
