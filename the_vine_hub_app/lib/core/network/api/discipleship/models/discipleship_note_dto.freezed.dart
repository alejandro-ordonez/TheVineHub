// GENERATED CODE - DO NOT MODIFY BY HAND
// coverage:ignore-file
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'discipleship_note_dto.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

// dart format off
T _$identity<T>(T value) => value;

/// @nodoc
mixin _$DiscipleshipNoteDto {

 String get noteId; String? get title; String? get description; int? get noteStatus; DateTime get createdAt; List<String>? get categories; String? get discipleId; String? get leaderId; List<DiscipleshipNoteEntryDto>? get entries;
/// Create a copy of DiscipleshipNoteDto
/// with the given fields replaced by the non-null parameter values.
@JsonKey(includeFromJson: false, includeToJson: false)
@pragma('vm:prefer-inline')
$DiscipleshipNoteDtoCopyWith<DiscipleshipNoteDto> get copyWith => _$DiscipleshipNoteDtoCopyWithImpl<DiscipleshipNoteDto>(this as DiscipleshipNoteDto, _$identity);

  /// Serializes this DiscipleshipNoteDto to a JSON map.
  Map<String, dynamic> toJson();


@override
bool operator ==(Object other) {
  return identical(this, other) || (other.runtimeType == runtimeType&&other is DiscipleshipNoteDto&&(identical(other.noteId, noteId) || other.noteId == noteId)&&(identical(other.title, title) || other.title == title)&&(identical(other.description, description) || other.description == description)&&(identical(other.noteStatus, noteStatus) || other.noteStatus == noteStatus)&&(identical(other.createdAt, createdAt) || other.createdAt == createdAt)&&const DeepCollectionEquality().equals(other.categories, categories)&&(identical(other.discipleId, discipleId) || other.discipleId == discipleId)&&(identical(other.leaderId, leaderId) || other.leaderId == leaderId)&&const DeepCollectionEquality().equals(other.entries, entries));
}

@JsonKey(includeFromJson: false, includeToJson: false)
@override
int get hashCode => Object.hash(runtimeType,noteId,title,description,noteStatus,createdAt,const DeepCollectionEquality().hash(categories),discipleId,leaderId,const DeepCollectionEquality().hash(entries));

@override
String toString() {
  return 'DiscipleshipNoteDto(noteId: $noteId, title: $title, description: $description, noteStatus: $noteStatus, createdAt: $createdAt, categories: $categories, discipleId: $discipleId, leaderId: $leaderId, entries: $entries)';
}


}

/// @nodoc
abstract mixin class $DiscipleshipNoteDtoCopyWith<$Res>  {
  factory $DiscipleshipNoteDtoCopyWith(DiscipleshipNoteDto value, $Res Function(DiscipleshipNoteDto) _then) = _$DiscipleshipNoteDtoCopyWithImpl;
@useResult
$Res call({
 String noteId, String? title, String? description, int? noteStatus, DateTime createdAt, List<String>? categories, String? discipleId, String? leaderId, List<DiscipleshipNoteEntryDto>? entries
});




}
/// @nodoc
class _$DiscipleshipNoteDtoCopyWithImpl<$Res>
    implements $DiscipleshipNoteDtoCopyWith<$Res> {
  _$DiscipleshipNoteDtoCopyWithImpl(this._self, this._then);

  final DiscipleshipNoteDto _self;
  final $Res Function(DiscipleshipNoteDto) _then;

/// Create a copy of DiscipleshipNoteDto
/// with the given fields replaced by the non-null parameter values.
@pragma('vm:prefer-inline') @override $Res call({Object? noteId = null,Object? title = freezed,Object? description = freezed,Object? noteStatus = freezed,Object? createdAt = null,Object? categories = freezed,Object? discipleId = freezed,Object? leaderId = freezed,Object? entries = freezed,}) {
  return _then(_self.copyWith(
noteId: null == noteId ? _self.noteId : noteId // ignore: cast_nullable_to_non_nullable
as String,title: freezed == title ? _self.title : title // ignore: cast_nullable_to_non_nullable
as String?,description: freezed == description ? _self.description : description // ignore: cast_nullable_to_non_nullable
as String?,noteStatus: freezed == noteStatus ? _self.noteStatus : noteStatus // ignore: cast_nullable_to_non_nullable
as int?,createdAt: null == createdAt ? _self.createdAt : createdAt // ignore: cast_nullable_to_non_nullable
as DateTime,categories: freezed == categories ? _self.categories : categories // ignore: cast_nullable_to_non_nullable
as List<String>?,discipleId: freezed == discipleId ? _self.discipleId : discipleId // ignore: cast_nullable_to_non_nullable
as String?,leaderId: freezed == leaderId ? _self.leaderId : leaderId // ignore: cast_nullable_to_non_nullable
as String?,entries: freezed == entries ? _self.entries : entries // ignore: cast_nullable_to_non_nullable
as List<DiscipleshipNoteEntryDto>?,
  ));
}

}


