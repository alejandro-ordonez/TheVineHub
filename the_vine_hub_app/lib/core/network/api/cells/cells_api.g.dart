// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'cells_api.dart';

// **************************************************************************
// RiverpodGenerator
// **************************************************************************

// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint, type=warning

@ProviderFor(cellsApi)
final cellsApiProvider = CellsApiProvider._();

final class CellsApiProvider
    extends $FunctionalProvider<CellsApi, CellsApi, CellsApi>
    with $Provider<CellsApi> {
  CellsApiProvider._()
    : super(
        from: null,
        argument: null,
        retry: null,
        name: r'cellsApiProvider',
        isAutoDispose: true,
        dependencies: null,
        $allTransitiveDependencies: null,
      );

  @override
  String debugGetCreateSourceHash() => _$cellsApiHash();

  @$internal
  @override
  $ProviderElement<CellsApi> $createElement($ProviderPointer pointer) =>
      $ProviderElement(pointer);

  @override
  CellsApi create(Ref ref) {
    return cellsApi(ref);
  }

  /// {@macro riverpod.override_with_value}
  Override overrideWithValue(CellsApi value) {
    return $ProviderOverride(
      origin: this,
      providerOverride: $SyncValueProvider<CellsApi>(value),
    );
  }
}

String _$cellsApiHash() => r'bae591f0135c1b4a4da849aff1b1106e8fea0f26';
