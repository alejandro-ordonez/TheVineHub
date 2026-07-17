// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'cell_member_repository_impl.dart';

// **************************************************************************
// RiverpodGenerator
// **************************************************************************

// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint, type=warning

@ProviderFor(cellMemberRepository)
final cellMemberRepositoryProvider = CellMemberRepositoryProvider._();

final class CellMemberRepositoryProvider
    extends
        $FunctionalProvider<
          CellMemberRepository,
          CellMemberRepository,
          CellMemberRepository
        >
    with $Provider<CellMemberRepository> {
  CellMemberRepositoryProvider._()
    : super(
        from: null,
        argument: null,
        retry: null,
        name: r'cellMemberRepositoryProvider',
        isAutoDispose: true,
        dependencies: null,
        $allTransitiveDependencies: null,
      );

  @override
  String debugGetCreateSourceHash() => _$cellMemberRepositoryHash();

  @$internal
  @override
  $ProviderElement<CellMemberRepository> $createElement(
    $ProviderPointer pointer,
  ) => $ProviderElement(pointer);

  @override
  CellMemberRepository create(Ref ref) {
    return cellMemberRepository(ref);
  }

  /// {@macro riverpod.override_with_value}
  Override overrideWithValue(CellMemberRepository value) {
    return $ProviderOverride(
      origin: this,
      providerOverride: $SyncValueProvider<CellMemberRepository>(value),
    );
  }
}

String _$cellMemberRepositoryHash() =>
    r'5ea5d21b9fba4d33906c2e8c4104884a4c3b589b';
