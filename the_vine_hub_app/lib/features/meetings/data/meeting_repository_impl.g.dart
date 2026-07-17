// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'meeting_repository_impl.dart';

// **************************************************************************
// RiverpodGenerator
// **************************************************************************

// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint, type=warning

@ProviderFor(meetingRepository)
final meetingRepositoryProvider = MeetingRepositoryProvider._();

final class MeetingRepositoryProvider
    extends
        $FunctionalProvider<
          MeetingRepository,
          MeetingRepository,
          MeetingRepository
        >
    with $Provider<MeetingRepository> {
  MeetingRepositoryProvider._()
    : super(
        from: null,
        argument: null,
        retry: null,
        name: r'meetingRepositoryProvider',
        isAutoDispose: true,
        dependencies: null,
        $allTransitiveDependencies: null,
      );

  @override
  String debugGetCreateSourceHash() => _$meetingRepositoryHash();

  @$internal
  @override
  $ProviderElement<MeetingRepository> $createElement(
    $ProviderPointer pointer,
  ) => $ProviderElement(pointer);

  @override
  MeetingRepository create(Ref ref) {
    return meetingRepository(ref);
  }

  /// {@macro riverpod.override_with_value}
  Override overrideWithValue(MeetingRepository value) {
    return $ProviderOverride(
      origin: this,
      providerOverride: $SyncValueProvider<MeetingRepository>(value),
    );
  }
}

String _$meetingRepositoryHash() => r'195eb146f9ba6e5b7f9a2938482150f5a294d7d8';
