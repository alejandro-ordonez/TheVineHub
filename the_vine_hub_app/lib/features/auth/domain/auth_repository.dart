import 'package:jm_ministry_app/features/auth/domain/authenticate_command.dart';
import 'package:jm_ministry_app/features/auth/domain/token_result.dart';

abstract class AuthRepository {
  Future<TokenResult> login(AuthenticateCommand command);
  Future<void> logout();
  Future<String?> getStoredToken();
}
