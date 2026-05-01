import 'package:dio/dio.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';
import '../domain/discipleship_repository.dart';
import '../domain/discipleship_note_dto.dart';
import '../domain/discipleship_note_entry_dto.dart';
import '../../../core/network/dio_provider.dart';

part 'discipleship_repository_impl.g.dart';

class DiscipleshipRepositoryImpl implements DiscipleshipRepository {
  final Dio _dio;

  DiscipleshipRepositoryImpl(this._dio);

  @override
  Future<List<DiscipleshipNoteDto>> getNotes(String discipleId) async {
    final response = await _dio.get('/api/Discipleship/$discipleId/notes');
    return (response.data as List)
        .map((e) => DiscipleshipNoteDto.fromJson(e as Map<String, dynamic>))
        .toList();
  }

  @override
  Future<DiscipleshipNoteDto> createNote(String discipleId, Map<String, dynamic> command) async {
    final response = await _dio.post('/api/Discipleship/$discipleId/notes', data: command);
    return DiscipleshipNoteDto.fromJson(response.data as Map<String, dynamic>);
  }

  @override
  Future<List<DiscipleshipNoteEntryDto>> getNoteEntries(String discipleId, int noteId) async {
    final response = await _dio.get('/api/Discipleship/$discipleId/notes/$noteId/entries');
    return (response.data as List)
        .map((e) => DiscipleshipNoteEntryDto.fromJson(e as Map<String, dynamic>))
        .toList();
  }

  @override
  Future<DiscipleshipNoteEntryDto> createNoteEntry(String discipleId, int noteId, Map<String, dynamic> command) async {
    final response = await _dio.post('/api/Discipleship/$discipleId/notes/$noteId/entries', data: command);
    return DiscipleshipNoteEntryDto.fromJson(response.data as Map<String, dynamic>);
  }
}

@riverpod
DiscipleshipRepository discipleshipRepository(Ref ref) {
  return DiscipleshipRepositoryImpl(ref.watch(dioProvider));
}
