// GENERATED CODE - DO NOT MODIFY BY HAND
// coverage:ignore-file
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'add_disciple_state.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

// dart format off
T _$identity<T>(T value) => value;

/// @nodoc
mixin _$AddDiscipleState {
  bool get isChecking;
  bool get isSubmitting;
  bool get documentChecked;
  DocumentCheckResultDto? get checkResult;
  UserInfoDto? get existingUserInfo;
  String? get error;

  /// Create a copy of AddDiscipleState
  /// with the given fields replaced by the non-null parameter values.
  @JsonKey(includeFromJson: false, includeToJson: false)
  @pragma('vm:prefer-inline')
  $AddDiscipleStateCopyWith<AddDiscipleState> get copyWith =>
      _$AddDiscipleStateCopyWithImpl<AddDiscipleState>(
          this as AddDiscipleState, _$identity);

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is AddDiscipleState &&
            (identical(other.isChecking, isChecking) ||
                other.isChecking == isChecking) &&
            (identical(other.isSubmitting, isSubmitting) ||
                other.isSubmitting == isSubmitting) &&
            (identical(other.documentChecked, documentChecked) ||
                other.documentChecked == documentChecked) &&
            (identical(other.checkResult, checkResult) ||
                other.checkResult == checkResult) &&
            (identical(other.existingUserInfo, existingUserInfo) ||
                other.existingUserInfo == existingUserInfo) &&
            (identical(other.error, error) || other.error == error));
  }

  @override
  int get hashCode => Object.hash(runtimeType, isChecking, isSubmitting,
      documentChecked, checkResult, existingUserInfo, error);

  @override
  String toString() {
    return 'AddDiscipleState(isChecking: $isChecking, isSubmitting: $isSubmitting, documentChecked: $documentChecked, checkResult: $checkResult, existingUserInfo: $existingUserInfo, error: $error)';
  }
}

/// @nodoc
abstract mixin class $AddDiscipleStateCopyWith<$Res> {
  factory $AddDiscipleStateCopyWith(
          AddDiscipleState value, $Res Function(AddDiscipleState) _then) =
      _$AddDiscipleStateCopyWithImpl;
  @useResult
  $Res call(
      {bool isChecking,
      bool isSubmitting,
      bool documentChecked,
      DocumentCheckResultDto? checkResult,
      UserInfoDto? existingUserInfo,
      String? error});

  $DocumentCheckResultDtoCopyWith<$Res>? get checkResult;
  $UserInfoDtoCopyWith<$Res>? get existingUserInfo;
}

/// @nodoc
class _$AddDiscipleStateCopyWithImpl<$Res>
    implements $AddDiscipleStateCopyWith<$Res> {
  _$AddDiscipleStateCopyWithImpl(this._self, this._then);

  final AddDiscipleState _self;
  final $Res Function(AddDiscipleState) _then;

  /// Create a copy of AddDiscipleState
  /// with the given fields replaced by the non-null parameter values.
  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? isChecking = null,
    Object? isSubmitting = null,
    Object? documentChecked = null,
    Object? checkResult = freezed,
    Object? existingUserInfo = freezed,
    Object? error = freezed,
  }) {
    return _then(_self.copyWith(
      isChecking: null == isChecking
          ? _self.isChecking
          : isChecking // ignore: cast_nullable_to_non_nullable
              as bool,
      isSubmitting: null == isSubmitting
          ? _self.isSubmitting
          : isSubmitting // ignore: cast_nullable_to_non_nullable
              as bool,
      documentChecked: null == documentChecked
          ? _self.documentChecked
          : documentChecked // ignore: cast_nullable_to_non_nullable
              as bool,
      checkResult: freezed == checkResult
          ? _self.checkResult
          : checkResult // ignore: cast_nullable_to_non_nullable
              as DocumentCheckResultDto?,
      existingUserInfo: freezed == existingUserInfo
          ? _self.existingUserInfo
          : existingUserInfo // ignore: cast_nullable_to_non_nullable
              as UserInfoDto?,
      error: freezed == error
          ? _self.error
          : error // ignore: cast_nullable_to_non_nullable
              as String?,
    ));
  }

  /// Create a copy of AddDiscipleState
  /// with the given fields replaced by the non-null parameter values.
  @override
  @pragma('vm:prefer-inline')
  $DocumentCheckResultDtoCopyWith<$Res>? get checkResult {
    if (_self.checkResult == null) {
      return null;
    }

    return $DocumentCheckResultDtoCopyWith<$Res>(_self.checkResult!, (value) {
      return _then(_self.copyWith(checkResult: value));
    });
  }

  /// Create a copy of AddDiscipleState
  /// with the given fields replaced by the non-null parameter values.
  @override
  @pragma('vm:prefer-inline')
  $UserInfoDtoCopyWith<$Res>? get existingUserInfo {
    if (_self.existingUserInfo == null) {
      return null;
    }

    return $UserInfoDtoCopyWith<$Res>(_self.existingUserInfo!, (value) {
      return _then(_self.copyWith(existingUserInfo: value));
    });
  }
}

