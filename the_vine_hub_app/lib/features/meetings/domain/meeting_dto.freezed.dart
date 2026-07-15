// GENERATED CODE - DO NOT MODIFY BY HAND
// coverage:ignore-file
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'meeting_dto.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

// dart format off
T _$identity<T>(T value) => value;

/// @nodoc
mixin _$MeetingDto {
  String? get name;
  String get start; // time format
  String get end; // time format
  int get meetingTypes;
  bool get isRecurrent;
  int? get dayOfWeek;
  DateTime? get date;
  int get meetingId;

  /// Create a copy of MeetingDto
  /// with the given fields replaced by the non-null parameter values.
  @JsonKey(includeFromJson: false, includeToJson: false)
  @pragma('vm:prefer-inline')
  $MeetingDtoCopyWith<MeetingDto> get copyWith =>
      _$MeetingDtoCopyWithImpl<MeetingDto>(this as MeetingDto, _$identity);

  /// Serializes this MeetingDto to a JSON map.
  Map<String, dynamic> toJson();

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is MeetingDto &&
            (identical(other.name, name) || other.name == name) &&
            (identical(other.start, start) || other.start == start) &&
            (identical(other.end, end) || other.end == end) &&
            (identical(other.meetingTypes, meetingTypes) ||
                other.meetingTypes == meetingTypes) &&
            (identical(other.isRecurrent, isRecurrent) ||
                other.isRecurrent == isRecurrent) &&
            (identical(other.dayOfWeek, dayOfWeek) ||
                other.dayOfWeek == dayOfWeek) &&
            (identical(other.date, date) || other.date == date) &&
            (identical(other.meetingId, meetingId) ||
                other.meetingId == meetingId));
  }

  @JsonKey(includeFromJson: false, includeToJson: false)
  @override
  int get hashCode => Object.hash(runtimeType, name, start, end, meetingTypes,
      isRecurrent, dayOfWeek, date, meetingId);

  @override
  String toString() {
    return 'MeetingDto(name: $name, start: $start, end: $end, meetingTypes: $meetingTypes, isRecurrent: $isRecurrent, dayOfWeek: $dayOfWeek, date: $date, meetingId: $meetingId)';
  }
}

/// @nodoc
abstract mixin class $MeetingDtoCopyWith<$Res> {
  factory $MeetingDtoCopyWith(
          MeetingDto value, $Res Function(MeetingDto) _then) =
      _$MeetingDtoCopyWithImpl;
  @useResult
  $Res call(
      {String? name,
      String start,
      String end,
      int meetingTypes,
      bool isRecurrent,
      int? dayOfWeek,
      DateTime? date,
      int meetingId});
}

/// @nodoc
class _$MeetingDtoCopyWithImpl<$Res> implements $MeetingDtoCopyWith<$Res> {
  _$MeetingDtoCopyWithImpl(this._self, this._then);

  final MeetingDto _self;
  final $Res Function(MeetingDto) _then;

  /// Create a copy of MeetingDto
  /// with the given fields replaced by the non-null parameter values.
  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? name = freezed,
    Object? start = null,
    Object? end = null,
    Object? meetingTypes = null,
    Object? isRecurrent = null,
    Object? dayOfWeek = freezed,
    Object? date = freezed,
    Object? meetingId = null,
  }) {
    return _then(_self.copyWith(
      name: freezed == name
          ? _self.name
          : name // ignore: cast_nullable_to_non_nullable
              as String?,
      start: null == start
          ? _self.start
          : start // ignore: cast_nullable_to_non_nullable
              as String,
      end: null == end
          ? _self.end
          : end // ignore: cast_nullable_to_non_nullable
              as String,
      meetingTypes: null == meetingTypes
          ? _self.meetingTypes
          : meetingTypes // ignore: cast_nullable_to_non_nullable
              as int,
      isRecurrent: null == isRecurrent
          ? _self.isRecurrent
          : isRecurrent // ignore: cast_nullable_to_non_nullable
              as bool,
      dayOfWeek: freezed == dayOfWeek
          ? _self.dayOfWeek
          : dayOfWeek // ignore: cast_nullable_to_non_nullable
              as int?,
      date: freezed == date
          ? _self.date
          : date // ignore: cast_nullable_to_non_nullable
              as DateTime?,
      meetingId: null == meetingId
          ? _self.meetingId
          : meetingId // ignore: cast_nullable_to_non_nullable
              as int,
    ));
  }
}

