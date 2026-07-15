import 'package:riverpod_annotation/riverpod_annotation.dart';
import '../domain/discipleship_repository.dart';
import '../../../core/network/api/discipleship/models/discipleship_note_dto.dart';
import '../../../core/network/api/discipleship/models/discipleship_note_entry_dto.dart';
import '../../../core/network/api/discipleship/discipleship_api.dart';

part 'discipleship_repository_impl.g.dart';

class DiscipleshipRepositoryImpl implements DiscipleshipRepository {
  final DiscipleshipApi _api;

  DiscipleshipRepositoryImpl(this._api);

  @override
  Future<List<DiscipleshipNoteDto>> getNotes(String discipleId) {
    return _api.getDiscipleshipNotes(discipleId);
  }

  @override
  Future<DiscipleshipNoteDto> getNoteById(String discipleId, String noteId) {
    return _api.getDiscipleshipNoteById(discipleId, noteId);
  }

  @override
  Future<DiscipleshipNoteDto> createNote(
    String discipleId,
    Map<String, dynamic> command,
  ) {
    return _api.createNote(discipleId, command);
  }

  @override
  Future<List<DiscipleshipNoteEntryDto>> getNoteEntries(
    String discipleId,
    String noteId,
  ) {
    return _api.getNoteEntries(discipleId, noteId);
  }

  @override
  Future<DiscipleshipNoteEntryDto> createNoteEntry(
    String discipleId,
    String noteId,
    Map<String, dynamic> command,
  ) {
    return _api.createNoteEntry(discipleId, noteId, command);
  }
}

@riverpod
DiscipleshipRepository discipleshipRepository(Ref ref) {
  return DiscipleshipRepositoryImpl(ref.watch(discipleshipApiProvider));
}
