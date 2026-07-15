import 'disciple_step_dto.dart';
import 'step_cycle_dto.dart';
import 'cycle_session_dto.dart';

abstract class TrainingRepository {
  Future<List<DiscipleStepDto>> getSteps();
  Future<List<StepCycleDto>> getActiveCycles(int stepId);
  Future<List<CycleSessionDto>> getSessions(int cycleId);
}
