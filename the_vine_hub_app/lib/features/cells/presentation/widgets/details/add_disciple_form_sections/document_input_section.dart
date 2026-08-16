import 'package:flutter/material.dart';
import 'package:the_vine_hub_app/i18n/strings.g.dart';
import 'package:the_vine_hub_app/features/cells/presentation/widgets/details/add_disciple_state.dart';

class DocumentInputSection extends StatelessWidget {
  final TextEditingController documentController;
  final AddDiscipleState state;
  final VoidCallback onCheckDocument;

  const DocumentInputSection({
    super.key,
    required this.documentController,
    required this.state,
    required this.onCheckDocument,
  });

  @override
  Widget build(BuildContext context) {
    final t = Translations.of(context);

    return Row(
      children: [
        Expanded(
          child: TextFormField(
            controller: documentController,
            decoration: InputDecoration(
              labelText: t.common.document,
              border: const OutlineInputBorder(),
            ),
            enabled: !state.documentChecked && !state.isChecking,
            validator: (v) => v?.isEmpty ?? true ? t.common.validation.required : null,
          ),
        ),
        const SizedBox(width: 12),
        FilledButton(
          onPressed: (!state.documentChecked && !state.isChecking) ? onCheckDocument : null,
          style: FilledButton.styleFrom(
            padding: const EdgeInsets.symmetric(vertical: 20, horizontal: 24),
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
    );
  }
}
