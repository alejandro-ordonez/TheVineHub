// GENERATED CODE - DO NOT MODIFY BY HAND
// coverage:ignore-file
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'disciple_step_dto.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

// dart format off
T _$identity<T>(T value) => value;

/// @nodoc
mixin _$DiscipleStepDto {
  int get id;
  String? get name;
  String? get description;
  int get stepCategory;
  bool get requiresCycle;
  bool get requiresAdminApproval;
  List<int>? get requirementIds;
  int? get parentStepId;
  List<DiscipleStepDto>? get subSteps;

  /// Create a copy of DiscipleStepDto
  /// with the given fields replaced by the non-null parameter values.
  @JsonKey(includeFromJson: false, includeToJson: false)
  @pragma('vm:prefer-inline')
  $DiscipleStepDtoCopyWith<DiscipleStepDto> get copyWith =>
      _$DiscipleStepDtoCopyWithImpl<DiscipleStepDto>(
          this as DiscipleStepDto, _$identity);

  /// Serializes this DiscipleStepDto to a JSON map.
  Map<String, dynamic> toJson();

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is DiscipleStepDto &&
            (identical(other.id, id) || other.id == id) &&
            (identical(other.name, name) || other.name == name) &&
            (identical(other.description, description) ||
                other.description == description) &&
            (identical(other.stepCategory, stepCategory) ||
                other.stepCategory == stepCategory) &&
            (identical(other.requiresCycle, requiresCycle) ||
                other.requiresCycle == requiresCycle) &&
            (identical(other.requiresAdminApproval, requiresAdminApproval) ||
                other.requiresAdminApproval == requiresAdminApproval) &&
            const DeepCollectionEquality()
                .equals(other.requirementIds, requirementIds) &&
            (identical(other.parentStepId, parentStepId) ||
                other.parentStepId == parentStepId) &&
            const DeepCollectionEquality().equals(other.subSteps, subSteps));
  }

  @JsonKey(includeFromJson: false, includeToJson: false)
  @override
  int get hashCode => Object.hash(
      runtimeType,
      id,
      name,
      description,
      stepCategory,
      requiresCycle,
      requiresAdminApproval,
      const DeepCollectionEquality().hash(requirementIds),
      parentStepId,
      const DeepCollectionEquality().hash(subSteps));

  @override
  String toString() {
    return 'DiscipleStepDto(id: $id, name: $name, description: $description, stepCategory: $stepCategory, requiresCycle: $requiresCycle, requiresAdminApproval: $requiresAdminApproval, requirementIds: $requirementIds, parentStepId: $parentStepId, subSteps: $subSteps)';
  }
}

/// @nodoc
abstract mixin class $DiscipleStepDtoCopyWith<$Res> {
  factory $DiscipleStepDtoCopyWith(
          DiscipleStepDto value, $Res Function(DiscipleStepDto) _then) =
      _$DiscipleStepDtoCopyWithImpl;
  @useResult
  $Res call(
      {int id,
      String? name,
      String? description,
      int stepCategory,
      bool requiresCycle,
      bool requiresAdminApproval,
      List<int>? requirementIds,
      int? parentStepId,
      List<DiscipleStepDto>? subSteps});
}

