// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'meetings_api.dart';

// **************************************************************************
// RiverpodGenerator
// **************************************************************************

// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint, type=warning

@ProviderFor(meetingsApi)
final meetingsApiProvider = MeetingsApiProvider._();

final class MeetingsApiProvider
    extends $FunctionalProvider<MeetingsApi, MeetingsApi, MeetingsApi>
    with $Provider<MeetingsApi> {
  MeetingsApiProvider._()
    : super(
        from: null,
        argument: null,
        retry: null,
        name: r'meetingsApiProvider',
        isAutoDispose: true,
        dependencies: null,
        $allTransitiveDependencies: null,
      );

  @override
  String debugGetCreateSourceHash() => _$meetingsApiHash();

  @$internal
  @override
  $ProviderElement<MeetingsApi> $createElement($ProviderPointer pointer) =>
      $ProviderElement(pointer);

  @override
  MeetingsApi create(Ref ref) {
    return meetingsApi(ref);
  }

  /// {@macro riverpod.override_with_value}
  Override overrideWithValue(MeetingsApi value) {
    return $ProviderOverride(
      origin: this,
      providerOverride: $SyncValueProvider<MeetingsApi>(value),
    );
  }
}

String _$meetingsApiHash() => r'da2949f4001a07176f0cf131b6998610ee790765';
