// GENERATED CODE - DO NOT MODIFY BY HAND
// coverage:ignore-file
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'cell_dto.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

// dart format off
T _$identity<T>(T value) => value;

/// @nodoc
mixin _$CellDto {

 int? get id; String? get name; String? get description; bool get mainCell; String? get address; CityDto? get city; LocalityDto? get locality; int? get day; DateTime? get openingDate;
/// Create a copy of CellDto
/// with the given fields replaced by the non-null parameter values.
@JsonKey(includeFromJson: false, includeToJson: false)
@pragma('vm:prefer-inline')
$CellDtoCopyWith<CellDto> get copyWith => _$CellDtoCopyWithImpl<CellDto>(this as CellDto, _$identity);

  /// Serializes this CellDto to a JSON map.
  Map<String, dynamic> toJson();


@override
bool operator ==(Object other) {
  return identical(this, other) || (other.runtimeType == runtimeType&&other is CellDto&&(identical(other.id, id) || other.id == id)&&(identical(other.name, name) || other.name == name)&&(identical(other.description, description) || other.description == description)&&(identical(other.mainCell, mainCell) || other.mainCell == mainCell)&&(identical(other.address, address) || other.address == address)&&(identical(other.city, city) || other.city == city)&&(identical(other.locality, locality) || other.locality == locality)&&(identical(other.day, day) || other.day == day)&&(identical(other.openingDate, openingDate) || other.openingDate == openingDate));
}

@JsonKey(includeFromJson: false, includeToJson: false)
@override
int get hashCode => Object.hash(runtimeType,id,name,description,mainCell,address,city,locality,day,openingDate);

@override
String toString() {
  return 'CellDto(id: $id, name: $name, description: $description, mainCell: $mainCell, address: $address, city: $city, locality: $locality, day: $day, openingDate: $openingDate)';
}


}

/// @nodoc
abstract mixin class $CellDtoCopyWith<$Res>  {
  factory $CellDtoCopyWith(CellDto value, $Res Function(CellDto) _then) = _$CellDtoCopyWithImpl;
@useResult
$Res call({
 int? id, String? name, String? description, bool mainCell, String? address, CityDto? city, LocalityDto? locality, int? day, DateTime? openingDate
});


$CityDtoCopyWith<$Res>? get city;$LocalityDtoCopyWith<$Res>? get locality;

}
/// @nodoc
class _$CellDtoCopyWithImpl<$Res>
    implements $CellDtoCopyWith<$Res> {
  _$CellDtoCopyWithImpl(this._self, this._then);

  final CellDto _self;
  final $Res Function(CellDto) _then;

/// Create a copy of CellDto
/// with the given fields replaced by the non-null parameter values.
@pragma('vm:prefer-inline') @override $Res call({Object? id = freezed,Object? name = freezed,Object? description = freezed,Object? mainCell = null,Object? address = freezed,Object? city = freezed,Object? locality = freezed,Object? day = freezed,Object? openingDate = freezed,}) {
  return _then(_self.copyWith(
id: freezed == id ? _self.id : id // ignore: cast_nullable_to_non_nullable
as int?,name: freezed == name ? _self.name : name // ignore: cast_nullable_to_non_nullable
as String?,description: freezed == description ? _self.description : description // ignore: cast_nullable_to_non_nullable
as String?,mainCell: null == mainCell ? _self.mainCell : mainCell // ignore: cast_nullable_to_non_nullable
as bool,address: freezed == address ? _self.address : address // ignore: cast_nullable_to_non_nullable
as String?,city: freezed == city ? _self.city : city // ignore: cast_nullable_to_non_nullable
as CityDto?,locality: freezed == locality ? _self.locality : locality // ignore: cast_nullable_to_non_nullable
as LocalityDto?,day: freezed == day ? _self.day : day // ignore: cast_nullable_to_non_nullable
as int?,openingDate: freezed == openingDate ? _self.openingDate : openingDate // ignore: cast_nullable_to_non_nullable
as DateTime?,
  ));
}
/// Create a copy of CellDto
/// with the given fields replaced by the non-null parameter values.
@override
@pragma('vm:prefer-inline')
$CityDtoCopyWith<$Res>? get city {
    if (_self.city == null) {
    return null;
  }

  return $CityDtoCopyWith<$Res>(_self.city!, (value) {
    return _then(_self.copyWith(city: value));
  });
}/// Create a copy of CellDto
/// with the given fields replaced by the non-null parameter values.
@override
@pragma('vm:prefer-inline')
$LocalityDtoCopyWith<$Res>? get locality {
    if (_self.locality == null) {
    return null;
  }

  return $LocalityDtoCopyWith<$Res>(_self.locality!, (value) {
    return _then(_self.copyWith(locality: value));
  });
}
}


