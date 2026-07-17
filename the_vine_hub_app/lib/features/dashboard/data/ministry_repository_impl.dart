import 'package:riverpod_annotation/riverpod_annotation.dart';
import 'package:the_vine_hub_app/features/dashboard/domain/ministry_repository.dart';
import 'package:the_vine_hub_app/features/cells/domain/cell_dto.dart';
import 'package:the_vine_hub_app/features/cells/domain/disciple_dto.dart';
import 'package:the_vine_hub_app/features/cells/domain/add_cell_attendance_dto.dart';
import 'package:the_vine_hub_app/features/cells/domain/update_cell_attendance_dto.dart';
import 'package:the_vine_hub_app/core/network/api/cells/cells_api.dart';
import 'package:the_vine_hub_app/core/network/api/locations/locations_api.dart';

part 'ministry_repository_impl.g.dart';

class MinistryRepositoryImpl implements MinistryRepository {
  final CellsApi _cellsApi;
  final LocationsApi _locationsApi;

  MinistryRepositoryImpl(this._cellsApi, this._locationsApi);

  @override
  Future<List<CellDto>> getCells() async {
    final response = await _cellsApi.getCells();
    return (response as List<dynamic>)
        .map((e) => CellDto.fromJson(e as Map<String, dynamic>))
        .toList();
  }

  @override
  Future<CellDto> getCell(String id) async {
    final response = await _cellsApi.getCell(id);
    return CellDto.fromJson(response as Map<String, dynamic>);
  }

  @override
  Future<CellDto> createCell(CellDto cell) async {
    final response = await _cellsApi.upsertCell(cell.toJson());
    return CellDto.fromJson(response as Map<String, dynamic>);
  }

  @override
  Future<CellDto> updateCell(CellDto cell) async {
    final response = await _cellsApi.upsertCell(cell.toJson());
    return CellDto.fromJson(response as Map<String, dynamic>);
  }

  @override
  Future<void> addAttendance(
    String cellId,
    AddCellAttendanceDto attendance,
  ) async {
    await _cellsApi.recordAttendance(cellId, attendance.toJson());
  }

  @override
  Future<void> updateAttendance(
    String cellId,
    String attendanceId,
    UpdateCellAttendanceDto attendance,
  ) async {
    await _cellsApi.updateAttendance(cellId, attendanceId, attendance.toJson());
  }

  @override
  Future<List<DiscipleDto>> getDisciples(String cellId) async {
    final response = await _cellsApi.getDisciples(cellId);
    return (response as List<dynamic>)
        .map((e) => DiscipleDto.fromJson(e as Map<String, dynamic>))
        .toList();
  }

  @override
  Future<List<CityDto>> getLocationData() async {
    final response = await _locationsApi.getLocationData();
    return response
        .map((e) => CityDto.fromJson(e as Map<String, dynamic>))
        .toList();
  }
}

@riverpod
MinistryRepository ministryRepository(Ref ref) {
  return MinistryRepositoryImpl(ref.watch(cellsApiProvider), ref.watch(locationsApiProvider));
}
