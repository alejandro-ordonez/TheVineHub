import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:the_vine_hub_app/i18n/strings.g.dart';
import 'package:the_vine_hub_app/shared/presentation/shell_utils.dart';
import 'package:the_vine_hub_app/core/network/api/disciple_journey/disciple_journey_api.dart';
import 'package:the_vine_hub_app/features/training/domain/step_cycle_dto.dart';
import 'package:the_vine_hub_app/features/training/domain/cycle_session_dto.dart';

final cyclesProvider = FutureProvider.family<List<StepCycleDto>, String>((ref, stepId) async {
  final api = ref.watch(discipleJourneyApiProvider);
  final response = await api.getCycles(stepId);
  return (response as List<dynamic>).map((e) => StepCycleDto.fromJson(e as Map<String, dynamic>)).toList();
});

final sessionsProvider = FutureProvider.family<List<CycleSessionDto>, String>((ref, cycleId) async {
  final api = ref.watch(discipleJourneyApiProvider);
  final response = await api.getSessions(cycleId);
  return (response as List<dynamic>).map((e) => CycleSessionDto.fromJson(e as Map<String, dynamic>)).toList();
});

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
      body: stepId == null
          ? Center(child: Text(t.training.content))
          : _StepDetailView(stepId: stepId!.toString()),
    );
  }
}

class _StepDetailView extends ConsumerWidget {
  final String stepId;

  const _StepDetailView({required this.stepId});

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final cyclesAsync = ref.watch(cyclesProvider(stepId));

    return cyclesAsync.when(
      data: (cycles) {
        if (cycles.isEmpty) return const Center(child: Text('No cycles available.'));
        return ListView.builder(
          itemCount: cycles.length,
          itemBuilder: (context, index) {
            final cycle = cycles[index];
            return ExpansionTile(
              title: Text(cycle.name),
              children: [
                if (cycle.id != null)
                  _CycleSessionsView(cycleId: cycle.id!.toString()),
              ],
            );
          },
        );
      },
      loading: () => const Center(child: CircularProgressIndicator()),
      error: (e, _) => Center(child: Text('Error loading cycles: $e')),
    );
  }
}

class _CycleSessionsView extends ConsumerWidget {
  final String cycleId;

  const _CycleSessionsView({required this.cycleId});

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final sessionsAsync = ref.watch(sessionsProvider(cycleId));

    return sessionsAsync.when(
      data: (sessions) {
        if (sessions.isEmpty) return const Padding(padding: EdgeInsets.all(16), child: Text('No sessions available.'));
        return ListView.builder(
          shrinkWrap: true,
          physics: const NeverScrollableScrollPhysics(),
          itemCount: sessions.length,
          itemBuilder: (context, index) {
            final session = sessions[index];
            return ListTile(
              title: Text(session.name),
              subtitle: Text(session.date?.toString() ?? ''),
              trailing: IconButton(
                icon: const Icon(Icons.check_circle_outline),
                onPressed: () {
                  // Show dialog to record attendance
                  if (session.id != null) {
                    _showRecordAttendanceDialog(context, ref, cycleId, session.id!.toString());
                  }
                },
              ),
            );
          },
        );
      },
      loading: () => const Center(child: CircularProgressIndicator()),
      error: (e, _) => Center(child: Text('Error: $e')),
    );
  }

  void _showRecordAttendanceDialog(BuildContext context, WidgetRef ref, String cycleId, String sessionId) {
    showDialog(
      context: context,
      builder: (context) {
        return AlertDialog(
          title: const Text('Record Attendance'),
          content: const Text('Record attendance for this session?'),
          actions: [
            TextButton(
              onPressed: () => Navigator.pop(context),
              child: const Text('Cancel'),
            ),
            FilledButton(
              onPressed: () async {
                try {
                  await ref.read(discipleJourneyApiProvider).recordAttendance(cycleId, sessionId, {'attended': true});
                  if (context.mounted) {
                    Navigator.pop(context);
                    ScaffoldMessenger.of(context).showSnackBar(const SnackBar(content: Text('Attendance recorded')));
                  }
                } catch (e) {
                  if (context.mounted) {
                    ScaffoldMessenger.of(context).showSnackBar(SnackBar(content: Text('Error: $e')));
                  }
                }
              },
              child: const Text('Confirm'),
            ),
          ],
        );
      },
    );
  }
}
