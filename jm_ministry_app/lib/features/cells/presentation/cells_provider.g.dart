// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'cells_provider.dart';

// **************************************************************************
// RiverpodGenerator
// **************************************************************************

// GENERATED CODE - DO NOT MODIFY BY HAND
// ignore_for_file: type=lint, type=warning

@ProviderFor(cells)
final cellsProvider = CellsProvider._();

final class CellsProvider
    extends
        $FunctionalProvider<
          AsyncValue<List<CellDto>>,
          List<CellDto>,
          FutureOr<List<CellDto>>
        >
    with $FutureModifier<List<CellDto>>, $FutureProvider<List<CellDto>> {
  CellsProvider._()
    : super(
        from: null,
        argument: null,
        retry: null,
        name: r'cellsProvider',
        isAutoDispose: true,
        dependencies: null,
        $allTransitiveDependencies: null,
      );

  @override
  String debugGetCreateSourceHash() => _$cellsHash();

  @$internal
  @override
  $FutureProviderElement<List<CellDto>> $createElement(
    $ProviderPointer pointer,
  ) => $FutureProviderElement(pointer);

  @override
  FutureOr<List<CellDto>> create(Ref ref) {
    return cells(ref);
  }
}

String _$cellsHash() => r'921ecf4d831f8c1baf6e3fbdc138e28bc475c1e3';

@ProviderFor(cellDetails)
final cellDetailsProvider = CellDetailsFamily._();

final class CellDetailsProvider
    extends $FunctionalProvider<AsyncValue<CellDto>, CellDto, FutureOr<CellDto>>
    with $FutureModifier<CellDto>, $FutureProvider<CellDto> {
  CellDetailsProvider._({
    required CellDetailsFamily super.from,
    required int super.argument,
  }) : super(
         retry: null,
         name: r'cellDetailsProvider',
         isAutoDispose: true,
         dependencies: null,
         $allTransitiveDependencies: null,
       );

  @override
  String debugGetCreateSourceHash() => _$cellDetailsHash();

  @override
  String toString() {
    return r'cellDetailsProvider'
        ''
        '($argument)';
  }

  @$internal
  @override
  $FutureProviderElement<CellDto> $createElement($ProviderPointer pointer) =>
      $FutureProviderElement(pointer);

  @override
  FutureOr<CellDto> create(Ref ref) {
    final argument = this.argument as int;
    return cellDetails(ref, argument);
  }

  @override
  bool operator ==(Object other) {
    return other is CellDetailsProvider && other.argument == argument;
  }

  @override
  int get hashCode {
    return argument.hashCode;
  }
}

String _$cellDetailsHash() => r'33284582d2d7da882a88ad39b61a42e42701d276';

final class CellDetailsFamily extends $Family
    with $FunctionalFamilyOverride<FutureOr<CellDto>, int> {
  CellDetailsFamily._()
    : super(
        retry: null,
        name: r'cellDetailsProvider',
        dependencies: null,
        $allTransitiveDependencies: null,
        isAutoDispose: true,
      );

  CellDetailsProvider call(int id) =>
      CellDetailsProvider._(argument: id, from: this);

  @override
  String toString() => r'cellDetailsProvider';
}
