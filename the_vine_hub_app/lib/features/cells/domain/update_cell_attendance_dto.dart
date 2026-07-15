import 'package:freezed_annotation/freezed_annotation.dart';

part 'update_cell_attendance_dto.freezed.dart';
part 'update_cell_attendance_dto.g.dart';

@freezed
abstract class UpdateCellAttendanceDto with _$UpdateCellAttendanceDto {
  const factory UpdateCellAttendanceDto({
    List<String>? disciples,
    String? notes,
    required DateTime date,
  }) = _UpdateCellAttendanceDto;

  factory UpdateCellAttendanceDto.fromJson(Map<String, dynamic> json) =>
      _$UpdateCellAttendanceDtoFromJson(json);
}
