// GENERATED CODE - DO NOT MODIFY BY HAND
// coverage:ignore-file
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'add_cell_attendance_dto.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

// dart format off
T _$identity<T>(T value) => value;

/// @nodoc
mixin _$AddCellAttendanceDto {

 List<String>? get disciples; String? get notes;
/// Create a copy of AddCellAttendanceDto
/// with the given fields replaced by the non-null parameter values.
@JsonKey(includeFromJson: false, includeToJson: false)
@pragma('vm:prefer-inline')
$AddCellAttendanceDtoCopyWith<AddCellAttendanceDto> get copyWith => _$AddCellAttendanceDtoCopyWithImpl<AddCellAttendanceDto>(this as AddCellAttendanceDto, _$identity);

  /// Serializes this AddCellAttendanceDto to a JSON map.
  Map<String, dynamic> toJson();


@override
bool operator ==(Object other) {
  return identical(this, other) || (other.runtimeType == runtimeType&&other is AddCellAttendanceDto&&const DeepCollectionEquality().equals(other.disciples, disciples)&&(identical(other.notes, notes) || other.notes == notes));
}

@JsonKey(includeFromJson: false, includeToJson: false)
@override
int get hashCode => Object.hash(runtimeType,const DeepCollectionEquality().hash(disciples),notes);

@override
String toString() {
  return 'AddCellAttendanceDto(disciples: $disciples, notes: $notes)';
}


}

/// @nodoc
abstract mixin class $AddCellAttendanceDtoCopyWith<$Res>  {
  factory $AddCellAttendanceDtoCopyWith(AddCellAttendanceDto value, $Res Function(AddCellAttendanceDto) _then) = _$AddCellAttendanceDtoCopyWithImpl;
@useResult
$Res call({
 List<String>? disciples, String? notes
});




}
/// @nodoc
class _$AddCellAttendanceDtoCopyWithImpl<$Res>
    implements $AddCellAttendanceDtoCopyWith<$Res> {
  _$AddCellAttendanceDtoCopyWithImpl(this._self, this._then);

  final AddCellAttendanceDto _self;
  final $Res Function(AddCellAttendanceDto) _then;

/// Create a copy of AddCellAttendanceDto
/// with the given fields replaced by the non-null parameter values.
@pragma('vm:prefer-inline') @override $Res call({Object? disciples = freezed,Object? notes = freezed,}) {
  return _then(_self.copyWith(
disciples: freezed == disciples ? _self.disciples : disciples // ignore: cast_nullable_to_non_nullable
as List<String>?,notes: freezed == notes ? _self.notes : notes // ignore: cast_nullable_to_non_nullable
as String?,
  ));
}

}


/// Adds pattern-matching-related methods to [AddCellAttendanceDto].
extension AddCellAttendanceDtoPatterns on AddCellAttendanceDto {
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

@optionalTypeArgs TResult maybeMap<TResult extends Object?>(TResult Function( _AddCellAttendanceDto value)?  $default,{required TResult orElse(),}){
final _that = this;
switch (_that) {
case _AddCellAttendanceDto() when $default != null:
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

@optionalTypeArgs TResult map<TResult extends Object?>(TResult Function( _AddCellAttendanceDto value)  $default,){
final _that = this;
switch (_that) {
case _AddCellAttendanceDto():
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

@optionalTypeArgs TResult? mapOrNull<TResult extends Object?>(TResult? Function( _AddCellAttendanceDto value)?  $default,){
final _that = this;
switch (_that) {
case _AddCellAttendanceDto() when $default != null:
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

@optionalTypeArgs TResult maybeWhen<TResult extends Object?>(TResult Function( List<String>? disciples,  String? notes)?  $default,{required TResult orElse(),}) {final _that = this;
switch (_that) {
case _AddCellAttendanceDto() when $default != null:
return $default(_that.disciples,_that.notes);case _:
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

@optionalTypeArgs TResult when<TResult extends Object?>(TResult Function( List<String>? disciples,  String? notes)  $default,) {final _that = this;
switch (_that) {
case _AddCellAttendanceDto():
return $default(_that.disciples,_that.notes);case _:
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

@optionalTypeArgs TResult? whenOrNull<TResult extends Object?>(TResult? Function( List<String>? disciples,  String? notes)?  $default,) {final _that = this;
switch (_that) {
case _AddCellAttendanceDto() when $default != null:
return $default(_that.disciples,_that.notes);case _:
  return null;

}
}

}

/// @nodoc
@JsonSerializable()

class _AddCellAttendanceDto implements AddCellAttendanceDto {
  const _AddCellAttendanceDto({final  List<String>? disciples, this.notes}): _disciples = disciples;
  factory _AddCellAttendanceDto.fromJson(Map<String, dynamic> json) => _$AddCellAttendanceDtoFromJson(json);

 final  List<String>? _disciples;
@override List<String>? get disciples {
  final value = _disciples;
  if (value == null) return null;
  if (_disciples is EqualUnmodifiableListView) return _disciples;
  // ignore: implicit_dynamic_type
  return EqualUnmodifiableListView(value);
}

@override final  String? notes;

/// Create a copy of AddCellAttendanceDto
/// with the given fields replaced by the non-null parameter values.
@override @JsonKey(includeFromJson: false, includeToJson: false)
@pragma('vm:prefer-inline')
_$AddCellAttendanceDtoCopyWith<_AddCellAttendanceDto> get copyWith => __$AddCellAttendanceDtoCopyWithImpl<_AddCellAttendanceDto>(this, _$identity);

@override
Map<String, dynamic> toJson() {
  return _$AddCellAttendanceDtoToJson(this, );
}

@override
bool operator ==(Object other) {
  return identical(this, other) || (other.runtimeType == runtimeType&&other is _AddCellAttendanceDto&&const DeepCollectionEquality().equals(other._disciples, _disciples)&&(identical(other.notes, notes) || other.notes == notes));
}

@JsonKey(includeFromJson: false, includeToJson: false)
@override
int get hashCode => Object.hash(runtimeType,const DeepCollectionEquality().hash(_disciples),notes);

@override
String toString() {
  return 'AddCellAttendanceDto(disciples: $disciples, notes: $notes)';
}


}

/// @nodoc
abstract mixin class _$AddCellAttendanceDtoCopyWith<$Res> implements $AddCellAttendanceDtoCopyWith<$Res> {
  factory _$AddCellAttendanceDtoCopyWith(_AddCellAttendanceDto value, $Res Function(_AddCellAttendanceDto) _then) = __$AddCellAttendanceDtoCopyWithImpl;
@override @useResult
$Res call({
 List<String>? disciples, String? notes
});




}
/// @nodoc
class __$AddCellAttendanceDtoCopyWithImpl<$Res>
    implements _$AddCellAttendanceDtoCopyWith<$Res> {
  __$AddCellAttendanceDtoCopyWithImpl(this._self, this._then);

  final _AddCellAttendanceDto _self;
  final $Res Function(_AddCellAttendanceDto) _then;

/// Create a copy of AddCellAttendanceDto
/// with the given fields replaced by the non-null parameter values.
@override @pragma('vm:prefer-inline') $Res call({Object? disciples = freezed,Object? notes = freezed,}) {
  return _then(_AddCellAttendanceDto(
disciples: freezed == disciples ? _self._disciples : disciples // ignore: cast_nullable_to_non_nullable
as List<String>?,notes: freezed == notes ? _self.notes : notes // ignore: cast_nullable_to_non_nullable
as String?,
  ));
}


}

// dart format on
