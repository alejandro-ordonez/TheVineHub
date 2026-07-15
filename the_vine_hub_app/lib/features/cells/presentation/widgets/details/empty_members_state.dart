import 'package:flutter/material.dart';
import 'package:jm_ministry_app/i18n/strings.g.dart';

class EmptyMembersState extends StatelessWidget {
  const EmptyMembersState({super.key});

  @override
  Widget build(BuildContext context) {
    final t = Translations.of(context);
    return Center(
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          const Icon(Icons.group_outlined, size: 64, color: Colors.grey),
          const SizedBox(height: 16),
          Text(
            t.cells.noMembers,
            style: Theme.of(context).textTheme.titleMedium,
          ),
        ],
      ),
    );
  }
}
