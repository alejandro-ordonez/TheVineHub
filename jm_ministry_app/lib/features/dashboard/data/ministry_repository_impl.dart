import 'package:dio/dio.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';
import '../domain/ministry_repository.dart';
import '../../cells/domain/cell_dto.dart';
import '../../cells/domain/add_cell_attendance_dto.dart';
import '../../cells/domain/update_cell_attendance_dto.dart';
import '../../../shared/domain/models/partial_user_info_dto.dart';
import '../../../core/network/dio_provider.dart';

part 'ministry_repository_impl.g.dart';

class MinistryRepositoryImpl implements MinistryRepository {
  final Dio _dio;

  MinistryRepositoryImpl(this._dio);

  @override
  Future<List<CellDto>> getCells() async {
    final response = await _dio.get('/api/Ministry');
    return (response.data as List)
        .map((e) => CellDto.fromJson(e as Map<String, dynamic>))
        .toList();
  }

  @override
  Future<CellDto> getCell(int id) async {
    final response = await _dio.get('/api/Ministry/$id');
    return CellDto.fromJson(response.data as Map<String, dynamic>);
  }

  @override
  Future<void> addAttendance(int cellId, AddCellAttendanceDto attendance) async {
    await _dio.post('/api/Ministry/attendances/$cellId', data: attendance.toJson());
  }

  @override
  Future<void> updateAttendance(int cellId, int attendanceId, UpdateCellAttendanceDto attendance) async {
    await _dio.put('/api/Ministry/attendances/$cellId/$attendanceId', data: attendance.toJson());
  }

  @override
  Future<List<PartialUserInfoDto>> getDisciples(int cellId) async {
    final response = await _dio.get('/api/Ministry/disciples/$cellId');
    return (response.data as List)
        .map((e) => PartialUserInfoDto.fromJson(e as Map<String, dynamic>))
        .toList();
  }
}

@riverpod
MinistryRepository ministryRepository(Ref ref) {
  return MinistryRepositoryImpl(ref.watch(dioProvider));
}
