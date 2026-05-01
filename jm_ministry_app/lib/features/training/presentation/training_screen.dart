import 'package:flutter/material.dart';
import '../../../i18n/strings.g.dart';

class TrainingScreen extends StatelessWidget {
  final int? stepId;

  const TrainingScreen({
    super.key,
    this.stepId,
  });

  @override
  Widget build(BuildContext context) {
    final t = Translations.of(context);
    return Scaffold(
      appBar: AppBar(
        title: Text(stepId == null ? t.training.title : '${t.training.title} - $stepId'),
      ),
      body: Center(
        child: Text(stepId == null 
          ? t.training.content 
          : 'Detailed view for step ID: $stepId'),
      ),
    );
  }
}
