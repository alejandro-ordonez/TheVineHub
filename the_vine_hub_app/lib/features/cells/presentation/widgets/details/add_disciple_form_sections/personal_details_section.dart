import 'package:flutter/material.dart';
import 'package:the_vine_hub_app/i18n/strings.g.dart';
import 'package:skeletonizer/skeletonizer.dart';

class PersonalDetailsSection extends StatelessWidget {
  final TextEditingController nameController;
  final TextEditingController lastNameController;
  final TextEditingController phoneController;
  final TextEditingController emailController;
  final int gender;
  final ValueChanged<int?> onGenderChanged;

  const PersonalDetailsSection({
    super.key,
    required this.nameController,
    required this.lastNameController,
    required this.phoneController,
    required this.emailController,
    required this.gender,
    required this.onGenderChanged,
  });

  @override
  Widget build(BuildContext context) {
    final t = Translations.of(context);

    return Column(
      children: [
        // Photo Upload Skeleton
        Center(
          child: Skeletonizer(
            enabled: true,
            child: Container(
              width: 100,
              height: 100,
              decoration: BoxDecoration(
                color: Colors.grey.shade300,
                shape: BoxShape.circle,
              ),
              child: const Icon(
                Icons.camera_alt,
                color: Colors.grey,
                size: 40,
              ),
            ),
          ),
        ),
        const SizedBox(height: 24),
        Row(
          children: [
            Expanded(
              child: TextFormField(
                controller: nameController,
                decoration: InputDecoration(
                  labelText: t.cells.form.name,
                  border: const OutlineInputBorder(),
                ),
                validator: (v) => v?.isEmpty ?? true ? t.common.validation.required : null,
              ),
            ),
            const SizedBox(width: 16),
            Expanded(
              child: TextFormField(
                controller: lastNameController,
                decoration: InputDecoration(
                  labelText: t.cells.form.lastName,
                  border: const OutlineInputBorder(),
                ),
                validator: (v) => v?.isEmpty ?? true ? t.common.validation.required : null,
              ),
            ),
          ],
        ),
        const SizedBox(height: 16),
        Row(
          children: [
            Expanded(
              child: TextFormField(
                controller: phoneController,
                decoration: const InputDecoration(
                  labelText: 'Phone',
                  border: OutlineInputBorder(),
                ),
              ),
            ),
            const SizedBox(width: 16),
            Expanded(
              child: DropdownButtonFormField<int>(
                initialValue: gender,
                decoration: const InputDecoration(
                  labelText: 'Gender',
                  border: OutlineInputBorder(),
                ),
                items: const [
                  DropdownMenuItem(value: 0, child: Text('Male')),
                  DropdownMenuItem(value: 1, child: Text('Female')),
                ],
                onChanged: onGenderChanged,
              ),
            ),
          ],
        ),
        const SizedBox(height: 16),
        TextFormField(
          controller: emailController,
          decoration: const InputDecoration(
            labelText: 'Email',
            border: OutlineInputBorder(),
          ),
        ),
      ],
    );
  }
}
