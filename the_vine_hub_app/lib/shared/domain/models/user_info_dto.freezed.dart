// GENERATED CODE - DO NOT MODIFY BY HAND
// coverage:ignore-file
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'user_info_dto.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

// dart format off
T _$identity<T>(T value) => value;

/// @nodoc
mixin _$UserInfoDto {

 String? get document; String? get name; String? get lastName; String? get phone; int? get gender; int? get maritalStatus; String? get photo; int? get cellId; String? get email; String? get address; String? get city; String? get locality; String? get neighborhood; String? get profession; String? get occupation; DateTime? get birthday; int? get educationalLevel; int? get accessType; List<PartialUserInfoDto>? get leaders;
/// Create a copy of UserInfoDto
/// with the given fields replaced by the non-null parameter values.
@JsonKey(includeFromJson: false, includeToJson: false)
@pragma('vm:prefer-inline')
$UserInfoDtoCopyWith<UserInfoDto> get copyWith => _$UserInfoDtoCopyWithImpl<UserInfoDto>(this as UserInfoDto, _$identity);

  /// Serializes this UserInfoDto to a JSON map.
  Map<String, dynamic> toJson();


@override
bool operator ==(Object other) {
  return identical(this, other) || (other.runtimeType == runtimeType&&other is UserInfoDto&&(identical(other.document, document) || other.document == document)&&(identical(other.name, name) || other.name == name)&&(identical(other.lastName, lastName) || other.lastName == lastName)&&(identical(other.phone, phone) || other.phone == phone)&&(identical(other.gender, gender) || other.gender == gender)&&(identical(other.maritalStatus, maritalStatus) || other.maritalStatus == maritalStatus)&&(identical(other.photo, photo) || other.photo == photo)&&(identical(other.cellId, cellId) || other.cellId == cellId)&&(identical(other.email, email) || other.email == email)&&(identical(other.address, address) || other.address == address)&&(identical(other.city, city) || other.city == city)&&(identical(other.locality, locality) || other.locality == locality)&&(identical(other.neighborhood, neighborhood) || other.neighborhood == neighborhood)&&(identical(other.profession, profession) || other.profession == profession)&&(identical(other.occupation, occupation) || other.occupation == occupation)&&(identical(other.birthday, birthday) || other.birthday == birthday)&&(identical(other.educationalLevel, educationalLevel) || other.educationalLevel == educationalLevel)&&(identical(other.accessType, accessType) || other.accessType == accessType)&&const DeepCollectionEquality().equals(other.leaders, leaders));
}

@JsonKey(includeFromJson: false, includeToJson: false)
@override
int get hashCode => Object.hashAll([runtimeType,document,name,lastName,phone,gender,maritalStatus,photo,cellId,email,address,city,locality,neighborhood,profession,occupation,birthday,educationalLevel,accessType,const DeepCollectionEquality().hash(leaders)]);

@override
String toString() {
  return 'UserInfoDto(document: $document, name: $name, lastName: $lastName, phone: $phone, gender: $gender, maritalStatus: $maritalStatus, photo: $photo, cellId: $cellId, email: $email, address: $address, city: $city, locality: $locality, neighborhood: $neighborhood, profession: $profession, occupation: $occupation, birthday: $birthday, educationalLevel: $educationalLevel, accessType: $accessType, leaders: $leaders)';
}


}

