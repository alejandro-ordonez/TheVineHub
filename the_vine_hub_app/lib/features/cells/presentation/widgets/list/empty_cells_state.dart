import 'package:flutter/material.dart';
import 'package:the_vine_hub_app/i18n/strings.g.dart';

class EmptyCellsState extends StatelessWidget {
  const EmptyCellsState({super.key});

  @override
  Widget build(BuildContext context) {
    final t = Translations.of(context);
    return SliverFillRemaining(
      hasScrollBody: false,
      child: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            const Icon(Icons.groups_outlined, size: 64, color: Colors.grey),
            const SizedBox(height: 16),
            Text(
              t.cells.emptyState,
              style: Theme.of(context).textTheme.titleMedium,
            ),
          ],
        ),
      ),
    );
  }
}
