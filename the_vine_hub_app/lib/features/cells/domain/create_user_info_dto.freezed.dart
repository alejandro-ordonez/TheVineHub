// GENERATED CODE - DO NOT MODIFY BY HAND
// coverage:ignore-file
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'create_user_info_dto.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

// dart format off
T _$identity<T>(T value) => value;

/// @nodoc
mixin _$CreateUserInfoDto {

 String get document; String get name; String get lastName; String? get password; bool get isUpdate; String get phone; int get gender; String get city; String? get locality; String get neighborhood; String get address; String get email; String get profession; String get occupation; DateTime? get birthday; int? get maritalStatus; int? get educationalLevel; int get accessType;
/// Create a copy of CreateUserInfoDto
/// with the given fields replaced by the non-null parameter values.
@JsonKey(includeFromJson: false, includeToJson: false)
@pragma('vm:prefer-inline')
$CreateUserInfoDtoCopyWith<CreateUserInfoDto> get copyWith => _$CreateUserInfoDtoCopyWithImpl<CreateUserInfoDto>(this as CreateUserInfoDto, _$identity);

  /// Serializes this CreateUserInfoDto to a JSON map.
  Map<String, dynamic> toJson();


@override
bool operator ==(Object other) {
  return identical(this, other) || (other.runtimeType == runtimeType&&other is CreateUserInfoDto&&(identical(other.document, document) || other.document == document)&&(identical(other.name, name) || other.name == name)&&(identical(other.lastName, lastName) || other.lastName == lastName)&&(identical(other.password, password) || other.password == password)&&(identical(other.isUpdate, isUpdate) || other.isUpdate == isUpdate)&&(identical(other.phone, phone) || other.phone == phone)&&(identical(other.gender, gender) || other.gender == gender)&&(identical(other.city, city) || other.city == city)&&(identical(other.locality, locality) || other.locality == locality)&&(identical(other.neighborhood, neighborhood) || other.neighborhood == neighborhood)&&(identical(other.address, address) || other.address == address)&&(identical(other.email, email) || other.email == email)&&(identical(other.profession, profession) || other.profession == profession)&&(identical(other.occupation, occupation) || other.occupation == occupation)&&(identical(other.birthday, birthday) || other.birthday == birthday)&&(identical(other.maritalStatus, maritalStatus) || other.maritalStatus == maritalStatus)&&(identical(other.educationalLevel, educationalLevel) || other.educationalLevel == educationalLevel)&&(identical(other.accessType, accessType) || other.accessType == accessType));
}

@JsonKey(includeFromJson: false, includeToJson: false)
@override
int get hashCode => Object.hash(runtimeType,document,name,lastName,password,isUpdate,phone,gender,city,locality,neighborhood,address,email,profession,occupation,birthday,maritalStatus,educationalLevel,accessType);

@override
String toString() {
  return 'CreateUserInfoDto(document: $document, name: $name, lastName: $lastName, password: $password, isUpdate: $isUpdate, phone: $phone, gender: $gender, city: $city, locality: $locality, neighborhood: $neighborhood, address: $address, email: $email, profession: $profession, occupation: $occupation, birthday: $birthday, maritalStatus: $maritalStatus, educationalLevel: $educationalLevel, accessType: $accessType)';
}


}

