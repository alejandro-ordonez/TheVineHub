///
/// Generated file. Do not edit.
///
// coverage:ignore-file
// ignore_for_file: type=lint, unused_import
// dart format off

import 'package:flutter/widgets.dart';
import 'package:intl/intl.dart';
import 'package:slang/generated.dart';
import 'strings.g.dart';

// Path: <root>
class TranslationsEs with BaseTranslations<AppLocale, Translations> implements Translations {
	/// You can call this constructor and build your own translation instance of this locale.
	/// Constructing via the enum [AppLocale.build] is preferred.
	TranslationsEs({Map<String, Node>? overrides, PluralResolver? cardinalResolver, PluralResolver? ordinalResolver, TranslationMetadata<AppLocale, Translations>? meta})
		: assert(overrides == null, 'Set "translation_overrides: true" in order to enable this feature.'),
		  $meta = meta ?? TranslationMetadata(
		    locale: AppLocale.es,
		    overrides: overrides ?? {},
		    cardinalResolver: cardinalResolver,
		    ordinalResolver: ordinalResolver,
		  ) {
		$meta.setFlatMapFunction(_flatMapFunction);
	}

	/// Metadata for the translations of <es>.
	@override final TranslationMetadata<AppLocale, Translations> $meta;

	/// Access flat map
	@override dynamic operator[](String key) => $meta.getTranslation(key);

	late final TranslationsEs _root = this; // ignore: unused_field

	@override 
	TranslationsEs $copyWith({TranslationMetadata<AppLocale, Translations>? meta}) => TranslationsEs(meta: meta ?? this.$meta);

	// Translations
	@override late final _TranslationsAuthEs auth = _TranslationsAuthEs._(_root);
	@override late final _TranslationsCommonEs common = _TranslationsCommonEs._(_root);
	@override late final _TranslationsNavEs nav = _TranslationsNavEs._(_root);
	@override late final _TranslationsDashboardEs dashboard = _TranslationsDashboardEs._(_root);
	@override late final _TranslationsCellsEs cells = _TranslationsCellsEs._(_root);
	@override late final _TranslationsTrainingEs training = _TranslationsTrainingEs._(_root);
}

// Path: auth
class _TranslationsAuthEs implements TranslationsAuthEn {
	_TranslationsAuthEs._(this._root);

	final TranslationsEs _root; // ignore: unused_field

	// Translations
	@override String get login => 'INICIAR SESIÓN';
	@override String get email => 'Correo electrónico';
	@override String get password => 'Contraseña';
	@override String get forgotPassword => '¿Olvidó su contraseña?';
	@override String get invalidCredentials => 'Credenciales inválidas';
	@override String get title => 'JM MINISTERIO';
	@override String get subtitle => 'Mayordomía y Crecimiento';
}

// Path: common
class _TranslationsCommonEs implements TranslationsCommonEn {
	_TranslationsCommonEs._(this._root);

	final TranslationsEs _root; // ignore: unused_field

	// Translations
	@override String get loading => 'Cargando...';
}

// Path: nav
class _TranslationsNavEs implements TranslationsNavEn {
	_TranslationsNavEs._(this._root);

	final TranslationsEs _root; // ignore: unused_field

	// Translations
	@override String get dashboard => 'Panel';
	@override String get cells => 'Células';
	@override String get training => 'Capacitación';
}

// Path: dashboard
class _TranslationsDashboardEs implements TranslationsDashboardEn {
	_TranslationsDashboardEs._(this._root);

	final TranslationsEs _root; // ignore: unused_field

	// Translations
	@override String get title => 'Panel del Ministerio';
	@override String get content => 'Contenido del Panel';
}

// Path: cells
class _TranslationsCellsEs implements TranslationsCellsEn {
	_TranslationsCellsEs._(this._root);

	final TranslationsEs _root; // ignore: unused_field

	// Translations
	@override String get title => 'Mis Células';
	@override String get content => 'Contenido de Células';
}

// Path: training
class _TranslationsTrainingEs implements TranslationsTrainingEn {
	_TranslationsTrainingEs._(this._root);

	final TranslationsEs _root; // ignore: unused_field

	// Translations
	@override String get title => 'Universidad de la Vida';
	@override String get content => 'Contenido de Capacitación';
}

/// The flat map containing all translations for locale <es>.
/// Only for edge cases! For simple maps, use the map function of this library.
///
/// The Dart AOT compiler has issues with very large switch statements,
/// so the map is split into smaller functions (512 entries each).
extension on TranslationsEs {
	dynamic _flatMapFunction(String path) {
		return switch (path) {
			'auth.login' => 'INICIAR SESIÓN',
			'auth.email' => 'Correo electrónico',
			'auth.password' => 'Contraseña',
			'auth.forgotPassword' => '¿Olvidó su contraseña?',
			'auth.invalidCredentials' => 'Credenciales inválidas',
			'auth.title' => 'JM MINISTERIO',
			'auth.subtitle' => 'Mayordomía y Crecimiento',
			'common.loading' => 'Cargando...',
			'nav.dashboard' => 'Panel',
			'nav.cells' => 'Células',
			'nav.training' => 'Capacitación',
			'dashboard.title' => 'Panel del Ministerio',
			'dashboard.content' => 'Contenido del Panel',
			'cells.title' => 'Mis Células',
			'cells.content' => 'Contenido de Células',
			'training.title' => 'Universidad de la Vida',
			'training.content' => 'Contenido de Capacitación',
			_ => null,
		};
	}
}
