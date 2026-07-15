// GENERATED CODE - DO NOT MODIFY BY HAND
// coverage:ignore-file
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'update_cell_attendance_dto.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

// dart format off
T _$identity<T>(T value) => value;

/// @nodoc
mixin _$UpdateCellAttendanceDto {
  List<String>? get disciples;
  String? get notes;
  DateTime get date;

  /// Create a copy of UpdateCellAttendanceDto
  /// with the given fields replaced by the non-null parameter values.
  @JsonKey(includeFromJson: false, includeToJson: false)
  @pragma('vm:prefer-inline')
  $UpdateCellAttendanceDtoCopyWith<UpdateCellAttendanceDto> get copyWith =>
      _$UpdateCellAttendanceDtoCopyWithImpl<UpdateCellAttendanceDto>(
          this as UpdateCellAttendanceDto, _$identity);

  /// Serializes this UpdateCellAttendanceDto to a JSON map.
  Map<String, dynamic> toJson();

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is UpdateCellAttendanceDto &&
            const DeepCollectionEquality().equals(other.disciples, disciples) &&
            (identical(other.notes, notes) || other.notes == notes) &&
            (identical(other.date, date) || other.date == date));
  }

  @JsonKey(includeFromJson: false, includeToJson: false)
  @override
  int get hashCode => Object.hash(
      runtimeType, const DeepCollectionEquality().hash(disciples), notes, date);

  @override
  String toString() {
    return 'UpdateCellAttendanceDto(disciples: $disciples, notes: $notes, date: $date)';
  }
}

/// @nodoc
abstract mixin class $UpdateCellAttendanceDtoCopyWith<$Res> {
  factory $UpdateCellAttendanceDtoCopyWith(UpdateCellAttendanceDto value,
          $Res Function(UpdateCellAttendanceDto) _then) =
      _$UpdateCellAttendanceDtoCopyWithImpl;
  @useResult
  $Res call({List<String>? disciples, String? notes, DateTime date});
}

/// @nodoc
class _$UpdateCellAttendanceDtoCopyWithImpl<$Res>
    implements $UpdateCellAttendanceDtoCopyWith<$Res> {
  _$UpdateCellAttendanceDtoCopyWithImpl(this._self, this._then);

  final UpdateCellAttendanceDto _self;
  final $Res Function(UpdateCellAttendanceDto) _then;

  /// Create a copy of UpdateCellAttendanceDto
  /// with the given fields replaced by the non-null parameter values.
  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? disciples = freezed,
    Object? notes = freezed,
    Object? date = null,
  }) {
    return _then(_self.copyWith(
      disciples: freezed == disciples
          ? _self.disciples
          : disciples // ignore: cast_nullable_to_non_nullable
              as List<String>?,
      notes: freezed == notes
          ? _self.notes
          : notes // ignore: cast_nullable_to_non_nullable
              as String?,
      date: null == date
          ? _self.date
          : date // ignore: cast_nullable_to_non_nullable
              as DateTime,
    ));
  }
}

