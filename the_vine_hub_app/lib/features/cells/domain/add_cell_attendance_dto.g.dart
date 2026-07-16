// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'add_cell_attendance_dto.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_AddCellAttendanceDto _$AddCellAttendanceDtoFromJson(
  Map<String, dynamic> json,
) => _AddCellAttendanceDto(
  disciples: (json['disciples'] as List<dynamic>?)
      ?.map((e) => e as String)
      .toList(),
  notes: json['notes'] as String?,
);

Map<String, dynamic> _$AddCellAttendanceDtoToJson(
  _AddCellAttendanceDto instance,
) => <String, dynamic>{
  'disciples': instance.disciples,
  'notes': instance.notes,
};
