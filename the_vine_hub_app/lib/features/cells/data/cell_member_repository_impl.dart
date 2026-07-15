import 'package:riverpod_annotation/riverpod_annotation.dart';
import 'package:jm_ministry_app/features/cells/domain/cell_member_repository.dart';
import 'package:jm_ministry_app/features/cells/domain/document_check_result_dto.dart';
import 'package:jm_ministry_app/features/cells/domain/create_user_info_dto.dart';
import 'package:jm_ministry_app/shared/domain/models/user_info_dto.dart';
import 'package:jm_ministry_app/core/network/api/users/users_api.dart';
import 'package:jm_ministry_app/core/network/api/cells/cells_api.dart';

part 'cell_member_repository_impl.g.dart';

class CellMemberRepositoryImpl implements CellMemberRepository {
  final UsersApi _usersApi;
  final CellsApi _cellsApi;

  CellMemberRepositoryImpl(this._usersApi, this._cellsApi);

  @override
  Future<DocumentCheckResultDto> checkDocument(String document) async {
    final response = await _usersApi.checkDocument(document);
    return DocumentCheckResultDto.fromJson(response as Map<String, dynamic>);
  }

  @override
  Future<void> registerUser(CreateUserInfoDto userInfo) async {
    await _usersApi.createUser(userInfo.toJson());
  }

  @override
  Future<void> updateUser(CreateUserInfoDto userInfo) async {
    await _usersApi.updateUser(userInfo.toJson());
  }

  @override
  Future<void> addDiscipleToCell(String cellId, String document) async {
    final command = {
      'cellId': cellId,
      'documents': [document],
    };
    await _cellsApi.addDisciples(cellId, command);
  }

  @override
  Future<UserInfoDto> getUserInfo(String document) async {
    final response = await _usersApi.getUserInfo(document);
    return UserInfoDto.fromJson(response as Map<String, dynamic>);
  }
}

@riverpod
CellMemberRepository cellMemberRepository(Ref ref) {
  return CellMemberRepositoryImpl(ref.watch(usersApiProvider), ref.watch(cellsApiProvider));
}
