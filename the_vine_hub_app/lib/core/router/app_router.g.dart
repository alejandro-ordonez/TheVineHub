// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'app_router.dart';

// **************************************************************************
// RiverpodGenerator
// **************************************************************************

// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint, type=warning

@ProviderFor(routerListenable)
final routerListenableProvider = RouterListenableProvider._();

final class RouterListenableProvider
    extends
        $FunctionalProvider<
          RouterListenable,
          RouterListenable,
          RouterListenable
        >
    with $Provider<RouterListenable> {
  RouterListenableProvider._()
    : super(
        from: null,
        argument: null,
        retry: null,
        name: r'routerListenableProvider',
        isAutoDispose: true,
        dependencies: null,
        $allTransitiveDependencies: null,
      );

  @override
  String debugGetCreateSourceHash() => _$routerListenableHash();

  @$internal
  @override
  $ProviderElement<RouterListenable> $createElement($ProviderPointer pointer) =>
      $ProviderElement(pointer);

  @override
  RouterListenable create(Ref ref) {
    return routerListenable(ref);
  }

  /// {@macro riverpod.override_with_value}
  Override overrideWithValue(RouterListenable value) {
    return $ProviderOverride(
      origin: this,
      providerOverride: $SyncValueProvider<RouterListenable>(value),
    );
  }
}

String _$routerListenableHash() => r'48d0ca0054da59e9d3b668d2c84be6264b94474b';

@ProviderFor(router)
final routerProvider = RouterProvider._();

final class RouterProvider
    extends $FunctionalProvider<GoRouter, GoRouter, GoRouter>
    with $Provider<GoRouter> {
  RouterProvider._()
    : super(
        from: null,
        argument: null,
        retry: null,
        name: r'routerProvider',
        isAutoDispose: true,
        dependencies: null,
        $allTransitiveDependencies: null,
      );

  @override
  String debugGetCreateSourceHash() => _$routerHash();

  @$internal
  @override
  $ProviderElement<GoRouter> $createElement($ProviderPointer pointer) =>
      $ProviderElement(pointer);

  @override
  GoRouter create(Ref ref) {
    return router(ref);
  }

  /// {@macro riverpod.override_with_value}
  Override overrideWithValue(GoRouter value) {
    return $ProviderOverride(
      origin: this,
      providerOverride: $SyncValueProvider<GoRouter>(value),
    );
  }
}

String _$routerHash() => r'dea45877e9c2e272b3bd8f708b8c29e5549dc2f1';
