import 'package:freezed_annotation/freezed_annotation.dart';

part 'discipleship_note_entry_dto.freezed.dart';
part 'discipleship_note_entry_dto.g.dart';

@freezed
abstract class DiscipleshipNoteEntryDto with _$DiscipleshipNoteEntryDto {
  const factory DiscipleshipNoteEntryDto({
    required String id,
    String? content,
    required DateTime date,
    required DateTime createdAt,
    required String noteId,
    String? authorId,
  }) = _DiscipleshipNoteEntryDto;

  factory DiscipleshipNoteEntryDto.fromJson(Map<String, dynamic> json) =>
      _$DiscipleshipNoteEntryDtoFromJson(json);
}
