import 'dart:io';
import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:image_picker/image_picker.dart';
import 'package:the_vine_hub_app/features/cells/presentation/widgets/details/add_disciple_notifier.dart';
import 'package:the_vine_hub_app/i18n/strings.g.dart';
import 'package:the_vine_hub_app/features/cells/domain/create_user_info_dto.dart';

class AddDiscipleForm extends ConsumerStatefulWidget {
  final String cellId;

  const AddDiscipleForm({super.key, required this.cellId});

  @override
  ConsumerState<AddDiscipleForm> createState() => _AddDiscipleFormState();
}

class _AddDiscipleFormState extends ConsumerState<AddDiscipleForm> {
  final _formKey = GlobalKey<FormState>();
  final _documentController = TextEditingController();
  final _nameController = TextEditingController();
  final _lastNameController = TextEditingController();
  final _phoneController = TextEditingController();
  final _emailController = TextEditingController();
  final _addressController = TextEditingController();
  final _cityController = TextEditingController();
  final _neighborhoodController = TextEditingController();

  int _gender = 0;
  XFile? _selectedPhoto;

  @override
  void dispose() {
    _documentController.dispose();
    _nameController.dispose();
    _lastNameController.dispose();
    _phoneController.dispose();
    _emailController.dispose();
    _addressController.dispose();
    _cityController.dispose();
    _neighborhoodController.dispose();
    super.dispose();
  }

  void _onCheckDocument() {
    final doc = _documentController.text.trim();
    if (doc.isEmpty) return;
    ref.read(addDiscipleProvider.notifier).checkDocument(doc);
  }

  Future<void> _pickImage() async {
    final ImagePicker picker = ImagePicker();
    final XFile? image = await picker.pickImage(source: ImageSource.gallery);
    if (image != null) {
      setState(() {
        _selectedPhoto = image;
      });
    }
  }

  void _onSubmit() async {
    if (!_formKey.currentState!.validate()) return;

    final userInfo = CreateUserInfoDto(
      document: _documentController.text.trim(),
      name: _nameController.text.trim(),
      lastName: _lastNameController.text.trim(),
      phone: _phoneController.text.trim(),
      gender: _gender,
      city: _cityController.text.trim(),
      neighborhood: _neighborhoodController.text.trim(),
      address: _addressController.text.trim(),
      email: _emailController.text.trim(),
    );

    final success = await ref
        .read(addDiscipleProvider.notifier)
        .submitDisciple(widget.cellId, userInfo, _selectedPhoto);

    if (success && mounted) {
      Navigator.of(context).pop(true);
    }
  }