/// Adds pattern-matching-related methods to [CellDto].
extension CellDtoPatterns on CellDto {
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

@optionalTypeArgs TResult maybeMap<TResult extends Object?>(TResult Function( _CellDto value)?  $default,{required TResult orElse(),}){
final _that = this;
switch (_that) {
case _CellDto() when $default != null:
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

@optionalTypeArgs TResult map<TResult extends Object?>(TResult Function( _CellDto value)  $default,){
final _that = this;
switch (_that) {
case _CellDto():
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

@optionalTypeArgs TResult? mapOrNull<TResult extends Object?>(TResult? Function( _CellDto value)?  $default,){
final _that = this;
switch (_that) {
case _CellDto() when $default != null:
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

@optionalTypeArgs TResult maybeWhen<TResult extends Object?>(TResult Function( int? id,  String? name,  String? description,  bool mainCell,  String? address,  CityDto? city,  LocalityDto? locality,  int? day,  DateTime? openingDate)?  $default,{required TResult orElse(),}) {final _that = this;
switch (_that) {
case _CellDto() when $default != null:
return $default(_that.id,_that.name,_that.description,_that.mainCell,_that.address,_that.city,_that.locality,_that.day,_that.openingDate);case _:
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

@optionalTypeArgs TResult when<TResult extends Object?>(TResult Function( int? id,  String? name,  String? description,  bool mainCell,  String? address,  CityDto? city,  LocalityDto? locality,  int? day,  DateTime? openingDate)  $default,) {final _that = this;
switch (_that) {
case _CellDto():
return $default(_that.id,_that.name,_that.description,_that.mainCell,_that.address,_that.city,_that.locality,_that.day,_that.openingDate);case _:
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

@optionalTypeArgs TResult? whenOrNull<TResult extends Object?>(TResult? Function( int? id,  String? name,  String? description,  bool mainCell,  String? address,  CityDto? city,  LocalityDto? locality,  int? day,  DateTime? openingDate)?  $default,) {final _that = this;
switch (_that) {
case _CellDto() when $default != null:
return $default(_that.id,_that.name,_that.description,_that.mainCell,_that.address,_that.city,_that.locality,_that.day,_that.openingDate);case _:
  return null;

}
}

}

/// @nodoc
@JsonSerializable()

class _CellDto implements CellDto {
  const _CellDto({this.id, this.name, this.description, required this.mainCell, this.address, this.city, this.locality, this.day, this.openingDate});
  factory _CellDto.fromJson(Map<String, dynamic> json) => _$CellDtoFromJson(json);

@override final  int? id;
@override final  String? name;
@override final  String? description;
@override final  bool mainCell;
@override final  String? address;
@override final  CityDto? city;
@override final  LocalityDto? locality;
@override final  int? day;
@override final  DateTime? openingDate;

/// Create a copy of CellDto
/// with the given fields replaced by the non-null parameter values.
@override @JsonKey(includeFromJson: false, includeToJson: false)
@pragma('vm:prefer-inline')
_$CellDtoCopyWith<_CellDto> get copyWith => __$CellDtoCopyWithImpl<_CellDto>(this, _$identity);

@override
Map<String, dynamic> toJson() {
  return _$CellDtoToJson(this, );
}

@override
bool operator ==(Object other) {
  return identical(this, other) || (other.runtimeType == runtimeType&&other is _CellDto&&(identical(other.id, id) || other.id == id)&&(identical(other.name, name) || other.name == name)&&(identical(other.description, description) || other.description == description)&&(identical(other.mainCell, mainCell) || other.mainCell == mainCell)&&(identical(other.address, address) || other.address == address)&&(identical(other.city, city) || other.city == city)&&(identical(other.locality, locality) || other.locality == locality)&&(identical(other.day, day) || other.day == day)&&(identical(other.openingDate, openingDate) || other.openingDate == openingDate));
}

@JsonKey(includeFromJson: false, includeToJson: false)
@override
int get hashCode => Object.hash(runtimeType,id,name,description,mainCell,address,city,locality,day,openingDate);

@override
String toString() {
  return 'CellDto(id: $id, name: $name, description: $description, mainCell: $mainCell, address: $address, city: $city, locality: $locality, day: $day, openingDate: $openingDate)';
}


}

/// @nodoc
abstract mixin class _$CellDtoCopyWith<$Res> implements $CellDtoCopyWith<$Res> {
  factory _$CellDtoCopyWith(_CellDto value, $Res Function(_CellDto) _then) = __$CellDtoCopyWithImpl;
@override @useResult
$Res call({
 int? id, String? name, String? description, bool mainCell, String? address, CityDto? city, LocalityDto? locality, int? day, DateTime? openingDate
});


@override $CityDtoCopyWith<$Res>? get city;@override $LocalityDtoCopyWith<$Res>? get locality;

}
/// @nodoc
class __$CellDtoCopyWithImpl<$Res>
    implements _$CellDtoCopyWith<$Res> {
  __$CellDtoCopyWithImpl(this._self, this._then);

  final _CellDto _self;
  final $Res Function(_CellDto) _then;

/// Create a copy of CellDto
/// with the given fields replaced by the non-null parameter values.
@override @pragma('vm:prefer-inline') $Res call({Object? id = freezed,Object? name = freezed,Object? description = freezed,Object? mainCell = null,Object? address = freezed,Object? city = freezed,Object? locality = freezed,Object? day = freezed,Object? openingDate = freezed,}) {
  return _then(_CellDto(
id: freezed == id ? _self.id : id // ignore: cast_nullable_to_non_nullable
as int?,name: freezed == name ? _self.name : name // ignore: cast_nullable_to_non_nullable
as String?,description: freezed == description ? _self.description : description // ignore: cast_nullable_to_non_nullable
as String?,mainCell: null == mainCell ? _self.mainCell : mainCell // ignore: cast_nullable_to_non_nullable
as bool,address: freezed == address ? _self.address : address // ignore: cast_nullable_to_non_nullable
as String?,city: freezed == city ? _self.city : city // ignore: cast_nullable_to_non_nullable
as CityDto?,locality: freezed == locality ? _self.locality : locality // ignore: cast_nullable_to_non_nullable
as LocalityDto?,day: freezed == day ? _self.day : day // ignore: cast_nullable_to_non_nullable
as int?,openingDate: freezed == openingDate ? _self.openingDate : openingDate // ignore: cast_nullable_to_non_nullable
as DateTime?,
  ));
}

/// Create a copy of CellDto
/// with the given fields replaced by the non-null parameter values.
@override
@pragma('vm:prefer-inline')
$CityDtoCopyWith<$Res>? get city {
    if (_self.city == null) {
    return null;
  }

  return $CityDtoCopyWith<$Res>(_self.city!, (value) {
    return _then(_self.copyWith(city: value));
  });
}/// Create a copy of CellDto
/// with the given fields replaced by the non-null parameter values.
@override
@pragma('vm:prefer-inline')
$LocalityDtoCopyWith<$Res>? get locality {
    if (_self.locality == null) {
    return null;
  }

  return $LocalityDtoCopyWith<$Res>(_self.locality!, (value) {
    return _then(_self.copyWith(locality: value));
  });
}
}


/// @nodoc
mixin _$CityDto {

 int get id; String? get name; List<LocalityDto>? get localities;
/// Create a copy of CityDto
/// with the given fields replaced by the non-null parameter values.
@JsonKey(includeFromJson: false, includeToJson: false)
@pragma('vm:prefer-inline')
$CityDtoCopyWith<CityDto> get copyWith => _$CityDtoCopyWithImpl<CityDto>(this as CityDto, _$identity);

  /// Serializes this CityDto to a JSON map.
  Map<String, dynamic> toJson();


@override
bool operator ==(Object other) {
  return identical(this, other) || (other.runtimeType == runtimeType&&other is CityDto&&(identical(other.id, id) || other.id == id)&&(identical(other.name, name) || other.name == name)&&const DeepCollectionEquality().equals(other.localities, localities));
}

@JsonKey(includeFromJson: false, includeToJson: false)
@override
int get hashCode => Object.hash(runtimeType,id,name,const DeepCollectionEquality().hash(localities));

@override
String toString() {
  return 'CityDto(id: $id, name: $name, localities: $localities)';
}


}

/// @nodoc
abstract mixin class $CityDtoCopyWith<$Res>  {
  factory $CityDtoCopyWith(CityDto value, $Res Function(CityDto) _then) = _$CityDtoCopyWithImpl;
@useResult
$Res call({
 int id, String? name, List<LocalityDto>? localities
});




}
/// @nodoc
class _$CityDtoCopyWithImpl<$Res>
    implements $CityDtoCopyWith<$Res> {
  _$CityDtoCopyWithImpl(this._self, this._then);

  final CityDto _self;
  final $Res Function(CityDto) _then;

/// Create a copy of CityDto
/// with the given fields replaced by the non-null parameter values.
@pragma('vm:prefer-inline') @override $Res call({Object? id = null,Object? name = freezed,Object? localities = freezed,}) {
  return _then(_self.copyWith(
id: null == id ? _self.id : id // ignore: cast_nullable_to_non_nullable
as int,name: freezed == name ? _self.name : name // ignore: cast_nullable_to_non_nullable
as String?,localities: freezed == localities ? _self.localities : localities // ignore: cast_nullable_to_non_nullable
as List<LocalityDto>?,
  ));
}

}


/// Adds pattern-matching-related methods to [CityDto].
extension CityDtoPatterns on CityDto {
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

@optionalTypeArgs TResult maybeMap<TResult extends Object?>(TResult Function( _CityDto value)?  $default,{required TResult orElse(),}){
final _that = this;
switch (_that) {
case _CityDto() when $default != null:
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

@optionalTypeArgs TResult map<TResult extends Object?>(TResult Function( _CityDto value)  $default,){
final _that = this;
switch (_that) {
case _CityDto():
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

@optionalTypeArgs TResult? mapOrNull<TResult extends Object?>(TResult? Function( _CityDto value)?  $default,){
final _that = this;
switch (_that) {
case _CityDto() when $default != null:
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

@optionalTypeArgs TResult maybeWhen<TResult extends Object?>(TResult Function( int id,  String? name,  List<LocalityDto>? localities)?  $default,{required TResult orElse(),}) {final _that = this;
switch (_that) {
case _CityDto() when $default != null:
return $default(_that.id,_that.name,_that.localities);case _:
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

@optionalTypeArgs TResult when<TResult extends Object?>(TResult Function( int id,  String? name,  List<LocalityDto>? localities)  $default,) {final _that = this;
switch (_that) {
case _CityDto():
return $default(_that.id,_that.name,_that.localities);case _:
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

@optionalTypeArgs TResult? whenOrNull<TResult extends Object?>(TResult? Function( int id,  String? name,  List<LocalityDto>? localities)?  $default,) {final _that = this;
switch (_that) {
case _CityDto() when $default != null:
return $default(_that.id,_that.name,_that.localities);case _:
  return null;

}
}

}

/// @nodoc
@JsonSerializable()

class _CityDto implements CityDto {
  const _CityDto({required this.id, required this.name, final  List<LocalityDto>? localities}): _localities = localities;
  factory _CityDto.fromJson(Map<String, dynamic> json) => _$CityDtoFromJson(json);

@override final  int id;
@override final  String? name;
 final  List<LocalityDto>? _localities;
@override List<LocalityDto>? get localities {
  final value = _localities;
  if (value == null) return null;
  if (_localities is EqualUnmodifiableListView) return _localities;
  // ignore: implicit_dynamic_type
  return EqualUnmodifiableListView(value);
}


/// Create a copy of CityDto
/// with the given fields replaced by the non-null parameter values.
@override @JsonKey(includeFromJson: false, includeToJson: false)
@pragma('vm:prefer-inline')
_$CityDtoCopyWith<_CityDto> get copyWith => __$CityDtoCopyWithImpl<_CityDto>(this, _$identity);

@override
Map<String, dynamic> toJson() {
  return _$CityDtoToJson(this, );
}

@override
bool operator ==(Object other) {
  return identical(this, other) || (other.runtimeType == runtimeType&&other is _CityDto&&(identical(other.id, id) || other.id == id)&&(identical(other.name, name) || other.name == name)&&const DeepCollectionEquality().equals(other._localities, _localities));
}

@JsonKey(includeFromJson: false, includeToJson: false)
@override
int get hashCode => Object.hash(runtimeType,id,name,const DeepCollectionEquality().hash(_localities));

@override
String toString() {
  return 'CityDto(id: $id, name: $name, localities: $localities)';
}


}

/// @nodoc
abstract mixin class _$CityDtoCopyWith<$Res> implements $CityDtoCopyWith<$Res> {
  factory _$CityDtoCopyWith(_CityDto value, $Res Function(_CityDto) _then) = __$CityDtoCopyWithImpl;
@override @useResult
$Res call({
 int id, String? name, List<LocalityDto>? localities
});




}
/// @nodoc
class __$CityDtoCopyWithImpl<$Res>
    implements _$CityDtoCopyWith<$Res> {
  __$CityDtoCopyWithImpl(this._self, this._then);

  final _CityDto _self;
  final $Res Function(_CityDto) _then;

/// Create a copy of CityDto
/// with the given fields replaced by the non-null parameter values.
@override @pragma('vm:prefer-inline') $Res call({Object? id = null,Object? name = freezed,Object? localities = freezed,}) {
  return _then(_CityDto(
id: null == id ? _self.id : id // ignore: cast_nullable_to_non_nullable
as int,name: freezed == name ? _self.name : name // ignore: cast_nullable_to_non_nullable
as String?,localities: freezed == localities ? _self._localities : localities // ignore: cast_nullable_to_non_nullable
as List<LocalityDto>?,
  ));
}


}


/// @nodoc
mixin _$LocalityDto {

 int get id; String? get name;
/// Create a copy of LocalityDto
/// with the given fields replaced by the non-null parameter values.
@JsonKey(includeFromJson: false, includeToJson: false)
@pragma('vm:prefer-inline')
$LocalityDtoCopyWith<LocalityDto> get copyWith => _$LocalityDtoCopyWithImpl<LocalityDto>(this as LocalityDto, _$identity);

  /// Serializes this LocalityDto to a JSON map.
  Map<String, dynamic> toJson();


@override
bool operator ==(Object other) {
  return identical(this, other) || (other.runtimeType == runtimeType&&other is LocalityDto&&(identical(other.id, id) || other.id == id)&&(identical(other.name, name) || other.name == name));
}

@JsonKey(includeFromJson: false, includeToJson: false)
@override
int get hashCode => Object.hash(runtimeType,id,name);

@override
String toString() {
  return 'LocalityDto(id: $id, name: $name)';
}


}

/// @nodoc
abstract mixin class $LocalityDtoCopyWith<$Res>  {
  factory $LocalityDtoCopyWith(LocalityDto value, $Res Function(LocalityDto) _then) = _$LocalityDtoCopyWithImpl;
@useResult
$Res call({
 int id, String? name
});




}
/// @nodoc
class _$LocalityDtoCopyWithImpl<$Res>
    implements $LocalityDtoCopyWith<$Res> {
  _$LocalityDtoCopyWithImpl(this._self, this._then);

  final LocalityDto _self;
  final $Res Function(LocalityDto) _then;

/// Create a copy of LocalityDto
/// with the given fields replaced by the non-null parameter values.
@pragma('vm:prefer-inline') @override $Res call({Object? id = null,Object? name = freezed,}) {
  return _then(_self.copyWith(
id: null == id ? _self.id : id // ignore: cast_nullable_to_non_nullable
as int,name: freezed == name ? _self.name : name // ignore: cast_nullable_to_non_nullable
as String?,
  ));
}

}


/// Adds pattern-matching-related methods to [LocalityDto].
extension LocalityDtoPatterns on LocalityDto {
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

@optionalTypeArgs TResult maybeMap<TResult extends Object?>(TResult Function( _LocalityDto value)?  $default,{required TResult orElse(),}){
final _that = this;
switch (_that) {
case _LocalityDto() when $default != null:
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

@optionalTypeArgs TResult map<TResult extends Object?>(TResult Function( _LocalityDto value)  $default,){
final _that = this;
switch (_that) {
case _LocalityDto():
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

@optionalTypeArgs TResult? mapOrNull<TResult extends Object?>(TResult? Function( _LocalityDto value)?  $default,){
final _that = this;
switch (_that) {
case _LocalityDto() when $default != null:
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

@optionalTypeArgs TResult maybeWhen<TResult extends Object?>(TResult Function( int id,  String? name)?  $default,{required TResult orElse(),}) {final _that = this;
switch (_that) {
case _LocalityDto() when $default != null:
return $default(_that.id,_that.name);case _:
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

@optionalTypeArgs TResult when<TResult extends Object?>(TResult Function( int id,  String? name)  $default,) {final _that = this;
switch (_that) {
case _LocalityDto():
return $default(_that.id,_that.name);case _:
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

@optionalTypeArgs TResult? whenOrNull<TResult extends Object?>(TResult? Function( int id,  String? name)?  $default,) {final _that = this;
switch (_that) {
case _LocalityDto() when $default != null:
return $default(_that.id,_that.name);case _:
  return null;

}
}

}

/// @nodoc
@JsonSerializable()

class _LocalityDto implements LocalityDto {
  const _LocalityDto({required this.id, required this.name});
  factory _LocalityDto.fromJson(Map<String, dynamic> json) => _$LocalityDtoFromJson(json);

@override final  int id;
@override final  String? name;

/// Create a copy of LocalityDto
/// with the given fields replaced by the non-null parameter values.
@override @JsonKey(includeFromJson: false, includeToJson: false)
@pragma('vm:prefer-inline')
_$LocalityDtoCopyWith<_LocalityDto> get copyWith => __$LocalityDtoCopyWithImpl<_LocalityDto>(this, _$identity);

@override
Map<String, dynamic> toJson() {
  return _$LocalityDtoToJson(this, );
}

@override
bool operator ==(Object other) {
  return identical(this, other) || (other.runtimeType == runtimeType&&other is _LocalityDto&&(identical(other.id, id) || other.id == id)&&(identical(other.name, name) || other.name == name));
}

@JsonKey(includeFromJson: false, includeToJson: false)
@override
int get hashCode => Object.hash(runtimeType,id,name);

@override
String toString() {
  return 'LocalityDto(id: $id, name: $name)';
}


}

/// @nodoc
abstract mixin class _$LocalityDtoCopyWith<$Res> implements $LocalityDtoCopyWith<$Res> {
  factory _$LocalityDtoCopyWith(_LocalityDto value, $Res Function(_LocalityDto) _then) = __$LocalityDtoCopyWithImpl;
@override @useResult
$Res call({
 int id, String? name
});




}
/// @nodoc
class __$LocalityDtoCopyWithImpl<$Res>
    implements _$LocalityDtoCopyWith<$Res> {
  __$LocalityDtoCopyWithImpl(this._self, this._then);

  final _LocalityDto _self;
  final $Res Function(_LocalityDto) _then;

/// Create a copy of LocalityDto
/// with the given fields replaced by the non-null parameter values.
@override @pragma('vm:prefer-inline') $Res call({Object? id = null,Object? name = freezed,}) {
  return _then(_LocalityDto(
id: null == id ? _self.id : id // ignore: cast_nullable_to_non_nullable
as int,name: freezed == name ? _self.name : name // ignore: cast_nullable_to_non_nullable
as String?,
  ));
}


}

// dart format on
