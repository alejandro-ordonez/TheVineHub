// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'discipleship_repository_impl.dart';

// **************************************************************************
// RiverpodGenerator
// **************************************************************************

// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint, type=warning

@ProviderFor(discipleshipRepository)
final discipleshipRepositoryProvider = DiscipleshipRepositoryProvider._();

final class DiscipleshipRepositoryProvider
    extends
        $FunctionalProvider<
          DiscipleshipRepository,
          DiscipleshipRepository,
          DiscipleshipRepository
        >
    with $Provider<DiscipleshipRepository> {
  DiscipleshipRepositoryProvider._()
    : super(
        from: null,
        argument: null,
        retry: null,
        name: r'discipleshipRepositoryProvider',
        isAutoDispose: true,
        dependencies: null,
        $allTransitiveDependencies: null,
      );

  @override
  String debugGetCreateSourceHash() => _$discipleshipRepositoryHash();

  @$internal
  @override
  $ProviderElement<DiscipleshipRepository> $createElement(
    $ProviderPointer pointer,
  ) => $ProviderElement(pointer);

  @override
  DiscipleshipRepository create(Ref ref) {
    return discipleshipRepository(ref);
  }

  /// {@macro riverpod.override_with_value}
  Override overrideWithValue(DiscipleshipRepository value) {
    return $ProviderOverride(
      origin: this,
      providerOverride: $SyncValueProvider<DiscipleshipRepository>(value),
    );
  }
}

String _$discipleshipRepositoryHash() =>
    r'48ef28b8a298594951e3d94bce1daf471c7163f7';
