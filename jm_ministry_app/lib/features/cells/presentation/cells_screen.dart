import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:go_router/go_router.dart';
import 'cells_provider.dart';
import 'widgets/cell_card.dart';

class CellsScreen extends ConsumerWidget {
  const CellsScreen({super.key});

  @override
  Widget build(BuildContext context, WidgetRef ref) {
    final cellsAsync = ref.watch(cellsProvider);

    return Scaffold(
      body: cellsAsync.when(
        data: (cells) {
          if (cells.isEmpty) {
            return Center(
              child: Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  const Icon(Icons.groups_outlined, size: 64, color: Colors.grey),
                  const SizedBox(height: 16),
                  Text(
                    'No cells assigned yet',
                    style: Theme.of(context).textTheme.titleMedium,
                  ),
                ],
              ),
            );
          }

          return RefreshIndicator(
            onRefresh: () => ref.refresh(cellsProvider.future),
            child: ListView(
              padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 20),
              children: [
                Text(
                  'My Cells',
                  style: Theme.of(context).textTheme.headlineMedium?.copyWith(
                    fontWeight: FontWeight.bold,
                  ),
                ),
                const SizedBox(height: 4),
                Text(
                  'Manage your ministry groups and attendance',
                  style: Theme.of(context).textTheme.bodyMedium?.copyWith(
                    color: Theme.of(context).colorScheme.onSurfaceVariant,
                  ),
                ),
                const SizedBox(height: 24),
                ...cells.map((cell) => CellCard(
                  cell: cell,
                  onTap: () => context.push('/cells/${cell.id}'),
                )),
              ],
            ),
          );
        },
        loading: () => const Center(child: CircularProgressIndicator()),
        error: (err, stack) => Center(
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              const Icon(Icons.error_outline, size: 48, color: Colors.red),
              const SizedBox(height: 16),
              Text('Error loading cells: $err'),
              ElevatedButton(
                onPressed: () => ref.refresh(cellsProvider),
                child: const Text('Retry'),
              ),
            ],
          ),
        ),
      ),
      floatingActionButton: FloatingActionButton.extended(
        onPressed: () {
          // TODO: Implement create cell (Admin or specific role)
        },
        icon: const Icon(Icons.add),
        label: const Text('New Cell'),
      ),
    );
  }
}
