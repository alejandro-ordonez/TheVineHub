import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:go_router/go_router.dart';
import '../features/training/data/training_repository_impl.dart';
import '../i18n/strings.g.dart';

class MainShell extends ConsumerWidget {
  final StatefulNavigationShell navigationShell;

  const MainShell({
    super.key,
    required this.navigationShell,
  });

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final t = Translations.of(context);
    final trainingSteps = ref.watch(trainingStepsProvider);

    return Scaffold(
      appBar: AppBar(
        title: Text(_getAppBarTitle(navigationShell.currentIndex, t)),
      ),
      drawer: Drawer(
        child: ListView(
          padding: EdgeInsets.zero,
          children: [
            DrawerHeader(
              decoration: BoxDecoration(
                color: Theme.of(context).colorScheme.primary,
              ),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  const CircleAvatar(
                    radius: 30,
                    backgroundColor: Colors.white,
                    child: Icon(Icons.person, size: 40),
                  ),
                  const SizedBox(height: 10),
                  Text(
                    'JM Ministry',
                    style: TextStyle(
                      color: Theme.of(context).colorScheme.onPrimary,
                      fontSize: 20,
                    ),
                  ),
                ],
              ),
            ),
            // User Section
            _DrawerItem(
              icon: Icons.home_outlined,
              label: 'Home',
              isSelected: navigationShell.currentIndex == 0,
              onTap: () {
                navigationShell.goBranch(0);
                context.pop();
              },
            ),
            _DrawerItem(
              icon: Icons.dashboard_outlined,
              label: t.nav.dashboard,
              isSelected: navigationShell.currentIndex == 1,
              onTap: () {
                navigationShell.goBranch(1);
                context.pop();
              },
            ),
            _DrawerItem(
              icon: Icons.groups_outlined,
              label: t.nav.cells,
              isSelected: navigationShell.currentIndex == 2,
              onTap: () {
                navigationShell.goBranch(2);
                context.pop();
              },
            ),
            
            // Ladder of Success (Training)
            ExpansionTile(
              leading: const Icon(Icons.auto_graph),
              title: const Text('Ladder of Success'),
              initiallyExpanded: navigationShell.currentIndex == 3,
              children: [
                _DrawerItem(
                  icon: Icons.school_outlined,
                  label: 'Overview',
                  isSelected: navigationShell.currentIndex == 3 && GoRouterState.of(context).matchedLocation == '/training',
                  onTap: () {
                    navigationShell.goBranch(3);
                    context.pop();
                  },
                ),
                ...trainingSteps.when(
                  data: (steps) => steps.map((step) => _DrawerItem(
                    icon: Icons.chevron_right,
                    label: step.name ?? 'Step ${step.id}',
                    isSelected: GoRouterState.of(context).matchedLocation == '/training/step/${step.id}',
                    onTap: () {
                      context.push('/training/step/${step.id}');
                      context.pop();
                    },
                  )),
                  loading: () => [const Center(child: CircularProgressIndicator())],
                  error: (e, _) => [ListTile(title: Text('Error loading steps: $e'))],
                ),
              ],
            ),

            const Divider(),
            // Admin Section
            Padding(
              padding: const EdgeInsets.all(16.0),
              child: Text(
                'Admin',
                style: Theme.of(context).textTheme.labelLarge?.copyWith(
                  color: Theme.of(context).colorScheme.secondary,
                ),
              ),
            ),
            _DrawerItem(
              icon: Icons.admin_panel_settings_outlined,
              label: 'Admin Panel',
              isSelected: navigationShell.currentIndex == 4,
              onTap: () {
                navigationShell.goBranch(4);
                context.pop();
              },
            ),
            _DrawerItem(
              icon: Icons.search,
              label: 'Search Users',
              onTap: () {
                // TODO: Implement user search
                context.pop();
              },
            ),
          ],
        ),
      ),
      body: navigationShell,
    );
  }

  String _getAppBarTitle(int index, Translations t) {
    switch (index) {
      case 0: return 'Announcements';
      case 1: return t.nav.dashboard;
      case 2: return t.nav.cells;
      case 3: return 'Ladder of Success';
      case 4: return 'Admin Panel';
      default: return 'JM Ministry';
    }
  }
}

class _DrawerItem extends StatelessWidget {
  final IconData icon;
  final String label;
  final bool isSelected;
  final VoidCallback onTap;

  const _DrawerItem({
    required this.icon,
    required this.label,
    this.isSelected = false,
    required this.onTap,
  });

  @override
  Widget build(BuildContext context) {
    return ListTile(
      leading: Icon(icon, color: isSelected ? Theme.of(context).colorScheme.primary : null),
      title: Text(
        label,
        style: TextStyle(
          color: isSelected ? Theme.of(context).colorScheme.primary : null,
          fontWeight: isSelected ? FontWeight.bold : null,
        ),
      ),
      selected: isSelected,
      onTap: onTap,
    );
  }
}

// Provider for dynamic steps in drawer
final trainingStepsProvider = FutureProvider((ref) async {
  final repo = ref.watch(trainingRepositoryProvider);
  return repo.getSteps();
});
