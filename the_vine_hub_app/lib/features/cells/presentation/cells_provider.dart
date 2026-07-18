import 'package:riverpod_annotation/riverpod_annotation.dart';
import 'package:the_vine_hub_app/features/dashboard/data/ministry_repository_impl.dart';
import 'package:the_vine_hub_app/features/cells/domain/cell_dto.dart';
import 'package:the_vine_hub_app/features/cells/domain/disciple_dto.dart';

part 'cells_provider.g.dart';

@riverpod
Future<List<CellDto>> cells(Ref ref) async {
  final repository = ref.watch(ministryRepositoryProvider);
  return repository.getCells();
}

@riverpod
Future<Map<int, List<CellDto>>> groupedCells(Ref ref) async {
  final cellsAsync = await ref.watch(cellsProvider.future);

  final groupedCells = <int, List<CellDto>>{};
  for (final cell in cellsAsync) {
    groupedCells.putIfAbsent(cell.level, () => []).add(cell);
  }

  return groupedCells;
}

@riverpod
Future<CellDto> cellDetails(Ref ref, String id) async {
  final repository = ref.watch(ministryRepositoryProvider);
  return repository.getCell(id);
}

@riverpod
Future<List<DiscipleDto>> cellDisciples(Ref ref, String cellId) async {
  final repo = ref.watch(ministryRepositoryProvider);
  return repo.getDisciples(cellId);
}

@riverpod
Future<List<CityDto>> locationData(Ref ref) async {
  final repo = ref.watch(ministryRepositoryProvider);
  return repo.getLocationData();
}
