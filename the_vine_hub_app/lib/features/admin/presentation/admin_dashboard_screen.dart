import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:go_router/go_router.dart';
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
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: GridView.count(
          crossAxisCount: 2,
          crossAxisSpacing: 16,
          mainAxisSpacing: 16,
          children: [
            Card(
              child: InkWell(
                onTap: () {
                  context.push('/admin/meetings');
                },
                child: Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    const Icon(Icons.event, size: 48),
                    const SizedBox(height: 8),
                    Text(t.admin.manageMeetings),
                  ],
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
