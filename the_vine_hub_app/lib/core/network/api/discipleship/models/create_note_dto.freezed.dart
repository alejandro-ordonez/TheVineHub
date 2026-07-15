// GENERATED CODE - DO NOT MODIFY BY HAND
// coverage:ignore-file
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'create_note_dto.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

// dart format off
T _$identity<T>(T value) => value;

/// @nodoc
mixin _$CreateNoteDto {
  String get title;
  String get description;
  List<String> get categories;

  /// Create a copy of CreateNoteDto
  /// with the given fields replaced by the non-null parameter values.
  @JsonKey(includeFromJson: false, includeToJson: false)
  @pragma('vm:prefer-inline')
  $CreateNoteDtoCopyWith<CreateNoteDto> get copyWith =>
      _$CreateNoteDtoCopyWithImpl<CreateNoteDto>(
          this as CreateNoteDto, _$identity);

  /// Serializes this CreateNoteDto to a JSON map.
  Map<String, dynamic> toJson();

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is CreateNoteDto &&
            (identical(other.title, title) || other.title == title) &&
            (identical(other.description, description) ||
                other.description == description) &&
            const DeepCollectionEquality()
                .equals(other.categories, categories));
  }

  @JsonKey(includeFromJson: false, includeToJson: false)
  @override
  int get hashCode => Object.hash(runtimeType, title, description,
      const DeepCollectionEquality().hash(categories));

  @override
  String toString() {
    return 'CreateNoteDto(title: $title, description: $description, categories: $categories)';
  }
}

/// @nodoc
abstract mixin class $CreateNoteDtoCopyWith<$Res> {
  factory $CreateNoteDtoCopyWith(
          CreateNoteDto value, $Res Function(CreateNoteDto) _then) =
      _$CreateNoteDtoCopyWithImpl;
  @useResult
  $Res call({String title, String description, List<String> categories});
}

/// @nodoc
class _$CreateNoteDtoCopyWithImpl<$Res>
    implements $CreateNoteDtoCopyWith<$Res> {
  _$CreateNoteDtoCopyWithImpl(this._self, this._then);

  final CreateNoteDto _self;
  final $Res Function(CreateNoteDto) _then;

  /// Create a copy of CreateNoteDto
  /// with the given fields replaced by the non-null parameter values.
  @pragma('vm:prefer-inline')
  @override
  $Res call({
    Object? title = null,
    Object? description = null,
    Object? categories = null,
  }) {
    return _then(_self.copyWith(
      title: null == title
          ? _self.title
          : title // ignore: cast_nullable_to_non_nullable
              as String,
      description: null == description
          ? _self.description
          : description // ignore: cast_nullable_to_non_nullable
              as String,
      categories: null == categories
          ? _self.categories
          : categories // ignore: cast_nullable_to_non_nullable
              as List<String>,
    ));
  }
}

/// Adds pattern-matching-related methods to [CreateNoteDto].
extension CreateNoteDtoPatterns on CreateNoteDto {
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
    TResult Function(_CreateNoteDto value)? $default, {
    required TResult orElse(),
  }) {
    final _that = this;
    switch (_that) {
      case _CreateNoteDto() when $default != null:
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
    TResult Function(_CreateNoteDto value) $default,
  ) {
    final _that = this;
    switch (_that) {
      case _CreateNoteDto():
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
    TResult? Function(_CreateNoteDto value)? $default,
  ) {
    final _that = this;
    switch (_that) {
      case _CreateNoteDto() when $default != null:
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
    TResult Function(String title, String description, List<String> categories)?
        $default, {
    required TResult orElse(),
  }) {
    final _that = this;
    switch (_that) {
      case _CreateNoteDto() when $default != null:
        return $default(_that.title, _that.description, _that.categories);
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
    TResult Function(String title, String description, List<String> categories)
        $default,
  ) {
    final _that = this;
    switch (_that) {
      case _CreateNoteDto():
        return $default(_that.title, _that.description, _that.categories);
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
            String title, String description, List<String> categories)?
        $default,
  ) {
    final _that = this;
    switch (_that) {
      case _CreateNoteDto() when $default != null:
        return $default(_that.title, _that.description, _that.categories);
      case _:
        return null;
    }
  }
}

/// @nodoc
@JsonSerializable()
class _CreateNoteDto implements CreateNoteDto {
  const _CreateNoteDto(
      {required this.title,
      this.description = '',
      final List<String> categories = const []})
      : _categories = categories;
  factory _CreateNoteDto.fromJson(Map<String, dynamic> json) =>
      _$CreateNoteDtoFromJson(json);

  @override
  final String title;
  @override
  @JsonKey()
  final String description;
  final List<String> _categories;
  @override
  @JsonKey()
  List<String> get categories {
    if (_categories is EqualUnmodifiableListView) return _categories;
    // ignore: implicit_dynamic_type
    return EqualUnmodifiableListView(_categories);
  }

  /// Create a copy of CreateNoteDto
  /// with the given fields replaced by the non-null parameter values.
  @override
  @JsonKey(includeFromJson: false, includeToJson: false)
  @pragma('vm:prefer-inline')
  _$CreateNoteDtoCopyWith<_CreateNoteDto> get copyWith =>
      __$CreateNoteDtoCopyWithImpl<_CreateNoteDto>(this, _$identity);

  @override
  Map<String, dynamic> toJson() {
    return _$CreateNoteDtoToJson(
      this,
    );
  }

  @override
  bool operator ==(Object other) {
    return identical(this, other) ||
        (other.runtimeType == runtimeType &&
            other is _CreateNoteDto &&
            (identical(other.title, title) || other.title == title) &&
            (identical(other.description, description) ||
                other.description == description) &&
            const DeepCollectionEquality()
                .equals(other._categories, _categories));
  }

  @JsonKey(includeFromJson: false, includeToJson: false)
  @override
  int get hashCode => Object.hash(runtimeType, title, description,
      const DeepCollectionEquality().hash(_categories));

  @override
  String toString() {
    return 'CreateNoteDto(title: $title, description: $description, categories: $categories)';
  }
}

/// @nodoc
abstract mixin class _$CreateNoteDtoCopyWith<$Res>
    implements $CreateNoteDtoCopyWith<$Res> {
  factory _$CreateNoteDtoCopyWith(
          _CreateNoteDto value, $Res Function(_CreateNoteDto) _then) =
      __$CreateNoteDtoCopyWithImpl;
  @override
  @useResult
  $Res call({String title, String description, List<String> categories});
}

/// @nodoc
class __$CreateNoteDtoCopyWithImpl<$Res>
    implements _$CreateNoteDtoCopyWith<$Res> {
  __$CreateNoteDtoCopyWithImpl(this._self, this._then);

  final _CreateNoteDto _self;
  final $Res Function(_CreateNoteDto) _then;

  /// Create a copy of CreateNoteDto
  /// with the given fields replaced by the non-null parameter values.
  @override
  @pragma('vm:prefer-inline')
  $Res call({
    Object? title = null,
    Object? description = null,
    Object? categories = null,
  }) {
    return _then(_CreateNoteDto(
      title: null == title
          ? _self.title
          : title // ignore: cast_nullable_to_non_nullable
              as String,
      description: null == description
          ? _self.description
          : description // ignore: cast_nullable_to_non_nullable
              as String,
      categories: null == categories
          ? _self._categories
          : categories // ignore: cast_nullable_to_non_nullable
              as List<String>,
    ));
  }
}

// dart format on
