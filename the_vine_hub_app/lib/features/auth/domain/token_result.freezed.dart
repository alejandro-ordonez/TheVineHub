// GENERATED CODE - DO NOT MODIFY BY HAND
// coverage:ignore-file
// ignore_for_file: type=lint
// ignore_for_file: unused_element, deprecated_member_use, deprecated_member_use_from_same_package, use_function_type_syntax_for_parameters, unnecessary_const, avoid_init_to_null, invalid_override_different_default_values_named, prefer_expression_function_bodies, annotate_overrides, invalid_annotation_target, unnecessary_question_mark

part of 'token_result.dart';

// **************************************************************************
// FreezedGenerator
// **************************************************************************

// dart format off
T _$identity<T>(T value) => value;

/// @nodoc
mixin _$TokenResult {

 bool get isAuthenticated; DateTime get expiration; String get token; String get refreshToken;
/// Create a copy of TokenResult
/// with the given fields replaced by the non-null parameter values.
@JsonKey(includeFromJson: false, includeToJson: false)
@pragma('vm:prefer-inline')
$TokenResultCopyWith<TokenResult> get copyWith => _$TokenResultCopyWithImpl<TokenResult>(this as TokenResult, _$identity);

  /// Serializes this TokenResult to a JSON map.
  Map<String, dynamic> toJson();


@override
bool operator ==(Object other) {
  return identical(this, other) || (other.runtimeType == runtimeType&&other is TokenResult&&(identical(other.isAuthenticated, isAuthenticated) || other.isAuthenticated == isAuthenticated)&&(identical(other.expiration, expiration) || other.expiration == expiration)&&(identical(other.token, token) || other.token == token)&&(identical(other.refreshToken, refreshToken) || other.refreshToken == refreshToken));
}

@JsonKey(includeFromJson: false, includeToJson: false)
@override
int get hashCode => Object.hash(runtimeType,isAuthenticated,expiration,token,refreshToken);

@override
String toString() {
  return 'TokenResult(isAuthenticated: $isAuthenticated, expiration: $expiration, token: $token, refreshToken: $refreshToken)';
}


}

/// @nodoc
abstract mixin class $TokenResultCopyWith<$Res>  {
  factory $TokenResultCopyWith(TokenResult value, $Res Function(TokenResult) _then) = _$TokenResultCopyWithImpl;
@useResult
$Res call({
 bool isAuthenticated, DateTime expiration, String token, String refreshToken
});




}
/// @nodoc
class _$TokenResultCopyWithImpl<$Res>
    implements $TokenResultCopyWith<$Res> {
  _$TokenResultCopyWithImpl(this._self, this._then);

  final TokenResult _self;
  final $Res Function(TokenResult) _then;

/// Create a copy of TokenResult
/// with the given fields replaced by the non-null parameter values.
@pragma('vm:prefer-inline') @override $Res call({Object? isAuthenticated = null,Object? expiration = null,Object? token = null,Object? refreshToken = null,}) {
  return _then(_self.copyWith(
isAuthenticated: null == isAuthenticated ? _self.isAuthenticated : isAuthenticated // ignore: cast_nullable_to_non_nullable
as bool,expiration: null == expiration ? _self.expiration : expiration // ignore: cast_nullable_to_non_nullable
as DateTime,token: null == token ? _self.token : token // ignore: cast_nullable_to_non_nullable
as String,refreshToken: null == refreshToken ? _self.refreshToken : refreshToken // ignore: cast_nullable_to_non_nullable
as String,
  ));
}

}


