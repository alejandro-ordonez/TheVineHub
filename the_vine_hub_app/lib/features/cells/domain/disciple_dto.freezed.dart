// GENERATED CODE - DO NOT MODIFY BY HAND
// coverage:ignore-file
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'disciple_dto.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

// dart format off
T _$identity<T>(T value) => value;

/// @nodoc
mixin _$DiscipleDto {
  String? get id;
  String get fullName;
  String? get phone;
  int? get gender;
  String? get photoPath;
  DateTime get memberSince;
  String? get cellId;
  String? get discipleStep;

  /// Create a copy of DiscipleDto
  /// with the given fields replaced by the non-null parameter values.
  @JsonKey(includeFromJson: false, includeToJson: false)
  @pragma('vm:prefer-inline')
  $DiscipleDtoCopyWith<DiscipleDto> get copyWith =>
      _$DiscipleDtoCopyWithImpl<DiscipleDto>(this as DiscipleDto, _$identity);

  /// Serializes this DiscipleDto to a JSON map.
  Map<String, dynamic> toJson();

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is DiscipleDto &&
            (identical(other.id, id) || other.id == id) &&
            (identical(other.fullName, fullName) ||
                other.fullName == fullName) &&
            (identical(other.phone, phone) || other.phone == phone) &&
            (identical(other.gender, gender) || other.gender == gender) &&
            (identical(other.photoPath, photoPath) ||
                other.photoPath == photoPath) &&
            (identical(other.memberSince, memberSince) ||
                other.memberSince == memberSince) &&
            (identical(other.cellId, cellId) || other.cellId == cellId) &&
            (identical(other.discipleStep, discipleStep) ||
                other.discipleStep == discipleStep));
  }

  @JsonKey(includeFromJson: false, includeToJson: false)
  @override
  int get hashCode => Object.hash(runtimeType, id, fullName, phone, gender,
      photoPath, memberSince, cellId, discipleStep);

  @override
  String toString() {
    return 'DiscipleDto(id: $id, fullName: $fullName, phone: $phone, gender: $gender, photoPath: $photoPath, memberSince: $memberSince, cellId: $cellId, discipleStep: $discipleStep)';
  }
}

/// @nodoc
abstract mixin class $DiscipleDtoCopyWith<$Res> {
  factory $DiscipleDtoCopyWith(
          DiscipleDto value, $Res Function(DiscipleDto) _then) =
      _$DiscipleDtoCopyWithImpl;
  @useResult
  $Res call(
      {String? id,
      String fullName,
      String? phone,
      int? gender,
      String? photoPath,
      DateTime memberSince,
      String? cellId,
      String? discipleStep});
}

/// @nodoc
class _$DiscipleDtoCopyWithImpl<$Res> implements $DiscipleDtoCopyWith<$Res> {
  _$DiscipleDtoCopyWithImpl(this._self, this._then);

  final DiscipleDto _self;
  final $Res Function(DiscipleDto) _then;

  /// Create a copy of DiscipleDto
  /// with the given fields replaced by the non-null parameter values.
  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? id = freezed,
    Object? fullName = null,
    Object? phone = freezed,
    Object? gender = freezed,
    Object? photoPath = freezed,
    Object? memberSince = null,
    Object? cellId = freezed,
    Object? discipleStep = freezed,
  }) {
    return _then(_self.copyWith(
      id: freezed == id
          ? _self.id
          : id // ignore: cast_nullable_to_non_nullable
              as String?,
      fullName: null == fullName
          ? _self.fullName
          : fullName // ignore: cast_nullable_to_non_nullable
              as String,
      phone: freezed == phone
          ? _self.phone
          : phone // ignore: cast_nullable_to_non_nullable
              as String?,
      gender: freezed == gender
          ? _self.gender
          : gender // ignore: cast_nullable_to_non_nullable
              as int?,
      photoPath: freezed == photoPath
          ? _self.photoPath
          : photoPath // ignore: cast_nullable_to_non_nullable
              as String?,
      memberSince: null == memberSince
          ? _self.memberSince
          : memberSince // ignore: cast_nullable_to_non_nullable
              as DateTime,
      cellId: freezed == cellId
          ? _self.cellId
          : cellId // ignore: cast_nullable_to_non_nullable
              as String?,
      discipleStep: freezed == discipleStep
          ? _self.discipleStep
          : discipleStep // ignore: cast_nullable_to_non_nullable
              as String?,
    ));
  }
}