/// Adds pattern-matching-related methods to [UpdateCellAttendanceDto].
extension UpdateCellAttendanceDtoPatterns on UpdateCellAttendanceDto {
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
    TResult Function(_UpdateCellAttendanceDto value)? $default, {
    required TResult orElse(),
  }) {
    final _that = this;
    switch (_that) {
      case _UpdateCellAttendanceDto() when $default != null:
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
    TResult Function(_UpdateCellAttendanceDto value) $default,
  ) {
    final _that = this;
    switch (_that) {
      case _UpdateCellAttendanceDto():
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
    TResult? Function(_UpdateCellAttendanceDto value)? $default,
  ) {
    final _that = this;
    switch (_that) {
      case _UpdateCellAttendanceDto() when $default != null:
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
    TResult Function(List<String>? disciples, String? notes, DateTime date)?
        $default, {
    required TResult orElse(),
  }) {
    final _that = this;
    switch (_that) {
      case _UpdateCellAttendanceDto() when $default != null:
        return $default(_that.disciples, _that.notes, _that.date);
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
    TResult Function(List<String>? disciples, String? notes, DateTime date)
        $default,
  ) {
    final _that = this;
    switch (_that) {
      case _UpdateCellAttendanceDto():
        return $default(_that.disciples, _that.notes, _that.date);
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
    TResult? Function(List<String>? disciples, String? notes, DateTime date)?
        $default,
  ) {
    final _that = this;
    switch (_that) {
      case _UpdateCellAttendanceDto() when $default != null:
        return $default(_that.disciples, _that.notes, _that.date);
      case _:
        return null;
    }
  }
}

/// @nodoc
@JsonSerializable()
class _UpdateCellAttendanceDto implements UpdateCellAttendanceDto {
  const _UpdateCellAttendanceDto(
      {final List<String>? disciples, this.notes, required this.date})
      : _disciples = disciples;
  factory _UpdateCellAttendanceDto.fromJson(Map<String, dynamic> json) =>
      _$UpdateCellAttendanceDtoFromJson(json);

  final List<String>? _disciples;
  @override
  List<String>? get disciples {
    final value = _disciples;
    if (value == null) return null;
    if (_disciples is EqualUnmodifiableListView) return _disciples;
    // ignore: implicit_dynamic_type
    return EqualUnmodifiableListView(value);
  }

  @override
  final String? notes;
  @override
  final DateTime date;

  /// Create a copy of UpdateCellAttendanceDto
  /// with the given fields replaced by the non-null parameter values.
  @override
  @JsonKey(includeFromJson: false, includeToJson: false)
  @pragma('vm:prefer-inline')
  _$UpdateCellAttendanceDtoCopyWith<_UpdateCellAttendanceDto> get copyWith =>
      __$UpdateCellAttendanceDtoCopyWithImpl<_UpdateCellAttendanceDto>(
          this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$UpdateCellAttendanceDtoToJson(
      this,
    );
  }

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _UpdateCellAttendanceDto &&
            const DeepCollectionEquality()
                .equals(other._disciples, _disciples) &&
            (identical(other.notes, notes) || other.notes == notes) &&
            (identical(other.date, date) || other.date == date));
  }

  @JsonKey(includeFromJson: false, includeToJson: false)
  @override
  int get hashCode => Object.hash(runtimeType,
      const DeepCollectionEquality().hash(_disciples), notes, date);

  @override
  String toString() {
    return 'UpdateCellAttendanceDto(disciples: $disciples, notes: $notes, date: $date)';
  }
}

/// @nodoc
abstract mixin class _$UpdateCellAttendanceDtoCopyWith<$Res>
    implements $UpdateCellAttendanceDtoCopyWith<$Res> {
  factory _$UpdateCellAttendanceDtoCopyWith(_UpdateCellAttendanceDto value,
          $Res Function(_UpdateCellAttendanceDto) _then) =
      __$UpdateCellAttendanceDtoCopyWithImpl;
  @override
  @useResult
  $Res call({List<String>? disciples, String? notes, DateTime date});
}

/// @nodoc
class __$UpdateCellAttendanceDtoCopyWithImpl<$Res>
    implements _$UpdateCellAttendanceDtoCopyWith<$Res> {
  __$UpdateCellAttendanceDtoCopyWithImpl(this._self, this._then);

  final _UpdateCellAttendanceDto _self;
  final $Res Function(_UpdateCellAttendanceDto) _then;

  /// Create a copy of UpdateCellAttendanceDto
  /// with the given fields replaced by the non-null parameter values.
  @override
  @pragma('vm:prefer-inline')
  $Res call({
    Object? disciples = freezed,
    Object? notes = freezed,
    Object? date = null,
  }) {
    return _then(_UpdateCellAttendanceDto(
      disciples: freezed == disciples
          ? _self._disciples
          : disciples // ignore: cast_nullable_to_non_nullable
              as List<String>?,
      notes: freezed == notes
          ? _self.notes
          : notes // ignore: cast_nullable_to_non_nullable
              as String?,
      date: null == date
          ? _self.date
          : date // ignore: cast_nullable_to_non_nullable
              as DateTime,
    ));
  }
}

// dart format on
