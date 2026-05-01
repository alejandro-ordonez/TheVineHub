import 'package:flutter/material.dart';
import '../../../i18n/strings.g.dart';

class DashboardScreen extends StatelessWidget {
  const DashboardScreen({super.key});

  @override
  Widget build(BuildContext context) {
    final t = Translations.of(context);
    return Scaffold(
      appBar: AppBar(title: Text(t.dashboard.title)),
      body: Center(child: Text(t.dashboard.content)),
    );
  }
}