/// @nodoc
class _$DiscipleStepDtoCopyWithImpl<$Res>
    implements $DiscipleStepDtoCopyWith<$Res> {
  _$DiscipleStepDtoCopyWithImpl(this._self, this._then);

  final DiscipleStepDto _self;
  final $Res Function(DiscipleStepDto) _then;

  /// Create a copy of DiscipleStepDto
  /// with the given fields replaced by the non-null parameter values.
  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? id = null,
    Object? name = freezed,
    Object? description = freezed,
    Object? stepCategory = null,
    Object? requiresCycle = null,
    Object? requiresAdminApproval = null,
    Object? requirementIds = freezed,
    Object? parentStepId = freezed,
    Object? subSteps = freezed,
  }) {
    return _then(_self.copyWith(
      id: null == id
          ? _self.id
          : id // ignore: cast_nullable_to_non_nullable
              as int,
      name: freezed == name
          ? _self.name
          : name // ignore: cast_nullable_to_non_nullable
              as String?,
      description: freezed == description
          ? _self.description
          : description // ignore: cast_nullable_to_non_nullable
              as String?,
      stepCategory: null == stepCategory
          ? _self.stepCategory
          : stepCategory // ignore: cast_nullable_to_non_nullable
              as int,
      requiresCycle: null == requiresCycle
          ? _self.requiresCycle
          : requiresCycle // ignore: cast_nullable_to_non_nullable
              as bool,
      requiresAdminApproval: null == requiresAdminApproval
          ? _self.requiresAdminApproval
          : requiresAdminApproval // ignore: cast_nullable_to_non_nullable
              as bool,
      requirementIds: freezed == requirementIds
          ? _self.requirementIds
          : requirementIds // ignore: cast_nullable_to_non_nullable
              as List<int>?,
      parentStepId: freezed == parentStepId
          ? _self.parentStepId
          : parentStepId // ignore: cast_nullable_to_non_nullable
              as int?,
      subSteps: freezed == subSteps
          ? _self.subSteps
          : subSteps // ignore: cast_nullable_to_non_nullable
              as List<DiscipleStepDto>?,
    ));
  }
}

/// Adds pattern-matching-related methods to [DiscipleStepDto].
extension DiscipleStepDtoPatterns on DiscipleStepDto {
  /// A variant of `map` that fallback to returning `orElse`.
  ///
  /// It is equivalent to doing:
  /// ```dart
  /// switch (sealedClass) {
  ///   case final Subclass value:
  ///     return ...;
  ///   case _:
  ///     return orElse();
  /// }
  /// ```

  @optionalTypeArgs
  TResult maybeMap<TResult extends Object?>(
    TResult Function(_DiscipleStepDto value)? $default, {
    required TResult orElse(),
  }) {
    final _that = this;
    switch (_that) {
      case _DiscipleStepDto() when $default != null:
        return $default(_that);
      case _:
        return orElse();
    }
  }

  /// A `switch`-like method, using callbacks.
  ///
  /// Callbacks receives the raw object, upcasted.
  /// It is equivalent to doing:
  /// ```dart
  /// switch (sealedClass) {
  ///   case final Subclass value:
  ///     return ...;
  ///   case final Subclass2 value:
  ///     return ...;
  /// }
  /// ```

  @optionalTypeArgs
  TResult map<TResult extends Object?>(
    TResult Function(_DiscipleStepDto value) $default,
  ) {
    final _that = this;
    switch (_that) {
      case _DiscipleStepDto():
        return $default(_that);
      case _:
        throw StateError('Unexpected subclass');
    }
  }

  /// A variant of `map` that fallback to returning `null`.
  ///
  /// It is equivalent to doing:
  /// ```dart
  /// switch (sealedClass) {
  ///   case final Subclass value:
  ///     return ...;
  ///   case _:
  ///     return null;
  /// }
  /// ```

  @optionalTypeArgs
  TResult? mapOrNull<TResult extends Object?>(
    TResult? Function(_DiscipleStepDto value)? $default,
  ) {
    final _that = this;
    switch (_that) {
      case _DiscipleStepDto() when $default != null:
        return $default(_that);
      case _:
        return null;
    }
  }

  /// A variant of `when` that fallback to an `orElse` callback.
  ///
  /// It is equivalent to doing:
  /// ```dart
  /// switch (sealedClass) {
  ///   case Subclass(:final field):
  ///     return ...;
  ///   case _:
  ///     return orElse();
  /// }
  /// ```

  @optionalTypeArgs
  TResult maybeWhen<TResult extends Object?>(
    TResult Function(
            int id,
            String? name,
            String? description,
            int stepCategory,
            bool requiresCycle,
            bool requiresAdminApproval,
            List<int>? requirementIds,
            int? parentStepId,
            List<DiscipleStepDto>? subSteps)?
        $default, {
    required TResult orElse(),
  }) {
    final _that = this;
    switch (_that) {
      case _DiscipleStepDto() when $default != null:
        return $default(
            _that.id,
            _that.name,
            _that.description,
            _that.stepCategory,
            _that.requiresCycle,
            _that.requiresAdminApproval,
            _that.requirementIds,
            _that.parentStepId,
            _that.subSteps);
      case _:
        return orElse();
    }
  }