/// Adds pattern-matching-related methods to [AddDiscipleState].
extension AddDiscipleStatePatterns on AddDiscipleState {
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
    TResult Function(_AddDiscipleState value)? $default, {
    required TResult orElse(),
  }) {
    final _that = this;
    switch (_that) {
      case _AddDiscipleState() when $default != null:
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
    TResult Function(_AddDiscipleState value) $default,
  ) {
    final _that = this;
    switch (_that) {
      case _AddDiscipleState():
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
    TResult? Function(_AddDiscipleState value)? $default,
  ) {
    final _that = this;
    switch (_that) {
      case _AddDiscipleState() when $default != null:
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
            bool isChecking,
            bool isSubmitting,
            bool documentChecked,
            DocumentCheckResultDto? checkResult,
            UserInfoDto? existingUserInfo,
            String? error)?
        $default, {
    required TResult orElse(),
  }) {
    final _that = this;
    switch (_that) {
      case _AddDiscipleState() when $default != null:
        return $default(
            _that.isChecking,
            _that.isSubmitting,
            _that.documentChecked,
            _that.checkResult,
            _that.existingUserInfo,
            _that.error);
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
            bool isChecking,
            bool isSubmitting,
            bool documentChecked,
            DocumentCheckResultDto? checkResult,
            UserInfoDto? existingUserInfo,
            String? error)
        $default,
  ) {
    final _that = this;
    switch (_that) {
      case _AddDiscipleState():
        return $default(
            _that.isChecking,
            _that.isSubmitting,
            _that.documentChecked,
            _that.checkResult,
            _that.existingUserInfo,
            _that.error);
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
            bool isChecking,
            bool isSubmitting,
            bool documentChecked,
            DocumentCheckResultDto? checkResult,
            UserInfoDto? existingUserInfo,
            String? error)?
        $default,
  ) {
    final _that = this;
    switch (_that) {
      case _AddDiscipleState() when $default != null:
        return $default(
            _that.isChecking,
            _that.isSubmitting,
            _that.documentChecked,
            _that.checkResult,
            _that.existingUserInfo,
            _that.error);
      case _:
        return null;
    }
  }
}

/// @nodoc

class _AddDiscipleState implements AddDiscipleState {
  const _AddDiscipleState(
      {this.isChecking = false,
      this.isSubmitting = false,
      this.documentChecked = false,
      this.checkResult,
      this.existingUserInfo,
      this.error});

  @override
  @JsonKey()
  final bool isChecking;
  @override
  @JsonKey()
  final bool isSubmitting;
  @override
  @JsonKey()
  final bool documentChecked;
  @override
  final DocumentCheckResultDto? checkResult;
  @override
  final UserInfoDto? existingUserInfo;
  @override
  final String? error;

  /// Create a copy of AddDiscipleState
  /// with the given fields replaced by the non-null parameter values.
  @override
  @JsonKey(includeFromJson: false, includeToJson: false)
  @pragma('vm:prefer-inline')
  _$AddDiscipleStateCopyWith<_AddDiscipleState> get copyWith =>
      __$AddDiscipleStateCopyWithImpl<_AddDiscipleState>(this, _$identity);

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _AddDiscipleState &&
            (identical(other.isChecking, isChecking) ||
                other.isChecking == isChecking) &&
            (identical(other.isSubmitting, isSubmitting) ||
                other.isSubmitting == isSubmitting) &&
            (identical(other.documentChecked, documentChecked) ||
                other.documentChecked == documentChecked) &&
            (identical(other.checkResult, checkResult) ||
                other.checkResult == checkResult) &&
            (identical(other.existingUserInfo, existingUserInfo) ||
                other.existingUserInfo == existingUserInfo) &&
            (identical(other.error, error) || other.error == error));
  }

  @override
  int get hashCode => Object.hash(runtimeType, isChecking, isSubmitting,
      documentChecked, checkResult, existingUserInfo, error);

  @override
  String toString() {
    return 'AddDiscipleState(isChecking: $isChecking, isSubmitting: $isSubmitting, documentChecked: $documentChecked, checkResult: $checkResult, existingUserInfo: $existingUserInfo, error: $error)';
  }
}

