// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'hierarchy_api.dart';

// **************************************************************************
// RiverpodGenerator
// **************************************************************************

// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint, type=warning

@ProviderFor(hierarchyApi)
final hierarchyApiProvider = HierarchyApiProvider._();

final class HierarchyApiProvider
    extends $FunctionalProvider<HierarchyApi, HierarchyApi, HierarchyApi>
    with $Provider<HierarchyApi> {
  HierarchyApiProvider._()
    : super(
        from: null,
        argument: null,
        retry: null,
        name: r'hierarchyApiProvider',
        isAutoDispose: true,
        dependencies: null,
        $allTransitiveDependencies: null,
      );

  @override
  String debugGetCreateSourceHash() => _$hierarchyApiHash();

  @$internal
  @override
  $ProviderElement<HierarchyApi> $createElement($ProviderPointer pointer) =>
      $ProviderElement(pointer);

  @override
  HierarchyApi create(Ref ref) {
    return hierarchyApi(ref);
  }

  /// {@macro riverpod.override_with_value}
  Override overrideWithValue(HierarchyApi value) {
    return $ProviderOverride(
      origin: this,
      providerOverride: $SyncValueProvider<HierarchyApi>(value),
    );
  }
}

String _$hierarchyApiHash() => r'9351a68e40fa89b44c9a6249fb1e28de665476af';
