import 'package:riverpod_annotation/riverpod_annotation.dart';
import '../domain/training_repository.dart';
import '../domain/disciple_step_dto.dart';
import '../domain/step_cycle_dto.dart';
import '../domain/cycle_session_dto.dart';
import '../../../core/network/api/disciple_journey/disciple_journey_api.dart';

part 'training_repository_impl.g.dart';

class TrainingRepositoryImpl implements TrainingRepository {
  final DiscipleJourneyApi _discipleJourneyApi;

  TrainingRepositoryImpl(this._discipleJourneyApi);

  @override
  Future<List<DiscipleStepDto>> getSteps() async {
    final response = await _discipleJourneyApi.getSteps();
    return (response as List<dynamic>)
        .map((e) => DiscipleStepDto.fromJson(e as Map<String, dynamic>))
        .toList();
  }

  @override
  Future<List<StepCycleDto>> getActiveCycles(int stepId) async {
    final response = await _discipleJourneyApi.getCycles(stepId.toString());
    return (response as List<dynamic>)
        .map((e) => StepCycleDto.fromJson(e as Map<String, dynamic>))
        .toList();
  }

  @override
  Future<List<CycleSessionDto>> getSessions(int cycleId) async {
    final response = await _discipleJourneyApi.getSessions(cycleId.toString());
    return (response as List<dynamic>)
        .map((e) => CycleSessionDto.fromJson(e as Map<String, dynamic>))
        .toList();
  }
}

@riverpod
TrainingRepository trainingRepository(Ref ref) {
  return TrainingRepositoryImpl(ref.watch(discipleJourneyApiProvider));
}