/// @nodoc
abstract mixin class $UserInfoDtoCopyWith<$Res>  {
  factory $UserInfoDtoCopyWith(UserInfoDto value, $Res Function(UserInfoDto) _then) = _$UserInfoDtoCopyWithImpl;
@useResult
$Res call({
 String? document, String? name, String? lastName, String? phone, int? gender, int? maritalStatus, String? photo, int? cellId, String? email, String? address, String? city, String? locality, String? neighborhood, String? profession, String? occupation, DateTime? birthday, int? educationalLevel, int? accessType, List<PartialUserInfoDto>? leaders
});




}
/// @nodoc
class _$UserInfoDtoCopyWithImpl<$Res>
    implements $UserInfoDtoCopyWith<$Res> {
  _$UserInfoDtoCopyWithImpl(this._self, this._then);

  final UserInfoDto _self;
  final $Res Function(UserInfoDto) _then;

/// Create a copy of UserInfoDto
/// with the given fields replaced by the non-null parameter values.
@pragma('vm:prefer-inline') @override $Res call({Object? document = freezed,Object? name = freezed,Object? lastName = freezed,Object? phone = freezed,Object? gender = freezed,Object? maritalStatus = freezed,Object? photo = freezed,Object? cellId = freezed,Object? email = freezed,Object? address = freezed,Object? city = freezed,Object? locality = freezed,Object? neighborhood = freezed,Object? profession = freezed,Object? occupation = freezed,Object? birthday = freezed,Object? educationalLevel = freezed,Object? accessType = freezed,Object? leaders = freezed,}) {
  return _then(_self.copyWith(
document: freezed == document ? _self.document : document // ignore: cast_nullable_to_non_nullable
as String?,name: freezed == name ? _self.name : name // ignore: cast_nullable_to_non_nullable
as String?,lastName: freezed == lastName ? _self.lastName : lastName // ignore: cast_nullable_to_non_nullable
as String?,phone: freezed == phone ? _self.phone : phone // ignore: cast_nullable_to_non_nullable
as String?,gender: freezed == gender ? _self.gender : gender // ignore: cast_nullable_to_non_nullable
as int?,maritalStatus: freezed == maritalStatus ? _self.maritalStatus : maritalStatus // ignore: cast_nullable_to_non_nullable
as int?,photo: freezed == photo ? _self.photo : photo // ignore: cast_nullable_to_non_nullable
as String?,cellId: freezed == cellId ? _self.cellId : cellId // ignore: cast_nullable_to_non_nullable
as int?,email: freezed == email ? _self.email : email // ignore: cast_nullable_to_non_nullable
as String?,address: freezed == address ? _self.address : address // ignore: cast_nullable_to_non_nullable
as String?,city: freezed == city ? _self.city : city // ignore: cast_nullable_to_non_nullable
as String?,locality: freezed == locality ? _self.locality : locality // ignore: cast_nullable_to_non_nullable
as String?,neighborhood: freezed == neighborhood ? _self.neighborhood : neighborhood // ignore: cast_nullable_to_non_nullable
as String?,profession: freezed == profession ? _self.profession : profession // ignore: cast_nullable_to_non_nullable
as String?,occupation: freezed == occupation ? _self.occupation : occupation // ignore: cast_nullable_to_non_nullable
as String?,birthday: freezed == birthday ? _self.birthday : birthday // ignore: cast_nullable_to_non_nullable
as DateTime?,educationalLevel: freezed == educationalLevel ? _self.educationalLevel : educationalLevel // ignore: cast_nullable_to_non_nullable
as int?,accessType: freezed == accessType ? _self.accessType : accessType // ignore: cast_nullable_to_non_nullable
as int?,leaders: freezed == leaders ? _self.leaders : leaders // ignore: cast_nullable_to_non_nullable
as List<PartialUserInfoDto>?,
  ));
}

}


