// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'shell_utils.dart';

// **************************************************************************
// RiverpodGenerator
// **************************************************************************

// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint, type=warning

@ProviderFor(shellScaffoldKey)
final shellScaffoldKeyProvider = ShellScaffoldKeyProvider._();

final class ShellScaffoldKeyProvider extends $FunctionalProvider<
    GlobalKey<ScaffoldState>,
    GlobalKey<ScaffoldState>,
    GlobalKey<ScaffoldState>> with $Provider<GlobalKey<ScaffoldState>> {
  ShellScaffoldKeyProvider._()
      : super(
          from: null,
          argument: null,
          retry: null,
          name: r'shellScaffoldKeyProvider',
          isAutoDispose: true,
          dependencies: null,
          $allTransitiveDependencies: null,
        );

  @override
  String debugGetCreateSourceHash() => _$shellScaffoldKeyHash();

  @$internal
  @override
  $ProviderElement<GlobalKey<ScaffoldState>> $createElement(
          $ProviderPointer pointer) =>
      $ProviderElement(pointer);

  @override
  GlobalKey<ScaffoldState> create(Ref ref) {
    return shellScaffoldKey(ref);
  }

  /// {@macro riverpod.override_with_value}
  Override overrideWithValue(GlobalKey<ScaffoldState> value) {
    return $ProviderOverride(
      origin: this,
      providerOverride: $SyncValueProvider<GlobalKey<ScaffoldState>>(value),
    );
  }
}

String _$shellScaffoldKeyHash() => r'3f5049ed197c11824ca7553ee7afc572f787df4d';
