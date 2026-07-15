import 'package:jm_ministry_app/features/training/domain/disciple_step_dto.dart';
import 'package:jm_ministry_app/features/training/domain/step_cycle_dto.dart';
import 'package:jm_ministry_app/features/training/domain/cycle_session_dto.dart';

abstract class TrainingRepository {
  Future<List<DiscipleStepDto>> getSteps();
  Future<List<StepCycleDto>> getActiveCycles(int stepId);
  Future<List<CycleSessionDto>> getSessions(int cycleId);
}