/// Adds pattern-matching-related methods to [MeetingDto].
extension MeetingDtoPatterns on MeetingDto {
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
    TResult Function(_MeetingDto value)? $default, {
    required TResult orElse(),
  }) {
    final _that = this;
    switch (_that) {
      case _MeetingDto() when $default != null:
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
    TResult Function(_MeetingDto value) $default,
  ) {
    final _that = this;
    switch (_that) {
      case _MeetingDto():
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
    TResult? Function(_MeetingDto value)? $default,
  ) {
    final _that = this;
    switch (_that) {
      case _MeetingDto() when $default != null:
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
    TResult Function(String? name, String start, String end, int meetingTypes,
            bool isRecurrent, int? dayOfWeek, DateTime? date, int meetingId)?
        $default, {
    required TResult orElse(),
  }) {
    final _that = this;
    switch (_that) {
      case _MeetingDto() when $default != null:
        return $default(_that.name, _that.start, _that.end, _that.meetingTypes,
            _that.isRecurrent, _that.dayOfWeek, _that.date, _that.meetingId);
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
    TResult Function(String? name, String start, String end, int meetingTypes,
            bool isRecurrent, int? dayOfWeek, DateTime? date, int meetingId)
        $default,
  ) {
    final _that = this;
    switch (_that) {
      case _MeetingDto():
        return $default(_that.name, _that.start, _that.end, _that.meetingTypes,
            _that.isRecurrent, _that.dayOfWeek, _that.date, _that.meetingId);
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
    TResult? Function(String? name, String start, String end, int meetingTypes,
            bool isRecurrent, int? dayOfWeek, DateTime? date, int meetingId)?
        $default,
  ) {
    final _that = this;
    switch (_that) {
      case _MeetingDto() when $default != null:
        return $default(_that.name, _that.start, _that.end, _that.meetingTypes,
            _that.isRecurrent, _that.dayOfWeek, _that.date, _that.meetingId);
      case _:
        return null;
    }
  }
}

/// @nodoc
@JsonSerializable()
class _MeetingDto implements MeetingDto {
  const _MeetingDto(
      {this.name,
      required this.start,
      required this.end,
      required this.meetingTypes,
      required this.isRecurrent,
      this.dayOfWeek,
      this.date,
      required this.meetingId});
  factory _MeetingDto.fromJson(Map<String, dynamic> json) =>
      _$MeetingDtoFromJson(json);

  @override
  final String? name;
  @override
  final String start;
// time format
  @override
  final String end;
// time format
  @override
  final int meetingTypes;
  @override
  final bool isRecurrent;
  @override
  final int? dayOfWeek;
  @override
  final DateTime? date;
  @override
  final int meetingId;

  /// Create a copy of MeetingDto
  /// with the given fields replaced by the non-null parameter values.
  @override
  @JsonKey(includeFromJson: false, includeToJson: false)
  @pragma('vm:prefer-inline')
  _$MeetingDtoCopyWith<_MeetingDto> get copyWith =>
      __$MeetingDtoCopyWithImpl<_MeetingDto>(this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$MeetingDtoToJson(
      this,
    );
  }

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _MeetingDto &&
            (identical(other.name, name) || other.name == name) &&
            (identical(other.start, start) || other.start == start) &&
            (identical(other.end, end) || other.end == end) &&
            (identical(other.meetingTypes, meetingTypes) ||
                other.meetingTypes == meetingTypes) &&
            (identical(other.isRecurrent, isRecurrent) ||
                other.isRecurrent == isRecurrent) &&
            (identical(other.dayOfWeek, dayOfWeek) ||
                other.dayOfWeek == dayOfWeek) &&
            (identical(other.date, date) || other.date == date) &&
            (identical(other.meetingId, meetingId) ||
                other.meetingId == meetingId));
  }

  @JsonKey(includeFromJson: false, includeToJson: false)
  @override
  int get hashCode => Object.hash(runtimeType, name, start, end, meetingTypes,
      isRecurrent, dayOfWeek, date, meetingId);

  @override
  String toString() {
    return 'MeetingDto(name: $name, start: $start, end: $end, meetingTypes: $meetingTypes, isRecurrent: $isRecurrent, dayOfWeek: $dayOfWeek, date: $date, meetingId: $meetingId)';
  }
}

/// @nodoc
abstract mixin class _$MeetingDtoCopyWith<$Res>
    implements $MeetingDtoCopyWith<$Res> {
  factory _$MeetingDtoCopyWith(
          _MeetingDto value, $Res Function(_MeetingDto) _then) =
      __$MeetingDtoCopyWithImpl;
  @override
  @useResult
  $Res call(
      {String? name,
      String start,
      String end,
      int meetingTypes,
      bool isRecurrent,
      int? dayOfWeek,
      DateTime? date,
      int meetingId});
}

/// @nodoc
class __$MeetingDtoCopyWithImpl<$Res> implements _$MeetingDtoCopyWith<$Res> {
  __$MeetingDtoCopyWithImpl(this._self, this._then);

  final _MeetingDto _self;
  final $Res Function(_MeetingDto) _then;

  /// Create a copy of MeetingDto
  /// with the given fields replaced by the non-null parameter values.
  @override
  @pragma('vm:prefer-inline')
  $Res call({
    Object? name = freezed,
    Object? start = null,
    Object? end = null,
    Object? meetingTypes = null,
    Object? isRecurrent = null,
    Object? dayOfWeek = freezed,
    Object? date = freezed,
    Object? meetingId = null,
  }) {
    return _then(_MeetingDto(
      name: freezed == name
          ? _self.name
          : name // ignore: cast_nullable_to_non_nullable
              as String?,
      start: null == start
          ? _self.start
          : start // ignore: cast_nullable_to_non_nullable
              as String,
      end: null == end
          ? _self.end
          : end // ignore: cast_nullable_to_non_nullable
              as String,
      meetingTypes: null == meetingTypes
          ? _self.meetingTypes
          : meetingTypes // ignore: cast_nullable_to_non_nullable
              as int,
      isRecurrent: null == isRecurrent
          ? _self.isRecurrent
          : isRecurrent // ignore: cast_nullable_to_non_nullable
              as bool,
      dayOfWeek: freezed == dayOfWeek
          ? _self.dayOfWeek
          : dayOfWeek // ignore: cast_nullable_to_non_nullable
              as int?,
      date: freezed == date
          ? _self.date
          : date // ignore: cast_nullable_to_non_nullable
              as DateTime?,
      meetingId: null == meetingId
          ? _self.meetingId
          : meetingId // ignore: cast_nullable_to_non_nullable
              as int,
    ));
  }
}

// dart format on
