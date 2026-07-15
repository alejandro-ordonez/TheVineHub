import 'package:freezed_annotation/freezed_annotation.dart';

part 'create_note_entry_dto.freezed.dart';
part 'create_note_entry_dto.g.dart';

@freezed
abstract class CreateNoteEntryDto with _$CreateNoteEntryDto {
  const factory CreateNoteEntryDto({
    required String content,
    required DateTime date,
  }) = _CreateNoteEntryDto;

  factory CreateNoteEntryDto.fromJson(Map<String, dynamic> json) =>
      _$CreateNoteEntryDtoFromJson(json);
}
