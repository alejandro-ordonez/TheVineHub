import 'package:flutter/material.dart';
import 'package:riverpod_annotation/riverpod_annotation.dart';

part 'shell_utils.g.dart';

@riverpod
GlobalKey<ScaffoldState> shellScaffoldKey(Ref ref) {
  return GlobalKey<ScaffoldState>(debugLabel: 'shellScaffold');
}
