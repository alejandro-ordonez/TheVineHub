import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:the_vine_hub_app/core/network/api/discipleship/discipleship_api.dart';
import 'package:the_vine_hub_app/core/network/api/discipleship/models/create_note_dto.dart';
import 'package:the_vine_hub_app/features/discipleship/presentation/disciple_profile_screen.dart';

class AddNoteDialog extends ConsumerStatefulWidget {
  final String discipleId;

  const AddNoteDialog({super.key, required this.discipleId});

  @override
  ConsumerState<AddNoteDialog> createState() => _AddNoteDialogState();
}

class _AddNoteDialogState extends ConsumerState<AddNoteDialog> {
  final _formKey = GlobalKey<FormState>();
  final _titleController = TextEditingController();
  final _descriptionController = TextEditingController();
  bool _isLoading = false;

  @override
  void dispose() {
    _titleController.dispose();
    _descriptionController.dispose();
    super.dispose();
  }

  Future<void> _submit() async {
    if (!_formKey.currentState!.validate()) return;

    setState(() => _isLoading = true);

    try {
      final api = ref.read(discipleshipApiProvider);
      final dto = CreateNoteDto(
        title: _titleController.text.trim(),
        description: _descriptionController.text.trim(),
        categories: [],
      );

      await api.createNote(widget.discipleId, dto);

      if (mounted) {
        ref.invalidate(notesProvider(widget.discipleId));
        Navigator.of(context).pop(true);
      }
    } catch (e) {
      if (mounted) {
        ScaffoldMessenger.of(context).showSnackBar(SnackBar(content: Text('Error: $e')));
      }
    } finally {
      if (mounted) {
        setState(() => _isLoading = false);
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: const Text('Add Discipleship Note'),
      content: Form(
        key: _formKey,
        child: Column(
          mainAxisSize: MainAxisSize.min,
          children: [
            TextFormField(
              controller: _titleController,
              decoration: const InputDecoration(labelText: 'Title'),
              validator: (v) => v?.isEmpty ?? true ? 'Required' : null,
            ),
            const SizedBox(height: 16),
            TextFormField(
              controller: _descriptionController,
              decoration: const InputDecoration(labelText: 'Description'),
              maxLines: 3,
            ),
          ],
        ),
      ),
      actions: [
        TextButton(
          onPressed: () => Navigator.of(context).pop(),
          child: const Text('Cancel'),
        ),
        FilledButton(
          onPressed: _isLoading ? null : _submit,
          child: _isLoading ? const CircularProgressIndicator() : const Text('Save'),
        ),
      ],
    );
  }
}
