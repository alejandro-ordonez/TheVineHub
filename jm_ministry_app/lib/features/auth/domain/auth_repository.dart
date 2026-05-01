import 'authenticate_command.dart';
import 'token_result.dart';

abstract class AuthRepository {
  Future<TokenResult> login(AuthenticateCommand command);
  Future<void> logout();
  Future<String?> getStoredToken();
}