  /// A `switch`-like method, using callbacks.
  ///
  /// As opposed to `map`, this offers destructuring.
  /// It is equivalent to doing:
  /// ```dart
  /// switch (sealedClass) {
  ///   case Subclass(:final field):
  ///     return ...;
  ///   case Subclass2(:final field2):
  ///     return ...;
  /// }
  /// ```

  @optionalTypeArgs
  TResult when<TResult extends Object?>(
    TResult Function(
            int id,
            String? name,
            String? description,
            int stepCategory,
            bool requiresCycle,
            bool requiresAdminApproval,
            List<int>? requirementIds,
            int? parentStepId,
            List<DiscipleStepDto>? subSteps)
        $default,
  ) {
    final _that = this;
    switch (_that) {
      case _DiscipleStepDto():
        return $default(
            _that.id,
            _that.name,
            _that.description,
            _that.stepCategory,
            _that.requiresCycle,
            _that.requiresAdminApproval,
            _that.requirementIds,
            _that.parentStepId,
            _that.subSteps);
      case _:
        throw StateError('Unexpected subclass');
    }
  }

  /// A variant of `when` that fallback to returning `null`
  ///
  /// It is equivalent to doing:
  /// ```dart
  /// switch (sealedClass) {
  ///   case Subclass(:final field):
  ///     return ...;
  ///   case _:
  ///     return null;
  /// }
  /// ```

  @optionalTypeArgs
  TResult? whenOrNull<TResult extends Object?>(
    TResult? Function(
            int id,
            String? name,
            String? description,
            int stepCategory,
            bool requiresCycle,
            bool requiresAdminApproval,
            List<int>? requirementIds,
            int? parentStepId,
            List<DiscipleStepDto>? subSteps)?
        $default,
  ) {
    final _that = this;
    switch (_that) {
      case _DiscipleStepDto() when $default != null:
        return $default(
            _that.id,
            _that.name,
            _that.description,
            _that.stepCategory,
            _that.requiresCycle,
            _that.requiresAdminApproval,
            _that.requirementIds,
            _that.parentStepId,
            _that.subSteps);
      case _:
        return null;
    }
  }
}

/// @nodoc
@JsonSerializable()
class _DiscipleStepDto implements DiscipleStepDto {
  const _DiscipleStepDto(
      {required this.id,
      this.name,
      this.description,
      required this.stepCategory,
      required this.requiresCycle,
      required this.requiresAdminApproval,
      final List<int>? requirementIds,
      this.parentStepId,
      final List<DiscipleStepDto>? subSteps})
      : _requirementIds = requirementIds,
        _subSteps = subSteps;
  factory _DiscipleStepDto.fromJson(Map<String, dynamic> json) =>
      _$DiscipleStepDtoFromJson(json);

  @override
  final int id;
  @override
  final String? name;
  @override
  final String? description;
  @override
  final int stepCategory;
  @override
  final bool requiresCycle;
  @override
  final bool requiresAdminApproval;
  final List<int>? _requirementIds;
  @override
  List<int>? get requirementIds {
    final value = _requirementIds;
    if (value == null) return null;
    if (_requirementIds is EqualUnmodifiableListView) return _requirementIds;
    // ignore: implicit_dynamic_type
    return EqualUnmodifiableListView(value);
  }

  @override
  final int? parentStepId;
  final List<DiscipleStepDto>? _subSteps;
  @override
  List<DiscipleStepDto>? get subSteps {
    final value = _subSteps;
    if (value == null) return null;
    if (_subSteps is EqualUnmodifiableListView) return _subSteps;
    // ignore: implicit_dynamic_type
    return EqualUnmodifiableListView(value);
  }

