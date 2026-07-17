import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:the_vine_hub_app/shared/domain/models/partial_user_info_dto.dart';

part 'user_info_dto.freezed.dart';
part 'user_info_dto.g.dart';

@freezed
abstract class UserInfoDto with _$UserInfoDto {
  const UserInfoDto._();

  const factory UserInfoDto({
    String? document,
    String? name,
    String? lastName,
    String? phone,
    int? gender,
    int? maritalStatus,
    String? photo,
    int? cellId,
    String? email,
    String? address,
    String? city,
    String? locality,
    String? neighborhood,
    String? profession,
    String? occupation,
    DateTime? birthday,
    int? educationalLevel,
    int? accessType,
    List<PartialUserInfoDto>? leaders,
  }) = _UserInfoDto;

  factory UserInfoDto.fromJson(Map<String, dynamic> json) => _$UserInfoDtoFromJson(json);
}
