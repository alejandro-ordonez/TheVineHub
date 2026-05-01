///
/// Generated file. Do not edit.
///
// coverage:ignore-file
// ignore_for_file: type=lint, unused_import
// dart format off

part of 'strings.g.dart';

// Path: <root>
typedef TranslationsEn = Translations; // ignore: unused_element
class Translations with BaseTranslations<AppLocale, Translations> {
	/// Returns the current translations of the given [context].
	///
	/// Usage:
	/// final t = Translations.of(context);
	static Translations of(BuildContext context) => InheritedLocaleData.of<AppLocale, Translations>(context).translations;

	/// You can call this constructor and build your own translation instance of this locale.
	/// Constructing via the enum [AppLocale.build] is preferred.
	Translations({Map<String, Node>? overrides, PluralResolver? cardinalResolver, PluralResolver? ordinalResolver, TranslationMetadata<AppLocale, Translations>? meta})
		: assert(overrides == null, 'Set "translation_overrides: true" in order to enable this feature.'),
		  $meta = meta ?? TranslationMetadata(
		    locale: AppLocale.en,
		    overrides: overrides ?? {},
		    cardinalResolver: cardinalResolver,
		    ordinalResolver: ordinalResolver,
		  ) {
		$meta.setFlatMapFunction(_flatMapFunction);
	}

	/// Metadata for the translations of <en>.
	@override final TranslationMetadata<AppLocale, Translations> $meta;

	/// Access flat map
	dynamic operator[](String key) => $meta.getTranslation(key);

	late final Translations _root = this; // ignore: unused_field

	Translations $copyWith({TranslationMetadata<AppLocale, Translations>? meta}) => Translations(meta: meta ?? this.$meta);

	// Translations
	late final TranslationsAuthEn auth = TranslationsAuthEn._(_root);
	late final TranslationsCommonEn common = TranslationsCommonEn._(_root);
	late final TranslationsNavEn nav = TranslationsNavEn._(_root);
	late final TranslationsDashboardEn dashboard = TranslationsDashboardEn._(_root);
	late final TranslationsCellsEn cells = TranslationsCellsEn._(_root);
	late final TranslationsTrainingEn training = TranslationsTrainingEn._(_root);
}

// Path: auth
class TranslationsAuthEn {
	TranslationsAuthEn._(this._root);

	final Translations _root; // ignore: unused_field

	// Translations

	/// en: 'LOGIN'
	String get login => 'LOGIN';

	/// en: 'Email'
	String get email => 'Email';

	/// en: 'Password'
	String get password => 'Password';

	/// en: 'Forgot Password?'
	String get forgotPassword => 'Forgot Password?';

	/// en: 'Invalid credentials'
	String get invalidCredentials => 'Invalid credentials';

	/// en: 'JM MINISTRY'
	String get title => 'JM MINISTRY';

	/// en: 'Stewardship & Growth'
	String get subtitle => 'Stewardship & Growth';
}

// Path: common
class TranslationsCommonEn {
	TranslationsCommonEn._(this._root);

	final Translations _root; // ignore: unused_field

	// Translations

	/// en: 'Loading...'
	String get loading => 'Loading...';
}

// Path: nav
class TranslationsNavEn {
	TranslationsNavEn._(this._root);

	final Translations _root; // ignore: unused_field

	// Translations

	/// en: 'Dashboard'
	String get dashboard => 'Dashboard';

	/// en: 'Cells'
	String get cells => 'Cells';

	/// en: 'Training'
	String get training => 'Training';
}

// Path: dashboard
class TranslationsDashboardEn {
	TranslationsDashboardEn._(this._root);

	final Translations _root; // ignore: unused_field

	// Translations

	/// en: 'Ministry Dashboard'
	String get title => 'Ministry Dashboard';

	/// en: 'Dashboard Content'
	String get content => 'Dashboard Content';
}

// Path: cells
class TranslationsCellsEn {
	TranslationsCellsEn._(this._root);

	final Translations _root; // ignore: unused_field

	// Translations

	/// en: 'My Cells'
	String get title => 'My Cells';

	/// en: 'Cells Content'
	String get content => 'Cells Content';
}

// Path: training
class TranslationsTrainingEn {
	TranslationsTrainingEn._(this._root);

	final Translations _root; // ignore: unused_field

	// Translations

	/// en: 'University of Life'
	String get title => 'University of Life';

	/// en: 'Training Content'
	String get content => 'Training Content';
}

/// The flat map containing all translations for locale <en>.
/// Only for edge cases! For simple maps, use the map function of this library.
///
/// The Dart AOT compiler has issues with very large switch statements,
/// so the map is split into smaller functions (512 entries each).
extension on Translations {
	dynamic _flatMapFunction(String path) {
		return switch (path) {
			'auth.login' => 'LOGIN',
			'auth.email' => 'Email',
			'auth.password' => 'Password',
			'auth.forgotPassword' => 'Forgot Password?',
			'auth.invalidCredentials' => 'Invalid credentials',
			'auth.title' => 'JM MINISTRY',
			'auth.subtitle' => 'Stewardship & Growth',
			'common.loading' => 'Loading...',
			'nav.dashboard' => 'Dashboard',
			'nav.cells' => 'Cells',
			'nav.training' => 'Training',
			'dashboard.title' => 'Ministry Dashboard',
			'dashboard.content' => 'Dashboard Content',
			'cells.title' => 'My Cells',
			'cells.content' => 'Cells Content',
			'training.title' => 'University of Life',
			'training.content' => 'Training Content',
			_ => null,
		};
	}
}