/// Adds pattern-matching-related methods to [TokenResult].
extension TokenResultPatterns on TokenResult {
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

@optionalTypeArgs TResult maybeMap<TResult extends Object?>(TResult Function( _TokenResult value)?  $default,{required TResult orElse(),}){
final _that = this;
switch (_that) {
case _TokenResult() when $default != null:
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

@optionalTypeArgs TResult map<TResult extends Object?>(TResult Function( _TokenResult value)  $default,){
final _that = this;
switch (_that) {
case _TokenResult():
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

@optionalTypeArgs TResult? mapOrNull<TResult extends Object?>(TResult? Function( _TokenResult value)?  $default,){
final _that = this;
switch (_that) {
case _TokenResult() when $default != null:
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

@optionalTypeArgs TResult maybeWhen<TResult extends Object?>(TResult Function( bool isAuthenticated,  DateTime expiration,  String token,  String refreshToken)?  $default,{required TResult orElse(),}) {final _that = this;
switch (_that) {
case _TokenResult() when $default != null:
return $default(_that.isAuthenticated,_that.expiration,_that.token,_that.refreshToken);case _:
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

@optionalTypeArgs TResult when<TResult extends Object?>(TResult Function( bool isAuthenticated,  DateTime expiration,  String token,  String refreshToken)  $default,) {final _that = this;
switch (_that) {
case _TokenResult():
return $default(_that.isAuthenticated,_that.expiration,_that.token,_that.refreshToken);case _:
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

@optionalTypeArgs TResult? whenOrNull<TResult extends Object?>(TResult? Function( bool isAuthenticated,  DateTime expiration,  String token,  String refreshToken)?  $default,) {final _that = this;
switch (_that) {
case _TokenResult() when $default != null:
return $default(_that.isAuthenticated,_that.expiration,_that.token,_that.refreshToken);case _:
  return null;

}
}

}

/// @nodoc
@JsonSerializable()

class _TokenResult implements TokenResult {
  const _TokenResult({required this.isAuthenticated, required this.expiration, required this.token, required this.refreshToken});
  factory _TokenResult.fromJson(Map<String, dynamic> json) => _$TokenResultFromJson(json);

@override final  bool isAuthenticated;
@override final  DateTime expiration;
@override final  String token;
@override final  String refreshToken;

/// Create a copy of TokenResult
/// with the given fields replaced by the non-null parameter values.
@override @JsonKey(includeFromJson: false, includeToJson: false)
@pragma('vm:prefer-inline')
_$TokenResultCopyWith<_TokenResult> get copyWith => __$TokenResultCopyWithImpl<_TokenResult>(this, _$identity);

@override
Map<String, dynamic> toJson() {
  return _$TokenResultToJson(this, );
}

@override
bool operator ==(Object other) {
  return identical(this, other) || (other.runtimeType == runtimeType&&other is _TokenResult&&(identical(other.isAuthenticated, isAuthenticated) || other.isAuthenticated == isAuthenticated)&&(identical(other.expiration, expiration) || other.expiration == expiration)&&(identical(other.token, token) || other.token == token)&&(identical(other.refreshToken, refreshToken) || other.refreshToken == refreshToken));
}

@JsonKey(includeFromJson: false, includeToJson: false)
@override
int get hashCode => Object.hash(runtimeType,isAuthenticated,expiration,token,refreshToken);

@override
String toString() {
  return 'TokenResult(isAuthenticated: $isAuthenticated, expiration: $expiration, token: $token, refreshToken: $refreshToken)';
}


}

/// @nodoc
abstract mixin class _$TokenResultCopyWith<$Res> implements $TokenResultCopyWith<$Res> {
  factory _$TokenResultCopyWith(_TokenResult value, $Res Function(_TokenResult) _then) = __$TokenResultCopyWithImpl;
@override @useResult
$Res call({
 bool isAuthenticated, DateTime expiration, String token, String refreshToken
});




}
/// @nodoc
class __$TokenResultCopyWithImpl<$Res>
    implements _$TokenResultCopyWith<$Res> {
  __$TokenResultCopyWithImpl(this._self, this._then);

  final _TokenResult _self;
  final $Res Function(_TokenResult) _then;

/// Create a copy of TokenResult
/// with the given fields replaced by the non-null parameter values.
@override @pragma('vm:prefer-inline') $Res call({Object? isAuthenticated = null,Object? expiration = null,Object? token = null,Object? refreshToken = null,}) {
  return _then(_TokenResult(
isAuthenticated: null == isAuthenticated ? _self.isAuthenticated : isAuthenticated // ignore: cast_nullable_to_non_nullable
as bool,expiration: null == expiration ? _self.expiration : expiration // ignore: cast_nullable_to_non_nullable
as DateTime,token: null == token ? _self.token : token // ignore: cast_nullable_to_non_nullable
as String,refreshToken: null == refreshToken ? _self.refreshToken : refreshToken // ignore: cast_nullable_to_non_nullable
as String,
  ));
}


}

// dart format on
