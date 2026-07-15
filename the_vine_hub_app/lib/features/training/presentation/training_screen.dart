import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:jm_ministry_app/i18n/strings.g.dart';
import 'package:jm_ministry_app/shared/presentation/shell_utils.dart';

class TrainingScreen extends ConsumerWidget {
  final int? stepId;

  const TrainingScreen({super.key, this.stepId});

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final t = Translations.of(context);
    return Scaffold(
      appBar: AppBar(
        title: Text(
          stepId == null ? t.training.title : '${t.training.title} - $stepId',
        ),
        leading: stepId == null
            ? IconButton(
                icon: const Icon(Icons.menu),
                onPressed: () {
                  ref.read(shellScaffoldKeyProvider).currentState?.openDrawer();
                },
              )
            : null, // Default back button
      ),
      body: Center(
        child: Text(
          stepId == null
              ? t.training.content
              : t.training.stepDetail(id: stepId!),
        ),
      ),
    );
  }
}
