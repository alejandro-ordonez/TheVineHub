import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:skeletonizer/skeletonizer.dart';
import 'package:the_vine_hub_app/features/cells/presentation/cells_provider.dart';
import 'package:the_vine_hub_app/features/cells/presentation/widgets/add_cell_form.dart';
import 'package:the_vine_hub_app/features/cells/presentation/widgets/list/cells_header.dart';
import 'package:the_vine_hub_app/features/cells/presentation/widgets/list/pending_attendance_card.dart';
import 'package:the_vine_hub_app/features/cells/presentation/widgets/list/empty_cells_state.dart';
import 'package:the_vine_hub_app/features/cells/presentation/widgets/list/cells_grid.dart';
import 'package:the_vine_hub_app/features/cells/domain/cell_dto.dart';
import 'package:the_vine_hub_app/shared/presentation/shell_utils.dart';
import 'package:the_vine_hub_app/shared/presentation/widgets/animations/entrance_fader.dart';
import 'package:the_vine_hub_app/i18n/strings.g.dart';

class CellsScreen extends ConsumerWidget {
  const CellsScreen({super.key});

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final t = Translations.of(context);
    final cellsAsync = ref.watch(cellsProvider);
    final groupedCellsAsync = ref.watch(groupedCellsProvider);

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
                    if (cells.isEmpty) {
                      return const EmptyCellsState();
                    }

                    final groupedCells = groupedCellsAsync.hasValue ? groupedCellsAsync.value! : <int, List<CellDto>>{};

                    return CellsGrid(
                      groupedCells: groupedCells,
                      crossAxisCount: crossAxisCount,
                    );
                  },
                  loading: () {
                    final dummyCells = List.generate(
                      6,
                      (index) => CellDto(
                        name: 'Loading Cell Name',
                        description: 'Loading description...',
                        mainCell: false,
                        level: (index % 2) + 1,
                      ),
                    );

                    final groupedDummyCells = <int, List<CellDto>>{};
                    for (final cell in dummyCells) {
                      groupedDummyCells.putIfAbsent(cell.level, () => []).add(cell);
                    }

                    return Skeletonizer.sliver(
                      enabled: true,
                      child: CellsGrid(
                        groupedCells: groupedDummyCells,
                        crossAxisCount: crossAxisCount,
                      ),
                    );
                  },
                  error: (err, stack) => _ErrorState(err: err, ref: ref),
                ),
                const SliverToBoxAdapter(child: SizedBox(height: 100)),
              ],
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
