import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:flutter_staggered_grid_view/flutter_staggered_grid_view.dart';
import 'package:the_vine_hub_app/features/cells/domain/cell_dto.dart';
import 'package:the_vine_hub_app/features/cells/presentation/widgets/cell_card.dart';
import 'package:the_vine_hub_app/i18n/strings.g.dart';
import 'dart:math' as math;

class CellsGrid extends StatelessWidget {
  final Map<int, List<CellDto>> groupedCells;
  final int crossAxisCount;

  const CellsGrid({
    super.key,
    required this.groupedCells,
    required this.crossAxisCount,
  });

  String _getLevelName(int level, Translations t) {
    if (level <= 0) return t.common.unknown;
    final powerValue = math.pow(12, level).toInt();
    return t.cells.levels.g12(count: powerValue);
  }

  @override
  Widget build(BuildContext context) {
    final t = Translations.of(context);
    final theme = Theme.of(context);
    final colorScheme = theme.colorScheme;

    final sortedLevels = groupedCells.keys.toList()..sort();

    return SliverList(
      delegate: SliverChildBuilderDelegate((context, levelIndex) {
        final level = sortedLevels[levelIndex];
        final levelCells = groupedCells[level]!;

        return Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 16),
              child: Text(
                _getLevelName(level, t),
                style: theme.textTheme.titleLarge?.copyWith(
                  fontWeight: FontWeight.bold,
                  color: colorScheme.secondary,
                ),
              ),
            ),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 20),
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
                    onTap: () => context.push('/cells/${levelCells[index].id}'),
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
  }
}
