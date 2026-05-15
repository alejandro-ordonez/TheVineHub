import 'package:dio/dio.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';
import '../domain/training_repository.dart';
import '../domain/disciple_step_dto.dart';
import '../domain/step_cycle_dto.dart';
import '../domain/cycle_session_dto.dart';
import '../../../core/network/dio_provider.dart';
import '../../../shared/domain/api_response.dart';

part 'training_repository_impl.g.dart';

class TrainingRepositoryImpl implements TrainingRepository {
  final Dio _dio;

  TrainingRepositoryImpl(this._dio);

  @override
  Future<List<DiscipleStepDto>> getSteps() async {
    final response = await _dio.get('/api/DiscipleJourney/steps');
    final apiResponse = ApiResponse<List<dynamic>>.fromJson(
      response.data,
      (json) => json as List<dynamic>,
    );

    if (apiResponse.success && apiResponse.data != null) {
      return apiResponse.data!
          .map((e) => DiscipleStepDto.fromJson(e as Map<String, dynamic>))
          .toList();
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  @override
  Future<List<StepCycleDto>> getActiveCycles(int stepId) async {
    final response = await _dio.get(
      '/api/DiscipleJourney/steps/$stepId/cycles/active',
    );
    final apiResponse = ApiResponse<List<dynamic>>.fromJson(
      response.data,
      (json) => json as List<dynamic>,
    );

    if (apiResponse.success && apiResponse.data != null) {
      return apiResponse.data!
          .map((e) => StepCycleDto.fromJson(e as Map<String, dynamic>))
          .toList();
    }
    throw Exception(apiResponse.errors.join(', '));
  }

  @override
  Future<List<CycleSessionDto>> getSessions(int cycleId) async {
    final response = await _dio.get(
      '/api/DiscipleJourney/cycles/$cycleId/sessions',
    );
    final apiResponse = ApiResponse<List<dynamic>>.fromJson(
      response.data,
      (json) => json as List<dynamic>,
    );

    if (apiResponse.success && apiResponse.data != null) {
      return apiResponse.data!
          .map((e) => CycleSessionDto.fromJson(e as Map<String, dynamic>))
          .toList();
    }
    throw Exception(apiResponse.errors.join(', '));
  }
}

@riverpod
TrainingRepository trainingRepository(Ref ref) {
  return TrainingRepositoryImpl(ref.watch(dioProvider));
}
