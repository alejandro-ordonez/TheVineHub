import 'package:riverpod_annotation/riverpod_annotation.dart';
import 'add_disciple_state.dart';
import '../../../data/cell_member_repository_impl.dart';
import '../../../domain/create_user_info_dto.dart';

part 'add_disciple_notifier.g.dart';

@riverpod
class AddDiscipleNotifier extends _$AddDiscipleNotifier {
  @override
  AddDiscipleState build() {
    return const AddDiscipleState();
  }

  Future<void> checkDocument(String document) async {
    state = state.copyWith(isChecking: true, error: null);
    try {
      final repo = ref.read(cellMemberRepositoryProvider);
      final result = await repo.checkDocument(document);

      if (result.hasCell) {
        state = state.copyWith(
          isChecking: false,
          error: 'El usuario ya pertenece a una célula.',
        );
        return;
      }

      if (result.exists) {
        final userInfo = await repo.getUserInfo(document);
        state = state.copyWith(
          isChecking: false,
          documentChecked: true,
          checkResult: result,
          existingUserInfo: userInfo,
        );
      } else {
        state = state.copyWith(
          isChecking: false,
          documentChecked: true,
          checkResult: result,
          existingUserInfo: null,
        );
      }
    } catch (e) {
      state = state.copyWith(
        isChecking: false,
        error: e.toString(),
      );
    }
  }

  Future<bool> submitDisciple(String cellId, CreateUserInfoDto userInfo) async {
    state = state.copyWith(isSubmitting: true, error: null);
    try {
      final repo = ref.read(cellMemberRepositoryProvider);

      if (state.checkResult?.exists == true) {
        await repo.updateUser(userInfo.copyWith(isUpdate: true));
      } else {
        await repo.registerUser(userInfo);
      }

      await repo.addDiscipleToCell(cellId, userInfo.document);
      state = state.copyWith(isSubmitting: false);
      return true;
    } catch (e) {
      state = state.copyWith(isSubmitting: false, error: e.toString());
      return false;
    }
  }
}
