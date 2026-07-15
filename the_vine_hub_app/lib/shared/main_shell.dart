import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:go_router/go_router.dart';
import 'package:the_vine_hub_app/features/training/data/training_repository_impl.dart';
import 'package:the_vine_hub_app/features/auth/presentation/auth_notifier.dart';
import 'package:the_vine_hub_app/i18n/strings.g.dart';
import 'package:the_vine_hub_app/shared/presentation/shell_utils.dart';

class MainShell extends ConsumerWidget {
  final StatefulNavigationShell navigationShell;

  const MainShell({super.key, required this.navigationShell});

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final t = Translations.of(context);
    final trainingSteps = ref.watch(trainingStepsProvider);
    final scaffoldKey = ref.watch(shellScaffoldKeyProvider);

    return Scaffold(
      key: scaffoldKey,
      drawer: Drawer(
        child: Column(
          children: [
            Expanded(
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
                          t.auth.appName,
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
                    label: t.nav.home,
                    isSelected: navigationShell.currentIndex == 0,
                    onTap: () {
                      _onItemTapped(0, context, scaffoldKey);
                    },
                  ),
                  _DrawerItem(
                    icon: Icons.dashboard_outlined,
                    label: t.nav.dashboard,
                    isSelected: navigationShell.currentIndex == 1,
                    onTap: () {
                      _onItemTapped(1, context, scaffoldKey);
                    },
                  ),
                  _DrawerItem(
                    icon: Icons.groups_outlined,
                    label: t.nav.cells,
                    isSelected: navigationShell.currentIndex == 2,
                    onTap: () {
                      _onItemTapped(2, context, scaffoldKey);
                    },
                  ),

                  // Ladder of Success (Training)
                  ExpansionTile(
                    leading: const Icon(Icons.auto_graph),
                    title: Text(t.common.ladderOfSuccess),
                    initiallyExpanded: navigationShell.currentIndex == 3,
                    children: [
                      _DrawerItem(
                        icon: Icons.school_outlined,
                        label: t.common.overview,
                        isSelected:
                            navigationShell.currentIndex == 3 &&
                            GoRouterState.of(context).matchedLocation ==
                                '/training',
                        onTap: () {
                          _onItemTapped(3, context, scaffoldKey);
                        },
                      ),
                      ...trainingSteps.when(
                        data: (steps) => steps.map(
                          (step) => _DrawerItem(
                            icon: Icons.chevron_right,
                            label: step.name ?? t.common.step(id: step.id),
                            isSelected:
                                GoRouterState.of(context).matchedLocation ==
                                '/training/step/${step.id}',
                            onTap: () {
                              context.push('/training/step/${step.id}');
                              if (scaffoldKey.currentState?.isDrawerOpen ??
                                  false) {
                                scaffoldKey.currentState?.closeDrawer();
                              }
                            },
                          ),
                        ),
                        loading: () => [
                          const Center(child: CircularProgressIndicator()),
                        ],
                        error: (e, _) => [
                          ListTile(
                            title: Text(t.common.errors.loadingSteps(error: e)),
                          ),
                        ],
                      ),
                    ],
                  ),

                  const Divider(),
                  // Admin Section
                  Padding(
                    padding: const EdgeInsets.all(16.0),
                    child: Text(
                      t.nav.admin,
                      style: Theme.of(context).textTheme.labelLarge?.copyWith(
                        color: Theme.of(context).colorScheme.secondary,
                      ),
                    ),
                  ),
                  _DrawerItem(
                    icon: Icons.admin_panel_settings_outlined,
                    label: t.nav.adminPanel,
                    isSelected: navigationShell.currentIndex == 4,
                    onTap: () {
                      _onItemTapped(4, context, scaffoldKey);
                    },
                  ),
                  _DrawerItem(
                    icon: Icons.search,
                    label: t.nav.searchUsers,
                    onTap: () {
                      // TODO: Implement user search
                      if (scaffoldKey.currentState?.isDrawerOpen ?? false) {
                        scaffoldKey.currentState?.closeDrawer();
                      }
                    },
                  ),
                ],
              ),
            ),
            const Divider(),
            ListTile(
              leading: const Icon(Icons.logout, color: Colors.red),
              title: Text(
                t.auth.logout,
                style: const TextStyle(color: Colors.red),
              ),
              onTap: () {
                ref.read(authProvider.notifier).logout();
                if (scaffoldKey.currentState?.isDrawerOpen ?? false) {
                  scaffoldKey.currentState?.closeDrawer();
                }
              },
            ),
            const SizedBox(height: 16),
          ],
        ),
      ),
      body: navigationShell,
    );
  }

  void _onItemTapped(
    int index,
    BuildContext context,
    GlobalKey<ScaffoldState> key,
  ) {
    navigationShell.goBranch(
      index,
      initialLocation: index == navigationShell.currentIndex,
    );
    if (key.currentState?.isDrawerOpen ?? false) {
      key.currentState?.closeDrawer();
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
      leading: Icon(
        icon,
        color: isSelected ? Theme.of(context).colorScheme.primary : null,
      ),
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
