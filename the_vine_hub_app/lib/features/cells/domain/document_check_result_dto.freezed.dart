// GENERATED CODE - DO NOT MODIFY BY HAND
// coverage:ignore-file
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'document_check_result_dto.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

// dart format off
T _$identity<T>(T value) => value;

/// @nodoc
mixin _$DocumentCheckResultDto {

 bool get exists; bool get hasCell; String? get name; String? get lastName;
/// Create a copy of DocumentCheckResultDto
/// with the given fields replaced by the non-null parameter values.
@JsonKey(includeFromJson: false, includeToJson: false)
@pragma('vm:prefer-inline')
$DocumentCheckResultDtoCopyWith<DocumentCheckResultDto> get copyWith => _$DocumentCheckResultDtoCopyWithImpl<DocumentCheckResultDto>(this as DocumentCheckResultDto, _$identity);

  /// Serializes this DocumentCheckResultDto to a JSON map.
  Map<String, dynamic> toJson();


@override
bool operator ==(Object other) {
  return identical(this, other) || (other.runtimeType == runtimeType&&other is DocumentCheckResultDto&&(identical(other.exists, exists) || other.exists == exists)&&(identical(other.hasCell, hasCell) || other.hasCell == hasCell)&&(identical(other.name, name) || other.name == name)&&(identical(other.lastName, lastName) || other.lastName == lastName));
}

@JsonKey(includeFromJson: false, includeToJson: false)
@override
int get hashCode => Object.hash(runtimeType,exists,hasCell,name,lastName);

@override
String toString() {
  return 'DocumentCheckResultDto(exists: $exists, hasCell: $hasCell, name: $name, lastName: $lastName)';
}


}

/// @nodoc
abstract mixin class $DocumentCheckResultDtoCopyWith<$Res>  {
  factory $DocumentCheckResultDtoCopyWith(DocumentCheckResultDto value, $Res Function(DocumentCheckResultDto) _then) = _$DocumentCheckResultDtoCopyWithImpl;
@useResult
$Res call({
 bool exists, bool hasCell, String? name, String? lastName
});




}
/// @nodoc
class _$DocumentCheckResultDtoCopyWithImpl<$Res>
    implements $DocumentCheckResultDtoCopyWith<$Res> {
  _$DocumentCheckResultDtoCopyWithImpl(this._self, this._then);

  final DocumentCheckResultDto _self;
  final $Res Function(DocumentCheckResultDto) _then;

/// Create a copy of DocumentCheckResultDto
/// with the given fields replaced by the non-null parameter values.
@pragma('vm:prefer-inline') @override $Res call({Object? exists = null,Object? hasCell = null,Object? name = freezed,Object? lastName = freezed,}) {
  return _then(_self.copyWith(
exists: null == exists ? _self.exists : exists // ignore: cast_nullable_to_non_nullable
as bool,hasCell: null == hasCell ? _self.hasCell : hasCell // ignore: cast_nullable_to_non_nullable
as bool,name: freezed == name ? _self.name : name // ignore: cast_nullable_to_non_nullable
as String?,lastName: freezed == lastName ? _self.lastName : lastName // ignore: cast_nullable_to_non_nullable
as String?,
  ));
}

}


