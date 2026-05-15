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
    required String super.argument,
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
    final argument = this.argument as String;
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

String _$cellDetailsHash() => r'e9726237c49229ea35f6aae8ced1c3b56abd4cba';

final class CellDetailsFamily extends $Family
    with $FunctionalFamilyOverride<FutureOr<CellDto>, String> {
  CellDetailsFamily._()
    : super(
        retry: null,
        name: r'cellDetailsProvider',
        dependencies: null,
        $allTransitiveDependencies: null,
        isAutoDispose: true,
      );

  CellDetailsProvider call(String id) =>
      CellDetailsProvider._(argument: id, from: this);

  @override
  String toString() => r'cellDetailsProvider';
}

@ProviderFor(cellDisciples)
final cellDisciplesProvider = CellDisciplesFamily._();

final class CellDisciplesProvider
    extends
        $FunctionalProvider<
          AsyncValue<List<DiscipleDto>>,
          List<DiscipleDto>,
          FutureOr<List<DiscipleDto>>
        >
    with
        $FutureModifier<List<DiscipleDto>>,
        $FutureProvider<List<DiscipleDto>> {
  CellDisciplesProvider._({
    required CellDisciplesFamily super.from,
    required String super.argument,
  }) : super(
         retry: null,
         name: r'cellDisciplesProvider',
         isAutoDispose: true,
         dependencies: null,
         $allTransitiveDependencies: null,
       );

  @override
  String debugGetCreateSourceHash() => _$cellDisciplesHash();

  @override
  String toString() {
    return r'cellDisciplesProvider'
        ''
        '($argument)';
  }

  @$internal
  @override
  $FutureProviderElement<List<DiscipleDto>> $createElement(
    $ProviderPointer pointer,
  ) => $FutureProviderElement(pointer);

  @override
  FutureOr<List<DiscipleDto>> create(Ref ref) {
    final argument = this.argument as String;
    return cellDisciples(ref, argument);
  }

  @override
  bool operator ==(Object other) {
    return other is CellDisciplesProvider && other.argument == argument;
  }

  @override
  int get hashCode {
    return argument.hashCode;
  }
}

String _$cellDisciplesHash() => r'55aa70fa63f60648c6c844eb3713dc676e8bc8d3';

final class CellDisciplesFamily extends $Family
    with $FunctionalFamilyOverride<FutureOr<List<DiscipleDto>>, String> {
  CellDisciplesFamily._()
    : super(
        retry: null,
        name: r'cellDisciplesProvider',
        dependencies: null,
        $allTransitiveDependencies: null,
        isAutoDispose: true,
      );

  CellDisciplesProvider call(String cellId) =>
      CellDisciplesProvider._(argument: cellId, from: this);

  @override
  String toString() => r'cellDisciplesProvider';
}

@ProviderFor(locationData)
final locationDataProvider = LocationDataProvider._();

final class LocationDataProvider
    extends
        $FunctionalProvider<
          AsyncValue<List<CityDto>>,
          List<CityDto>,
          FutureOr<List<CityDto>>
        >
    with $FutureModifier<List<CityDto>>, $FutureProvider<List<CityDto>> {
  LocationDataProvider._()
    : super(
        from: null,
        argument: null,
        retry: null,
        name: r'locationDataProvider',
        isAutoDispose: true,
        dependencies: null,
        $allTransitiveDependencies: null,
      );

  @override
  String debugGetCreateSourceHash() => _$locationDataHash();

  @$internal
  @override
  $FutureProviderElement<List<CityDto>> $createElement(
    $ProviderPointer pointer,
  ) => $FutureProviderElement(pointer);

  @override
  FutureOr<List<CityDto>> create(Ref ref) {
    return locationData(ref);
  }
}

String _$locationDataHash() => r'91fd1f35b951c1a346f0feda55649e57caf1150b';