/// @nodoc
abstract mixin class $CreateUserInfoDtoCopyWith<$Res>  {
  factory $CreateUserInfoDtoCopyWith(CreateUserInfoDto value, $Res Function(CreateUserInfoDto) _then) = _$CreateUserInfoDtoCopyWithImpl;
@useResult
$Res call({
 String document, String name, String lastName, String? password, bool isUpdate, String phone, int gender, String city, String? locality, String neighborhood, String address, String email, String profession, String occupation, DateTime? birthday, int? maritalStatus, int? educationalLevel, int accessType
});




}
/// @nodoc
class _$CreateUserInfoDtoCopyWithImpl<$Res>
    implements $CreateUserInfoDtoCopyWith<$Res> {
  _$CreateUserInfoDtoCopyWithImpl(this._self, this._then);

  final CreateUserInfoDto _self;
  final $Res Function(CreateUserInfoDto) _then;

/// Create a copy of CreateUserInfoDto
/// with the given fields replaced by the non-null parameter values.
@pragma('vm:prefer-inline') @override $Res call({Object? document = null,Object? name = null,Object? lastName = null,Object? password = freezed,Object? isUpdate = null,Object? phone = null,Object? gender = null,Object? city = null,Object? locality = freezed,Object? neighborhood = null,Object? address = null,Object? email = null,Object? profession = null,Object? occupation = null,Object? birthday = freezed,Object? maritalStatus = freezed,Object? educationalLevel = freezed,Object? accessType = null,}) {
  return _then(_self.copyWith(
document: null == document ? _self.document : document // ignore: cast_nullable_to_non_nullable
as String,name: null == name ? _self.name : name // ignore: cast_nullable_to_non_nullable
as String,lastName: null == lastName ? _self.lastName : lastName // ignore: cast_nullable_to_non_nullable
as String,password: freezed == password ? _self.password : password // ignore: cast_nullable_to_non_nullable
as String?,isUpdate: null == isUpdate ? _self.isUpdate : isUpdate // ignore: cast_nullable_to_non_nullable
as bool,phone: null == phone ? _self.phone : phone // ignore: cast_nullable_to_non_nullable
as String,gender: null == gender ? _self.gender : gender // ignore: cast_nullable_to_non_nullable
as int,city: null == city ? _self.city : city // ignore: cast_nullable_to_non_nullable
as String,locality: freezed == locality ? _self.locality : locality // ignore: cast_nullable_to_non_nullable
as String?,neighborhood: null == neighborhood ? _self.neighborhood : neighborhood // ignore: cast_nullable_to_non_nullable
as String,address: null == address ? _self.address : address // ignore: cast_nullable_to_non_nullable
as String,email: null == email ? _self.email : email // ignore: cast_nullable_to_non_nullable
as String,profession: null == profession ? _self.profession : profession // ignore: cast_nullable_to_non_nullable
as String,occupation: null == occupation ? _self.occupation : occupation // ignore: cast_nullable_to_non_nullable
as String,birthday: freezed == birthday ? _self.birthday : birthday // ignore: cast_nullable_to_non_nullable
as DateTime?,maritalStatus: freezed == maritalStatus ? _self.maritalStatus : maritalStatus // ignore: cast_nullable_to_non_nullable
as int?,educationalLevel: freezed == educationalLevel ? _self.educationalLevel : educationalLevel // ignore: cast_nullable_to_non_nullable
as int?,accessType: null == accessType ? _self.accessType : accessType // ignore: cast_nullable_to_non_nullable
as int,
  ));
}

}


