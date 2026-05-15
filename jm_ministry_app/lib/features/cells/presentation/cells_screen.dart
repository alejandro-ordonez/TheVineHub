import 'dart:math' as math;
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:go_router/go_router.dart';
import 'package:flutter_staggered_grid_view/flutter_staggered_grid_view.dart';
import 'package:skeletonizer/skeletonizer.dart';
import 'cells_provider.dart';
import 'widgets/cell_card.dart';
import 'widgets/add_cell_form.dart';
import 'widgets/list/cells_header.dart';
import 'widgets/list/pending_attendance_card.dart';
import 'widgets/list/empty_cells_state.dart';
import '../domain/cell_dto.dart';
import '../../../shared/presentation/shell_utils.dart';
import '../../../shared/presentation/widgets/animations/entrance_fader.dart';
import 'package:jm_ministry_app/i18n/strings.g.dart';

class CellsScreen extends ConsumerWidget {
  const CellsScreen({super.key});

  String _getLevelName(int level, Translations t) {
    if (level <= 0) return t.common.unknown;
    final powerValue = math.pow(12, level).toInt();
    return t.cells.levels.g12(count: powerValue);
  }

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final t = Translations.of(context);
    final cellsAsync = ref.watch(cellsProvider);
    final theme = Theme.of(context);
    final colorScheme = theme.colorScheme;
    final screenWidth = MediaQuery.of(context).size.width;

    // Responsive column count
    final crossAxisCount = screenWidth > 1200
        ? 3
        : screenWidth > 800
        ? 2
        : 1;

    return Scaffold(
      backgroundColor: colorScheme.surface,
      appBar: AppBar(
        title: Text(t.cells.title),
        elevation: 0,
        backgroundColor: colorScheme.surface,
        foregroundColor: colorScheme.primary,
        leading: IconButton(
          icon: const Icon(Icons.menu),
          onPressed: () {
            ref.read(shellScaffoldKeyProvider).currentState?.openDrawer();
          },
        ),
      ),
      body: RefreshIndicator(
        onRefresh: () => ref.refresh(cellsProvider.future),
        child: Skeletonizer(
          enabled: cellsAsync.isLoading,
          child: Center(
            child: ConstrainedBox(
              constraints: const BoxConstraints(maxWidth: 1400),
              child: CustomScrollView(
                slivers: [
                  SliverPadding(
                    padding: const EdgeInsets.symmetric(
                      horizontal: 20,
                      vertical: 24,
                    ),
                    sliver: SliverToBoxAdapter(
                      child: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          const EntranceFader(delay: 0, child: CellsHeader()),
                          const SizedBox(height: 24),
                          EntranceFader(
                            delay: 100,
                            child: _SearchField(colorScheme: colorScheme, t: t),
                          ),
                          const SizedBox(height: 24),
                          const EntranceFader(
                            delay: 200,
                            child: PendingAttendanceCard(),
                          ),
                          const SizedBox(height: 32),
                        ],
                      ),
                    ),
                  ),
                  cellsAsync.when(
                    data: (cells) {
                      if (cells.isEmpty && !cellsAsync.isLoading) {
                        return const EmptyCellsState();
                      }

                      final displayCells = cellsAsync.isLoading
                          ? List.generate(
                              6,
                              (index) => CellDto(
                                name: 'Loading Cell Name',
                                description:
                                    'This is a loading description for the skeleton state.',
                                mainCell: false,
                                level: (index % 2) + 1,
                              ),
                            )
                          : cells;

                      // Group cells by level
                      final groupedCells = <int, List<CellDto>>{};
                      for (final cell in displayCells) {
                        groupedCells
                            .putIfAbsent(cell.level, () => [])
                            .add(cell);
                      }

                      final sortedLevels = groupedCells.keys.toList()..sort();

                      return SliverList(
                        delegate: SliverChildBuilderDelegate((
                          context,
                          levelIndex,
                        ) {
                          final level = sortedLevels[levelIndex];
                          final levelCells = groupedCells[level]!;

                          return Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              Padding(
                                padding: const EdgeInsets.symmetric(
                                  horizontal: 20,
                                  vertical: 16,
                                ),
                                child: Text(
                                  _getLevelName(level, t),
                                  style: theme.textTheme.titleLarge?.copyWith(
                                    fontWeight: FontWeight.bold,
                                    color: colorScheme.secondary,
                                  ),
                                ),
                              ),
                              Padding(
                                padding: const EdgeInsets.symmetric(
                                  horizontal: 20,
                                ),
                                child: MasonryGridView.count(
                                  shrinkWrap: true,
                                  physics: const NeverScrollableScrollPhysics(),
                                  crossAxisCount: crossAxisCount,
                                  mainAxisSpacing: 20,
                                  crossAxisSpacing: 20,
                                  itemBuilder: (context, index) {
                                    return CellCard(
                                      index: index,
                                      cell: levelCells[index],
                                      onTap: () => context.push(
                                        '/cells/${levelCells[index].id}',
                                      ),
                                    );
                                  },
                                  itemCount: levelCells.length,
                                ),
                              ),
                              const SizedBox(height: 32),
                            ],
                          );
                        }, childCount: sortedLevels.length),
                      );
                    },
                    loading: () =>
                        const SliverToBoxAdapter(child: SizedBox.shrink()),
                    error: (err, stack) => _ErrorState(err: err, ref: ref),
                  ),
                  const SliverToBoxAdapter(child: SizedBox(height: 100)),
                ],
              ),
            ),
          ),
        ),
      ),
      floatingActionButton: FloatingActionButton.extended(
        onPressed: () {
          Navigator.of(context).push(
            MaterialPageRoute(
              builder: (_) => const AddCellForm(),
              fullscreenDialog: true,
            ),
          );
        },
        icon: const Icon(Icons.add),
        label: Text(t.cells.newCell),
      ),
    );
  }
}

class _SearchField extends StatelessWidget {
  const _SearchField({required this.colorScheme, required this.t});

  final ColorScheme colorScheme;
  final Translations t;

  @override
  Widget build(BuildContext context) {
    return TextField(
      decoration: InputDecoration(
        hintText: t.cells.searchHint,
        prefixIcon: const Icon(Icons.search),
        filled: true,
        fillColor: colorScheme.surfaceContainerLowest,
        border: OutlineInputBorder(
          borderRadius: BorderRadius.circular(12),
          borderSide: BorderSide(color: colorScheme.outlineVariant),
        ),
        enabledBorder: OutlineInputBorder(
          borderRadius: BorderRadius.circular(12),
          borderSide: BorderSide(color: colorScheme.outlineVariant),
        ),
      ),
    );
  }
}

class _ErrorState extends StatelessWidget {
  const _ErrorState({required this.err, required this.ref});

  final Object err;
  final WidgetRef ref;

  @override
  Widget build(BuildContext context) {
    final t = Translations.of(context);
    return SliverFillRemaining(
      hasScrollBody: false,
      child: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            const Icon(Icons.error_outline, size: 48, color: Colors.red),
            const SizedBox(height: 16),
            Text(t.cells.errors.loadingCells(error: err)),
            ElevatedButton(
              onPressed: () => ref.refresh(cellsProvider),
              child: Text(t.common.retry),
            ),
          ],
        ),
      ),
    );
  }
}
