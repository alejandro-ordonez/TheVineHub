// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'update_cell_attendance_dto.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

_UpdateCellAttendanceDto _$UpdateCellAttendanceDtoFromJson(
  Map<String, dynamic> json,
) => _UpdateCellAttendanceDto(
  disciples: (json['disciples'] as List<dynamic>?)
      ?.map((e) => e as String)
      .toList(),
  notes: json['notes'] as String?,
  date: DateTime.parse(json['date'] as String),
);

Map<String, dynamic> _$UpdateCellAttendanceDtoToJson(
  _UpdateCellAttendanceDto instance,
) => <String, dynamic>{
  'disciples': instance.disciples,
  'notes': instance.notes,
  'date': instance.date.toIso8601String(),
};
