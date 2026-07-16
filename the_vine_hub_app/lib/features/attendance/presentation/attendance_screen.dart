import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:the_vine_hub_app/core/network/api/meetings/meetings_api.dart';
import 'package:the_vine_hub_app/core/network/api/cells/cells_api.dart';
import 'package:the_vine_hub_app/features/cells/presentation/cells_provider.dart';
import 'package:the_vine_hub_app/shared/presentation/shell_utils.dart';
import 'package:the_vine_hub_app/features/meetings/domain/meeting_dto.dart';

final meetingsProvider = FutureProvider.autoDispose<List<MeetingDto>>((ref) async {
  final api = ref.watch(meetingsApiProvider);
  final response = await api.getMeetings();
  return response.map((e) => MeetingDto.fromJson(e as Map<String, dynamic>)).toList();
});

class AttendanceScreen extends ConsumerStatefulWidget {
  const AttendanceScreen({super.key});

  @override
  ConsumerState<AttendanceScreen> createState() => _AttendanceScreenState();
}

class _AttendanceScreenState extends ConsumerState<AttendanceScreen> {
  String? _selectedMeetingId;
  String? _selectedCellId;

  @override
  Widget build(BuildContext context) {
    final meetingsAsync = ref.watch(meetingsProvider);
    final cellsAsync = ref.watch(cellsProvider); // Existing provider for cells

    return Scaffold(
      appBar: AppBar(
        title: const Text('Record Attendance'),
        leading: IconButton(
          icon: const Icon(Icons.menu),
          onPressed: () {
            ref.read(shellScaffoldKeyProvider).currentState?.openDrawer();
          },
        ),
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.stretch,
          children: [
            meetingsAsync.when(
              data: (meetings) {
                return DropdownButton<String>(
                  hint: const Text('Select Meeting'),
                  value: _selectedMeetingId,
                  items: meetings.map((m) {
                    return DropdownMenuItem<String>(
                      value: m.id?.toString(),
                      child: Text(m.name),
                    );
                  }).toList(),
                  onChanged: (val) {
                    setState(() => _selectedMeetingId = val);
                  },
                );
              },
              loading: () => const CircularProgressIndicator(),
              error: (e, _) => Text('Error loading meetings: $e'),
            ),
            const SizedBox(height: 16),
            cellsAsync.when(
              data: (cells) {
                return DropdownButton<String>(
                  hint: const Text('Select Cell'),
                  value: _selectedCellId,
                  items: cells.map((c) {
                    return DropdownMenuItem<String>(
                      value: c.id,
                      child: Text(c.name),
                    );
                  }).toList(),
                  onChanged: (val) {
                    setState(() => _selectedCellId = val);
                  },
                );
              },
              loading: () => const CircularProgressIndicator(),
              error: (e, _) => Text('Error loading cells: $e'),
            ),
            const SizedBox(height: 32),
            if (_selectedCellId != null && _selectedMeetingId != null)
              Expanded(
                child: _DisciplesList(cellId: _selectedCellId!, meetingId: _selectedMeetingId!),
              ),
          ],
        ),
      ),
    );
  }
}

class _DisciplesList extends ConsumerStatefulWidget {
  final String cellId;
  final String meetingId;

  const _DisciplesList({required this.cellId, required this.meetingId});

  @override
  ConsumerState<_DisciplesList> createState() => _DisciplesListState();
}

class _DisciplesListState extends ConsumerState<_DisciplesList> {
  final Set<String> _attendedDiscipleIds = {};
  bool _isSaving = false;

  Future<void> _submitAttendance() async {
    setState(() => _isSaving = true);
    try {
      final api = ref.read(cellsApiProvider);

      // As per the provided CellsApi.recordAttendance endpoint
      // Expected structure depends on backend, typical example:
      final command = {
        'meetingId': int.tryParse(widget.meetingId),
        'attendedDisciples': _attendedDiscipleIds.toList(),
      };

      await api.recordAttendance(widget.cellId, command);

      if (mounted) {
        ScaffoldMessenger.of(context).showSnackBar(const SnackBar(content: Text('Attendance recorded!')));
      }
    } catch (e) {
      if (mounted) {
        ScaffoldMessenger.of(context).showSnackBar(SnackBar(content: Text('Error: $e')));
      }
    } finally {
      if (mounted) {
        setState(() => _isSaving = false);
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    final disciplesAsync = ref.watch(cellDisciplesProvider(widget.cellId));

    return Column(
      children: [
        Expanded(
          child: disciplesAsync.when(
            data: (disciples) {
              if (disciples.isEmpty) return const Text('No disciples in this cell.');
              return ListView.builder(
                itemCount: disciples.length,
                itemBuilder: (context, index) {
                  final d = disciples[index];
                  final isAttended = _attendedDiscipleIds.contains(d.id);
                  return CheckboxListTile(
                    title: Text(d.fullName),
                    value: isAttended,
                    onChanged: (val) {
                      setState(() {
                        if (val == true) {
                          if (d.id != null) _attendedDiscipleIds.add(d.id!);
                        } else {
                          if (d.id != null) _attendedDiscipleIds.remove(d.id!);
                        }
                      });
                    },
                  );
                },
              );
            },
            loading: () => const Center(child: CircularProgressIndicator()),
            error: (e, _) => Text('Error loading disciples: $e'),
          ),
        ),
        Padding(
          padding: const EdgeInsets.symmetric(vertical: 16.0),
          child: FilledButton(
            onPressed: _isSaving ? null : _submitAttendance,
            child: _isSaving ? const CircularProgressIndicator() : const Text('Save Attendance'),
          ),
        )
      ],
    );
  }
}