/// Adds pattern-matching-related methods to [CreateUserInfoDto].
extension CreateUserInfoDtoPatterns on CreateUserInfoDto {
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

@optionalTypeArgs TResult maybeMap<TResult extends Object?>(TResult Function( _CreateUserInfoDto value)?  $default,{required TResult orElse(),}){
final _that = this;
switch (_that) {
case _CreateUserInfoDto() when $default != null:
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

@optionalTypeArgs TResult map<TResult extends Object?>(TResult Function( _CreateUserInfoDto value)  $default,){
final _that = this;
switch (_that) {
case _CreateUserInfoDto():
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

@optionalTypeArgs TResult? mapOrNull<TResult extends Object?>(TResult? Function( _CreateUserInfoDto value)?  $default,){
final _that = this;
switch (_that) {
case _CreateUserInfoDto() when $default != null:
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

@optionalTypeArgs TResult maybeWhen<TResult extends Object?>(TResult Function( String document,  String name,  String lastName,  String? password,  bool isUpdate,  String phone,  int gender,  String city,  String? locality,  String neighborhood,  String address,  String email,  String profession,  String occupation,  DateTime? birthday,  int? maritalStatus,  int? educationalLevel,  int accessType)?  $default,{required TResult orElse(),}) {final _that = this;
switch (_that) {
case _CreateUserInfoDto() when $default != null:
return $default(_that.document,_that.name,_that.lastName,_that.password,_that.isUpdate,_that.phone,_that.gender,_that.city,_that.locality,_that.neighborhood,_that.address,_that.email,_that.profession,_that.occupation,_that.birthday,_that.maritalStatus,_that.educationalLevel,_that.accessType);case _:
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

@optionalTypeArgs TResult when<TResult extends Object?>(TResult Function( String document,  String name,  String lastName,  String? password,  bool isUpdate,  String phone,  int gender,  String city,  String? locality,  String neighborhood,  String address,  String email,  String profession,  String occupation,  DateTime? birthday,  int? maritalStatus,  int? educationalLevel,  int accessType)  $default,) {final _that = this;
switch (_that) {
case _CreateUserInfoDto():
return $default(_that.document,_that.name,_that.lastName,_that.password,_that.isUpdate,_that.phone,_that.gender,_that.city,_that.locality,_that.neighborhood,_that.address,_that.email,_that.profession,_that.occupation,_that.birthday,_that.maritalStatus,_that.educationalLevel,_that.accessType);case _:
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

@optionalTypeArgs TResult? whenOrNull<TResult extends Object?>(TResult? Function( String document,  String name,  String lastName,  String? password,  bool isUpdate,  String phone,  int gender,  String city,  String? locality,  String neighborhood,  String address,  String email,  String profession,  String occupation,  DateTime? birthday,  int? maritalStatus,  int? educationalLevel,  int accessType)?  $default,) {final _that = this;
switch (_that) {
case _CreateUserInfoDto() when $default != null:
return $default(_that.document,_that.name,_that.lastName,_that.password,_that.isUpdate,_that.phone,_that.gender,_that.city,_that.locality,_that.neighborhood,_that.address,_that.email,_that.profession,_that.occupation,_that.birthday,_that.maritalStatus,_that.educationalLevel,_that.accessType);case _:
  return null;

}
}

}

/// @nodoc
@JsonSerializable()

class _CreateUserInfoDto implements CreateUserInfoDto {
  const _CreateUserInfoDto({required this.document, required this.name, required this.lastName, this.password, this.isUpdate = false, required this.phone, required this.gender, required this.city, this.locality, required this.neighborhood, required this.address, this.email = '', this.profession = '', this.occupation = '', this.birthday, this.maritalStatus, this.educationalLevel, this.accessType = 0});
  factory _CreateUserInfoDto.fromJson(Map<String, dynamic> json) => _$CreateUserInfoDtoFromJson(json);

@override final  String document;
@override final  String name;
@override final  String lastName;
@override final  String? password;
@override@JsonKey() final  bool isUpdate;
@override final  String phone;
@override final  int gender;
@override final  String city;
@override final  String? locality;
@override final  String neighborhood;
@override final  String address;
@override@JsonKey() final  String email;
@override@JsonKey() final  String profession;
@override@JsonKey() final  String occupation;
@override final  DateTime? birthday;
@override final  int? maritalStatus;
@override final  int? educationalLevel;
@override@JsonKey() final  int accessType;

/// Create a copy of CreateUserInfoDto
/// with the given fields replaced by the non-null parameter values.
@override @JsonKey(includeFromJson: false, includeToJson: false)
@pragma('vm:prefer-inline')
_$CreateUserInfoDtoCopyWith<_CreateUserInfoDto> get copyWith => __$CreateUserInfoDtoCopyWithImpl<_CreateUserInfoDto>(this, _$identity);

@override
Map<String, dynamic> toJson() {
  return _$CreateUserInfoDtoToJson(this, );
}

@override
bool operator ==(Object other) {
  return identical(this, other) || (other.runtimeType == runtimeType&&other is _CreateUserInfoDto&&(identical(other.document, document) || other.document == document)&&(identical(other.name, name) || other.name == name)&&(identical(other.lastName, lastName) || other.lastName == lastName)&&(identical(other.password, password) || other.password == password)&&(identical(other.isUpdate, isUpdate) || other.isUpdate == isUpdate)&&(identical(other.phone, phone) || other.phone == phone)&&(identical(other.gender, gender) || other.gender == gender)&&(identical(other.city, city) || other.city == city)&&(identical(other.locality, locality) || other.locality == locality)&&(identical(other.neighborhood, neighborhood) || other.neighborhood == neighborhood)&&(identical(other.address, address) || other.address == address)&&(identical(other.email, email) || other.email == email)&&(identical(other.profession, profession) || other.profession == profession)&&(identical(other.occupation, occupation) || other.occupation == occupation)&&(identical(other.birthday, birthday) || other.birthday == birthday)&&(identical(other.maritalStatus, maritalStatus) || other.maritalStatus == maritalStatus)&&(identical(other.educationalLevel, educationalLevel) || other.educationalLevel == educationalLevel)&&(identical(other.accessType, accessType) || other.accessType == accessType));
}

@JsonKey(includeFromJson: false, includeToJson: false)
@override
int get hashCode => Object.hash(runtimeType,document,name,lastName,password,isUpdate,phone,gender,city,locality,neighborhood,address,email,profession,occupation,birthday,maritalStatus,educationalLevel,accessType);

@override
String toString() {
  return 'CreateUserInfoDto(document: $document, name: $name, lastName: $lastName, password: $password, isUpdate: $isUpdate, phone: $phone, gender: $gender, city: $city, locality: $locality, neighborhood: $neighborhood, address: $address, email: $email, profession: $profession, occupation: $occupation, birthday: $birthday, maritalStatus: $maritalStatus, educationalLevel: $educationalLevel, accessType: $accessType)';
}


}

/// @nodoc
abstract mixin class _$CreateUserInfoDtoCopyWith<$Res> implements $CreateUserInfoDtoCopyWith<$Res> {
  factory _$CreateUserInfoDtoCopyWith(_CreateUserInfoDto value, $Res Function(_CreateUserInfoDto) _then) = __$CreateUserInfoDtoCopyWithImpl;
@override @useResult
$Res call({
 String document, String name, String lastName, String? password, bool isUpdate, String phone, int gender, String city, String? locality, String neighborhood, String address, String email, String profession, String occupation, DateTime? birthday, int? maritalStatus, int? educationalLevel, int accessType
});




}
/// @nodoc
class __$CreateUserInfoDtoCopyWithImpl<$Res>
    implements _$CreateUserInfoDtoCopyWith<$Res> {
  __$CreateUserInfoDtoCopyWithImpl(this._self, this._then);

  final _CreateUserInfoDto _self;
  final $Res Function(_CreateUserInfoDto) _then;

/// Create a copy of CreateUserInfoDto
/// with the given fields replaced by the non-null parameter values.
@override @pragma('vm:prefer-inline') $Res call({Object? document = null,Object? name = null,Object? lastName = null,Object? password = freezed,Object? isUpdate = null,Object? phone = null,Object? gender = null,Object? city = null,Object? locality = freezed,Object? neighborhood = null,Object? address = null,Object? email = null,Object? profession = null,Object? occupation = null,Object? birthday = freezed,Object? maritalStatus = freezed,Object? educationalLevel = freezed,Object? accessType = null,}) {
  return _then(_CreateUserInfoDto(
document: null == document ? _self.document : document // ignore: cast_nullable_to_non_nullable
as String,name: null == name ? _self.name : name // ignore: cast_nullable_to_non_nullable
as String,lastName: null == lastName ? _self.lastName : lastName // ignore: cast_nullable_to_non_nullable
as String,password: freezed == password ? _self.password : password // ignore: cast_nullable_to_non_nullable
as String?,isUpdate: null == isUpdate ? _self.isUpdate : isUpdate // ignore: cast_nullable_to_non_nullable
as bool,phone: null == phone ? _self.phone : phone // ignore: cast_nullable_to_non_nullable
as String,gender: null == gender ? _self.gender : gender // ignore: cast_nullable_to_non_nullable
as int,city: null == city ? _self.city : city // ignore: cast_nullable_to_non_nullable
as String,locality: freezed == locality ? _self.locality : locality // ignore: cast_nullable_to_non_nullable
as String?,neighborhood: null == neighborhood ? _self.neighborhood : neighborhood // ignore: cast_nullable_to_non_nullable
as String,address: null == address ? _self.address : address // ignore: cast_nullable_to_non_nullable
as String,email: null == email ? _self.email : email // ignore: cast_nullable_to_non_nullable
as String,profession: null == profession ? _self.profession : profession // ignore: cast_nullable_to_non_nullable
as String,occupation: null == occupation ? _self.occupation : occupation // ignore: cast_nullable_to_non_nullable
as String,birthday: freezed == birthday ? _self.birthday : birthday // ignore: cast_nullable_to_non_nullable
as DateTime?,maritalStatus: freezed == maritalStatus ? _self.maritalStatus : maritalStatus // ignore: cast_nullable_to_non_nullable
as int?,educationalLevel: freezed == educationalLevel ? _self.educationalLevel : educationalLevel // ignore: cast_nullable_to_non_nullable
as int?,accessType: null == accessType ? _self.accessType : accessType // ignore: cast_nullable_to_non_nullable
as int,
  ));
}


}

// dart format on