/// Adds pattern-matching-related methods to [DiscipleshipNoteDto].
extension DiscipleshipNoteDtoPatterns on DiscipleshipNoteDto {
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

@optionalTypeArgs TResult maybeMap<TResult extends Object?>(TResult Function( _DiscipleshipNoteDto value)?  $default,{required TResult orElse(),}){
final _that = this;
switch (_that) {
case _DiscipleshipNoteDto() when $default != null:
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

@optionalTypeArgs TResult map<TResult extends Object?>(TResult Function( _DiscipleshipNoteDto value)  $default,){
final _that = this;
switch (_that) {
case _DiscipleshipNoteDto():
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

@optionalTypeArgs TResult? mapOrNull<TResult extends Object?>(TResult? Function( _DiscipleshipNoteDto value)?  $default,){
final _that = this;
switch (_that) {
case _DiscipleshipNoteDto() when $default != null:
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

@optionalTypeArgs TResult maybeWhen<TResult extends Object?>(TResult Function( String noteId,  String? title,  String? description,  int? noteStatus,  DateTime createdAt,  List<String>? categories,  String? discipleId,  String? leaderId,  List<DiscipleshipNoteEntryDto>? entries)?  $default,{required TResult orElse(),}) {final _that = this;
switch (_that) {
case _DiscipleshipNoteDto() when $default != null:
return $default(_that.noteId,_that.title,_that.description,_that.noteStatus,_that.createdAt,_that.categories,_that.discipleId,_that.leaderId,_that.entries);case _:
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

@optionalTypeArgs TResult when<TResult extends Object?>(TResult Function( String noteId,  String? title,  String? description,  int? noteStatus,  DateTime createdAt,  List<String>? categories,  String? discipleId,  String? leaderId,  List<DiscipleshipNoteEntryDto>? entries)  $default,) {final _that = this;
switch (_that) {
case _DiscipleshipNoteDto():
return $default(_that.noteId,_that.title,_that.description,_that.noteStatus,_that.createdAt,_that.categories,_that.discipleId,_that.leaderId,_that.entries);case _:
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

@optionalTypeArgs TResult? whenOrNull<TResult extends Object?>(TResult? Function( String noteId,  String? title,  String? description,  int? noteStatus,  DateTime createdAt,  List<String>? categories,  String? discipleId,  String? leaderId,  List<DiscipleshipNoteEntryDto>? entries)?  $default,) {final _that = this;
switch (_that) {
case _DiscipleshipNoteDto() when $default != null:
return $default(_that.noteId,_that.title,_that.description,_that.noteStatus,_that.createdAt,_that.categories,_that.discipleId,_that.leaderId,_that.entries);case _:
  return null;

}
}

}

/// @nodoc
@JsonSerializable()

class _DiscipleshipNoteDto implements DiscipleshipNoteDto {
  const _DiscipleshipNoteDto({required this.noteId, this.title, this.description, this.noteStatus, required this.createdAt, final  List<String>? categories, this.discipleId, this.leaderId, final  List<DiscipleshipNoteEntryDto>? entries}): _categories = categories,_entries = entries;
  factory _DiscipleshipNoteDto.fromJson(Map<String, dynamic> json) => _$DiscipleshipNoteDtoFromJson(json);

@override final  String noteId;
@override final  String? title;
@override final  String? description;
@override final  int? noteStatus;
@override final  DateTime createdAt;
 final  List<String>? _categories;
@override List<String>? get categories {
  final value = _categories;
  if (value == null) return null;
  if (_categories is EqualUnmodifiableListView) return _categories;
  // ignore: implicit_dynamic_type
  return EqualUnmodifiableListView(value);
}

@override final  String? discipleId;
@override final  String? leaderId;
 final  List<DiscipleshipNoteEntryDto>? _entries;
@override List<DiscipleshipNoteEntryDto>? get entries {
  final value = _entries;
  if (value == null) return null;
  if (_entries is EqualUnmodifiableListView) return _entries;
  // ignore: implicit_dynamic_type
  return EqualUnmodifiableListView(value);
}


/// Create a copy of DiscipleshipNoteDto
/// with the given fields replaced by the non-null parameter values.
@override @JsonKey(includeFromJson: false, includeToJson: false)
@pragma('vm:prefer-inline')
_$DiscipleshipNoteDtoCopyWith<_DiscipleshipNoteDto> get copyWith => __$DiscipleshipNoteDtoCopyWithImpl<_DiscipleshipNoteDto>(this, _$identity);

@override
Map<String, dynamic> toJson() {
  return _$DiscipleshipNoteDtoToJson(this, );
}

@override
bool operator ==(Object other) {
  return identical(this, other) || (other.runtimeType == runtimeType&&other is _DiscipleshipNoteDto&&(identical(other.noteId, noteId) || other.noteId == noteId)&&(identical(other.title, title) || other.title == title)&&(identical(other.description, description) || other.description == description)&&(identical(other.noteStatus, noteStatus) || other.noteStatus == noteStatus)&&(identical(other.createdAt, createdAt) || other.createdAt == createdAt)&&const DeepCollectionEquality().equals(other._categories, _categories)&&(identical(other.discipleId, discipleId) || other.discipleId == discipleId)&&(identical(other.leaderId, leaderId) || other.leaderId == leaderId)&&const DeepCollectionEquality().equals(other._entries, _entries));
}

@JsonKey(includeFromJson: false, includeToJson: false)
@override
int get hashCode => Object.hash(runtimeType,noteId,title,description,noteStatus,createdAt,const DeepCollectionEquality().hash(_categories),discipleId,leaderId,const DeepCollectionEquality().hash(_entries));

@override
String toString() {
  return 'DiscipleshipNoteDto(noteId: $noteId, title: $title, description: $description, noteStatus: $noteStatus, createdAt: $createdAt, categories: $categories, discipleId: $discipleId, leaderId: $leaderId, entries: $entries)';
}


}

/// @nodoc
abstract mixin class _$DiscipleshipNoteDtoCopyWith<$Res> implements $DiscipleshipNoteDtoCopyWith<$Res> {
  factory _$DiscipleshipNoteDtoCopyWith(_DiscipleshipNoteDto value, $Res Function(_DiscipleshipNoteDto) _then) = __$DiscipleshipNoteDtoCopyWithImpl;
@override @useResult
$Res call({
 String noteId, String? title, String? description, int? noteStatus, DateTime createdAt, List<String>? categories, String? discipleId, String? leaderId, List<DiscipleshipNoteEntryDto>? entries
});




}
/// @nodoc
class __$DiscipleshipNoteDtoCopyWithImpl<$Res>
    implements _$DiscipleshipNoteDtoCopyWith<$Res> {
  __$DiscipleshipNoteDtoCopyWithImpl(this._self, this._then);

  final _DiscipleshipNoteDto _self;
  final $Res Function(_DiscipleshipNoteDto) _then;

/// Create a copy of DiscipleshipNoteDto
/// with the given fields replaced by the non-null parameter values.
@override @pragma('vm:prefer-inline') $Res call({Object? noteId = null,Object? title = freezed,Object? description = freezed,Object? noteStatus = freezed,Object? createdAt = null,Object? categories = freezed,Object? discipleId = freezed,Object? leaderId = freezed,Object? entries = freezed,}) {
  return _then(_DiscipleshipNoteDto(
noteId: null == noteId ? _self.noteId : noteId // ignore: cast_nullable_to_non_nullable
as String,title: freezed == title ? _self.title : title // ignore: cast_nullable_to_non_nullable
as String?,description: freezed == description ? _self.description : description // ignore: cast_nullable_to_non_nullable
as String?,noteStatus: freezed == noteStatus ? _self.noteStatus : noteStatus // ignore: cast_nullable_to_non_nullable
as int?,createdAt: null == createdAt ? _self.createdAt : createdAt // ignore: cast_nullable_to_non_nullable
as DateTime,categories: freezed == categories ? _self._categories : categories // ignore: cast_nullable_to_non_nullable
as List<String>?,discipleId: freezed == discipleId ? _self.discipleId : discipleId // ignore: cast_nullable_to_non_nullable
as String?,leaderId: freezed == leaderId ? _self.leaderId : leaderId // ignore: cast_nullable_to_non_nullable
as String?,entries: freezed == entries ? _self._entries : entries // ignore: cast_nullable_to_non_nullable
as List<DiscipleshipNoteEntryDto>?,
  ));
}


}

// dart format on
