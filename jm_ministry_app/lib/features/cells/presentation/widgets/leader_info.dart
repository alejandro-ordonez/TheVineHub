import 'package:flutter/material.dart';
import '../../domain/cell_dto.dart';
import '../../../../i18n/strings.g.dart';

class LeaderInfo extends StatelessWidget {
  final CellDto cell;

  const LeaderInfo({super.key, required this.cell});

  @override
  Widget build(BuildContext context) {
    final t = Translations.of(context);
    final theme = Theme.of(context);
    final colorScheme = theme.colorScheme;

    return Row(
      children: [
        Container(
          width: 32,
          height: 32,
          decoration: BoxDecoration(
            color: colorScheme.surfaceContainerHighest,
            borderRadius: BorderRadius.circular(8),
          ),
          child: Icon(Icons.person, size: 20, color: colorScheme.outline),
        ),
        const SizedBox(width: 12),
        Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Text(
              cell.leaders.isNotEmpty
                  ? cell.leaders.first.fullName
                  : t.cells.noLeader,
              style: theme.textTheme.labelLarge?.copyWith(
                fontWeight: FontWeight.w600,
              ),
            ),
            Text(
              _getDayName(cell.day, t),
              style: theme.textTheme.labelSmall?.copyWith(
                color: colorScheme.outline,
              ),
            ),
          ],
        ),
      ],
    );
  }

  String _getDayName(int? day, Translations t) {
    if (day == null) return t.cells.notScheduled;
    final days = [
      t.common.days.sunday,
      t.common.days.monday,
      t.common.days.tuesday,
      t.common.days.wednesday,
      t.common.days.thursday,
      t.common.days.friday,
      t.common.days.saturday,
    ];
    if (day >= 0 && day < days.length) return days[day];
    return t.common.unknown;
  }
}
