import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:the_vine_hub_app/features/cells/domain/disciple_dto.dart';
import 'package:the_vine_hub_app/core/network/api/discipleship/discipleship_api.dart';
import 'package:the_vine_hub_app/core/network/api/hierarchy/hierarchy_api.dart';
import 'package:the_vine_hub_app/i18n/strings.g.dart';
import 'package:the_vine_hub_app/features/discipleship/presentation/add_note_dialog.dart';

// Provider to check if the current user is a leader in the hierarchy for this disciple
final isLeaderProvider = FutureProvider.family<bool, String>((ref, discipleId) async {
  final api = ref.watch(hierarchyApiProvider);
  return api.isLeaderInHierarchy(discipleId);
});

// Provider to fetch discipleship notes for a disciple
final notesProvider = FutureProvider.family<List<dynamic>, String>((ref, discipleId) async {
  final api = ref.watch(discipleshipApiProvider);
  return api.getDiscipleshipNotes(discipleId);
});

class DiscipleProfileScreen extends ConsumerWidget {
  final DiscipleDto disciple;

  const DiscipleProfileScreen({super.key, required this.disciple});

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final t = Translations.of(context);
    final theme = Theme.of(context);
    final discipleId = disciple.id ?? disciple.fullName; // fallback

    final isLeaderAsync = ref.watch(isLeaderProvider(discipleId));
    final notesAsync = ref.watch(notesProvider(discipleId));

    return Scaffold(
      appBar: AppBar(
        title: Text(t.common.profile),
      ),
      body: SingleChildScrollView(
        padding: const EdgeInsets.all(24.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            Row(
              children: [
                CircleAvatar(
                  radius: 40,
                  backgroundImage: disciple.photoPath != null
                    ? NetworkImage(disciple.photoPath!)
                    : const NetworkImage('https://i.pravatar.cc/150?u=1') as ImageProvider,
                ),
                const SizedBox(width: 16),
                Expanded(
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Text(
                        disciple.fullName,
                        style: theme.textTheme.headlineSmall?.copyWith(fontWeight: FontWeight.bold),
                      ),
                      if (disciple.phone != null)
                        Text(disciple.phone!, style: theme.textTheme.bodyLarge),
                    ],
                  ),
                ),
              ],
            ),
            const SizedBox(height: 32),
            isLeaderAsync.when(
              data: (isLeader) {
                if (!isLeader) {
                  return const Center(child: Text("You do not have permission to view discipleship notes for this user."));
                }

                return Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        Text('Discipleship Notes', style: theme.textTheme.titleLarge),
                        FilledButton.icon(
                          onPressed: () {
                            showDialog(
                              context: context,
                              builder: (_) => AddNoteDialog(discipleId: discipleId),
                            );
                          },
                          icon: const Icon(Icons.add),
                          label: const Text('Add Note'),
                        ),
                      ],
                    ),
                    const SizedBox(height: 16),
                    notesAsync.when(
                      data: (notes) {
                        if (notes.isEmpty) {
                          return const Text("No notes found.");
                        }
                        return ListView.builder(
                          shrinkWrap: true,
                          physics: const NeverScrollableScrollPhysics(),
                          itemCount: notes.length,
                          itemBuilder: (context, index) {
                            final note = notes[index];
                            return Card(
                              margin: const EdgeInsets.only(bottom: 8),
                              child: ListTile(
                                title: Text(note.title ?? 'Untitled Note'),
                                subtitle: Text(note.createdAt?.toString() ?? ''),
                                trailing: const Icon(Icons.chevron_right),
                                onTap: () {
                                  // TODO: View Note Details
                                },
                              ),
                            );
                          },
                        );
                      },
                      loading: () => const Center(child: CircularProgressIndicator()),
                      error: (e, s) => Text('Error loading notes: $e'),
                    ),
                  ],
                );
              },
              loading: () => const Center(child: CircularProgressIndicator()),
              error: (e, s) => Text('Error checking permissions: $e'),
            ),
          ],
        ),
      ),
    );
  }
}
