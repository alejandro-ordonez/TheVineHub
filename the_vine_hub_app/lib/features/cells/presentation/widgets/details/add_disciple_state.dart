import 'package:freezed_annotation/freezed_annotation.dart';
import 'package:the_vine_hub_app/features/cells/domain/document_check_result_dto.dart';
import 'package:the_vine_hub_app/shared/domain/models/user_info_dto.dart';

part 'add_disciple_state.freezed.dart';

@freezed
abstract class AddDiscipleState with _$AddDiscipleState {
  const factory AddDiscipleState({
    @Default(false) bool isChecking,
    @Default(false) bool isSubmitting,
    @Default(false) bool documentChecked,
    DocumentCheckResultDto? checkResult,
    UserInfoDto? existingUserInfo,
    String? error,
  }) = _AddDiscipleState;
}