/// @nodoc
abstract mixin class _$AddDiscipleStateCopyWith<$Res>
    implements $AddDiscipleStateCopyWith<$Res> {
  factory _$AddDiscipleStateCopyWith(
          _AddDiscipleState value, $Res Function(_AddDiscipleState) _then) =
      __$AddDiscipleStateCopyWithImpl;
  @override
  @useResult
  $Res call(
      {bool isChecking,
      bool isSubmitting,
      bool documentChecked,
      DocumentCheckResultDto? checkResult,
      UserInfoDto? existingUserInfo,
      String? error});

  @override
  $DocumentCheckResultDtoCopyWith<$Res>? get checkResult;
  @override
  $UserInfoDtoCopyWith<$Res>? get existingUserInfo;
}

/// @nodoc
class __$AddDiscipleStateCopyWithImpl<$Res>
    implements _$AddDiscipleStateCopyWith<$Res> {
  __$AddDiscipleStateCopyWithImpl(this._self, this._then);

  final _AddDiscipleState _self;
  final $Res Function(_AddDiscipleState) _then;

  /// Create a copy of AddDiscipleState
  /// with the given fields replaced by the non-null parameter values.
  @override
  @pragma('vm:prefer-inline')
  $Res call({
    Object? isChecking = null,
    Object? isSubmitting = null,
    Object? documentChecked = null,
    Object? checkResult = freezed,
    Object? existingUserInfo = freezed,
    Object? error = freezed,
  }) {
    return _then(_AddDiscipleState(
      isChecking: null == isChecking
          ? _self.isChecking
          : isChecking // ignore: cast_nullable_to_non_nullable
              as bool,
      isSubmitting: null == isSubmitting
          ? _self.isSubmitting
          : isSubmitting // ignore: cast_nullable_to_non_nullable
              as bool,
      documentChecked: null == documentChecked
          ? _self.documentChecked
          : documentChecked // ignore: cast_nullable_to_non_nullable
              as bool,
      checkResult: freezed == checkResult
          ? _self.checkResult
          : checkResult // ignore: cast_nullable_to_non_nullable
              as DocumentCheckResultDto?,
      existingUserInfo: freezed == existingUserInfo
          ? _self.existingUserInfo
          : existingUserInfo // ignore: cast_nullable_to_non_nullable
              as UserInfoDto?,
      error: freezed == error
          ? _self.error
          : error // ignore: cast_nullable_to_non_nullable
              as String?,
    ));
  }

  /// Create a copy of AddDiscipleState
  /// with the given fields replaced by the non-null parameter values.
  @override
  @pragma('vm:prefer-inline')
  $DocumentCheckResultDtoCopyWith<$Res>? get checkResult {
    if (_self.checkResult == null) {
      return null;
    }

    return $DocumentCheckResultDtoCopyWith<$Res>(_self.checkResult!, (value) {
      return _then(_self.copyWith(checkResult: value));
    });
  }

  /// Create a copy of AddDiscipleState
  /// with the given fields replaced by the non-null parameter values.
  @override
  @pragma('vm:prefer-inline')
  $UserInfoDtoCopyWith<$Res>? get existingUserInfo {
    if (_self.existingUserInfo == null) {
      return null;
    }

    return $UserInfoDtoCopyWith<$Res>(_self.existingUserInfo!, (value) {
      return _then(_self.copyWith(existingUserInfo: value));
    });
  }
}

// dart format on