  @override
  Widget build(BuildContext context) {
    final t = Translations.of(context);
    final state = ref.watch(addDiscipleProvider);
    final theme = Theme.of(context);
    final colorScheme = theme.colorScheme;

    // Populate fields if existing user info was loaded
    ref.listen(addDiscipleProvider, (previous, next) {
      if (previous?.existingUserInfo != next.existingUserInfo &&
          next.existingUserInfo != null) {
        final info = next.existingUserInfo!;
        _nameController.text = info.name ?? '';
        _lastNameController.text = info.lastName ?? '';
        _phoneController.text = info.phone ?? '';
        _emailController.text = info.email ?? '';
        _addressController.text = info.address ?? '';
        _cityController.text = info.city ?? '';
        _neighborhoodController.text = info.neighborhood ?? '';
        setState(() {
          _gender = info.gender ?? 0;
        });
      }
    });

    return AlertDialog(
      title: Text(t.cells.addDisciple),
      content: SingleChildScrollView(
        child: SizedBox(
          width: 500,
          child: Form(
            key: _formKey,
            child: Column(
              mainAxisSize: MainAxisSize.min,
              crossAxisAlignment: CrossAxisAlignment.stretch,
              children: [
                if (state.error != null)
                  Container(
                    padding: const EdgeInsets.all(12),
                    margin: const EdgeInsets.only(bottom: 16),
                    decoration: BoxDecoration(
                      color: colorScheme.errorContainer,
                      borderRadius: BorderRadius.circular(8),
                    ),
                    child: Text(
                      state.error!,
                      style: TextStyle(color: colorScheme.onErrorContainer),
                    ),
                  ),

                Row(
                  children: [
                    Expanded(
                      child: TextFormField(
                        controller: _documentController,
                        decoration: InputDecoration(
                          labelText: t.common.document,
                          border: const OutlineInputBorder(),
                        ),
                        enabled: !state.documentChecked && !state.isChecking,
                        validator: (v) => v?.isEmpty ?? true
                            ? t.common.validation.required
                            : null,
                      ),
                    ),
                    const SizedBox(width: 12),
                    FilledButton(
                      onPressed: (!state.documentChecked && !state.isChecking)
                          ? _onCheckDocument
                          : null,
                      style: FilledButton.styleFrom(
                        padding: const EdgeInsets.symmetric(
                          vertical: 20,
                          horizontal: 24,
                        ),
                      ),
                      child: state.isChecking
                          ? const SizedBox(
                              width: 20,
                              height: 20,
                              child: CircularProgressIndicator(strokeWidth: 2),
                            )
                          : const Icon(Icons.search),
                    ),
                  ],
                ),

                if (state.documentChecked) ...[
                  const SizedBox(height: 24),

                  Center(
                    child: InkWell(
                      onTap: _pickImage,
                      child: Container(
                        width: 100,
                        height: 100,
                        decoration: BoxDecoration(
                          color: colorScheme.surfaceContainerHighest,
                          shape: BoxShape.circle,
                          image: _selectedPhoto != null
                              ? DecorationImage(
                                  image: FileImage(File(_selectedPhoto!.path)),
                                  fit: BoxFit.cover,
                                )
                              : null,
                        ),
                        child: _selectedPhoto == null
                            ? const Icon(
                                Icons.camera_alt,
                                color: Colors.grey,
                                size: 40,
                              )
                            : null,
                      ),
                    ),
                  ),
                  if (_selectedPhoto == null)
                    Padding(
                      padding: const EdgeInsets.only(top: 8.0),
                      child: Center(
                        child: Text(
                          'Photo (Optional)',
                          style: theme.textTheme.labelSmall,
                        ),
                      ),
                    ),
                  const SizedBox(height: 24),

                  Row(
                    children: [
                      Expanded(
                        child: TextFormField(
                          controller: _nameController,
                          decoration: InputDecoration(
                            labelText: t.cells.form.name,
                            border: const OutlineInputBorder(),
                          ),
                          validator: (v) => v?.isEmpty ?? true
                              ? t.common.validation.required
                              : null,
                        ),
                      ),
                      const SizedBox(width: 16),
                      Expanded(
                        child: TextFormField(
                          controller: _lastNameController,
                          decoration: InputDecoration(
                            labelText: t
                                .cells
                                .form
                                .lastName, // Ensure to add translation or default to last name
                            border: const OutlineInputBorder(),
                          ),
                          validator: (v) => v?.isEmpty ?? true
                              ? t.common.validation.required
                              : null,
                        ),
                      ),
                    ],
                  ),
                  const SizedBox(height: 16),

                  Row(
                    children: [
                      Expanded(
                        child: TextFormField(
                          controller: _phoneController,
                          decoration: const InputDecoration(
                            labelText: 'Phone',
                            border: OutlineInputBorder(),
                          ),
                        ),
                      ),
                      const SizedBox(width: 16),
                      Expanded(
                        child: DropdownButtonFormField<int>(
                          initialValue: _gender,
                          decoration: const InputDecoration(
                            labelText: 'Gender',
                            border: OutlineInputBorder(),
                          ),
                          items: const [
                            DropdownMenuItem(value: 0, child: Text('Male')),
                            DropdownMenuItem(value: 1, child: Text('Female')),
                          ],
                          onChanged: (v) => setState(() => _gender = v ?? 0),
                        ),
                      ),
                    ],
                  ),
                  const SizedBox(height: 16),

                  TextFormField(
                    controller: _emailController,
                    decoration: const InputDecoration(
                      labelText: 'Email',
                      border: OutlineInputBorder(),
                    ),
                  ),
                  const SizedBox(height: 16),

                  Row(
                    children: [
                      Expanded(
                        child: TextFormField(
                          controller: _cityController,
                          decoration: const InputDecoration(
                            labelText: 'City',
                            border: OutlineInputBorder(),
                          ),
                          validator: (v) => v?.isEmpty ?? true
                              ? t.common.validation.required
                              : null,
                        ),
                      ),
                      const SizedBox(width: 16),
                      Expanded(
                        child: TextFormField(
                          controller: _neighborhoodController,
                          decoration: const InputDecoration(
                            labelText: 'Neighborhood',
                            border: OutlineInputBorder(),
                          ),
                          validator: (v) => v?.isEmpty ?? true
                              ? t.common.validation.required
                              : null,
                        ),
                      ),
                    ],
                  ),
                  const SizedBox(height: 16),

                  TextFormField(
                    controller: _addressController,
                    decoration: InputDecoration(
                      labelText: t.cells.form.address,
                      border: const OutlineInputBorder(),
                    ),
                    validator: (v) => v?.isEmpty ?? true
                        ? t.common.validation.required
                        : null,
                  ),
                ],
              ],
            ),
          ),
        ),
      ),
      actions: [
        TextButton(
          onPressed: () => Navigator.of(context).pop(),
          child: Text(t.common.cancel),
        ),
        if (state.documentChecked)
          FilledButton(
            onPressed: state.isSubmitting ? null : _onSubmit,
            child: state.isSubmitting
                ? const SizedBox(
                    width: 20,
                    height: 20,
                    child: CircularProgressIndicator(strokeWidth: 2),
                  )
                : Text(t.common.save),
          ),
      ],
    );
  }
}