/// Adds pattern-matching-related methods to [UserInfoDto].
extension UserInfoDtoPatterns on UserInfoDto {
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

@optionalTypeArgs TResult maybeMap<TResult extends Object?>(TResult Function( _UserInfoDto value)?  $default,{required TResult orElse(),}){
final _that = this;
switch (_that) {
case _UserInfoDto() when $default != null:
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

@optionalTypeArgs TResult map<TResult extends Object?>(TResult Function( _UserInfoDto value)  $default,){
final _that = this;
switch (_that) {
case _UserInfoDto():
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

@optionalTypeArgs TResult? mapOrNull<TResult extends Object?>(TResult? Function( _UserInfoDto value)?  $default,){
final _that = this;
switch (_that) {
case _UserInfoDto() when $default != null:
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

@optionalTypeArgs TResult maybeWhen<TResult extends Object?>(TResult Function( String? document,  String? name,  String? lastName,  String? phone,  int? gender,  int? maritalStatus,  String? photo,  int? cellId,  String? email,  String? address,  String? city,  String? locality,  String? neighborhood,  String? profession,  String? occupation,  DateTime? birthday,  int? educationalLevel,  int? accessType,  List<PartialUserInfoDto>? leaders)?  $default,{required TResult orElse(),}) {final _that = this;
switch (_that) {
case _UserInfoDto() when $default != null:
return $default(_that.document,_that.name,_that.lastName,_that.phone,_that.gender,_that.maritalStatus,_that.photo,_that.cellId,_that.email,_that.address,_that.city,_that.locality,_that.neighborhood,_that.profession,_that.occupation,_that.birthday,_that.educationalLevel,_that.accessType,_that.leaders);case _:
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

@optionalTypeArgs TResult when<TResult extends Object?>(TResult Function( String? document,  String? name,  String? lastName,  String? phone,  int? gender,  int? maritalStatus,  String? photo,  int? cellId,  String? email,  String? address,  String? city,  String? locality,  String? neighborhood,  String? profession,  String? occupation,  DateTime? birthday,  int? educationalLevel,  int? accessType,  List<PartialUserInfoDto>? leaders)  $default,) {final _that = this;
switch (_that) {
case _UserInfoDto():
return $default(_that.document,_that.name,_that.lastName,_that.phone,_that.gender,_that.maritalStatus,_that.photo,_that.cellId,_that.email,_that.address,_that.city,_that.locality,_that.neighborhood,_that.profession,_that.occupation,_that.birthday,_that.educationalLevel,_that.accessType,_that.leaders);case _:
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

@optionalTypeArgs TResult? whenOrNull<TResult extends Object?>(TResult? Function( String? document,  String? name,  String? lastName,  String? phone,  int? gender,  int? maritalStatus,  String? photo,  int? cellId,  String? email,  String? address,  String? city,  String? locality,  String? neighborhood,  String? profession,  String? occupation,  DateTime? birthday,  int? educationalLevel,  int? accessType,  List<PartialUserInfoDto>? leaders)?  $default,) {final _that = this;
switch (_that) {
case _UserInfoDto() when $default != null:
return $default(_that.document,_that.name,_that.lastName,_that.phone,_that.gender,_that.maritalStatus,_that.photo,_that.cellId,_that.email,_that.address,_that.city,_that.locality,_that.neighborhood,_that.profession,_that.occupation,_that.birthday,_that.educationalLevel,_that.accessType,_that.leaders);case _:
  return null;

}
}

}

/// @nodoc
@JsonSerializable()

class _UserInfoDto extends UserInfoDto {
  const _UserInfoDto({this.document, this.name, this.lastName, this.phone, this.gender, this.maritalStatus, this.photo, this.cellId, this.email, this.address, this.city, this.locality, this.neighborhood, this.profession, this.occupation, this.birthday, this.educationalLevel, this.accessType, final  List<PartialUserInfoDto>? leaders}): _leaders = leaders,super._();
  factory _UserInfoDto.fromJson(Map<String, dynamic> json) => _$UserInfoDtoFromJson(json);

@override final  String? document;
@override final  String? name;
@override final  String? lastName;
@override final  String? phone;
@override final  int? gender;
@override final  int? maritalStatus;
@override final  String? photo;
@override final  int? cellId;
@override final  String? email;
@override final  String? address;
@override final  String? city;
@override final  String? locality;
@override final  String? neighborhood;
@override final  String? profession;
@override final  String? occupation;
@override final  DateTime? birthday;
@override final  int? educationalLevel;
@override final  int? accessType;
 final  List<PartialUserInfoDto>? _leaders;
@override List<PartialUserInfoDto>? get leaders {
  final value = _leaders;
  if (value == null) return null;
  if (_leaders is EqualUnmodifiableListView) return _leaders;
  // ignore: implicit_dynamic_type
  return EqualUnmodifiableListView(value);
}


/// Create a copy of UserInfoDto
/// with the given fields replaced by the non-null parameter values.
@override @JsonKey(includeFromJson: false, includeToJson: false)
@pragma('vm:prefer-inline')
_$UserInfoDtoCopyWith<_UserInfoDto> get copyWith => __$UserInfoDtoCopyWithImpl<_UserInfoDto>(this, _$identity);

@override
Map<String, dynamic> toJson() {
  return _$UserInfoDtoToJson(this, );
}

@override
bool operator ==(Object other) {
  return identical(this, other) || (other.runtimeType == runtimeType&&other is _UserInfoDto&&(identical(other.document, document) || other.document == document)&&(identical(other.name, name) || other.name == name)&&(identical(other.lastName, lastName) || other.lastName == lastName)&&(identical(other.phone, phone) || other.phone == phone)&&(identical(other.gender, gender) || other.gender == gender)&&(identical(other.maritalStatus, maritalStatus) || other.maritalStatus == maritalStatus)&&(identical(other.photo, photo) || other.photo == photo)&&(identical(other.cellId, cellId) || other.cellId == cellId)&&(identical(other.email, email) || other.email == email)&&(identical(other.address, address) || other.address == address)&&(identical(other.city, city) || other.city == city)&&(identical(other.locality, locality) || other.locality == locality)&&(identical(other.neighborhood, neighborhood) || other.neighborhood == neighborhood)&&(identical(other.profession, profession) || other.profession == profession)&&(identical(other.occupation, occupation) || other.occupation == occupation)&&(identical(other.birthday, birthday) || other.birthday == birthday)&&(identical(other.educationalLevel, educationalLevel) || other.educationalLevel == educationalLevel)&&(identical(other.accessType, accessType) || other.accessType == accessType)&&const DeepCollectionEquality().equals(other._leaders, _leaders));
}

@JsonKey(includeFromJson: false, includeToJson: false)
@override
int get hashCode => Object.hashAll([runtimeType,document,name,lastName,phone,gender,maritalStatus,photo,cellId,email,address,city,locality,neighborhood,profession,occupation,birthday,educationalLevel,accessType,const DeepCollectionEquality().hash(_leaders)]);

@override
String toString() {
  return 'UserInfoDto(document: $document, name: $name, lastName: $lastName, phone: $phone, gender: $gender, maritalStatus: $maritalStatus, photo: $photo, cellId: $cellId, email: $email, address: $address, city: $city, locality: $locality, neighborhood: $neighborhood, profession: $profession, occupation: $occupation, birthday: $birthday, educationalLevel: $educationalLevel, accessType: $accessType, leaders: $leaders)';
}


}

/// @nodoc
abstract mixin class _$UserInfoDtoCopyWith<$Res> implements $UserInfoDtoCopyWith<$Res> {
  factory _$UserInfoDtoCopyWith(_UserInfoDto value, $Res Function(_UserInfoDto) _then) = __$UserInfoDtoCopyWithImpl;
@override @useResult
$Res call({
 String? document, String? name, String? lastName, String? phone, int? gender, int? maritalStatus, String? photo, int? cellId, String? email, String? address, String? city, String? locality, String? neighborhood, String? profession, String? occupation, DateTime? birthday, int? educationalLevel, int? accessType, List<PartialUserInfoDto>? leaders
});




}
/// @nodoc
class __$UserInfoDtoCopyWithImpl<$Res>
    implements _$UserInfoDtoCopyWith<$Res> {
  __$UserInfoDtoCopyWithImpl(this._self, this._then);

  final _UserInfoDto _self;
  final $Res Function(_UserInfoDto) _then;

/// Create a copy of UserInfoDto
/// with the given fields replaced by the non-null parameter values.
@override @pragma('vm:prefer-inline') $Res call({Object? document = freezed,Object? name = freezed,Object? lastName = freezed,Object? phone = freezed,Object? gender = freezed,Object? maritalStatus = freezed,Object? photo = freezed,Object? cellId = freezed,Object? email = freezed,Object? address = freezed,Object? city = freezed,Object? locality = freezed,Object? neighborhood = freezed,Object? profession = freezed,Object? occupation = freezed,Object? birthday = freezed,Object? educationalLevel = freezed,Object? accessType = freezed,Object? leaders = freezed,}) {
  return _then(_UserInfoDto(
document: freezed == document ? _self.document : document // ignore: cast_nullable_to_non_nullable
as String?,name: freezed == name ? _self.name : name // ignore: cast_nullable_to_non_nullable
as String?,lastName: freezed == lastName ? _self.lastName : lastName // ignore: cast_nullable_to_non_nullable
as String?,phone: freezed == phone ? _self.phone : phone // ignore: cast_nullable_to_non_nullable
as String?,gender: freezed == gender ? _self.gender : gender // ignore: cast_nullable_to_non_nullable
as int?,maritalStatus: freezed == maritalStatus ? _self.maritalStatus : maritalStatus // ignore: cast_nullable_to_non_nullable
as int?,photo: freezed == photo ? _self.photo : photo // ignore: cast_nullable_to_non_nullable
as String?,cellId: freezed == cellId ? _self.cellId : cellId // ignore: cast_nullable_to_non_nullable
as int?,email: freezed == email ? _self.email : email // ignore: cast_nullable_to_non_nullable
as String?,address: freezed == address ? _self.address : address // ignore: cast_nullable_to_non_nullable
as String?,city: freezed == city ? _self.city : city // ignore: cast_nullable_to_non_nullable
as String?,locality: freezed == locality ? _self.locality : locality // ignore: cast_nullable_to_non_nullable
as String?,neighborhood: freezed == neighborhood ? _self.neighborhood : neighborhood // ignore: cast_nullable_to_non_nullable
as String?,profession: freezed == profession ? _self.profession : profession // ignore: cast_nullable_to_non_nullable
as String?,occupation: freezed == occupation ? _self.occupation : occupation // ignore: cast_nullable_to_non_nullable
as String?,birthday: freezed == birthday ? _self.birthday : birthday // ignore: cast_nullable_to_non_nullable
as DateTime?,educationalLevel: freezed == educationalLevel ? _self.educationalLevel : educationalLevel // ignore: cast_nullable_to_non_nullable
as int?,accessType: freezed == accessType ? _self.accessType : accessType // ignore: cast_nullable_to_non_nullable
as int?,leaders: freezed == leaders ? _self._leaders : leaders // ignore: cast_nullable_to_non_nullable
as List<PartialUserInfoDto>?,
  ));
}


}

// dart format on
