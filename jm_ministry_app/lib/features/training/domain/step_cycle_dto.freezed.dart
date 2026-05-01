// GENERATED CODE - DO NOT MODIFY BY HAND
// coverage:ignore-file
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'step_cycle_dto.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

// dart format off
T _$identity<T>(T value) => value;

/// @nodoc
mixin _$StepCycleDto {

 int get id; int get discipleStepId; String? get name; DateTime get startDate; DateTime get endDate; int get minAttendanceRequired; bool get isOpen; DateTime? get enrollmentDeadline; int get sessionCount; int get enrolledCount;
/// Create a copy of StepCycleDto
/// with the given fields replaced by the non-null parameter values.
@JsonKey(includeFromJson: false, includeToJson: false)
@pragma('vm:prefer-inline')
$StepCycleDtoCopyWith<StepCycleDto> get copyWith => _$StepCycleDtoCopyWithImpl<StepCycleDto>(this as StepCycleDto, _$identity);

  /// Serializes this StepCycleDto to a JSON map.
  Map<String, dynamic> toJson();


@override
bool operator ==(Object other) {
  return identical(this, other) || (other.runtimeType == runtimeType&&other is StepCycleDto&&(identical(other.id, id) || other.id == id)&&(identical(other.discipleStepId, discipleStepId) || other.discipleStepId == discipleStepId)&&(identical(other.name, name) || other.name == name)&&(identical(other.startDate, startDate) || other.startDate == startDate)&&(identical(other.endDate, endDate) || other.endDate == endDate)&&(identical(other.minAttendanceRequired, minAttendanceRequired) || other.minAttendanceRequired == minAttendanceRequired)&&(identical(other.isOpen, isOpen) || other.isOpen == isOpen)&&(identical(other.enrollmentDeadline, enrollmentDeadline) || other.enrollmentDeadline == enrollmentDeadline)&&(identical(other.sessionCount, sessionCount) || other.sessionCount == sessionCount)&&(identical(other.enrolledCount, enrolledCount) || other.enrolledCount == enrolledCount));
}

@JsonKey(includeFromJson: false, includeToJson: false)
@override
int get hashCode => Object.hash(runtimeType,id,discipleStepId,name,startDate,endDate,minAttendanceRequired,isOpen,enrollmentDeadline,sessionCount,enrolledCount);

@override
String toString() {
  return 'StepCycleDto(id: $id, discipleStepId: $discipleStepId, name: $name, startDate: $startDate, endDate: $endDate, minAttendanceRequired: $minAttendanceRequired, isOpen: $isOpen, enrollmentDeadline: $enrollmentDeadline, sessionCount: $sessionCount, enrolledCount: $enrolledCount)';
}


}

/// @nodoc
abstract mixin class $StepCycleDtoCopyWith<$Res>  {
  factory $StepCycleDtoCopyWith(StepCycleDto value, $Res Function(StepCycleDto) _then) = _$StepCycleDtoCopyWithImpl;
@useResult
$Res call({
 int id, int discipleStepId, String? name, DateTime startDate, DateTime endDate, int minAttendanceRequired, bool isOpen, DateTime? enrollmentDeadline, int sessionCount, int enrolledCount
});




}
/// @nodoc
class _$StepCycleDtoCopyWithImpl<$Res>
    implements $StepCycleDtoCopyWith<$Res> {
  _$StepCycleDtoCopyWithImpl(this._self, this._then);

  final StepCycleDto _self;
  final $Res Function(StepCycleDto) _then;

/// Create a copy of StepCycleDto
/// with the given fields replaced by the non-null parameter values.
@pragma('vm:prefer-inline') @override $Res call({Object? id = null,Object? discipleStepId = null,Object? name = freezed,Object? startDate = null,Object? endDate = null,Object? minAttendanceRequired = null,Object? isOpen = null,Object? enrollmentDeadline = freezed,Object? sessionCount = null,Object? enrolledCount = null,}) {
  return _then(_self.copyWith(
id: null == id ? _self.id : id // ignore: cast_nullable_to_non_nullable
as int,discipleStepId: null == discipleStepId ? _self.discipleStepId : discipleStepId // ignore: cast_nullable_to_non_nullable
as int,name: freezed == name ? _self.name : name // ignore: cast_nullable_to_non_nullable
as String?,startDate: null == startDate ? _self.startDate : startDate // ignore: cast_nullable_to_non_nullable
as DateTime,endDate: null == endDate ? _self.endDate : endDate // ignore: cast_nullable_to_non_nullable
as DateTime,minAttendanceRequired: null == minAttendanceRequired ? _self.minAttendanceRequired : minAttendanceRequired // ignore: cast_nullable_to_non_nullable
as int,isOpen: null == isOpen ? _self.isOpen : isOpen // ignore: cast_nullable_to_non_nullable
as bool,enrollmentDeadline: freezed == enrollmentDeadline ? _self.enrollmentDeadline : enrollmentDeadline // ignore: cast_nullable_to_non_nullable
as DateTime?,sessionCount: null == sessionCount ? _self.sessionCount : sessionCount // ignore: cast_nullable_to_non_nullable
as int,enrolledCount: null == enrolledCount ? _self.enrolledCount : enrolledCount // ignore: cast_nullable_to_non_nullable
as int,
  ));
}

}


