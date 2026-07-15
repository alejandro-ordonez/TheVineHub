// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'auth_events.dart';

// **************************************************************************
// RiverpodGenerator
// **************************************************************************

// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint, type=warning

@ProviderFor(authEventStream)
final authEventStreamProvider = AuthEventStreamProvider._();

final class AuthEventStreamProvider extends $FunctionalProvider<
        AsyncValue<AuthEvent>, AuthEvent, Stream<AuthEvent>>
    with $FutureModifier<AuthEvent>, $StreamProvider<AuthEvent> {
  AuthEventStreamProvider._()
      : super(
          from: null,
          argument: null,
          retry: null,
          name: r'authEventStreamProvider',
          isAutoDispose: true,
          dependencies: null,
          $allTransitiveDependencies: null,
        );

  @override
  String debugGetCreateSourceHash() => _$authEventStreamHash();

  @$internal
  @override
  $StreamProviderElement<AuthEvent> $createElement($ProviderPointer pointer) =>
      $StreamProviderElement(pointer);

  @override
  Stream<AuthEvent> create(Ref ref) {
    return authEventStream(ref);
  }
}

String _$authEventStreamHash() => r'5fe2d69e085d1eb0db31f26ada27cfd31002ddeb';
