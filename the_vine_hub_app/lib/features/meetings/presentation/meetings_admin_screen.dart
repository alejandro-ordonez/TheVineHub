import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:the_vine_hub_app/core/network/api/meetings/meetings_api.dart';
import 'package:the_vine_hub_app/features/meetings/domain/meeting_dto.dart';

final meetingsProvider = FutureProvider.autoDispose<List<MeetingDto>>((ref) async {
  final api = ref.watch(meetingsApiProvider);
  final response = await api.getMeetings();
  return response.map((e) => MeetingDto.fromJson(e as Map<String, dynamic>)).toList();
});

class MeetingsAdminScreen extends ConsumerWidget {
  const MeetingsAdminScreen({super.key});

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final meetingsAsync = ref.watch(meetingsProvider);

    return Scaffold(
      appBar: AppBar(
        title: const Text('Manage Meetings'),
      ),
      body: meetingsAsync.when(
        data: (meetings) {
          if (meetings.isEmpty) {
            return const Center(child: Text("No meetings found."));
          }
          return ListView.builder(
            itemCount: meetings.length,
            itemBuilder: (context, index) {
              final meeting = meetings[index];
              return ListTile(
                title: Text(meeting.name),
                subtitle: Text('ID: ${meeting.id}'),
                trailing: IconButton(
                  icon: const Icon(Icons.delete, color: Colors.red),
                  onPressed: () async {
                    if (meeting.id == null) return;
                    try {
                      await ref.read(meetingsApiProvider).deleteMeeting(meeting.id!);
                      ref.invalidate(meetingsProvider);
                    } catch (e) {
                      if (context.mounted) {
                        ScaffoldMessenger.of(context).showSnackBar(SnackBar(content: Text('Error: $e')));
                      }
                    }
                  },
                ),
              );
            },
          );
        },
        loading: () => const Center(child: CircularProgressIndicator()),
        error: (e, s) => Center(child: Text('Error: $e')),
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () => _showAddMeetingDialog(context, ref),
        child: const Icon(Icons.add),
      ),
    );
  }

  void _showAddMeetingDialog(BuildContext context, WidgetRef ref) {
    final controller = TextEditingController();
    showDialog(
      context: context,
      builder: (context) => AlertDialog(
        title: const Text('Add Meeting'),
        content: TextField(
          controller: controller,
          decoration: const InputDecoration(labelText: 'Meeting Name'),
        ),
        actions: [
          TextButton(
            onPressed: () => Navigator.pop(context),
            child: const Text('Cancel'),
          ),
          FilledButton(
            onPressed: () async {
              if (controller.text.trim().isEmpty) return;
              try {
                await ref.read(meetingsApiProvider).createMeeting({'name': controller.text.trim()});
                ref.invalidate(meetingsProvider);
                if (context.mounted) Navigator.pop(context);
              } catch (e) {
                if (context.mounted) {
                  ScaffoldMessenger.of(context).showSnackBar(SnackBar(content: Text('Error: $e')));
                }
              }
            },
            child: const Text('Save'),
          ),
        ],
      ),
    );
  }
}
