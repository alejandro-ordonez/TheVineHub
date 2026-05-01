import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';
import '../../dashboard/data/ministry_repository_impl.dart';
import '../domain/cell_dto.dart';

part 'cells_provider.g.dart';

@riverpod
Future<List<CellDto>> cells(Ref ref) async {
  final repository = ref.watch(ministryRepositoryProvider);
  return repository.getCells();
}

@riverpod
Future<CellDto> cellDetails(Ref ref, int id) async {
  final repository = ref.watch(ministryRepositoryProvider);
  return repository.getCell(id);
}
