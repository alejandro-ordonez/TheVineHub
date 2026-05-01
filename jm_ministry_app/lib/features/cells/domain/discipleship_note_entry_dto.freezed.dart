// GENERATED CODE - DO NOT MODIFY BY HAND
// coverage:ignore-file
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'discipleship_note_entry_dto.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

// dart format off
T _$identity<T>(T value) => value;

/// @nodoc
mixin _$DiscipleshipNoteEntryDto {

 int get id; String? get content; DateTime get date; DateTime get createdAt; int get noteId; String? get authorId;
/// Create a copy of DiscipleshipNoteEntryDto
/// with the given fields replaced by the non-null parameter values.
@JsonKey(includeFromJson: false, includeToJson: false)
@pragma('vm:prefer-inline')
$DiscipleshipNoteEntryDtoCopyWith<DiscipleshipNoteEntryDto> get copyWith => _$DiscipleshipNoteEntryDtoCopyWithImpl<DiscipleshipNoteEntryDto>(this as DiscipleshipNoteEntryDto, _$identity);

  /// Serializes this DiscipleshipNoteEntryDto to a JSON map.
  Map<String, dynamic> toJson();


@override
bool operator ==(Object other) {
  return identical(this, other) || (other.runtimeType == runtimeType&&other is DiscipleshipNoteEntryDto&&(identical(other.id, id) || other.id == id)&&(identical(other.content, content) || other.content == content)&&(identical(other.date, date) || other.date == date)&&(identical(other.createdAt, createdAt) || other.createdAt == createdAt)&&(identical(other.noteId, noteId) || other.noteId == noteId)&&(identical(other.authorId, authorId) || other.authorId == authorId));
}

@JsonKey(includeFromJson: false, includeToJson: false)
@override
int get hashCode => Object.hash(runtimeType,id,content,date,createdAt,noteId,authorId);

@override
String toString() {
  return 'DiscipleshipNoteEntryDto(id: $id, content: $content, date: $date, createdAt: $createdAt, noteId: $noteId, authorId: $authorId)';
}


}

/// @nodoc
abstract mixin class $DiscipleshipNoteEntryDtoCopyWith<$Res>  {
  factory $DiscipleshipNoteEntryDtoCopyWith(DiscipleshipNoteEntryDto value, $Res Function(DiscipleshipNoteEntryDto) _then) = _$DiscipleshipNoteEntryDtoCopyWithImpl;
@useResult
$Res call({
 int id, String? content, DateTime date, DateTime createdAt, int noteId, String? authorId
});




}
/// @nodoc
class _$DiscipleshipNoteEntryDtoCopyWithImpl<$Res>
    implements $DiscipleshipNoteEntryDtoCopyWith<$Res> {
  _$DiscipleshipNoteEntryDtoCopyWithImpl(this._self, this._then);

  final DiscipleshipNoteEntryDto _self;
  final $Res Function(DiscipleshipNoteEntryDto) _then;

/// Create a copy of DiscipleshipNoteEntryDto
/// with the given fields replaced by the non-null parameter values.
@pragma('vm:prefer-inline') @override $Res call({Object? id = null,Object? content = freezed,Object? date = null,Object? createdAt = null,Object? noteId = null,Object? authorId = freezed,}) {
  return _then(_self.copyWith(
id: null == id ? _self.id : id // ignore: cast_nullable_to_non_nullable
as int,content: freezed == content ? _self.content : content // ignore: cast_nullable_to_non_nullable
as String?,date: null == date ? _self.date : date // ignore: cast_nullable_to_non_nullable
as DateTime,createdAt: null == createdAt ? _self.createdAt : createdAt // ignore: cast_nullable_to_non_nullable
as DateTime,noteId: null == noteId ? _self.noteId : noteId // ignore: cast_nullable_to_non_nullable
as int,authorId: freezed == authorId ? _self.authorId : authorId // ignore: cast_nullable_to_non_nullable
as String?,
  ));
}

}


