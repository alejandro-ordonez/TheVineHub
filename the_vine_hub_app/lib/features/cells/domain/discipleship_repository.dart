import 'package:jm_ministry_app/core/network/api/discipleship/models/discipleship_note_dto.dart';
import 'package:jm_ministry_app/core/network/api/discipleship/models/discipleship_note_entry_dto.dart';
import 'package:jm_ministry_app/core/network/api/discipleship/models/create_note_dto.dart';
import 'package:jm_ministry_app/core/network/api/discipleship/models/create_note_entry_dto.dart';

abstract class DiscipleshipRepository {
  Future<List<DiscipleshipNoteDto>> getNotes(String discipleId);
  Future<DiscipleshipNoteDto> getNoteById(String discipleId, String noteId);
  Future<DiscipleshipNoteDto> createNote(String discipleId, CreateNoteDto command);
  Future<List<DiscipleshipNoteEntryDto>> getNoteEntries(String discipleId, String noteId);
  Future<DiscipleshipNoteEntryDto> createNoteEntry(String discipleId, String noteId, CreateNoteEntryDto command);
}