  /// Create a copy of DiscipleStepDto
  /// with the given fields replaced by the non-null parameter values.
  @override
  @JsonKey(includeFromJson: false, includeToJson: false)
  @pragma('vm:prefer-inline')
  _$DiscipleStepDtoCopyWith<_DiscipleStepDto> get copyWith =>
      __$DiscipleStepDtoCopyWithImpl<_DiscipleStepDto>(this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$DiscipleStepDtoToJson(
      this,
    );
  }

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _DiscipleStepDto &&
            (identical(other.id, id) || other.id == id) &&
            (identical(other.name, name) || other.name == name) &&
            (identical(other.description, description) ||
                other.description == description) &&
            (identical(other.stepCategory, stepCategory) ||
                other.stepCategory == stepCategory) &&
            (identical(other.requiresCycle, requiresCycle) ||
                other.requiresCycle == requiresCycle) &&
            (identical(other.requiresAdminApproval, requiresAdminApproval) ||
                other.requiresAdminApproval == requiresAdminApproval) &&
            const DeepCollectionEquality()
                .equals(other._requirementIds, _requirementIds) &&
            (identical(other.parentStepId, parentStepId) ||
                other.parentStepId == parentStepId) &&
            const DeepCollectionEquality().equals(other._subSteps, _subSteps));
  }

  @JsonKey(includeFromJson: false, includeToJson: false)
  @override
  int get hashCode => Object.hash(
      runtimeType,
      id,
      name,
      description,
      stepCategory,
      requiresCycle,
      requiresAdminApproval,
      const DeepCollectionEquality().hash(_requirementIds),
      parentStepId,
      const DeepCollectionEquality().hash(_subSteps));

  @override
  String toString() {
    return 'DiscipleStepDto(id: $id, name: $name, description: $description, stepCategory: $stepCategory, requiresCycle: $requiresCycle, requiresAdminApproval: $requiresAdminApproval, requirementIds: $requirementIds, parentStepId: $parentStepId, subSteps: $subSteps)';
  }
}

/// @nodoc
abstract mixin class _$DiscipleStepDtoCopyWith<$Res>
    implements $DiscipleStepDtoCopyWith<$Res> {
  factory _$DiscipleStepDtoCopyWith(
          _DiscipleStepDto value, $Res Function(_DiscipleStepDto) _then) =
      __$DiscipleStepDtoCopyWithImpl;
  @override
  @useResult
  $Res call(
      {int id,
      String? name,
      String? description,
      int stepCategory,
      bool requiresCycle,
      bool requiresAdminApproval,
      List<int>? requirementIds,
      int? parentStepId,
      List<DiscipleStepDto>? subSteps});
}

/// @nodoc
class __$DiscipleStepDtoCopyWithImpl<$Res>
    implements _$DiscipleStepDtoCopyWith<$Res> {
  __$DiscipleStepDtoCopyWithImpl(this._self, this._then);

  final _DiscipleStepDto _self;
  final $Res Function(_DiscipleStepDto) _then;

  /// Create a copy of DiscipleStepDto
  /// with the given fields replaced by the non-null parameter values.
  @override
  @pragma('vm:prefer-inline')
  $Res call({
    Object? id = null,
    Object? name = freezed,
    Object? description = freezed,
    Object? stepCategory = null,
    Object? requiresCycle = null,
    Object? requiresAdminApproval = null,
    Object? requirementIds = freezed,
    Object? parentStepId = freezed,
    Object? subSteps = freezed,
  }) {
    return _then(_DiscipleStepDto(
      id: null == id
          ? _self.id
          : id // ignore: cast_nullable_to_non_nullable
              as int,
      name: freezed == name
          ? _self.name
          : name // ignore: cast_nullable_to_non_nullable
              as String?,
      description: freezed == description
          ? _self.description
          : description // ignore: cast_nullable_to_non_nullable
              as String?,
      stepCategory: null == stepCategory
          ? _self.stepCategory
          : stepCategory // ignore: cast_nullable_to_non_nullable
              as int,
      requiresCycle: null == requiresCycle
          ? _self.requiresCycle
          : requiresCycle // ignore: cast_nullable_to_non_nullable
              as bool,
      requiresAdminApproval: null == requiresAdminApproval
          ? _self.requiresAdminApproval
          : requiresAdminApproval // ignore: cast_nullable_to_non_nullable
              as bool,
      requirementIds: freezed == requirementIds
          ? _self._requirementIds
          : requirementIds // ignore: cast_nullable_to_non_nullable
              as List<int>?,
      parentStepId: freezed == parentStepId
          ? _self.parentStepId
          : parentStepId // ignore: cast_nullable_to_non_nullable
              as int?,
      subSteps: freezed == subSteps
          ? _self._subSteps
          : subSteps // ignore: cast_nullable_to_non_nullable
              as List<DiscipleStepDto>?,
    ));
  }
}

// dart format on
