import 'package:flutter/material.dart';
import 'package:the_vine_hub_app/i18n/strings.g.dart';
import 'package:the_vine_hub_app/features/cells/domain/disciple_dto.dart';
import 'package:the_vine_hub_app/shared/presentation/widgets/animations/entrance_fader.dart';

class LadderProgressBar extends StatelessWidget {
  final int progress;
  const LadderProgressBar({super.key, required this.progress});

  @override
  Widget build(BuildContext context) {
    final colorScheme = Theme.of(context).colorScheme;
    return Row(
      children: List.generate(4, (index) {
        final isActive = index < progress;
        return Expanded(
          child: Container(
            height: 6,
            margin: EdgeInsets.only(right: index == 3 ? 0 : 4),
            decoration: BoxDecoration(
              color: isActive
                  ? colorScheme.secondary
                  : colorScheme.surfaceContainerHighest,
              borderRadius: BorderRadius.circular(3),
              border: isActive
                  ? null
                  : Border.all(color: colorScheme.outlineVariant, width: 0.5),
            ),
          ),
        );
      }),
    );
  }
}

class MemberCard extends StatelessWidget {
  final int index;
  final DiscipleDto disciple;

  const MemberCard({super.key, required this.index, required this.disciple});

  @override
  Widget build(BuildContext context) {
    final t = Translations.of(context);
    final theme = Theme.of(context);
    final colorScheme = theme.colorScheme;

    return EntranceFader(
      delay: index * 50,
      child: Container(
        margin: const EdgeInsets.only(bottom: 16),
        padding: const EdgeInsets.all(20),
        decoration: BoxDecoration(
          color: colorScheme.surfaceContainerLowest,
          borderRadius: BorderRadius.circular(16),
          border: Border.all(
            color: colorScheme.outlineVariant.withValues(alpha: 0.5),
          ),
          boxShadow: [
            BoxShadow(
              color: Colors.black.withValues(alpha: 0.02),
              blurRadius: 8,
              offset: const Offset(0, 2),
            ),
          ],
        ),
        child: Column(
          children: [
            Row(
              children: [
                _MemberAvatar(
                  colorScheme: colorScheme,
                  photoPath: disciple.photoPath,
                ),
                const SizedBox(width: 16),
                Expanded(
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      _MemberNameRow(
                        disciple: disciple,
                        theme: theme,
                        colorScheme: colorScheme,
                        t: t,
                      ),
                      const SizedBox(height: 8),
                      Text(
                        t.common.ladderOfSuccess.toUpperCase(),
                        style: theme.textTheme.labelSmall?.copyWith(
                          color: colorScheme.outline,
                          fontSize: 9,
                          letterSpacing: 0.5,
                        ),
                      ),
                      const SizedBox(height: 4),
                      const LadderProgressBar(progress: 3), // Placeholder
                    ],
                  ),
                ),
              ],
            ),
            const SizedBox(height: 16),
            _MemberActions(t: t, colorScheme: colorScheme),
          ],
        ),
      ),
    );
  }
}

class _ActionButton extends StatelessWidget {
  final IconData icon;
  final VoidCallback onTap;

  const _ActionButton({required this.icon, required this.onTap});

  @override
  Widget build(BuildContext context) {
    final colorScheme = Theme.of(context).colorScheme;
    return InkWell(
      onTap: onTap,
      borderRadius: BorderRadius.circular(10),
      child: Container(
        padding: const EdgeInsets.all(10),
        decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(10),
          border: Border.all(color: colorScheme.outlineVariant),
        ),
        child: Icon(icon, size: 18, color: colorScheme.primary),
      ),
    );
  }
}

class _MemberActions extends StatelessWidget {
  final Translations t;
  final ColorScheme colorScheme;

  const _MemberActions({required this.t, required this.colorScheme});

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        Expanded(
          child: FilledButton.icon(
            onPressed: () {},
            icon: const Icon(Icons.person_outline, size: 18),
            label: Text(t.common.profile),
            style: FilledButton.styleFrom(
              backgroundColor: colorScheme.primaryContainer,
              foregroundColor: Colors.white,
              shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(10),
              ),
            ),
          ),
        ),
        const SizedBox(width: 8),
        _ActionButton(icon: Icons.chat_bubble_outline, onTap: () {}),
        const SizedBox(width: 8),
        _ActionButton(icon: Icons.call_outlined, onTap: () {}),
      ],
    );
  }
}

class _MemberAvatar extends StatelessWidget {
  final ColorScheme colorScheme;
  final String? photoPath;

  const _MemberAvatar({required this.colorScheme, this.photoPath});

  @override
  Widget build(BuildContext context) {
    return Stack(
      children: [
        Container(
          width: 64,
          height: 64,
          decoration: BoxDecoration(
            color: colorScheme.surfaceContainerHighest,
            borderRadius: BorderRadius.circular(12),
            image: DecorationImage(
              image: photoPath != null
                  ? NetworkImage(photoPath!)
                  : const NetworkImage('https://i.pravatar.cc/150?u=1')
                        as ImageProvider,
              fit: BoxFit.cover,
            ),
          ),
        ),
        Positioned(
          bottom: -2,
          right: -2,
          child: Container(
            padding: const EdgeInsets.all(2),
            decoration: BoxDecoration(
              color: colorScheme.secondaryContainer,
              borderRadius: BorderRadius.circular(6),
              border: Border.all(color: Colors.white, width: 2),
            ),
            child: Icon(
              Icons.star,
              size: 12,
              color: colorScheme.onSecondaryContainer,
            ),
          ),
        ),
      ],
    );
  }
}

class _MemberNameRow extends StatelessWidget {
  final DiscipleDto disciple;
  final ThemeData theme;
  final ColorScheme colorScheme;
  final Translations t;

  const _MemberNameRow({
    required this.disciple,
    required this.theme,
    required this.colorScheme,
    required this.t,
  });

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        Text(
          disciple.fullName,
          style: theme.textTheme.titleMedium?.copyWith(
            fontWeight: FontWeight.bold,
            color: colorScheme.primary,
          ),
        ),
        const SizedBox(width: 8),
        Container(
          padding: const EdgeInsets.symmetric(horizontal: 8, vertical: 2),
          decoration: BoxDecoration(
            color: colorScheme.surfaceContainerHighest,
            borderRadius: BorderRadius.circular(10),
          ),
          child: Text(
            t.common.roles.helper,
            style: theme.textTheme.labelSmall?.copyWith(
              color: colorScheme.onSurfaceVariant,
              fontSize: 10,
            ),
          ),
        ),
      ],
    );
  }
}
