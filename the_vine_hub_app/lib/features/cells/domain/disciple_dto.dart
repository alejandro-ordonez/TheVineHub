import 'package:freezed_annotation/freezed_annotation.dart';

part 'disciple_dto.freezed.dart';
part 'disciple_dto.g.dart';

@freezed
abstract class DiscipleDto with _$DiscipleDto {
  const factory DiscipleDto({
    String? id,
    required String fullName,
    String? phone,
    int? gender,
    String? photoPath,
    required DateTime memberSince,
    String? cellId,
    String? discipleStep,
  }) = _DiscipleDto;

  factory DiscipleDto.fromJson(Map<String, dynamic> json) =>
      _$DiscipleDtoFromJson(json);
}
