import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:jm_ministry_app/shared/presentation/shell_utils.dart';
import 'package:jm_ministry_app/i18n/strings.g.dart';

class HomeScreen extends ConsumerWidget {
  const HomeScreen({super.key});

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final t = Translations.of(context);
    return Scaffold(
      appBar: AppBar(
        title: Text(t.home.title),
        leading: IconButton(
          icon: const Icon(Icons.menu),
          onPressed: () {
            ref.read(shellScaffoldKeyProvider).currentState?.openDrawer();
          },
        ),
      ),
      body: Center(child: Text(t.home.emptyState)),
    );
  }
}
