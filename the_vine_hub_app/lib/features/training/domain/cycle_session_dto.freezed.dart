// GENERATED CODE - DO NOT MODIFY BY HAND
// coverage:ignore-file
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'cycle_session_dto.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

// dart format off
T _$identity<T>(T value) => value;

/// @nodoc
mixin _$CycleSessionDto {
  int get id;
  int get stepCycleId;
  DateTime get date;
  String? get topic;

  /// Create a copy of CycleSessionDto
  /// with the given fields replaced by the non-null parameter values.
  @JsonKey(includeFromJson: false, includeToJson: false)
  @pragma('vm:prefer-inline')
  $CycleSessionDtoCopyWith<CycleSessionDto> get copyWith =>
      _$CycleSessionDtoCopyWithImpl<CycleSessionDto>(
          this as CycleSessionDto, _$identity);

  /// Serializes this CycleSessionDto to a JSON map.
  Map<String, dynamic> toJson();

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is CycleSessionDto &&
            (identical(other.id, id) || other.id == id) &&
            (identical(other.stepCycleId, stepCycleId) ||
                other.stepCycleId == stepCycleId) &&
            (identical(other.date, date) || other.date == date) &&
            (identical(other.topic, topic) || other.topic == topic));
  }

  @JsonKey(includeFromJson: false, includeToJson: false)
  @override
  int get hashCode => Object.hash(runtimeType, id, stepCycleId, date, topic);

  @override
  String toString() {
    return 'CycleSessionDto(id: $id, stepCycleId: $stepCycleId, date: $date, topic: $topic)';
  }
}

/// @nodoc
abstract mixin class $CycleSessionDtoCopyWith<$Res> {
  factory $CycleSessionDtoCopyWith(
          CycleSessionDto value, $Res Function(CycleSessionDto) _then) =
      _$CycleSessionDtoCopyWithImpl;
  @useResult
  $Res call({int id, int stepCycleId, DateTime date, String? topic});
}

/// @nodoc
class _$CycleSessionDtoCopyWithImpl<$Res>
    implements $CycleSessionDtoCopyWith<$Res> {
  _$CycleSessionDtoCopyWithImpl(this._self, this._then);

  final CycleSessionDto _self;
  final $Res Function(CycleSessionDto) _then;

  /// Create a copy of CycleSessionDto
  /// with the given fields replaced by the non-null parameter values.
  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? id = null,
    Object? stepCycleId = null,
    Object? date = null,
    Object? topic = freezed,
  }) {
    return _then(_self.copyWith(
      id: null == id
          ? _self.id
          : id // ignore: cast_nullable_to_non_nullable
              as int,
      stepCycleId: null == stepCycleId
          ? _self.stepCycleId
          : stepCycleId // ignore: cast_nullable_to_non_nullable
              as int,
      date: null == date
          ? _self.date
          : date // ignore: cast_nullable_to_non_nullable
              as DateTime,
      topic: freezed == topic
          ? _self.topic
          : topic // ignore: cast_nullable_to_non_nullable
              as String?,
    ));
  }
}

