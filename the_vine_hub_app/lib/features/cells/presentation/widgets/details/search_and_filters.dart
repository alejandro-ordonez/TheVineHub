import 'package:flutter/material.dart';

import 'package:the_vine_hub_app/i18n/strings.g.dart';

class SearchAndFilters extends StatelessWidget {
  final TextEditingController controller;

  const SearchAndFilters({super.key, required this.controller});

  @override
  Widget build(BuildContext context) {
    final t = Translations.of(context);
    final colorScheme = Theme.of(context).colorScheme;

    return Row(
      children: [
        Expanded(
          child: TextField(
            controller: controller,
            decoration: InputDecoration(
              hintText: t.cells.searchMembersHint,
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
          ),
        ),
        const SizedBox(width: 12),
        FilterIconButton(icon: Icons.filter_list, onTap: () {}),
        const SizedBox(width: 8),
        FilterIconButton(icon: Icons.sort, onTap: () {}),
      ],
    );
  }
}

class FilterIconButton extends StatelessWidget {
  final IconData icon;
  final VoidCallback onTap;

  const FilterIconButton({super.key, required this.icon, required this.onTap});

  @override
  Widget build(BuildContext context) {
    final colorScheme = Theme.of(context).colorScheme;
    return InkWell(
      onTap: onTap,
      borderRadius: BorderRadius.circular(12),
      child: Container(
        padding: const EdgeInsets.all(12),
        decoration: BoxDecoration(
          color: colorScheme.surfaceContainerLowest,
          borderRadius: BorderRadius.circular(12),
          border: Border.all(color: colorScheme.outlineVariant),
        ),
        child: Icon(icon, color: colorScheme.onSurfaceVariant),
      ),
    );
  }
}
