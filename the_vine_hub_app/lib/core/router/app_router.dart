import 'package:flutter/material.dart';
import 'package:go_router/go_router.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';
import 'package:the_vine_hub_app/features/dashboard/presentation/dashboard_screen.dart';
import 'package:the_vine_hub_app/features/cells/presentation/cells_screen.dart';
import 'package:the_vine_hub_app/features/cells/presentation/cell_details_screen.dart';
import 'package:the_vine_hub_app/features/training/presentation/training_screen.dart';
import 'package:the_vine_hub_app/features/auth/presentation/login_screen.dart';
import 'package:the_vine_hub_app/features/auth/presentation/auth_notifier.dart';
import 'package:the_vine_hub_app/features/home/presentation/home_screen.dart';
import 'package:the_vine_hub_app/features/admin/presentation/admin_dashboard_screen.dart';
import 'package:the_vine_hub_app/shared/main_shell.dart';

part 'app_router.g.dart';

final _rootNavigatorKey = GlobalKey<NavigatorState>(debugLabel: 'root');
final _shellNavigatorHomeKey = GlobalKey<NavigatorState>(debugLabel: 'home');
final _shellNavigatorDashboardKey = GlobalKey<NavigatorState>(
  debugLabel: 'dashboard',
);
final _shellNavigatorCellsKey = GlobalKey<NavigatorState>(debugLabel: 'cells');
final _shellNavigatorTrainingKey = GlobalKey<NavigatorState>(
  debugLabel: 'training',
);
final _shellNavigatorAdminKey = GlobalKey<NavigatorState>(debugLabel: 'admin');

class RouterListenable extends ChangeNotifier {
  RouterListenable(Ref ref) {
    _ref = ref;
    final link = _ref.keepAlive();

    _ref.listen(authProvider, (previous, next) {
      if (previous?.isLoading != next.isLoading ||
          previous?.value != next.value) {
        debugPrint(
          'RouterListenable: Auth state changed, notifying router. LoggedIn: ${next.value != null}',
        );
        notifyListeners();
      }
    });

    _ref.onDispose(() {
      link.close();
    });
  }

  late final Ref _ref;
}

@riverpod
RouterListenable routerListenable(Ref ref) {
  return RouterListenable(ref);
}

@riverpod
GoRouter router(Ref ref) {
  final listenable = ref.watch(routerListenableProvider);

  return GoRouter(
    initialLocation: '/login',
    navigatorKey: _rootNavigatorKey,
    refreshListenable: listenable,
    redirect: (context, state) {
      final authState = ref.read(authProvider);

      // If auth is still initializing, don't redirect yet
      if (authState.isLoading) {
        return null;
      }

      final isLoggedIn = authState.value != null;
      final isLoggingIn = state.matchedLocation == '/login';

      debugPrint(
        'Router Redirect: isLoggedIn=$isLoggedIn, isLoggingIn=$isLoggingIn, path=${state.matchedLocation}',
      );

      if (!isLoggedIn) {
        if (isLoggingIn) return null;
        return '/login';
      }

      // If logged in and trying to go to login, go home
      if (isLoggingIn) {
        return '/home';
      }

      return null;
    },
    routes: [
      GoRoute(path: '/login', builder: (context, state) => const LoginScreen()),
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
                      return CellDetailsScreen(cellId: id);
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
