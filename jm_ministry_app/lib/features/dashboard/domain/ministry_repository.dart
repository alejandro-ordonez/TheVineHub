import '../../cells/domain/cell_dto.dart';
import '../../cells/domain/add_cell_attendance_dto.dart';
import '../../cells/domain/update_cell_attendance_dto.dart';
import '../../../shared/domain/models/partial_user_info_dto.dart';

abstract class MinistryRepository {
  Future<List<CellDto>> getCells();
  Future<CellDto> getCell(int id);
  Future<void> addAttendance(int cellId, AddCellAttendanceDto attendance);
  Future<void> updateAttendance(int cellId, int attendanceId, UpdateCellAttendanceDto attendance);
  Future<List<PartialUserInfoDto>> getDisciples(int cellId);
}
