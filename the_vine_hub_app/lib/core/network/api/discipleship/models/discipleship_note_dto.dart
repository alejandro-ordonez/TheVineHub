import 'package:freezed_annotation/freezed_annotation.dart';
import 'discipleship_note_entry_dto.dart';

part 'discipleship_note_dto.freezed.dart';
part 'discipleship_note_dto.g.dart';

@freezed
abstract class DiscipleshipNoteDto with _$DiscipleshipNoteDto {
  const factory DiscipleshipNoteDto({
    required String noteId,
    String? title,
    String? description,
    int? noteStatus,
    required DateTime createdAt,
    List<String>? categories,
    String? discipleId,
    String? leaderId,
    List<DiscipleshipNoteEntryDto>? entries,
  }) = _DiscipleshipNoteDto;

  factory DiscipleshipNoteDto.fromJson(Map<String, dynamic> json) =>
      _$DiscipleshipNoteDtoFromJson(json);
}
