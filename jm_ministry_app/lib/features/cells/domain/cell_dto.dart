import 'package:freezed_annotation/freezed_annotation.dart';

part 'cell_dto.freezed.dart';
part 'cell_dto.g.dart';

@freezed
abstract class CellDto with _$CellDto {
  const factory CellDto({
    int? id,
    String? name,
    String? description,
    required bool mainCell,
    String? address,
    CityDto? city,
    LocalityDto? locality,
    int? day,
    DateTime? openingDate,
  }) = _CellDto;

  factory CellDto.fromJson(Map<String, dynamic> json) => _$CellDtoFromJson(json);
}

@freezed
abstract class CityDto with _$CityDto {
  const factory CityDto({
    required int id,
    required String? name,
    List<LocalityDto>? localities,
  }) = _CityDto;

  factory CityDto.fromJson(Map<String, dynamic> json) => _$CityDtoFromJson(json);
}

@freezed
abstract class LocalityDto with _$LocalityDto {
  const factory LocalityDto({
    required int id,
    required String? name,
  }) = _LocalityDto;

  factory LocalityDto.fromJson(Map<String, dynamic> json) => _$LocalityDtoFromJson(json);
}
