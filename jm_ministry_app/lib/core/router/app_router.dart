import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';
import '../../features/dashboard/presentation/dashboard_screen.dart';
import '../../features/cells/presentation/cells_screen.dart';
import '../../features/cells/presentation/cell_details_screen.dart';
import '../../features/training/presentation/training_screen.dart';
import '../../features/auth/presentation/login_screen.dart';
import '../../features/auth/presentation/auth_notifier.dart';
import '../../features/home/presentation/home_screen.dart';
import '../../features/admin/presentation/admin_dashboard_screen.dart';
import '../../shared/main_shell.dart';

part 'app_router.g.dart';

final _rootNavigatorKey = GlobalKey<NavigatorState>();
final _shellNavigatorHomeKey = GlobalKey<NavigatorState>(debugLabel: 'home');
final _shellNavigatorDashboardKey = GlobalKey<NavigatorState>(debugLabel: 'dashboard');
final _shellNavigatorCellsKey = GlobalKey<NavigatorState>(debugLabel: 'cells');
final _shellNavigatorTrainingKey = GlobalKey<NavigatorState>(debugLabel: 'training');
final _shellNavigatorAdminKey = GlobalKey<NavigatorState>(debugLabel: 'admin');

@riverpod
GoRouter router(Ref ref) {
  final authState = ref.watch(authProvider);

  return GoRouter(
    initialLocation: '/home',
    navigatorKey: _rootNavigatorKey,
    redirect: (context, state) {
      final isLoggedIn = authState.value != null;
      final isLoggingIn = state.matchedLocation == '/login';

      if (!isLoggedIn && !isLoggingIn) return '/login';
      if (isLoggedIn && isLoggingIn) return '/home';

      return null;
    },
    routes: [
      GoRoute(
        path: '/login',
        builder: (context, state) => const LoginScreen(),
      ),
      StatefulShellRoute.indexedStack(
        builder: (context, state, navigationShell) {
          return MainShell(navigationShell: navigationShell);
        },
        branches: [
          StatefulShellBranch(
            navigatorKey: _shellNavigatorHomeKey,
            routes: [
              GoRoute(
                path: '/home',
                builder: (context, state) => const HomeScreen(),
              ),
            ],
          ),
          StatefulShellBranch(
            navigatorKey: _shellNavigatorDashboardKey,
            routes: [
              GoRoute(
                path: '/dashboard',
                builder: (context, state) => const DashboardScreen(),
              ),
            ],
          ),
          StatefulShellBranch(
            navigatorKey: _shellNavigatorCellsKey,
            routes: [
              GoRoute(
                path: '/cells',
                builder: (context, state) => const CellsScreen(),
                routes: [
                  GoRoute(
                    path: ':id',
                    builder: (context, state) {
                      final id = state.pathParameters['id']!;
                      return CellDetailsScreen(cellId: int.parse(id));
                    },
                  ),
                ],
              ),
            ],
          ),
          StatefulShellBranch(
            navigatorKey: _shellNavigatorTrainingKey,
            routes: [
              GoRoute(
                path: '/training',
                builder: (context, state) => const TrainingScreen(),
                routes: [
                  GoRoute(
                    path: 'step/:id',
                    builder: (context, state) {
                      final id = state.pathParameters['id']!;
                      return TrainingScreen(stepId: int.parse(id));
                    },
                  ),
                ],
              ),
            ],
          ),
          StatefulShellBranch(
            navigatorKey: _shellNavigatorAdminKey,
            routes: [
              GoRoute(
                path: '/admin',
                builder: (context, state) => const AdminDashboardScreen(),
              ),
            ],
          ),
        ],
      ),
    ],
  );
}