/// Adds pattern-matching-related methods to [StepCycleDto].
extension StepCycleDtoPatterns on StepCycleDto {
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

@optionalTypeArgs TResult maybeMap<TResult extends Object?>(TResult Function( _StepCycleDto value)?  $default,{required TResult orElse(),}){
final _that = this;
switch (_that) {
case _StepCycleDto() when $default != null:
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

@optionalTypeArgs TResult map<TResult extends Object?>(TResult Function( _StepCycleDto value)  $default,){
final _that = this;
switch (_that) {
case _StepCycleDto():
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

@optionalTypeArgs TResult? mapOrNull<TResult extends Object?>(TResult? Function( _StepCycleDto value)?  $default,){
final _that = this;
switch (_that) {
case _StepCycleDto() when $default != null:
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

@optionalTypeArgs TResult maybeWhen<TResult extends Object?>(TResult Function( int id,  int discipleStepId,  String? name,  DateTime startDate,  DateTime endDate,  int minAttendanceRequired,  bool isOpen,  DateTime? enrollmentDeadline,  int sessionCount,  int enrolledCount)?  $default,{required TResult orElse(),}) {final _that = this;
switch (_that) {
case _StepCycleDto() when $default != null:
return $default(_that.id,_that.discipleStepId,_that.name,_that.startDate,_that.endDate,_that.minAttendanceRequired,_that.isOpen,_that.enrollmentDeadline,_that.sessionCount,_that.enrolledCount);case _:
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

@optionalTypeArgs TResult when<TResult extends Object?>(TResult Function( int id,  int discipleStepId,  String? name,  DateTime startDate,  DateTime endDate,  int minAttendanceRequired,  bool isOpen,  DateTime? enrollmentDeadline,  int sessionCount,  int enrolledCount)  $default,) {final _that = this;
switch (_that) {
case _StepCycleDto():
return $default(_that.id,_that.discipleStepId,_that.name,_that.startDate,_that.endDate,_that.minAttendanceRequired,_that.isOpen,_that.enrollmentDeadline,_that.sessionCount,_that.enrolledCount);case _:
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

@optionalTypeArgs TResult? whenOrNull<TResult extends Object?>(TResult? Function( int id,  int discipleStepId,  String? name,  DateTime startDate,  DateTime endDate,  int minAttendanceRequired,  bool isOpen,  DateTime? enrollmentDeadline,  int sessionCount,  int enrolledCount)?  $default,) {final _that = this;
switch (_that) {
case _StepCycleDto() when $default != null:
return $default(_that.id,_that.discipleStepId,_that.name,_that.startDate,_that.endDate,_that.minAttendanceRequired,_that.isOpen,_that.enrollmentDeadline,_that.sessionCount,_that.enrolledCount);case _:
  return null;

}
}

}

/// @nodoc
@JsonSerializable()

class _StepCycleDto implements StepCycleDto {
  const _StepCycleDto({required this.id, required this.discipleStepId, this.name, required this.startDate, required this.endDate, required this.minAttendanceRequired, required this.isOpen, this.enrollmentDeadline, required this.sessionCount, required this.enrolledCount});
  factory _StepCycleDto.fromJson(Map<String, dynamic> json) => _$StepCycleDtoFromJson(json);

@override final  int id;
@override final  int discipleStepId;
@override final  String? name;
@override final  DateTime startDate;
@override final  DateTime endDate;
@override final  int minAttendanceRequired;
@override final  bool isOpen;
@override final  DateTime? enrollmentDeadline;
@override final  int sessionCount;
@override final  int enrolledCount;

/// Create a copy of StepCycleDto
/// with the given fields replaced by the non-null parameter values.
@override @JsonKey(includeFromJson: false, includeToJson: false)
@pragma('vm:prefer-inline')
_$StepCycleDtoCopyWith<_StepCycleDto> get copyWith => __$StepCycleDtoCopyWithImpl<_StepCycleDto>(this, _$identity);

@override
Map<String, dynamic> toJson() {
  return _$StepCycleDtoToJson(this, );
}

@override
bool operator ==(Object other) {
  return identical(this, other) || (other.runtimeType == runtimeType&&other is _StepCycleDto&&(identical(other.id, id) || other.id == id)&&(identical(other.discipleStepId, discipleStepId) || other.discipleStepId == discipleStepId)&&(identical(other.name, name) || other.name == name)&&(identical(other.startDate, startDate) || other.startDate == startDate)&&(identical(other.endDate, endDate) || other.endDate == endDate)&&(identical(other.minAttendanceRequired, minAttendanceRequired) || other.minAttendanceRequired == minAttendanceRequired)&&(identical(other.isOpen, isOpen) || other.isOpen == isOpen)&&(identical(other.enrollmentDeadline, enrollmentDeadline) || other.enrollmentDeadline == enrollmentDeadline)&&(identical(other.sessionCount, sessionCount) || other.sessionCount == sessionCount)&&(identical(other.enrolledCount, enrolledCount) || other.enrolledCount == enrolledCount));
}

@JsonKey(includeFromJson: false, includeToJson: false)
@override
int get hashCode => Object.hash(runtimeType,id,discipleStepId,name,startDate,endDate,minAttendanceRequired,isOpen,enrollmentDeadline,sessionCount,enrolledCount);

@override
String toString() {
  return 'StepCycleDto(id: $id, discipleStepId: $discipleStepId, name: $name, startDate: $startDate, endDate: $endDate, minAttendanceRequired: $minAttendanceRequired, isOpen: $isOpen, enrollmentDeadline: $enrollmentDeadline, sessionCount: $sessionCount, enrolledCount: $enrolledCount)';
}


}

/// @nodoc
abstract mixin class _$StepCycleDtoCopyWith<$Res> implements $StepCycleDtoCopyWith<$Res> {
  factory _$StepCycleDtoCopyWith(_StepCycleDto value, $Res Function(_StepCycleDto) _then) = __$StepCycleDtoCopyWithImpl;
@override @useResult
$Res call({
 int id, int discipleStepId, String? name, DateTime startDate, DateTime endDate, int minAttendanceRequired, bool isOpen, DateTime? enrollmentDeadline, int sessionCount, int enrolledCount
});




}
/// @nodoc
class __$StepCycleDtoCopyWithImpl<$Res>
    implements _$StepCycleDtoCopyWith<$Res> {
  __$StepCycleDtoCopyWithImpl(this._self, this._then);

  final _StepCycleDto _self;
  final $Res Function(_StepCycleDto) _then;

/// Create a copy of StepCycleDto
/// with the given fields replaced by the non-null parameter values.
@override @pragma('vm:prefer-inline') $Res call({Object? id = null,Object? discipleStepId = null,Object? name = freezed,Object? startDate = null,Object? endDate = null,Object? minAttendanceRequired = null,Object? isOpen = null,Object? enrollmentDeadline = freezed,Object? sessionCount = null,Object? enrolledCount = null,}) {
  return _then(_StepCycleDto(
id: null == id ? _self.id : id // ignore: cast_nullable_to_non_nullable
as int,discipleStepId: null == discipleStepId ? _self.discipleStepId : discipleStepId // ignore: cast_nullable_to_non_nullable
as int,name: freezed == name ? _self.name : name // ignore: cast_nullable_to_non_nullable
as String?,startDate: null == startDate ? _self.startDate : startDate // ignore: cast_nullable_to_non_nullable
as DateTime,endDate: null == endDate ? _self.endDate : endDate // ignore: cast_nullable_to_non_nullable
as DateTime,minAttendanceRequired: null == minAttendanceRequired ? _self.minAttendanceRequired : minAttendanceRequired // ignore: cast_nullable_to_non_nullable
as int,isOpen: null == isOpen ? _self.isOpen : isOpen // ignore: cast_nullable_to_non_nullable
as bool,enrollmentDeadline: freezed == enrollmentDeadline ? _self.enrollmentDeadline : enrollmentDeadline // ignore: cast_nullable_to_non_nullable
as DateTime?,sessionCount: null == sessionCount ? _self.sessionCount : sessionCount // ignore: cast_nullable_to_non_nullable
as int,enrolledCount: null == enrolledCount ? _self.enrolledCount : enrolledCount // ignore: cast_nullable_to_non_nullable
as int,
  ));
}


}

// dart format on
