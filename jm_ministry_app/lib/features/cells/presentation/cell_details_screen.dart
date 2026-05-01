import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'cells_provider.dart';
import '../../dashboard/data/ministry_repository_impl.dart';
import '../domain/add_cell_attendance_dto.dart';
import '../domain/cell_dto.dart';
import '../../../shared/domain/models/partial_user_info_dto.dart';

class CellDetailsScreen extends ConsumerStatefulWidget {
  final int cellId;

  const CellDetailsScreen({
    super.key,
    required this.cellId,
  });

  @override
  ConsumerState<CellDetailsScreen> createState() => _CellDetailsScreenState();
}

class _CellDetailsScreenState extends ConsumerState<CellDetailsScreen> {
  final Set<String> _selectedDisciples = {};
  final _notesController = TextEditingController();
  bool _isSubmitting = false;

  @override
  void dispose() {
    _notesController.dispose();
    super.dispose();
  }

  Future<void> _submitAttendance() async {
    setState(() => _isSubmitting = true);
    try {
      final repo = ref.read(ministryRepositoryProvider);
      await repo.addAttendance(
        widget.cellId,
        AddCellAttendanceDto(
          disciples: _selectedDisciples.toList(),
          notes: _notesController.text,
        ),
      );
      if (mounted) {
        ScaffoldMessenger.of(context).showSnackBar(
          const SnackBar(content: Text('Attendance recorded successfully')),
        );
        Navigator.of(context).pop();
      }
    } catch (e) {
      if (mounted) {
        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(content: Text('Failed to record attendance: $e')),
        );
      }
    } finally {
      if (mounted) setState(() => _isSubmitting = false);
    }
  }

  @override
  Widget build(BuildContext context) {
    final cellAsync = ref.watch(cellDetailsProvider(widget.cellId));
    final disciplesAsync = ref.watch(cellDisciplesProvider(widget.cellId));

    return Scaffold(
      appBar: AppBar(
        title: cellAsync.when(
          data: (cell) => Text(cell.name ?? 'Cell Details'),
          loading: () => const Text('Loading...'),
          error: (_, __) => const Text('Error'),
        ),
      ),
      body: cellAsync.when(
        data: (cell) => SingleChildScrollView(
          padding: const EdgeInsets.all(16),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              _buildInfoSection(cell),
              const SizedBox(height: 32),
              Text(
                'Record Attendance',
                style: Theme.of(context).textTheme.titleLarge?.copyWith(
                  fontWeight: FontWeight.bold,
                ),
              ),
              const SizedBox(height: 16),
              disciplesAsync.when(
                data: (disciples) => Column(
                  children: [
                    ...disciples.map((disciple) => CheckboxListTile(
                      title: Text('${disciple.name} ${disciple.lastName}'),
                      subtitle: Text(disciple.document ?? ''),
                      value: _selectedDisciples.contains(disciple.document),
                      onChanged: (selected) {
                        setState(() {
                          if (selected == true) {
                            _selectedDisciples.add(disciple.document!);
                          } else {
                            _selectedDisciples.remove(disciple.document);
                          }
                        });
                      },
                    )),
                    const SizedBox(height: 16),
                    TextField(
                      controller: _notesController,
                      decoration: const InputDecoration(
                        labelText: 'Meeting Notes',
                        border: OutlineInputBorder(),
                        hintText: 'What happened in the cell today?',
                      ),
                      maxLines: 3,
                    ),
                    const SizedBox(height: 24),
                    SizedBox(
                      width: double.infinity,
                      child: ElevatedButton.icon(
                        onPressed: _isSubmitting || _selectedDisciples.isEmpty 
                          ? null 
                          : _submitAttendance,
                        icon: _isSubmitting 
                          ? const SizedBox(
                              width: 20, 
                              height: 20, 
                              child: CircularProgressIndicator(strokeWidth: 2),
                            )
                          : const Icon(Icons.check),
                        label: const Text('Submit Weekly Report'),
                        style: ElevatedButton.styleFrom(
                          padding: const EdgeInsets.symmetric(vertical: 16),
                        ),
                      ),
                    ),
                  ],
                ),
                loading: () => const Center(child: CircularProgressIndicator()),
                error: (e, _) => Text('Error loading disciples: $e'),
              ),
            ],
          ),
        ),
        loading: () => const Center(child: CircularProgressIndicator()),
        error: (e, _) => Center(child: Text('Error: $e')),
      ),
    );
  }

  Widget _buildInfoSection(CellDto cell) {
    final theme = Theme.of(context);
    return Container(
      padding: const EdgeInsets.all(16),
      decoration: BoxDecoration(
        color: theme.colorScheme.surfaceContainer,
        borderRadius: BorderRadius.circular(12),
      ),
      child: Column(
        children: [
          _buildInfoRow(Icons.location_on, cell.address ?? 'No address'),
          const Divider(),
          _buildInfoRow(Icons.calendar_month, 'Every ${_getDayName(cell.day)}'),
          const Divider(),
          _buildInfoRow(Icons.description, cell.description ?? 'No description'),
        ],
      ),
    );
  }

  Widget _buildInfoRow(IconData icon, String text) {
    return Padding(
      padding: const EdgeInsets.symmetric(vertical: 8),
      child: Row(
        children: [
          Icon(icon, size: 20, color: Theme.of(context).colorScheme.primary),
          const SizedBox(width: 12),
          Expanded(child: Text(text)),
        ],
      ),
    );
  }

  String _getDayName(int? day) {
    if (day == null) return 'Not scheduled';
    const days = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];
    return (day >= 0 && day < days.length) ? days[day] : 'Unknown';
  }
}

// Additional provider for disciples
final cellDisciplesProvider = FutureProvider.family<List<PartialUserInfoDto>, int>((ref, cellId) async {
  final repo = ref.watch(ministryRepositoryProvider);
  return repo.getDisciples(cellId);
});
