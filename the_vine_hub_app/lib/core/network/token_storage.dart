import 'package:flutter/foundation.dart';
import 'package:flutter_secure_storage/flutter_secure_storage.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';

part 'token_storage.g.dart';

class TokenStorage {
  final FlutterSecureStorage _storage;
  static const _tokenKey = 'auth_token';
  static const _refreshTokenKey = 'refresh_token';

  String? _cachedToken;
  String? _cachedRefreshToken;

  TokenStorage(this._storage);

  Future<void> saveTokens({
    required String token,
    required String refreshToken,
  }) async {
    try {
      _cachedToken = token;
      _cachedRefreshToken = refreshToken;
      await _storage.write(key: _tokenKey, value: token);
      await _storage.write(key: _refreshTokenKey, value: refreshToken);
    } catch (e) {
      debugPrint('TokenStorage: Error saving tokens: $e');
    }
  }

  Future<String?> getToken() async {
    if (_cachedToken != null) return _cachedToken;
    try {
      _cachedToken = await _storage.read(key: _tokenKey);
      return _cachedToken;
    } catch (e) {
      debugPrint('TokenStorage: Error reading token: $e');
      return null;
    }
  }

  Future<String?> getRefreshToken() async {
    if (_cachedRefreshToken != null) return _cachedRefreshToken;
    try {
      _cachedRefreshToken = await _storage.read(key: _refreshTokenKey);
      return _cachedRefreshToken;
    } catch (e) {
      debugPrint('TokenStorage: Error reading refresh token: $e');
      return null;
    }
  }

  Future<void> deleteTokens() async {
    try {
      _cachedToken = null;
      _cachedRefreshToken = null;
      await _storage.delete(key: _tokenKey);
      await _storage.delete(key: _refreshTokenKey);
    } catch (e) {
      debugPrint('TokenStorage: Error deleting tokens: $e');
    }
  }
}

@riverpod
TokenStorage tokenStorage(Ref ref) {
  return TokenStorage(
    const FlutterSecureStorage(webOptions: WebOptions(dbName: 'JMMinistryDB')),
  );
}
