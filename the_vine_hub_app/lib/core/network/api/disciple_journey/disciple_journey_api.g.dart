// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'disciple_journey_api.dart';

// **************************************************************************
// RiverpodGenerator
// **************************************************************************

// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint, type=warning

@ProviderFor(discipleJourneyApi)
final discipleJourneyApiProvider = DiscipleJourneyApiProvider._();

final class DiscipleJourneyApiProvider extends $FunctionalProvider<
    DiscipleJourneyApi,
    DiscipleJourneyApi,
    DiscipleJourneyApi> with $Provider<DiscipleJourneyApi> {
  DiscipleJourneyApiProvider._()
      : super(
          from: null,
          argument: null,
          retry: null,
          name: r'discipleJourneyApiProvider',
          isAutoDispose: true,
          dependencies: null,
          $allTransitiveDependencies: null,
        );

  @override
  String debugGetCreateSourceHash() => _$discipleJourneyApiHash();

  @$internal
  @override
  $ProviderElement<DiscipleJourneyApi> $createElement(
          $ProviderPointer pointer) =>
      $ProviderElement(pointer);

  @override
  DiscipleJourneyApi create(Ref ref) {
    return discipleJourneyApi(ref);
  }

  /// {@macro riverpod.override_with_value}
  Override overrideWithValue(DiscipleJourneyApi value) {
    return $ProviderOverride(
      origin: this,
      providerOverride: $SyncValueProvider<DiscipleJourneyApi>(value),
    );
  }
}

String _$discipleJourneyApiHash() =>
    r'61cb9b48d6d08ec20e91288bfa193f2e4ab647b1';
