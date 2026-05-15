import 'package:flutter/material.dart';
import 'package:flutter_riverpod/flutter_riverpod.dart';
import 'package:skeletonizer/skeletonizer.dart';
import 'cells_provider.dart';
import 'widgets/details/header_bento_section.dart';
import 'widgets/details/search_and_filters.dart';
import 'widgets/details/member_card.dart';
import 'widgets/details/empty_members_state.dart';
import '../domain/disciple_dto.dart';
import '../../../i18n/strings.g.dart';

class CellDetailsScreen extends ConsumerStatefulWidget {
  final String cellId;

  const CellDetailsScreen({super.key, required this.cellId});

  @override
  ConsumerState<CellDetailsScreen> createState() => _CellDetailsScreenState();
}

class _CellDetailsScreenState extends ConsumerState<CellDetailsScreen> {
  final _searchController = TextEditingController();

  @override
  void dispose() {
    _searchController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    final t = Translations.of(context);
    final cellAsync = ref.watch(cellDetailsProvider(widget.cellId));
    final disciplesAsync = ref.watch(cellDisciplesProvider(widget.cellId));
    final theme = Theme.of(context);
    final colorScheme = theme.colorScheme;

    return Scaffold(
      backgroundColor: colorScheme.surface,
      appBar: AppBar(
        title: cellAsync.when(
          data: (cell) => Text(cell.name),
          loading: () => Text(t.common.loading),
          error: (e, s) => Text(t.common.error),
        ),
        elevation: 0,
        backgroundColor: colorScheme.surface,
        foregroundColor: colorScheme.primary,
      ),
      body: RefreshIndicator(
        onRefresh: () async {
          ref.invalidate(cellDetailsProvider(widget.cellId));
          ref.invalidate(cellDisciplesProvider(widget.cellId));
          return await ref.read(cellDetailsProvider(widget.cellId).future);
        },
        child: Skeletonizer(
          enabled: cellAsync.isLoading || disciplesAsync.isLoading,
          child: Center(
            child: ConstrainedBox(
              constraints: const BoxConstraints(maxWidth: 900),
              child: CustomScrollView(
                slivers: [
                  // Header Bento Section
                  SliverPadding(
                    padding: const EdgeInsets.symmetric(
                      horizontal: 20,
                      vertical: 24,
                    ),
                    sliver: SliverToBoxAdapter(
                      child: HeaderBentoSection(
                        cell: cellAsync.value,
                        memberCount: disciplesAsync.value?.length ?? 0,
                      ),
                    ),
                  ),

                  // Search & Filters
                  SliverPadding(
                    padding: const EdgeInsets.symmetric(horizontal: 20),
                    sliver: SliverToBoxAdapter(
                      child: SearchAndFilters(controller: _searchController),
                    ),
                  ),

                  // Members List
                  SliverPadding(
                    padding: const EdgeInsets.fromLTRB(20, 32, 20, 100),
                    sliver: disciplesAsync.when(
                      data: (disciples) {
                        if (disciples.isEmpty && !disciplesAsync.isLoading) {
                          return const SliverFillRemaining(
                            hasScrollBody: false,
                            child: EmptyMembersState(),
                          );
                        }

                        final displayDisciples = disciplesAsync.isLoading
                            ? List.generate(
                                5,
                                (index) => DiscipleDto(
                                  id: 'loading_$index',
                                  fullName: 'Loading Name',
                                  memberSince: DateTime.now(),
                                ),
                              )
                            : disciples;

                        return SliverList(
                          delegate: SliverChildBuilderDelegate(
                            (context, index) => MemberCard(
                              index: index,
                              disciple: displayDisciples[index],
                            ),
                            childCount: displayDisciples.length,
                          ),
                        );
                      },
                      loading: () =>
                          const SliverToBoxAdapter(child: SizedBox.shrink()),
                      error: (err, stack) => _ErrorState(err: err),
                    ),
                  ),
                ],
              ),
            ),
          ),
        ),
      ),
      floatingActionButton: FloatingActionButton(
        onPressed: () {
          // TODO: Add member
        },
        backgroundColor: colorScheme.secondaryContainer,
        foregroundColor: colorScheme.onSecondaryContainer,
        child: const Icon(Icons.person_add_outlined),
      ),
    );
  }
}

class _ErrorState extends StatelessWidget {
  final Object err;
  const _ErrorState({required this.err});

  @override
  Widget build(BuildContext context) {
    final t = Translations.of(context);
    return SliverToBoxAdapter(
      child: Center(child: Text(t.cells.errors.loadingDisciples(error: err))),
    );
  }
}
