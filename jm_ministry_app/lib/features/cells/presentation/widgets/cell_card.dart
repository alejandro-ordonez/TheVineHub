import 'package:flutter/material.dart';
import '../../domain/cell_dto.dart';
import 'leader_info.dart';
import '../../../../shared/presentation/widgets/animations/entrance_fader.dart';
import '../../../../i18n/strings.g.dart';

class CellCard extends StatefulWidget {
  final CellDto cell;
  final VoidCallback onTap;
  final int index;

  const CellCard({
    super.key,
    required this.cell,
    required this.onTap,
    this.index = 0,
  });

  @override
  State<CellCard> createState() => _CellCardState();
}

class _CellCardState extends State<CellCard> {
  bool _isHovered = false;

  @override
  Widget build(BuildContext context) {
    final t = Translations.of(context);
    final theme = Theme.of(context);
    final colorScheme = theme.colorScheme;

    return EntranceFader(
      delay: (widget.index * 100).clamp(0, 400),
      offset: const Offset(0, 30),
      child: MouseRegion(
        onEnter: (_) => setState(() => _isHovered = true),
        onExit: (_) => setState(() => _isHovered = false),
        child: AnimatedContainer(
          duration: const Duration(milliseconds: 200),
          curve: Curves.easeInOut,
          transform: _isHovered
              ? (Matrix4.identity()
                  ..translate(0, -4, 0)
                  ..scale(1.02))
              : Matrix4.identity(),
          decoration: BoxDecoration(
            color: colorScheme.surfaceContainerLowest,
            borderRadius: BorderRadius.circular(16),
            border: Border.all(
              color: _isHovered
                  ? colorScheme.primary.withValues(alpha: 0.2)
                  : colorScheme.outlineVariant.withValues(alpha: 0.5),
              width: 1,
            ),
            boxShadow: [
              BoxShadow(
                color: _isHovered
                    ? colorScheme.primary.withValues(alpha: 0.08)
                    : Colors.black.withValues(alpha: 0.04),
                blurRadius: _isHovered ? 12 : 4,
                offset: Offset(0, _isHovered ? 6 : 2),
              ),
            ],
          ),
          child: InkWell(
            onTap: widget.onTap,
            borderRadius: BorderRadius.circular(16),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                _CellCardContent(cell: widget.cell, t: t),
                const Divider(height: 1),
                _CellCardFooter(cell: widget.cell, t: t),
              ],
            ),
          ),
        ),
      ),
    );
  }
}

class _CellCardContent extends StatelessWidget {
  final CellDto cell;
  final Translations t;

  const _CellCardContent({required this.cell, required this.t});

  @override
  Widget build(BuildContext context) {
    final theme = Theme.of(context);
    final colorScheme = theme.colorScheme;

    return Padding(
      padding: const EdgeInsets.all(20),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Wrap(
                spacing: 8,
                children: [
                  _StatusTag(isActive: true, t: t), // Assuming Active for now
                  if (cell.mainCell) _MainCellTag(t: t),
                ],
              ),
              Icon(Icons.more_vert, size: 20, color: colorScheme.outline),
            ],
          ),
          const SizedBox(height: 16),
          Text(
            cell.name,
            style: theme.textTheme.titleLarge?.copyWith(
              fontWeight: FontWeight.bold,
              color: colorScheme.primary,
              fontSize: 22,
            ),
          ),
          const SizedBox(height: 8),
          Text(
            cell.description,
            maxLines: 2,
            overflow: TextOverflow.ellipsis,
            style: theme.textTheme.bodyMedium?.copyWith(
              color: colorScheme.onSurfaceVariant,
            ),
          ),
          const SizedBox(height: 16),
          LeaderInfo(cell: cell),
        ],
      ),
    );
  }
}

class _StatusTag extends StatelessWidget {
  final bool isActive;
  final Translations t;

  const _StatusTag({required this.isActive, required this.t});

  @override
  Widget build(BuildContext context) {
    final theme = Theme.of(context);
    final colorScheme = theme.colorScheme;

    return Container(
      padding: const EdgeInsets.symmetric(horizontal: 10, vertical: 4),
      decoration: BoxDecoration(
        color: isActive
            ? colorScheme.primaryContainer.withValues(alpha: 0.5)
            : colorScheme.surfaceContainerHighest,
        borderRadius: BorderRadius.circular(8),
      ),
      child: Text(
        isActive ? t.cells.tags.active : t.cells.tags.inactive,
        style: theme.textTheme.labelSmall?.copyWith(
          color: isActive
              ? colorScheme.onPrimaryContainer
              : colorScheme.onSurfaceVariant,
          fontWeight: FontWeight.bold,
          letterSpacing: 0.5,
        ),
      ),
    );
  }
}

class _MainCellTag extends StatelessWidget {
  final Translations t;

  const _MainCellTag({required this.t});

  @override
  Widget build(BuildContext context) {
    final theme = Theme.of(context);
    final colorScheme = theme.colorScheme;

    return Container(
      padding: const EdgeInsets.symmetric(horizontal: 10, vertical: 4),
      decoration: BoxDecoration(
        color: colorScheme.secondaryContainer,
        borderRadius: BorderRadius.circular(8),
      ),
      child: Text(
        t.cells.tags.mainCell,
        style: theme.textTheme.labelSmall?.copyWith(
          color: colorScheme.onSecondaryContainer,
          fontWeight: FontWeight.bold,
          letterSpacing: 0.5,
        ),
      ),
    );
  }
}

class _CellCardFooter extends StatelessWidget {
  final CellDto cell;
  final Translations t;

  const _CellCardFooter({required this.cell, required this.t});

  @override
  Widget build(BuildContext context) {
    final theme = Theme.of(context);
    final colorScheme = theme.colorScheme;

    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 20, vertical: 12),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          Row(
            children: [
              Icon(
                Icons.group_outlined,
                size: 18,
                color: colorScheme.onSurfaceVariant,
              ),
              const SizedBox(width: 8),
              Text(
                t.cells.memberCount(count: cell.memberCount),
                style: theme.textTheme.labelLarge?.copyWith(
                  color: colorScheme.onSurfaceVariant,
                ),
              ),
            ],
          ),
          Row(
            children: [
              Text(
                t.common.details,
                style: theme.textTheme.labelLarge?.copyWith(
                  color: colorScheme.primary,
                  fontWeight: FontWeight.bold,
                ),
              ),
              const SizedBox(width: 4),
              Icon(Icons.chevron_right, size: 18, color: colorScheme.primary),
            ],
          ),
        ],
      ),
    );
  }
}
