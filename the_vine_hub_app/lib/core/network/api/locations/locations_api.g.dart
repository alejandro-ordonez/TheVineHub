// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'locations_api.dart';

// **************************************************************************
// RiverpodGenerator
// **************************************************************************

// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint, type=warning

@ProviderFor(locationsApi)
final locationsApiProvider = LocationsApiProvider._();

final class LocationsApiProvider
    extends $FunctionalProvider<LocationsApi, LocationsApi, LocationsApi>
    with $Provider<LocationsApi> {
  LocationsApiProvider._()
      : super(
          from: null,
          argument: null,
          retry: null,
          name: r'locationsApiProvider',
          isAutoDispose: true,
          dependencies: null,
          $allTransitiveDependencies: null,
        );

  @override
  String debugGetCreateSourceHash() => _$locationsApiHash();

  @$internal
  @override
  $ProviderElement<LocationsApi> $createElement($ProviderPointer pointer) =>
      $ProviderElement(pointer);

  @override
  LocationsApi create(Ref ref) {
    return locationsApi(ref);
  }

  /// {@macro riverpod.override_with_value}
  Override overrideWithValue(LocationsApi value) {
    return $ProviderOverride(
      origin: this,
      providerOverride: $SyncValueProvider<LocationsApi>(value),
    );
  }
}

String _$locationsApiHash() => r'ae34cef34d39796ca4df85bedf174d1d4bfaa271';
