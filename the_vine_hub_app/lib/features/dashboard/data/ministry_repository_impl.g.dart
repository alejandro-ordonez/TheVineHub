// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'ministry_repository_impl.dart';

// **************************************************************************
// RiverpodGenerator
// **************************************************************************

// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint, type=warning

@ProviderFor(ministryRepository)
final ministryRepositoryProvider = MinistryRepositoryProvider._();

final class MinistryRepositoryProvider
    extends
        $FunctionalProvider<
          MinistryRepository,
          MinistryRepository,
          MinistryRepository
        >
    with $Provider<MinistryRepository> {
  MinistryRepositoryProvider._()
    : super(
        from: null,
        argument: null,
        retry: null,
        name: r'ministryRepositoryProvider',
        isAutoDispose: true,
        dependencies: null,
        $allTransitiveDependencies: null,
      );

  @override
  String debugGetCreateSourceHash() => _$ministryRepositoryHash();

  @$internal
  @override
  $ProviderElement<MinistryRepository> $createElement(
    $ProviderPointer pointer,
  ) => $ProviderElement(pointer);

  @override
  MinistryRepository create(Ref ref) {
    return ministryRepository(ref);
  }

  /// {@macro riverpod.override_with_value}
  Override overrideWithValue(MinistryRepository value) {
    return $ProviderOverride(
      origin: this,
      providerOverride: $SyncValueProvider<MinistryRepository>(value),
    );
  }
}

String _$ministryRepositoryHash() =>
    r'460be291d579bdf91b4e3f7c0559b6590c11e0d8';
