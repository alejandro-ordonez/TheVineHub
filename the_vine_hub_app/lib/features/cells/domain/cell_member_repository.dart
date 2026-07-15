import 'document_check_result_dto.dart';
import 'create_user_info_dto.dart';
import '../../../shared/domain/models/user_info_dto.dart';

abstract class CellMemberRepository {
  Future<DocumentCheckResultDto> checkDocument(String document);
  Future<void> registerUser(CreateUserInfoDto userInfo);
  Future<void> updateUser(CreateUserInfoDto userInfo);
  Future<void> addDiscipleToCell(String cellId, String document);
  Future<UserInfoDto> getUserInfo(String document);
}
