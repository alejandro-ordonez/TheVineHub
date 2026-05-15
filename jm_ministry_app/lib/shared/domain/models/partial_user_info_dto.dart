import 'package:freezed_annotation/freezed_annotation.dart';

part 'partial_user_info_dto.freezed.dart';
part 'partial_user_info_dto.g.dart';

@freezed
abstract class PartialUserInfoDto with _$PartialUserInfoDto {
  const PartialUserInfoDto._();

  const factory PartialUserInfoDto({
    String? document,
    String? name,
    String? lastName,
    String? phone,
    int? gender,
    int? maritalStatus,
    String? photo,
    int? cellId,
  }) = _PartialUserInfoDto;

  factory PartialUserInfoDto.fromJson(Map<String, dynamic> json) => _$PartialUserInfoDtoFromJson(json);
}
