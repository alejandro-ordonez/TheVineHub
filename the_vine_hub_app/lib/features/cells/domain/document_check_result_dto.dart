import 'package:freezed_annotation/freezed_annotation.dart';

part 'document_check_result_dto.freezed.dart';
part 'document_check_result_dto.g.dart';

@freezed
abstract class DocumentCheckResultDto with _$DocumentCheckResultDto {
  const factory DocumentCheckResultDto({
    required bool exists,
    required bool hasCell,
    String? name,
    String? lastName,
  }) = _DocumentCheckResultDto;

  factory DocumentCheckResultDto.fromJson(Map<String, dynamic> json) =>
      _$DocumentCheckResultDtoFromJson(json);
}
