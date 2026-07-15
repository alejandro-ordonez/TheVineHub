import 'package:dio/dio.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';
import '../domain/cell_member_repository.dart';
import '../domain/document_check_result_dto.dart';
import '../domain/create_user_info_dto.dart';
import '../../../shared/domain/models/user_info_dto.dart';
import '../../../core/network/dio_provider.dart';

part 'cell_member_repository_impl.g.dart';

class CellMemberRepositoryImpl implements CellMemberRepository {
  final Dio _dio;

  CellMemberRepositoryImpl(this._dio);

  @override
  Future<DocumentCheckResultDto> checkDocument(String document) async {
    final response = await _dio.get('/api/User/Check/$document');
    return DocumentCheckResultDto.fromJson(response.data as Map<String, dynamic>);
  }

  @override
  Future<void> registerUser(CreateUserInfoDto userInfo) async {
    await _dio.post('/api/User/register', data: userInfo.toJson());
  }

  @override
  Future<void> updateUser(CreateUserInfoDto userInfo) async {
    await _dio.put('/api/User', data: userInfo.toJson());
  }

  @override
  Future<void> addDiscipleToCell(String cellId, String document) async {
    final command = {
      'cellId': cellId,
      'documents': [document],
    };
    await _dio.post('/api/Ministry/disciples/$cellId', data: command);
  }

  @override
  Future<UserInfoDto> getUserInfo(String document) async {
    final response = await _dio.get('/api/User/$document');
    return UserInfoDto.fromJson(response.data as Map<String, dynamic>);
  }
}

@riverpod
CellMemberRepository cellMemberRepository(Ref ref) {
  return CellMemberRepositoryImpl(ref.watch(dioProvider));
}
