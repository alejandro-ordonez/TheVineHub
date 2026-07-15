import 'package:freezed_annotation/freezed_annotation.dart';

part 'add_cell_attendance_dto.freezed.dart';
part 'add_cell_attendance_dto.g.dart';

@freezed
abstract class AddCellAttendanceDto with _$AddCellAttendanceDto {
  const factory AddCellAttendanceDto({
    List<String>? disciples,
    String? notes,
  }) = _AddCellAttendanceDto;

  factory AddCellAttendanceDto.fromJson(Map<String, dynamic> json) =>
      _$AddCellAttendanceDtoFromJson(json);
}
