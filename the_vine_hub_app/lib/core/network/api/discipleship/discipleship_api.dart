import 'package:dio/dio.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';
import 'package:jm_ministry_app/core/network/api/discipleship/models/discipleship_note_dto.dart';
import 'package:jm_ministry_app/core/network/api/discipleship/models/discipleship_note_entry_dto.dart';
import 'package:jm_ministry_app/core/network/api/discipleship/models/create_note_dto.dart';
import 'package:jm_ministry_app/core/network/api/discipleship/models/create_note_entry_dto.dart';
import 'package:jm_ministry_app/core/network/dio_provider.dart';
import 'package:jm_ministry_app/shared/domain/api_response.dart';

part 'discipleship_api.g.dart';

class DiscipleshipApi {
  final Dio _dio;

  DiscipleshipApi(this._dio);

  Future<List<DiscipleshipNoteDto>> getDiscipleshipNotes(String discipleId) async {
    final response = await _dio.get('/api/discipleship/$discipleId/notes');
    final apiResponse = ApiResponse<List<dynamic>>.fromJson(
      response.data,
      (json) => json as List<dynamic>,
    );

    if (apiResponse.success) {
      return apiResponse.data!
          .map((e) => DiscipleshipNoteDto.fromJson(e as Map<String, dynamic>))
          .toList();
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  Future<DiscipleshipNoteDto> getDiscipleshipNoteById(String discipleId, String noteId) async {
    final response = await _dio.get('/api/discipleship/$discipleId/notes/$noteId');
    final apiResponse = ApiResponse<Map<String, dynamic>>.fromJson(
      response.data,
      (json) => json as Map<String, dynamic>,
    );

    if (apiResponse.success) {
      return DiscipleshipNoteDto.fromJson(apiResponse.data!);
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  Future<DiscipleshipNoteDto> createNote(
    String discipleId,
    CreateNoteDto command,
  ) async {
    final response = await _dio.post(
      '/api/discipleship/$discipleId/notes',
      data: command.toJson(),
    );
    final apiResponse = ApiResponse<Map<String, dynamic>>.fromJson(
      response.data,
      (json) => json as Map<String, dynamic>,
    );

    if (apiResponse.success) {
      return DiscipleshipNoteDto.fromJson(apiResponse.data!);
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  Future<List<DiscipleshipNoteEntryDto>> getNoteEntries(
    String discipleId,
    String noteId,
  ) async {
    final response = await _dio.get(
      '/api/discipleship/$discipleId/notes/$noteId/entries',
    );
    final apiResponse = ApiResponse<List<dynamic>>.fromJson(
      response.data,
      (json) => json as List<dynamic>,
    );

    if (apiResponse.success) {
      return apiResponse.data!
          .map(
            (e) => DiscipleshipNoteEntryDto.fromJson(e as Map<String, dynamic>),
          )
          .toList();
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  Future<DiscipleshipNoteEntryDto> createNoteEntry(
    String discipleId,
    String noteId,
    CreateNoteEntryDto command,
  ) async {
    final response = await _dio.post(
      '/api/discipleship/$discipleId/notes/$noteId/entries',
      data: command.toJson(),
    );
    final apiResponse = ApiResponse<Map<String, dynamic>>.fromJson(
      response.data,
      (json) => json as Map<String, dynamic>,
    );

    if (apiResponse.success) {
      return DiscipleshipNoteEntryDto.fromJson(apiResponse.data!);
    }
    throw Exception(apiResponse.errors.join(', '));
  }
}

@riverpod
DiscipleshipApi discipleshipApi(Ref ref) {
  return DiscipleshipApi(ref.watch(dioProvider));
}
