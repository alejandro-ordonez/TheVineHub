import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:the_vine_hub_app/features/cells/presentation/widgets/details/add_disciple_notifier.dart';
import 'package:the_vine_hub_app/i18n/strings.g.dart';
import 'package:the_vine_hub_app/features/cells/domain/create_user_info_dto.dart';
import 'package:the_vine_hub_app/features/cells/presentation/widgets/details/add_disciple_form_sections/document_input_section.dart';
import 'package:the_vine_hub_app/features/cells/presentation/widgets/details/add_disciple_form_sections/personal_details_section.dart';
import 'package:the_vine_hub_app/features/cells/presentation/widgets/details/add_disciple_form_sections/address_section.dart';

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
        .submitDisciple(widget.cellId, userInfo);

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

                DocumentInputSection(
                  documentController: _documentController,
                  state: state,
                  onCheckDocument: _onCheckDocument,
                ),
                if (state.documentChecked) ...[
                  const SizedBox(height: 24),
                  PersonalDetailsSection(
                    nameController: _nameController,
                    lastNameController: _lastNameController,
                    phoneController: _phoneController,
                    emailController: _emailController,
                    gender: _gender,
                    onGenderChanged: (v) => setState(() => _gender = v ?? 0),
                  ),
                  const SizedBox(height: 16),
                  AddressSection(
                    cityController: _cityController,
                    neighborhoodController: _neighborhoodController,
                    addressController: _addressController,
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
