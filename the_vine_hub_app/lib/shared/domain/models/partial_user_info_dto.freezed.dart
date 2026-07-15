// GENERATED CODE - DO NOT MODIFY BY HAND
// coverage:ignore-file
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'partial_user_info_dto.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

// dart format off
T _$identity<T>(T value) => value;

/// @nodoc
mixin _$PartialUserInfoDto {
  String? get document;
  String? get name;
  String? get lastName;
  String? get phone;
  int? get gender;
  int? get maritalStatus;
  String? get photo;
  int? get cellId;

  /// Create a copy of PartialUserInfoDto
  /// with the given fields replaced by the non-null parameter values.
  @JsonKey(includeFromJson: false, includeToJson: false)
  @pragma('vm:prefer-inline')
  $PartialUserInfoDtoCopyWith<PartialUserInfoDto> get copyWith =>
      _$PartialUserInfoDtoCopyWithImpl<PartialUserInfoDto>(
          this as PartialUserInfoDto, _$identity);

  /// Serializes this PartialUserInfoDto to a JSON map.
  Map<String, dynamic> toJson();

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is PartialUserInfoDto &&
            (identical(other.document, document) ||
                other.document == document) &&
            (identical(other.name, name) || other.name == name) &&
            (identical(other.lastName, lastName) ||
                other.lastName == lastName) &&
            (identical(other.phone, phone) || other.phone == phone) &&
            (identical(other.gender, gender) || other.gender == gender) &&
            (identical(other.maritalStatus, maritalStatus) ||
                other.maritalStatus == maritalStatus) &&
            (identical(other.photo, photo) || other.photo == photo) &&
            (identical(other.cellId, cellId) || other.cellId == cellId));
  }

  @JsonKey(includeFromJson: false, includeToJson: false)
  @override
  int get hashCode => Object.hash(runtimeType, document, name, lastName, phone,
      gender, maritalStatus, photo, cellId);

  @override
  String toString() {
    return 'PartialUserInfoDto(document: $document, name: $name, lastName: $lastName, phone: $phone, gender: $gender, maritalStatus: $maritalStatus, photo: $photo, cellId: $cellId)';
  }
}

/// @nodoc
abstract mixin class $PartialUserInfoDtoCopyWith<$Res> {
  factory $PartialUserInfoDtoCopyWith(
          PartialUserInfoDto value, $Res Function(PartialUserInfoDto) _then) =
      _$PartialUserInfoDtoCopyWithImpl;
  @useResult
  $Res call(
      {String? document,
      String? name,
      String? lastName,
      String? phone,
      int? gender,
      int? maritalStatus,
      String? photo,
      int? cellId});
}

/// @nodoc
class _$PartialUserInfoDtoCopyWithImpl<$Res>
    implements $PartialUserInfoDtoCopyWith<$Res> {
  _$PartialUserInfoDtoCopyWithImpl(this._self, this._then);

  final PartialUserInfoDto _self;
  final $Res Function(PartialUserInfoDto) _then;

  /// Create a copy of PartialUserInfoDto
  /// with the given fields replaced by the non-null parameter values.
  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? document = freezed,
    Object? name = freezed,
    Object? lastName = freezed,
    Object? phone = freezed,
    Object? gender = freezed,
    Object? maritalStatus = freezed,
    Object? photo = freezed,
    Object? cellId = freezed,
  }) {
    return _then(_self.copyWith(
      document: freezed == document
          ? _self.document
          : document // ignore: cast_nullable_to_non_nullable
              as String?,
      name: freezed == name
          ? _self.name
          : name // ignore: cast_nullable_to_non_nullable
              as String?,
      lastName: freezed == lastName
          ? _self.lastName
          : lastName // ignore: cast_nullable_to_non_nullable
              as String?,
      phone: freezed == phone
          ? _self.phone
          : phone // ignore: cast_nullable_to_non_nullable
              as String?,
      gender: freezed == gender
          ? _self.gender
          : gender // ignore: cast_nullable_to_non_nullable
              as int?,
      maritalStatus: freezed == maritalStatus
          ? _self.maritalStatus
          : maritalStatus // ignore: cast_nullable_to_non_nullable
              as int?,
      photo: freezed == photo
          ? _self.photo
          : photo // ignore: cast_nullable_to_non_nullable
              as String?,
      cellId: freezed == cellId
          ? _self.cellId
          : cellId // ignore: cast_nullable_to_non_nullable
              as int?,
    ));
  }
}

