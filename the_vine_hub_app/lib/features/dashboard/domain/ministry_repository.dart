import '../../cells/domain/cell_dto.dart';
import '../../cells/domain/disciple_dto.dart';
import '../../cells/domain/add_cell_attendance_dto.dart';
import '../../cells/domain/update_cell_attendance_dto.dart';

abstract class MinistryRepository {
  Future<List<CellDto>> getCells();
  Future<CellDto> getCell(String id);
  Future<CellDto> createCell(CellDto cell);
  Future<CellDto> updateCell(CellDto cell);
  Future<void> addAttendance(String cellId, AddCellAttendanceDto attendance);
  Future<void> updateAttendance(
    String cellId,
    String attendanceId,
    UpdateCellAttendanceDto attendance,
  );
  Future<List<DiscipleDto>> getDisciples(String cellId);
  Future<List<CityDto>> getLocationData();
}