/// Adds pattern-matching-related methods to [DocumentCheckResultDto].
extension DocumentCheckResultDtoPatterns on DocumentCheckResultDto {
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

@optionalTypeArgs TResult maybeMap<TResult extends Object?>(TResult Function( _DocumentCheckResultDto value)?  $default,{required TResult orElse(),}){
final _that = this;
switch (_that) {
case _DocumentCheckResultDto() when $default != null:
return $default(_that);case _:
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

@optionalTypeArgs TResult map<TResult extends Object?>(TResult Function( _DocumentCheckResultDto value)  $default,){
final _that = this;
switch (_that) {
case _DocumentCheckResultDto():
return $default(_that);case _:
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

@optionalTypeArgs TResult? mapOrNull<TResult extends Object?>(TResult? Function( _DocumentCheckResultDto value)?  $default,){
final _that = this;
switch (_that) {
case _DocumentCheckResultDto() when $default != null:
return $default(_that);case _:
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

@optionalTypeArgs TResult maybeWhen<TResult extends Object?>(TResult Function( bool exists,  bool hasCell,  String? name,  String? lastName)?  $default,{required TResult orElse(),}) {final _that = this;
switch (_that) {
case _DocumentCheckResultDto() when $default != null:
return $default(_that.exists,_that.hasCell,_that.name,_that.lastName);case _:
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

@optionalTypeArgs TResult when<TResult extends Object?>(TResult Function( bool exists,  bool hasCell,  String? name,  String? lastName)  $default,) {final _that = this;
switch (_that) {
case _DocumentCheckResultDto():
return $default(_that.exists,_that.hasCell,_that.name,_that.lastName);case _:
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

@optionalTypeArgs TResult? whenOrNull<TResult extends Object?>(TResult? Function( bool exists,  bool hasCell,  String? name,  String? lastName)?  $default,) {final _that = this;
switch (_that) {
case _DocumentCheckResultDto() when $default != null:
return $default(_that.exists,_that.hasCell,_that.name,_that.lastName);case _:
  return null;

}
}

}

/// @nodoc
@JsonSerializable()

class _DocumentCheckResultDto implements DocumentCheckResultDto {
  const _DocumentCheckResultDto({required this.exists, required this.hasCell, this.name, this.lastName});
  factory _DocumentCheckResultDto.fromJson(Map<String, dynamic> json) => _$DocumentCheckResultDtoFromJson(json);

@override final  bool exists;
@override final  bool hasCell;
@override final  String? name;
@override final  String? lastName;

/// Create a copy of DocumentCheckResultDto
/// with the given fields replaced by the non-null parameter values.
@override @JsonKey(includeFromJson: false, includeToJson: false)
@pragma('vm:prefer-inline')
_$DocumentCheckResultDtoCopyWith<_DocumentCheckResultDto> get copyWith => __$DocumentCheckResultDtoCopyWithImpl<_DocumentCheckResultDto>(this, _$identity);

@override
Map<String, dynamic> toJson() {
  return _$DocumentCheckResultDtoToJson(this, );
}

@override
bool operator ==(Object other) {
  return identical(this, other) || (other.runtimeType == runtimeType&&other is _DocumentCheckResultDto&&(identical(other.exists, exists) || other.exists == exists)&&(identical(other.hasCell, hasCell) || other.hasCell == hasCell)&&(identical(other.name, name) || other.name == name)&&(identical(other.lastName, lastName) || other.lastName == lastName));
}

@JsonKey(includeFromJson: false, includeToJson: false)
@override
int get hashCode => Object.hash(runtimeType,exists,hasCell,name,lastName);

@override
String toString() {
  return 'DocumentCheckResultDto(exists: $exists, hasCell: $hasCell, name: $name, lastName: $lastName)';
}


}

/// @nodoc
abstract mixin class _$DocumentCheckResultDtoCopyWith<$Res> implements $DocumentCheckResultDtoCopyWith<$Res> {
  factory _$DocumentCheckResultDtoCopyWith(_DocumentCheckResultDto value, $Res Function(_DocumentCheckResultDto) _then) = __$DocumentCheckResultDtoCopyWithImpl;
@override @useResult
$Res call({
 bool exists, bool hasCell, String? name, String? lastName
});




}
/// @nodoc
class __$DocumentCheckResultDtoCopyWithImpl<$Res>
    implements _$DocumentCheckResultDtoCopyWith<$Res> {
  __$DocumentCheckResultDtoCopyWithImpl(this._self, this._then);

  final _DocumentCheckResultDto _self;
  final $Res Function(_DocumentCheckResultDto) _then;

/// Create a copy of DocumentCheckResultDto
/// with the given fields replaced by the non-null parameter values.
@override @pragma('vm:prefer-inline') $Res call({Object? exists = null,Object? hasCell = null,Object? name = freezed,Object? lastName = freezed,}) {
  return _then(_DocumentCheckResultDto(
exists: null == exists ? _self.exists : exists // ignore: cast_nullable_to_non_nullable
as bool,hasCell: null == hasCell ? _self.hasCell : hasCell // ignore: cast_nullable_to_non_nullable
as bool,name: freezed == name ? _self.name : name // ignore: cast_nullable_to_non_nullable
as String?,lastName: freezed == lastName ? _self.lastName : lastName // ignore: cast_nullable_to_non_nullable
as String?,
  ));
}


}

// dart format on
