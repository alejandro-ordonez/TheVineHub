import 'package:flutter/material.dart';
import 'package:the_vine_hub_app/i18n/strings.g.dart';

class AddressSection extends StatelessWidget {
  final TextEditingController cityController;
  final TextEditingController neighborhoodController;
  final TextEditingController addressController;

  const AddressSection({
    super.key,
    required this.cityController,
    required this.neighborhoodController,
    required this.addressController,
  });

  @override
  Widget build(BuildContext context) {
    final t = Translations.of(context);

    return Column(
      children: [
        Row(
          children: [
            Expanded(
              child: TextFormField(
                controller: cityController,
                decoration: const InputDecoration(
                  labelText: 'City',
                  border: OutlineInputBorder(),
                ),
                validator: (v) => v?.isEmpty ?? true ? t.common.validation.required : null,
              ),
            ),
            const SizedBox(width: 16),
            Expanded(
              child: TextFormField(
                controller: neighborhoodController,
                decoration: const InputDecoration(
                  labelText: 'Neighborhood',
                  border: OutlineInputBorder(),
                ),
                validator: (v) => v?.isEmpty ?? true ? t.common.validation.required : null,
              ),
            ),
          ],
        ),
        const SizedBox(height: 16),
        TextFormField(
          controller: addressController,
          decoration: InputDecoration(
            labelText: t.cells.form.address,
            border: const OutlineInputBorder(),
          ),
          validator: (v) => v?.isEmpty ?? true ? t.common.validation.required : null,
        ),
      ],
    );
  }
}
