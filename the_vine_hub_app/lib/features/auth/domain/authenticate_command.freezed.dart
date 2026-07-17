// GENERATED CODE - DO NOT MODIFY BY HAND
// coverage:ignore-file
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'authenticate_command.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

// dart format off
T _$identity<T>(T value) => value;

/// @nodoc
mixin _$AuthenticateCommand {

 String? get document; String? get password;
/// Create a copy of AuthenticateCommand
/// with the given fields replaced by the non-null parameter values.
@JsonKey(includeFromJson: false, includeToJson: false)
@pragma('vm:prefer-inline')
$AuthenticateCommandCopyWith<AuthenticateCommand> get copyWith => _$AuthenticateCommandCopyWithImpl<AuthenticateCommand>(this as AuthenticateCommand, _$identity);

  /// Serializes this AuthenticateCommand to a JSON map.
  Map<String, dynamic> toJson();


@override
bool operator ==(Object other) {
  return identical(this, other) || (other.runtimeType == runtimeType&&other is AuthenticateCommand&&(identical(other.document, document) || other.document == document)&&(identical(other.password, password) || other.password == password));
}

@JsonKey(includeFromJson: false, includeToJson: false)
@override
int get hashCode => Object.hash(runtimeType,document,password);

@override
String toString() {
  return 'AuthenticateCommand(document: $document, password: $password)';
}


}

/// @nodoc
abstract mixin class $AuthenticateCommandCopyWith<$Res>  {
  factory $AuthenticateCommandCopyWith(AuthenticateCommand value, $Res Function(AuthenticateCommand) _then) = _$AuthenticateCommandCopyWithImpl;
@useResult
$Res call({
 String? document, String? password
});




}
/// @nodoc
class _$AuthenticateCommandCopyWithImpl<$Res>
    implements $AuthenticateCommandCopyWith<$Res> {
  _$AuthenticateCommandCopyWithImpl(this._self, this._then);

  final AuthenticateCommand _self;
  final $Res Function(AuthenticateCommand) _then;

/// Create a copy of AuthenticateCommand
/// with the given fields replaced by the non-null parameter values.
@pragma('vm:prefer-inline') @override $Res call({Object? document = freezed,Object? password = freezed,}) {
  return _then(_self.copyWith(
document: freezed == document ? _self.document : document // ignore: cast_nullable_to_non_nullable
as String?,password: freezed == password ? _self.password : password // ignore: cast_nullable_to_non_nullable
as String?,
  ));
}

}


/// Adds pattern-matching-related methods to [AuthenticateCommand].
extension AuthenticateCommandPatterns on AuthenticateCommand {
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

@optionalTypeArgs TResult maybeMap<TResult extends Object?>(TResult Function( _AuthenticateCommand value)?  $default,{required TResult orElse(),}){
final _that = this;
switch (_that) {
case _AuthenticateCommand() when $default != null:
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

@optionalTypeArgs TResult map<TResult extends Object?>(TResult Function( _AuthenticateCommand value)  $default,){
final _that = this;
switch (_that) {
case _AuthenticateCommand():
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

@optionalTypeArgs TResult? mapOrNull<TResult extends Object?>(TResult? Function( _AuthenticateCommand value)?  $default,){
final _that = this;
switch (_that) {
case _AuthenticateCommand() when $default != null:
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

@optionalTypeArgs TResult maybeWhen<TResult extends Object?>(TResult Function( String? document,  String? password)?  $default,{required TResult orElse(),}) {final _that = this;
switch (_that) {
case _AuthenticateCommand() when $default != null:
return $default(_that.document,_that.password);case _:
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

@optionalTypeArgs TResult when<TResult extends Object?>(TResult Function( String? document,  String? password)  $default,) {final _that = this;
switch (_that) {
case _AuthenticateCommand():
return $default(_that.document,_that.password);case _:
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

@optionalTypeArgs TResult? whenOrNull<TResult extends Object?>(TResult? Function( String? document,  String? password)?  $default,) {final _that = this;
switch (_that) {
case _AuthenticateCommand() when $default != null:
return $default(_that.document,_that.password);case _:
  return null;

}
}

}

/// @nodoc
@JsonSerializable()

class _AuthenticateCommand implements AuthenticateCommand {
  const _AuthenticateCommand({this.document, this.password});
  factory _AuthenticateCommand.fromJson(Map<String, dynamic> json) => _$AuthenticateCommandFromJson(json);

@override final  String? document;
@override final  String? password;

/// Create a copy of AuthenticateCommand
/// with the given fields replaced by the non-null parameter values.
@override @JsonKey(includeFromJson: false, includeToJson: false)
@pragma('vm:prefer-inline')
_$AuthenticateCommandCopyWith<_AuthenticateCommand> get copyWith => __$AuthenticateCommandCopyWithImpl<_AuthenticateCommand>(this, _$identity);

@override
Map<String, dynamic> toJson() {
  return _$AuthenticateCommandToJson(this, );
}

@override
bool operator ==(Object other) {
  return identical(this, other) || (other.runtimeType == runtimeType&&other is _AuthenticateCommand&&(identical(other.document, document) || other.document == document)&&(identical(other.password, password) || other.password == password));
}

@JsonKey(includeFromJson: false, includeToJson: false)
@override
int get hashCode => Object.hash(runtimeType,document,password);

@override
String toString() {
  return 'AuthenticateCommand(document: $document, password: $password)';
}


}

/// @nodoc
abstract mixin class _$AuthenticateCommandCopyWith<$Res> implements $AuthenticateCommandCopyWith<$Res> {
  factory _$AuthenticateCommandCopyWith(_AuthenticateCommand value, $Res Function(_AuthenticateCommand) _then) = __$AuthenticateCommandCopyWithImpl;
@override @useResult
$Res call({
 String? document, String? password
});




}
/// @nodoc
class __$AuthenticateCommandCopyWithImpl<$Res>
    implements _$AuthenticateCommandCopyWith<$Res> {
  __$AuthenticateCommandCopyWithImpl(this._self, this._then);

  final _AuthenticateCommand _self;
  final $Res Function(_AuthenticateCommand) _then;

/// Create a copy of AuthenticateCommand
/// with the given fields replaced by the non-null parameter values.
@override @pragma('vm:prefer-inline') $Res call({Object? document = freezed,Object? password = freezed,}) {
  return _then(_AuthenticateCommand(
document: freezed == document ? _self.document : document // ignore: cast_nullable_to_non_nullable
as String?,password: freezed == password ? _self.password : password // ignore: cast_nullable_to_non_nullable
as String?,
  ));
}


}

// dart format on
