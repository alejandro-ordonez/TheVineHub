// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'training_repository_impl.dart';

// **************************************************************************
// RiverpodGenerator
// **************************************************************************

// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint, type=warning

@ProviderFor(trainingRepository)
final trainingRepositoryProvider = TrainingRepositoryProvider._();

final class TrainingRepositoryProvider
    extends
        $FunctionalProvider<
          TrainingRepository,
          TrainingRepository,
          TrainingRepository
        >
    with $Provider<TrainingRepository> {
  TrainingRepositoryProvider._()
    : super(
        from: null,
        argument: null,
        retry: null,
        name: r'trainingRepositoryProvider',
        isAutoDispose: true,
        dependencies: null,
        $allTransitiveDependencies: null,
      );

  @override
  String debugGetCreateSourceHash() => _$trainingRepositoryHash();

  @$internal
  @override
  $ProviderElement<TrainingRepository> $createElement(
    $ProviderPointer pointer,
  ) => $ProviderElement(pointer);

  @override
  TrainingRepository create(Ref ref) {
    return trainingRepository(ref);
  }

  /// {@macro riverpod.override_with_value}
  Override overrideWithValue(TrainingRepository value) {
    return $ProviderOverride(
      origin: this,
      providerOverride: $SyncValueProvider<TrainingRepository>(value),
    );
  }
}

String _$trainingRepositoryHash() =>
    r'8ac9e85c1c094458cc1003f5de5ee1b231a04977';
