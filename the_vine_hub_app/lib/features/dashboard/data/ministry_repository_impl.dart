import 'package:dio/dio.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';
import '../domain/ministry_repository.dart';
import '../../cells/domain/cell_dto.dart';
import '../../cells/domain/disciple_dto.dart';
import '../../cells/domain/add_cell_attendance_dto.dart';
import '../../cells/domain/update_cell_attendance_dto.dart';
import '../../../core/network/dio_provider.dart';
import '../../../shared/domain/api_response.dart';

part 'ministry_repository_impl.g.dart';

class MinistryRepositoryImpl implements MinistryRepository {
  final Dio _dio;

  MinistryRepositoryImpl(this._dio);

  @override
  Future<List<CellDto>> getCells() async {
    final response = await _dio.get('/api/Ministry');
    final apiResponse = ApiResponse<List<dynamic>>.fromJson(
      response.data,
      (json) => json as List<dynamic>,
    );

    if (apiResponse.success && apiResponse.data != null) {
      return apiResponse.data!
          .map((e) => CellDto.fromJson(e as Map<String, dynamic>))
          .toList();
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  @override
  Future<CellDto> getCell(String id) async {
    final response = await _dio.get('/api/Ministry/$id');
    final apiResponse = ApiResponse<Map<String, dynamic>>.fromJson(
      response.data,
      (json) => json as Map<String, dynamic>,
    );

    if (apiResponse.success && apiResponse.data != null) {
      return CellDto.fromJson(apiResponse.data!);
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  @override
  Future<CellDto> createCell(CellDto cell) async {
    final response = await _dio.post('/api/Ministry', data: cell.toJson());
    final apiResponse = ApiResponse<Map<String, dynamic>>.fromJson(
      response.data,
      (json) => json as Map<String, dynamic>,
    );

    if (apiResponse.success && apiResponse.data != null) {
      return CellDto.fromJson(apiResponse.data!);
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  @override
  Future<CellDto> updateCell(CellDto cell) async {
    final response = await _dio.put('/api/Ministry', data: cell.toJson());
    final apiResponse = ApiResponse<Map<String, dynamic>>.fromJson(
      response.data,
      (json) => json as Map<String, dynamic>,
    );

    if (apiResponse.success && apiResponse.data != null) {
      return CellDto.fromJson(apiResponse.data!);
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  @override
  Future<void> addAttendance(
    String cellId,
    AddCellAttendanceDto attendance,
  ) async {
    final response = await _dio.post(
      '/api/Ministry/attendances/$cellId',
      data: attendance.toJson(),
    );
    final apiResponse = ApiResponse.fromJson(response.data, (json) => json);
    if (!apiResponse.success) {
      throw Exception(apiResponse.errors.join(', '));
    }
  }

  @override
  Future<void> updateAttendance(
    String cellId,
    String attendanceId,
    UpdateCellAttendanceDto attendance,
  ) async {
    final response = await _dio.put(
      '/api/Ministry/attendances/$cellId/$attendanceId',
      data: attendance.toJson(),
    );
    final apiResponse = ApiResponse.fromJson(response.data, (json) => json);
    if (!apiResponse.success) {
      throw Exception(apiResponse.errors.join(', '));
    }
  }

  @override
  Future<List<DiscipleDto>> getDisciples(String cellId) async {
    final response = await _dio.get('/api/Ministry/disciples/$cellId');
    final apiResponse = ApiResponse<List<dynamic>>.fromJson(
      response.data,
      (json) => json as List<dynamic>,
    );

    if (apiResponse.success && apiResponse.data != null) {
      return apiResponse.data!
          .map((e) => DiscipleDto.fromJson(e as Map<String, dynamic>))
          .toList();
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  @override
  Future<List<CityDto>> getLocationData() async {
    final response = await _dio.get('/api/Location');
    final apiResponse = ApiResponse<List<dynamic>>.fromJson(
      response.data,
      (json) => json as List<dynamic>,
    );

    if (apiResponse.success && apiResponse.data != null) {
      return apiResponse.data!
          .map((e) => CityDto.fromJson(e as Map<String, dynamic>))
          .toList();
    }
    throw Exception(apiResponse.errors.join(', '));
  }
}

@riverpod
MinistryRepository ministryRepository(Ref ref) {
  return MinistryRepositoryImpl(ref.watch(dioProvider));
}
