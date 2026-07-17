// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'add_disciple_notifier.dart';

// **************************************************************************
// RiverpodGenerator
// **************************************************************************

// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint, type=warning

@ProviderFor(AddDiscipleNotifier)
final addDiscipleProvider = AddDiscipleNotifierProvider._();

final class AddDiscipleNotifierProvider
    extends $NotifierProvider<AddDiscipleNotifier, AddDiscipleState> {
  AddDiscipleNotifierProvider._()
    : super(
        from: null,
        argument: null,
        retry: null,
        name: r'addDiscipleProvider',
        isAutoDispose: true,
        dependencies: null,
        $allTransitiveDependencies: null,
      );

  @override
  String debugGetCreateSourceHash() => _$addDiscipleNotifierHash();

  @$internal
  @override
  AddDiscipleNotifier create() => AddDiscipleNotifier();

  /// {@macro riverpod.override_with_value}
  Override overrideWithValue(AddDiscipleState value) {
    return $ProviderOverride(
      origin: this,
      providerOverride: $SyncValueProvider<AddDiscipleState>(value),
    );
  }
}

String _$addDiscipleNotifierHash() =>
    r'253464d45dfeee9b868d0f1b0286abea0ac28e4e';

abstract class _$AddDiscipleNotifier extends $Notifier<AddDiscipleState> {
  AddDiscipleState build();
  @$mustCallSuper
  @override
  void runBuild() {
    final ref = this.ref as $Ref<AddDiscipleState, AddDiscipleState>;
    final element =
        ref.element
            as $ClassProviderElement<
              AnyNotifier<AddDiscipleState, AddDiscipleState>,
              AddDiscipleState,
              Object?,
              Object?
            >;
    element.handleCreate(ref, build);
  }
}
