import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:the_vine_hub_app/shared/presentation/shell_utils.dart';
import 'package:the_vine_hub_app/i18n/strings.g.dart';

class AdminDashboardScreen extends ConsumerWidget {
  const AdminDashboardScreen({super.key});

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final t = Translations.of(context);
    return Scaffold(
      appBar: AppBar(
        title: Text(t.admin.title),
        leading: IconButton(
          icon: const Icon(Icons.menu),
          onPressed: () {
            ref.read(shellScaffoldKeyProvider).currentState?.openDrawer();
          },
        ),
      ),
      body: Center(child: Text(t.admin.emptyState)),
    );
  }
}
