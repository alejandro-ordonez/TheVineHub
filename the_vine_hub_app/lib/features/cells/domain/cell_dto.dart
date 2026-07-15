import 'package:freezed_annotation/freezed_annotation.dart';

part 'cell_dto.freezed.dart';
part 'cell_dto.g.dart';

@freezed
abstract class CellDto with _$CellDto {
  const factory CellDto({
    String? id,
    required String name,
    required String description,
    required bool mainCell,
    String? address,
    @Default(1) int level,
    @Default(0) int memberCount,
    int? day,
    DateTime? openingDate,
    @Default([]) List<LeaderInfoDto> leaders,
    CityDto? city,
    LocalityDto? locality,
  }) = _CellDto;

  factory CellDto.fromJson(Map<String, dynamic> json) =>
      _$CellDtoFromJson(json);
}

@freezed
abstract class LeaderInfoDto with _$LeaderInfoDto {
  const factory LeaderInfoDto({
    String? id,
    String? photoUrl,
    required String fullName,
  }) = _LeaderInfoDto;

  factory LeaderInfoDto.fromJson(Map<String, dynamic> json) =>
      _$LeaderInfoDtoFromJson(json);
}

@freezed
abstract class CityDto with _$CityDto {
  const factory CityDto({
    required String id,
    required String name,
    List<LocalityDto>? localities,
  }) = _CityDto;

  factory CityDto.fromJson(Map<String, dynamic> json) =>
      _$CityDtoFromJson(json);
}

@freezed
abstract class LocalityDto with _$LocalityDto {
  const factory LocalityDto({required String id, required String name}) =
      _LocalityDto;

  factory LocalityDto.fromJson(Map<String, dynamic> json) =>
      _$LocalityDtoFromJson(json);
}
