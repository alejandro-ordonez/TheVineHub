import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:the_vine_hub_app/features/cells/presentation/cells_provider.dart';
import 'package:the_vine_hub_app/features/dashboard/data/ministry_repository_impl.dart';
import 'package:the_vine_hub_app/features/cells/domain/cell_dto.dart';
import 'package:the_vine_hub_app/i18n/strings.g.dart';

class AddCellForm extends ConsumerStatefulWidget {
  const AddCellForm({super.key});

  @override
  ConsumerState<AddCellForm> createState() => _AddCellFormState();
}

class _AddCellFormState extends ConsumerState<AddCellForm> {
  final _formKey = GlobalKey<FormState>();
  final _nameController = TextEditingController();
  final _descriptionController = TextEditingController();
  final _addressController = TextEditingController();

  bool _mainCell = false;
  CityDto? _selectedCity;
  LocalityDto? _selectedLocality;
  int? _selectedDay;
  DateTime? _openingDate;
  bool _isSubmitting = false;

  @override
  void dispose() {
    _nameController.dispose();
    _descriptionController.dispose();
    _addressController.dispose();
    super.dispose();
  }

  Future<void> _submit() async {
    final t = Translations.of(context);
    if (!_formKey.currentState!.validate()) return;

    setState(() => _isSubmitting = true);
    try {
      final repo = ref.read(ministryRepositoryProvider);
      await repo.createCell(
        CellDto(
          name: _nameController.text,
          description: _descriptionController.text,
          mainCell: _mainCell,
          address: _addressController.text,
          city: _selectedCity,
          locality: _selectedLocality,
          day: _selectedDay,
          openingDate: _openingDate,
        ),
      );

      if (mounted) {
        ref.invalidate(cellsProvider);
        Navigator.of(context).pop();
        ScaffoldMessenger.of(
          context,
        ).showSnackBar(SnackBar(content: Text(t.cells.success.cellCreated)));
      }
    } catch (e) {
      if (mounted) {
        ScaffoldMessenger.of(context).showSnackBar(
          SnackBar(content: Text(t.cells.errors.createCell(error: e))),
        );
      }
    } finally {
      if (mounted) setState(() => _isSubmitting = false);
    }
  }

  @override
  Widget build(BuildContext context) {
    final t = Translations.of(context);
    final locationsAsync = ref.watch(locationDataProvider);

    final List<String> days = [
      t.common.days.sunday,
      t.common.days.monday,
      t.common.days.tuesday,
      t.common.days.wednesday,
      t.common.days.thursday,
      t.common.days.friday,
      t.common.days.saturday,
    ];

    return Scaffold(
      appBar: AppBar(
        title: Text(t.cells.newCell),
        actions: [
          if (_isSubmitting)
            const Center(
              child: Padding(
                padding: EdgeInsets.symmetric(horizontal: 16.0),
                child: CircularProgressIndicator(),
              ),
            )
          else
            IconButton(icon: const Icon(Icons.check), onPressed: _submit),
        ],
      ),
      body: Form(
        key: _formKey,
        child: ListView(
          padding: const EdgeInsets.all(16),
          children: [
            TextFormField(
              controller: _nameController,
              decoration: InputDecoration(
                labelText: t.cells.form.name,
                border: const OutlineInputBorder(),
                prefixIcon: const Icon(Icons.groups_outlined),
              ),
              validator: (v) =>
                  v?.isEmpty ?? true ? t.common.validation.required : null,
            ),
            const SizedBox(height: 16),
            TextFormField(
              controller: _descriptionController,
              decoration: InputDecoration(
                labelText: t.cells.form.description,
                border: const OutlineInputBorder(),
                prefixIcon: const Icon(Icons.description_outlined),
              ),
              maxLines: 3,
            ),
            const SizedBox(height: 16),
            SwitchListTile(
              title: Text(t.cells.form.isMainCell),
              subtitle: Text(t.cells.form.mainCellSubtitle),
              value: _mainCell,
              onChanged: (v) => setState(() => _mainCell = v),
            ),
            const Divider(),
            TextFormField(
              controller: _addressController,
              decoration: InputDecoration(
                labelText: t.cells.form.address,
                border: const OutlineInputBorder(),
                prefixIcon: const Icon(Icons.location_on_outlined),
              ),
            ),
            const SizedBox(height: 16),
            locationsAsync.when(
              data: (cities) => Column(
                children: [
                  DropdownButtonFormField<CityDto>(
                    initialValue: _selectedCity,
                    decoration: InputDecoration(
                      labelText: t.cells.form.city,
                      border: const OutlineInputBorder(),
                    ),
                    items: cities
                        .map(
                          (city) => DropdownMenuItem(
                            value: city,
                            child: Text(city.name),
                          ),
                        )
                        .toList(),
                    onChanged: (city) {
                      setState(() {
                        _selectedCity = city;
                        _selectedLocality = null;
                      });
                    },
                  ),
                  if (_selectedCity != null) ...[
                    const SizedBox(height: 16),
                    DropdownButtonFormField<LocalityDto>(
                      initialValue: _selectedLocality,
                      decoration: InputDecoration(
                        labelText: t.cells.form.locality,
                        border: const OutlineInputBorder(),
                      ),
                      items:
                          _selectedCity!.localities
                              ?.map(
                                (l) => DropdownMenuItem(
                                  value: l,
                                  child: Text(l.name),
                                ),
                              )
                              .toList() ??
                          [],
                      onChanged: (l) => setState(() => _selectedLocality = l),
                    ),
                  ],
                ],
              ),
              loading: () => const LinearProgressIndicator(),
              error: (e, _) => Text(t.cells.errors.loadingLocations(error: e)),
            ),
            const SizedBox(height: 16),
            DropdownButtonFormField<int>(
              initialValue: _selectedDay,
              decoration: InputDecoration(
                labelText: t.cells.form.meetingDay,
                border: const OutlineInputBorder(),
                prefixIcon: const Icon(Icons.calendar_today_outlined),
              ),
              items: List.generate(
                7,
                (index) =>
                    DropdownMenuItem(value: index, child: Text(days[index])),
              ),
              onChanged: (day) => setState(() => _selectedDay = day),
            ),
            const SizedBox(height: 16),
            ListTile(
              title: Text(t.cells.form.openingDate),
              subtitle: Text(
                _openingDate == null
                    ? t.cells.form.selectDate
                    : '${_openingDate!.day}/${_openingDate!.month}/${_openingDate!.year}',
              ),
              leading: const Icon(Icons.event),
              trailing: const Icon(Icons.chevron_right),
              onTap: () async {
                final picked = await showDatePicker(
                  context: context,
                  initialDate: DateTime.now(),
                  firstDate: DateTime(2000),
                  lastDate: DateTime(2100),
                );
                if (picked != null) setState(() => _openingDate = picked);
              },
            ),
          ],
        ),
      ),
    );
  }
}
