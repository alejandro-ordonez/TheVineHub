// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'discipleship_api.dart';

// **************************************************************************
// RiverpodGenerator
// **************************************************************************

// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint, type=warning

@ProviderFor(discipleshipApi)
final discipleshipApiProvider = DiscipleshipApiProvider._();

final class DiscipleshipApiProvider
    extends
        $FunctionalProvider<DiscipleshipApi, DiscipleshipApi, DiscipleshipApi>
    with $Provider<DiscipleshipApi> {
  DiscipleshipApiProvider._()
    : super(
        from: null,
        argument: null,
        retry: null,
        name: r'discipleshipApiProvider',
        isAutoDispose: true,
        dependencies: null,
        $allTransitiveDependencies: null,
      );

  @override
  String debugGetCreateSourceHash() => _$discipleshipApiHash();

  @$internal
  @override
  $ProviderElement<DiscipleshipApi> $createElement($ProviderPointer pointer) =>
      $ProviderElement(pointer);

  @override
  DiscipleshipApi create(Ref ref) {
    return discipleshipApi(ref);
  }

  /// {@macro riverpod.override_with_value}
  Override overrideWithValue(DiscipleshipApi value) {
    return $ProviderOverride(
      origin: this,
      providerOverride: $SyncValueProvider<DiscipleshipApi>(value),
    );
  }
}

String _$discipleshipApiHash() => r'9a3e96e9a0af851e28a145d1bf72414cc3570331';