/// Adds pattern-matching-related methods to [DiscipleDto].
extension DiscipleDtoPatterns on DiscipleDto {
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
    TResult Function(_DiscipleDto value)? $default, {
    required TResult orElse(),
  }) {
    final _that = this;
    switch (_that) {
      case _DiscipleDto() when $default != null:
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
    TResult Function(_DiscipleDto value) $default,
  ) {
    final _that = this;
    switch (_that) {
      case _DiscipleDto():
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
    TResult? Function(_DiscipleDto value)? $default,
  ) {
    final _that = this;
    switch (_that) {
      case _DiscipleDto() when $default != null:
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
            String? id,
            String fullName,
            String? phone,
            int? gender,
            String? photoPath,
            DateTime memberSince,
            String? cellId,
            String? discipleStep)?
        $default, {
    required TResult orElse(),
  }) {
    final _that = this;
    switch (_that) {
      case _DiscipleDto() when $default != null:
        return $default(
            _that.id,
            _that.fullName,
            _that.phone,
            _that.gender,
            _that.photoPath,
            _that.memberSince,
            _that.cellId,
            _that.discipleStep);
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
            String? id,
            String fullName,
            String? phone,
            int? gender,
            String? photoPath,
            DateTime memberSince,
            String? cellId,
            String? discipleStep)
        $default,
  ) {
    final _that = this;
    switch (_that) {
      case _DiscipleDto():
        return $default(
            _that.id,
            _that.fullName,
            _that.phone,
            _that.gender,
            _that.photoPath,
            _that.memberSince,
            _that.cellId,
            _that.discipleStep);
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
            String? id,
            String fullName,
            String? phone,
            int? gender,
            String? photoPath,
            DateTime memberSince,
            String? cellId,
            String? discipleStep)?
        $default,
  ) {
    final _that = this;
    switch (_that) {
      case _DiscipleDto() when $default != null:
        return $default(
            _that.id,
            _that.fullName,
            _that.phone,
            _that.gender,
            _that.photoPath,
            _that.memberSince,
            _that.cellId,
            _that.discipleStep);
      case _:
        return null;
    }
  }
}

/// @nodoc
@JsonSerializable()
class _DiscipleDto implements DiscipleDto {
  const _DiscipleDto(
      {this.id,
      required this.fullName,
      this.phone,
      this.gender,
      this.photoPath,
      required this.memberSince,
      this.cellId,
      this.discipleStep});
  factory _DiscipleDto.fromJson(Map<String, dynamic> json) =>
      _$DiscipleDtoFromJson(json);

  @override
  final String? id;
  @override
  final String fullName;
  @override
  final String? phone;
  @override
  final int? gender;
  @override
  final String? photoPath;
  @override
  final DateTime memberSince;
  @override
  final String? cellId;
  @override
  final String? discipleStep;

  /// Create a copy of DiscipleDto
  /// with the given fields replaced by the non-null parameter values.
  @override
  @JsonKey(includeFromJson: false, includeToJson: false)
  @pragma('vm:prefer-inline')
  _$DiscipleDtoCopyWith<_DiscipleDto> get copyWith =>
      __$DiscipleDtoCopyWithImpl<_DiscipleDto>(this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$DiscipleDtoToJson(
      this,
    );
  }

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _DiscipleDto &&
            (identical(other.id, id) || other.id == id) &&
            (identical(other.fullName, fullName) ||
                other.fullName == fullName) &&
            (identical(other.phone, phone) || other.phone == phone) &&
            (identical(other.gender, gender) || other.gender == gender) &&
            (identical(other.photoPath, photoPath) ||
                other.photoPath == photoPath) &&
            (identical(other.memberSince, memberSince) ||
                other.memberSince == memberSince) &&
            (identical(other.cellId, cellId) || other.cellId == cellId) &&
            (identical(other.discipleStep, discipleStep) ||
                other.discipleStep == discipleStep));
  }

  @JsonKey(includeFromJson: false, includeToJson: false)
  @override
  int get hashCode => Object.hash(runtimeType, id, fullName, phone, gender,
      photoPath, memberSince, cellId, discipleStep);

  @override
  String toString() {
    return 'DiscipleDto(id: $id, fullName: $fullName, phone: $phone, gender: $gender, photoPath: $photoPath, memberSince: $memberSince, cellId: $cellId, discipleStep: $discipleStep)';
  }
}

/// @nodoc
abstract mixin class _$DiscipleDtoCopyWith<$Res>
    implements $DiscipleDtoCopyWith<$Res> {
  factory _$DiscipleDtoCopyWith(
          _DiscipleDto value, $Res Function(_DiscipleDto) _then) =
      __$DiscipleDtoCopyWithImpl;
  @override
  @useResult
  $Res call(
      {String? id,
      String fullName,
      String? phone,
      int? gender,
      String? photoPath,
      DateTime memberSince,
      String? cellId,
      String? discipleStep});
}

/// @nodoc
class __$DiscipleDtoCopyWithImpl<$Res> implements _$DiscipleDtoCopyWith<$Res> {
  __$DiscipleDtoCopyWithImpl(this._self, this._then);

  final _DiscipleDto _self;
  final $Res Function(_DiscipleDto) _then;

  /// Create a copy of DiscipleDto
  /// with the given fields replaced by the non-null parameter values.
  @override
  @pragma('vm:prefer-inline')
  $Res call({
    Object? id = freezed,
    Object? fullName = null,
    Object? phone = freezed,
    Object? gender = freezed,
    Object? photoPath = freezed,
    Object? memberSince = null,
    Object? cellId = freezed,
    Object? discipleStep = freezed,
  }) {
    return _then(_DiscipleDto(
      id: freezed == id
          ? _self.id
          : id // ignore: cast_nullable_to_non_nullable
              as String?,
      fullName: null == fullName
          ? _self.fullName
          : fullName // ignore: cast_nullable_to_non_nullable
              as String,
      phone: freezed == phone
          ? _self.phone
          : phone // ignore: cast_nullable_to_non_nullable
              as String?,
      gender: freezed == gender
          ? _self.gender
          : gender // ignore: cast_nullable_to_non_nullable
              as int?,
      photoPath: freezed == photoPath
          ? _self.photoPath
          : photoPath // ignore: cast_nullable_to_non_nullable
              as String?,
      memberSince: null == memberSince
          ? _self.memberSince
          : memberSince // ignore: cast_nullable_to_non_nullable
              as DateTime,
      cellId: freezed == cellId
          ? _self.cellId
          : cellId // ignore: cast_nullable_to_non_nullable
              as String?,
      discipleStep: freezed == discipleStep
          ? _self.discipleStep
          : discipleStep // ignore: cast_nullable_to_non_nullable
              as String?,
    ));
  }
}

// dart format on