/// Adds pattern-matching-related methods to [PartialUserInfoDto].
extension PartialUserInfoDtoPatterns on PartialUserInfoDto {
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
    TResult Function(_PartialUserInfoDto value)? $default, {
    required TResult orElse(),
  }) {
    final _that = this;
    switch (_that) {
      case _PartialUserInfoDto() when $default != null:
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
    TResult Function(_PartialUserInfoDto value) $default,
  ) {
    final _that = this;
    switch (_that) {
      case _PartialUserInfoDto():
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
    TResult? Function(_PartialUserInfoDto value)? $default,
  ) {
    final _that = this;
    switch (_that) {
      case _PartialUserInfoDto() when $default != null:
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
            String? document,
            String? name,
            String? lastName,
            String? phone,
            int? gender,
            int? maritalStatus,
            String? photo,
            int? cellId)?
        $default, {
    required TResult orElse(),
  }) {
    final _that = this;
    switch (_that) {
      case _PartialUserInfoDto() when $default != null:
        return $default(_that.document, _that.name, _that.lastName, _that.phone,
            _that.gender, _that.maritalStatus, _that.photo, _that.cellId);
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
            String? document,
            String? name,
            String? lastName,
            String? phone,
            int? gender,
            int? maritalStatus,
            String? photo,
            int? cellId)
        $default,
  ) {
    final _that = this;
    switch (_that) {
      case _PartialUserInfoDto():
        return $default(_that.document, _that.name, _that.lastName, _that.phone,
            _that.gender, _that.maritalStatus, _that.photo, _that.cellId);
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
            String? document,
            String? name,
            String? lastName,
            String? phone,
            int? gender,
            int? maritalStatus,
            String? photo,
            int? cellId)?
        $default,
  ) {
    final _that = this;
    switch (_that) {
      case _PartialUserInfoDto() when $default != null:
        return $default(_that.document, _that.name, _that.lastName, _that.phone,
            _that.gender, _that.maritalStatus, _that.photo, _that.cellId);
      case _:
        return null;
    }
  }
}

/// @nodoc
@JsonSerializable()
class _PartialUserInfoDto extends PartialUserInfoDto {
  const _PartialUserInfoDto(
      {this.document,
      this.name,
      this.lastName,
      this.phone,
      this.gender,
      this.maritalStatus,
      this.photo,
      this.cellId})
      : super._();
  factory _PartialUserInfoDto.fromJson(Map<String, dynamic> json) =>
      _$PartialUserInfoDtoFromJson(json);

  @override
  final String? document;
  @override
  final String? name;
  @override
  final String? lastName;
  @override
  final String? phone;
  @override
  final int? gender;
  @override
  final int? maritalStatus;
  @override
  final String? photo;
  @override
  final int? cellId;

  /// Create a copy of PartialUserInfoDto
  /// with the given fields replaced by the non-null parameter values.
  @override
  @JsonKey(includeFromJson: false, includeToJson: false)
  @pragma('vm:prefer-inline')
  _$PartialUserInfoDtoCopyWith<_PartialUserInfoDto> get copyWith =>
      __$PartialUserInfoDtoCopyWithImpl<_PartialUserInfoDto>(this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$PartialUserInfoDtoToJson(
      this,
    );
  }

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _PartialUserInfoDto &&
            (identical(other.document, document) ||
                other.document == document) &&
            (identical(other.name, name) || other.name == name) &&
            (identical(other.lastName, lastName) ||
                other.lastName == lastName) &&
            (identical(other.phone, phone) || other.phone == phone) &&
            (identical(other.gender, gender) || other.gender == gender) &&
            (identical(other.maritalStatus, maritalStatus) ||
                other.maritalStatus == maritalStatus) &&
            (identical(other.photo, photo) || other.photo == photo) &&
            (identical(other.cellId, cellId) || other.cellId == cellId));
  }

  @JsonKey(includeFromJson: false, includeToJson: false)
  @override
  int get hashCode => Object.hash(runtimeType, document, name, lastName, phone,
      gender, maritalStatus, photo, cellId);

  @override
  String toString() {
    return 'PartialUserInfoDto(document: $document, name: $name, lastName: $lastName, phone: $phone, gender: $gender, maritalStatus: $maritalStatus, photo: $photo, cellId: $cellId)';
  }
}

/// @nodoc
abstract mixin class _$PartialUserInfoDtoCopyWith<$Res>
    implements $PartialUserInfoDtoCopyWith<$Res> {
  factory _$PartialUserInfoDtoCopyWith(
          _PartialUserInfoDto value, $Res Function(_PartialUserInfoDto) _then) =
      __$PartialUserInfoDtoCopyWithImpl;
  @override
  @useResult
  $Res call(
      {String? document,
      String? name,
      String? lastName,
      String? phone,
      int? gender,
      int? maritalStatus,
      String? photo,
      int? cellId});
}

/// @nodoc
class __$PartialUserInfoDtoCopyWithImpl<$Res>
    implements _$PartialUserInfoDtoCopyWith<$Res> {
  __$PartialUserInfoDtoCopyWithImpl(this._self, this._then);

  final _PartialUserInfoDto _self;
  final $Res Function(_PartialUserInfoDto) _then;

  /// Create a copy of PartialUserInfoDto
  /// with the given fields replaced by the non-null parameter values.
  @override
  @pragma('vm:prefer-inline')
  $Res call({
    Object? document = freezed,
    Object? name = freezed,
    Object? lastName = freezed,
    Object? phone = freezed,
    Object? gender = freezed,
    Object? maritalStatus = freezed,
    Object? photo = freezed,
    Object? cellId = freezed,
  }) {
    return _then(_PartialUserInfoDto(
      document: freezed == document
          ? _self.document
          : document // ignore: cast_nullable_to_non_nullable
              as String?,
      name: freezed == name
          ? _self.name
          : name // ignore: cast_nullable_to_non_nullable
              as String?,
      lastName: freezed == lastName
          ? _self.lastName
          : lastName // ignore: cast_nullable_to_non_nullable
              as String?,
      phone: freezed == phone
          ? _self.phone
          : phone // ignore: cast_nullable_to_non_nullable
              as String?,
      gender: freezed == gender
          ? _self.gender
          : gender // ignore: cast_nullable_to_non_nullable
              as int?,
      maritalStatus: freezed == maritalStatus
          ? _self.maritalStatus
          : maritalStatus // ignore: cast_nullable_to_non_nullable
              as int?,
      photo: freezed == photo
          ? _self.photo
          : photo // ignore: cast_nullable_to_non_nullable
              as String?,
      cellId: freezed == cellId
          ? _self.cellId
          : cellId // ignore: cast_nullable_to_non_nullable
              as int?,
    ));
  }
}

// dart format on
