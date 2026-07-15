import 'package:freezed_annotation/freezed_annotation.dart';

part 'create_user_info_dto.freezed.dart';
part 'create_user_info_dto.g.dart';

@freezed
abstract class CreateUserInfoDto with _$CreateUserInfoDto {
  const factory CreateUserInfoDto({
    required String document,
    required String name,
    required String lastName,
    String? password,
    @Default(false) bool isUpdate,
    required String phone,
    required int gender,
    required String city,
    String? locality,
    required String neighborhood,
    required String address,
    @Default('') String email,
    @Default('') String profession,
    @Default('') String occupation,
    DateTime? birthday,
    int? maritalStatus,
    int? educationalLevel,
    @Default(0) int accessType,
  }) = _CreateUserInfoDto;

  factory CreateUserInfoDto.fromJson(Map<String, dynamic> json) =>
      _$CreateUserInfoDtoFromJson(json);
}
