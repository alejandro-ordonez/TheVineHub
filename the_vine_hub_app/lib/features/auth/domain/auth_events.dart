import 'dart:async';
import 'package:riverpod_annotation/riverpod_annotation.dart';

part 'auth_events.g.dart';

enum AuthEvent { logout }

@riverpod
Stream<AuthEvent> authEventStream(Ref ref) {
  return _authEventController.stream;
}

final _authEventController = StreamController<AuthEvent>.broadcast();

void triggerGlobalLogout() {
  _authEventController.add(AuthEvent.logout);
}