/// Adds pattern-matching-related methods to [CycleSessionDto].
extension CycleSessionDtoPatterns on CycleSessionDto {
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
    TResult Function(_CycleSessionDto value)? $default, {
    required TResult orElse(),
  }) {
    final _that = this;
    switch (_that) {
      case _CycleSessionDto() when $default != null:
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
    TResult Function(_CycleSessionDto value) $default,
  ) {
    final _that = this;
    switch (_that) {
      case _CycleSessionDto():
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
    TResult? Function(_CycleSessionDto value)? $default,
  ) {
    final _that = this;
    switch (_that) {
      case _CycleSessionDto() when $default != null:
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
    TResult Function(int id, int stepCycleId, DateTime date, String? topic)?
        $default, {
    required TResult orElse(),
  }) {
    final _that = this;
    switch (_that) {
      case _CycleSessionDto() when $default != null:
        return $default(_that.id, _that.stepCycleId, _that.date, _that.topic);
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
    TResult Function(int id, int stepCycleId, DateTime date, String? topic)
        $default,
  ) {
    final _that = this;
    switch (_that) {
      case _CycleSessionDto():
        return $default(_that.id, _that.stepCycleId, _that.date, _that.topic);
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
    TResult? Function(int id, int stepCycleId, DateTime date, String? topic)?
        $default,
  ) {
    final _that = this;
    switch (_that) {
      case _CycleSessionDto() when $default != null:
        return $default(_that.id, _that.stepCycleId, _that.date, _that.topic);
      case _:
        return null;
    }
  }
}

/// @nodoc
@JsonSerializable()
class _CycleSessionDto implements CycleSessionDto {
  const _CycleSessionDto(
      {required this.id,
      required this.stepCycleId,
      required this.date,
      this.topic});
  factory _CycleSessionDto.fromJson(Map<String, dynamic> json) =>
      _$CycleSessionDtoFromJson(json);

  @override
  final int id;
  @override
  final int stepCycleId;
  @override
  final DateTime date;
  @override
  final String? topic;

  /// Create a copy of CycleSessionDto
  /// with the given fields replaced by the non-null parameter values.
  @override
  @JsonKey(includeFromJson: false, includeToJson: false)
  @pragma('vm:prefer-inline')
  _$CycleSessionDtoCopyWith<_CycleSessionDto> get copyWith =>
      __$CycleSessionDtoCopyWithImpl<_CycleSessionDto>(this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$CycleSessionDtoToJson(
      this,
    );
  }

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _CycleSessionDto &&
            (identical(other.id, id) || other.id == id) &&
            (identical(other.stepCycleId, stepCycleId) ||
                other.stepCycleId == stepCycleId) &&
            (identical(other.date, date) || other.date == date) &&
            (identical(other.topic, topic) || other.topic == topic));
  }

  @JsonKey(includeFromJson: false, includeToJson: false)
  @override
  int get hashCode => Object.hash(runtimeType, id, stepCycleId, date, topic);

  @override
  String toString() {
    return 'CycleSessionDto(id: $id, stepCycleId: $stepCycleId, date: $date, topic: $topic)';
  }
}

/// @nodoc
abstract mixin class _$CycleSessionDtoCopyWith<$Res>
    implements $CycleSessionDtoCopyWith<$Res> {
  factory _$CycleSessionDtoCopyWith(
          _CycleSessionDto value, $Res Function(_CycleSessionDto) _then) =
      __$CycleSessionDtoCopyWithImpl;
  @override
  @useResult
  $Res call({int id, int stepCycleId, DateTime date, String? topic});
}

/// @nodoc
class __$CycleSessionDtoCopyWithImpl<$Res>
    implements _$CycleSessionDtoCopyWith<$Res> {
  __$CycleSessionDtoCopyWithImpl(this._self, this._then);

  final _CycleSessionDto _self;
  final $Res Function(_CycleSessionDto) _then;

  /// Create a copy of CycleSessionDto
  /// with the given fields replaced by the non-null parameter values.
  @override
  @pragma('vm:prefer-inline')
  $Res call({
    Object? id = null,
    Object? stepCycleId = null,
    Object? date = null,
    Object? topic = freezed,
  }) {
    return _then(_CycleSessionDto(
      id: null == id
          ? _self.id
          : id // ignore: cast_nullable_to_non_nullable
              as int,
      stepCycleId: null == stepCycleId
          ? _self.stepCycleId
          : stepCycleId // ignore: cast_nullable_to_non_nullable
              as int,
      date: null == date
          ? _self.date
          : date // ignore: cast_nullable_to_non_nullable
              as DateTime,
      topic: freezed == topic
          ? _self.topic
          : topic // ignore: cast_nullable_to_non_nullable
              as String?,
    ));
  }
}

// dart format on