/// Adds pattern-matching-related methods to [DiscipleshipNoteEntryDto].
extension DiscipleshipNoteEntryDtoPatterns on DiscipleshipNoteEntryDto {
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

@optionalTypeArgs TResult maybeMap<TResult extends Object?>(TResult Function( _DiscipleshipNoteEntryDto value)?  $default,{required TResult orElse(),}){
final _that = this;
switch (_that) {
case _DiscipleshipNoteEntryDto() when $default != null:
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

@optionalTypeArgs TResult map<TResult extends Object?>(TResult Function( _DiscipleshipNoteEntryDto value)  $default,){
final _that = this;
switch (_that) {
case _DiscipleshipNoteEntryDto():
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

@optionalTypeArgs TResult? mapOrNull<TResult extends Object?>(TResult? Function( _DiscipleshipNoteEntryDto value)?  $default,){
final _that = this;
switch (_that) {
case _DiscipleshipNoteEntryDto() when $default != null:
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

@optionalTypeArgs TResult maybeWhen<TResult extends Object?>(TResult Function( int id,  String? content,  DateTime date,  DateTime createdAt,  int noteId,  String? authorId)?  $default,{required TResult orElse(),}) {final _that = this;
switch (_that) {
case _DiscipleshipNoteEntryDto() when $default != null:
return $default(_that.id,_that.content,_that.date,_that.createdAt,_that.noteId,_that.authorId);case _:
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

@optionalTypeArgs TResult when<TResult extends Object?>(TResult Function( int id,  String? content,  DateTime date,  DateTime createdAt,  int noteId,  String? authorId)  $default,) {final _that = this;
switch (_that) {
case _DiscipleshipNoteEntryDto():
return $default(_that.id,_that.content,_that.date,_that.createdAt,_that.noteId,_that.authorId);case _:
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

@optionalTypeArgs TResult? whenOrNull<TResult extends Object?>(TResult? Function( int id,  String? content,  DateTime date,  DateTime createdAt,  int noteId,  String? authorId)?  $default,) {final _that = this;
switch (_that) {
case _DiscipleshipNoteEntryDto() when $default != null:
return $default(_that.id,_that.content,_that.date,_that.createdAt,_that.noteId,_that.authorId);case _:
  return null;

}
}

}

/// @nodoc
@JsonSerializable()

class _DiscipleshipNoteEntryDto implements DiscipleshipNoteEntryDto {
  const _DiscipleshipNoteEntryDto({required this.id, this.content, required this.date, required this.createdAt, required this.noteId, this.authorId});
  factory _DiscipleshipNoteEntryDto.fromJson(Map<String, dynamic> json) => _$DiscipleshipNoteEntryDtoFromJson(json);

@override final  int id;
@override final  String? content;
@override final  DateTime date;
@override final  DateTime createdAt;
@override final  int noteId;
@override final  String? authorId;

/// Create a copy of DiscipleshipNoteEntryDto
/// with the given fields replaced by the non-null parameter values.
@override @JsonKey(includeFromJson: false, includeToJson: false)
@pragma('vm:prefer-inline')
_$DiscipleshipNoteEntryDtoCopyWith<_DiscipleshipNoteEntryDto> get copyWith => __$DiscipleshipNoteEntryDtoCopyWithImpl<_DiscipleshipNoteEntryDto>(this, _$identity);

@override
Map<String, dynamic> toJson() {
  return _$DiscipleshipNoteEntryDtoToJson(this, );
}

@override
bool operator ==(Object other) {
  return identical(this, other) || (other.runtimeType == runtimeType&&other is _DiscipleshipNoteEntryDto&&(identical(other.id, id) || other.id == id)&&(identical(other.content, content) || other.content == content)&&(identical(other.date, date) || other.date == date)&&(identical(other.createdAt, createdAt) || other.createdAt == createdAt)&&(identical(other.noteId, noteId) || other.noteId == noteId)&&(identical(other.authorId, authorId) || other.authorId == authorId));
}

@JsonKey(includeFromJson: false, includeToJson: false)
@override
int get hashCode => Object.hash(runtimeType,id,content,date,createdAt,noteId,authorId);

@override
String toString() {
  return 'DiscipleshipNoteEntryDto(id: $id, content: $content, date: $date, createdAt: $createdAt, noteId: $noteId, authorId: $authorId)';
}


}

/// @nodoc
abstract mixin class _$DiscipleshipNoteEntryDtoCopyWith<$Res> implements $DiscipleshipNoteEntryDtoCopyWith<$Res> {
  factory _$DiscipleshipNoteEntryDtoCopyWith(_DiscipleshipNoteEntryDto value, $Res Function(_DiscipleshipNoteEntryDto) _then) = __$DiscipleshipNoteEntryDtoCopyWithImpl;
@override @useResult
$Res call({
 int id, String? content, DateTime date, DateTime createdAt, int noteId, String? authorId
});




}
/// @nodoc
class __$DiscipleshipNoteEntryDtoCopyWithImpl<$Res>
    implements _$DiscipleshipNoteEntryDtoCopyWith<$Res> {
  __$DiscipleshipNoteEntryDtoCopyWithImpl(this._self, this._then);

  final _DiscipleshipNoteEntryDto _self;
  final $Res Function(_DiscipleshipNoteEntryDto) _then;

/// Create a copy of DiscipleshipNoteEntryDto
/// with the given fields replaced by the non-null parameter values.
@override @pragma('vm:prefer-inline') $Res call({Object? id = null,Object? content = freezed,Object? date = null,Object? createdAt = null,Object? noteId = null,Object? authorId = freezed,}) {
  return _then(_DiscipleshipNoteEntryDto(
id: null == id ? _self.id : id // ignore: cast_nullable_to_non_nullable
as int,content: freezed == content ? _self.content : content // ignore: cast_nullable_to_non_nullable
as String?,date: null == date ? _self.date : date // ignore: cast_nullable_to_non_nullable
as DateTime,createdAt: null == createdAt ? _self.createdAt : createdAt // ignore: cast_nullable_to_non_nullable
as DateTime,noteId: null == noteId ? _self.noteId : noteId // ignore: cast_nullable_to_non_nullable
as int,authorId: freezed == authorId ? _self.authorId : authorId // ignore: cast_nullable_to_non_nullable
as String?,
  ));
}


}

// dart format on
