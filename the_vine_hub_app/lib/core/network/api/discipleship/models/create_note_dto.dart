import 'package:freezed_annotation/freezed_annotation.dart';

part 'create_note_dto.freezed.dart';
part 'create_note_dto.g.dart';

@freezed
abstract class CreateNoteDto with _$CreateNoteDto {
  const factory CreateNoteDto({
    required String title,
    @Default('') String description,
    @Default([]) List<String> categories,
  }) = _CreateNoteDto;

  factory CreateNoteDto.fromJson(Map<String, dynamic> json) =>
      _$CreateNoteDtoFromJson(json);
}
