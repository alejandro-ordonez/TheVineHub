import 'discipleship_note_dto.dart';
import 'discipleship_note_entry_dto.dart';

abstract class DiscipleshipRepository {
  Future<List<DiscipleshipNoteDto>> getNotes(String discipleId);
  Future<DiscipleshipNoteDto> createNote(String discipleId, Map<String, dynamic> command);
  Future<List<DiscipleshipNoteEntryDto>> getNoteEntries(String discipleId, int noteId);
  Future<DiscipleshipNoteEntryDto> createNoteEntry(String discipleId, int noteId, Map<String, dynamic> command);
}
