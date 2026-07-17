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
	@override late final _Translations$auth$es auth = _Translations$auth$es._(_root);
	@override late final _Translations$common$es common = _Translations$common$es._(_root);
	@override late final _Translations$nav$es nav = _Translations$nav$es._(_root);
	@override late final _Translations$home$es home = _Translations$home$es._(_root);
	@override late final _Translations$admin$es admin = _Translations$admin$es._(_root);
	@override late final _Translations$dashboard$es dashboard = _Translations$dashboard$es._(_root);
	@override late final _Translations$cells$es cells = _Translations$cells$es._(_root);
	@override late final _Translations$training$es training = _Translations$training$es._(_root);
}

// Path: auth
class _Translations$auth$es implements Translations$auth$en {
	_Translations$auth$es._(this._root);

	final TranslationsEs _root; // ignore: unused_field

	// Translations
	@override String get login => 'INICIAR SESIÓN';
	@override String get email => 'Correo electrónico';
	@override String get password => 'Contraseña';
	@override String get forgotPassword => '¿Olvidó su contraseña?';
	@override String get invalidCredentials => 'Credenciales inválidas';
	@override String get title => 'JM MINISTERIO';
	@override String get subtitle => 'Mayordomía y Crecimiento';
	@override String get logout => 'Cerrar Sesión';
	@override String get appName => 'JM Ministerio';
	@override late final _Translations$auth$errors$es errors = _Translations$auth$errors$es._(_root);
}

// Path: common
class _Translations$common$es implements Translations$common$en {
	_Translations$common$es._(this._root);

	final TranslationsEs _root; // ignore: unused_field

	// Translations
	@override String get loading => 'Cargando...';
	@override String get error => 'Error';
	@override String get retry => 'Reintentar';
	@override String get ladderOfSuccess => 'Escalera del Éxito';
	@override String get overview => 'Resumen';
	@override String get details => 'Detalles';
	@override String step({required Object id}) => 'Paso ${id}';
	@override String get unknown => 'Desconocido';
	@override String get profile => 'Perfil';
	@override String get success => 'Éxito';
	@override String get document => 'Documento';
	@override String get cancel => 'Cancelar';
	@override String get save => 'Guardar';
	@override late final _Translations$common$roles$es roles = _Translations$common$roles$es._(_root);
	@override late final _Translations$common$errors$es errors = _Translations$common$errors$es._(_root);
	@override late final _Translations$common$validation$es validation = _Translations$common$validation$es._(_root);
	@override late final _Translations$common$days$es days = _Translations$common$days$es._(_root);
}

// Path: nav
class _Translations$nav$es implements Translations$nav$en {
	_Translations$nav$es._(this._root);

	final TranslationsEs _root; // ignore: unused_field

	// Translations
	@override String get home => 'Inicio';
	@override String get dashboard => 'Panel';
	@override String get cells => 'Células';
	@override String get training => 'Capacitación';
	@override String get admin => 'Admin';
	@override String get adminPanel => 'Panel de Administración';
	@override String get searchUsers => 'Buscar Usuarios';
}

// Path: home
class _Translations$home$es implements Translations$home$en {
	_Translations$home$es._(this._root);

	final TranslationsEs _root; // ignore: unused_field

	// Translations
	@override String get title => 'Inicio / Anuncios';
	@override String get emptyState => 'Los anuncios aparecerán aquí.';
}

// Path: admin
class _Translations$admin$es implements Translations$admin$en {
	_Translations$admin$es._(this._root);

	final TranslationsEs _root; // ignore: unused_field

	// Translations
	@override String get title => 'Panel de Administración';
	@override String get emptyState => 'Las herramientas de administración aparecerán aquí.';
	@override String get manageMeetings => 'Administrar Reuniones';
}

// Path: dashboard
class _Translations$dashboard$es implements Translations$dashboard$en {
	_Translations$dashboard$es._(this._root);

	final TranslationsEs _root; // ignore: unused_field

	// Translations
	@override String get title => 'Panel del Ministerio';
	@override String get content => 'Contenido del Panel';
}

// Path: cells
class _Translations$cells$es implements Translations$cells$en {
	_Translations$cells$es._(this._root);

	final TranslationsEs _root; // ignore: unused_field

	// Translations
	@override String get title => 'Células';
	@override String get myCells => 'Mis Células';
	@override String get subtitle => 'Gestiona tus grupos de ministerio y asistencia.';
	@override String get content => 'Contenido de Células';
	@override String get report => 'Reportar';
	@override String get newCell => 'Nueva Célula';
	@override String get addDisciple => 'Agregar Discípulo';
	@override String get submitReport => 'Enviar Reporte Semanal';
	@override String get meetingNotes => 'Notas de la Reunión';
	@override String get notesHint => '¿Qué pasó en la célula hoy?';
	@override String get recordAttendance => 'Registrar Asistencia';
	@override String get pendingAttendance => 'Asistencia Pendiente';
	@override String get reportLastMeeting => 'Reportar la reunión de la semana pasada';
	@override String get emptyState => 'No hay células asignadas todavía';
	@override String get searchHint => 'Buscar células...';
	@override String get searchMembersHint => 'Buscar miembros...';
	@override String get noAddress => 'Sin dirección';
	@override String everyDay({required Object day}) => 'Cada ${day}';
	@override String get notScheduled => 'No programado';
	@override String get activeGroup => 'GRUPO ACTIVO';
	@override String get totalMembers => 'TOTAL MIEMBROS';
	@override String memberCount({required Object count}) => '${count} Miembros';
	@override String get leader => 'Líder';
	@override String get leaders => 'Líderes';
	@override String get noLeader => 'No hay líder asignado';
	@override String get noMembers => 'No hay miembros en esta célula todavía';
	@override String growth({required Object count}) => '${count} este mes';
	@override late final _Translations$cells$tags$es tags = _Translations$cells$tags$es._(_root);
	@override late final _Translations$cells$levels$es levels = _Translations$cells$levels$es._(_root);
	@override late final _Translations$cells$errors$es errors = _Translations$cells$errors$es._(_root);
	@override late final _Translations$cells$success$es success = _Translations$cells$success$es._(_root);
	@override late final _Translations$cells$form$es form = _Translations$cells$form$es._(_root);
}

// Path: training
class _Translations$training$es implements Translations$training$en {
	_Translations$training$es._(this._root);

	final TranslationsEs _root; // ignore: unused_field

	// Translations
	@override String get title => 'Universidad de la Vida';
	@override String get content => 'Contenido de Capacitación';
	@override String stepDetail({required Object id}) => 'Vista detallada para el paso con ID: ${id}';
}

// Path: auth.errors
class _Translations$auth$errors$es implements Translations$auth$errors$en {
	_Translations$auth$errors$es._(this._root);

	final TranslationsEs _root; // ignore: unused_field

	// Translations
	@override String get failed => 'Error de autenticación';
}

// Path: common.roles
class _Translations$common$roles$es implements Translations$common$roles$en {
	_Translations$common$roles$es._(this._root);

	final TranslationsEs _root; // ignore: unused_field

	// Translations
	@override String get helper => 'Asistente';
	@override String get leader => 'Líder';
}

// Path: common.errors
class _Translations$common$errors$es implements Translations$common$errors$en {
	_Translations$common$errors$es._(this._root);

	final TranslationsEs _root; // ignore: unused_field

	// Translations
	@override String generic({required Object error}) => 'Error: ${error}';
	@override String loadingSteps({required Object error}) => 'Error al cargar los pasos: ${error}';
}

// Path: common.validation
class _Translations$common$validation$es implements Translations$common$validation$en {
	_Translations$common$validation$es._(this._root);

	final TranslationsEs _root; // ignore: unused_field

	// Translations
	@override String get required => 'Requerido';
}

// Path: common.days
class _Translations$common$days$es implements Translations$common$days$en {
	_Translations$common$days$es._(this._root);

	final TranslationsEs _root; // ignore: unused_field

	// Translations
	@override String get sunday => 'Domingo';
	@override String get monday => 'Lunes';
	@override String get tuesday => 'Martes';
	@override String get wednesday => 'Miércoles';
	@override String get thursday => 'Jueves';
	@override String get friday => 'Viernes';
	@override String get saturday => 'Sábado';
}

// Path: cells.tags
class _Translations$cells$tags$es implements Translations$cells$tags$en {
	_Translations$cells$tags$es._(this._root);

	final TranslationsEs _root; // ignore: unused_field

	// Translations
	@override String get active => 'ACTIVA';
	@override String get inactive => 'INACTIVA';
	@override String get mainCell => 'CÉLULA PRINCIPAL';
}

// Path: cells.levels
class _Translations$cells$levels$es implements Translations$cells$levels$en {
	_Translations$cells$levels$es._(this._root);

	final TranslationsEs _root; // ignore: unused_field

	// Translations
	@override String get direct => 'Liderazgo Directo';
	@override String get disciples => 'Células de Discípulos';
	@override String generic({required Object level}) => 'Nivel ${level}';
	@override String g12({required Object count}) => 'Los ${count}';
}

// Path: cells.errors
class _Translations$cells$errors$es implements Translations$cells$errors$en {
	_Translations$cells$errors$es._(this._root);

	final TranslationsEs _root; // ignore: unused_field

	// Translations
	@override String loadingCells({required Object error}) => 'Error al cargar las células: ${error}';
	@override String failedAttendance({required Object error}) => 'Error al registrar la asistencia: ${error}';
	@override String loadingDisciples({required Object error}) => 'Error al cargar los discípulos: ${error}';
	@override String loadingLocations({required Object error}) => 'Error al cargar las ubicaciones: ${error}';
	@override String createCell({required Object error}) => 'Error al crear la célula: ${error}';
}

// Path: cells.success
class _Translations$cells$success$es implements Translations$cells$success$en {
	_Translations$cells$success$es._(this._root);

	final TranslationsEs _root; // ignore: unused_field

	// Translations
	@override String get attendanceRecorded => 'Asistencia registrada con éxito';
	@override String get cellCreated => 'Célula creada con éxito';
}

// Path: cells.form
class _Translations$cells$form$es implements Translations$cells$form$en {
	_Translations$cells$form$es._(this._root);

	final TranslationsEs _root; // ignore: unused_field

	// Translations
	@override String get name => 'Nombre de la Célula';
	@override String get lastName => 'Apellido';
	@override String get description => 'Descripción';
	@override String get address => 'Dirección';
	@override String get city => 'Ciudad';
	@override String get locality => 'Localidad';
	@override String get meetingDay => 'Día de Reunión';
	@override String get isMainCell => '¿Es Célula Principal?';
	@override String get mainCellSubtitle => 'Las células principales son puntos centrales del ministerio';
	@override String get openingDate => 'Fecha de Apertura';
	@override String get selectDate => 'Seleccionar una fecha';
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
			'auth.logout' => 'Cerrar Sesión',
			'auth.appName' => 'JM Ministerio',
			'auth.errors.failed' => 'Error de autenticación',
			'common.loading' => 'Cargando...',
			'common.error' => 'Error',
			'common.retry' => 'Reintentar',
			'common.ladderOfSuccess' => 'Escalera del Éxito',
			'common.overview' => 'Resumen',
			'common.details' => 'Detalles',
			'common.step' => ({required Object id}) => 'Paso ${id}',
			'common.unknown' => 'Desconocido',
			'common.profile' => 'Perfil',
			'common.success' => 'Éxito',
			'common.document' => 'Documento',
			'common.cancel' => 'Cancelar',
			'common.save' => 'Guardar',
			'common.roles.helper' => 'Asistente',
			'common.roles.leader' => 'Líder',
			'common.errors.generic' => ({required Object error}) => 'Error: ${error}',
			'common.errors.loadingSteps' => ({required Object error}) => 'Error al cargar los pasos: ${error}',
			'common.validation.required' => 'Requerido',
			'common.days.sunday' => 'Domingo',
			'common.days.monday' => 'Lunes',
			'common.days.tuesday' => 'Martes',
			'common.days.wednesday' => 'Miércoles',
			'common.days.thursday' => 'Jueves',
			'common.days.friday' => 'Viernes',
			'common.days.saturday' => 'Sábado',
			'nav.home' => 'Inicio',
			'nav.dashboard' => 'Panel',
			'nav.cells' => 'Células',
			'nav.training' => 'Capacitación',
			'nav.admin' => 'Admin',
			'nav.adminPanel' => 'Panel de Administración',
			'nav.searchUsers' => 'Buscar Usuarios',
			'home.title' => 'Inicio / Anuncios',
			'home.emptyState' => 'Los anuncios aparecerán aquí.',
			'admin.title' => 'Panel de Administración',
			'admin.emptyState' => 'Las herramientas de administración aparecerán aquí.',
			'admin.manageMeetings' => 'Administrar Reuniones',
			'dashboard.title' => 'Panel del Ministerio',
			'dashboard.content' => 'Contenido del Panel',
			'cells.title' => 'Células',
			'cells.myCells' => 'Mis Células',
			'cells.subtitle' => 'Gestiona tus grupos de ministerio y asistencia.',
			'cells.content' => 'Contenido de Células',
			'cells.report' => 'Reportar',
			'cells.newCell' => 'Nueva Célula',
			'cells.addDisciple' => 'Agregar Discípulo',
			'cells.submitReport' => 'Enviar Reporte Semanal',
			'cells.meetingNotes' => 'Notas de la Reunión',
			'cells.notesHint' => '¿Qué pasó en la célula hoy?',
			'cells.recordAttendance' => 'Registrar Asistencia',
			'cells.pendingAttendance' => 'Asistencia Pendiente',
			'cells.reportLastMeeting' => 'Reportar la reunión de la semana pasada',
			'cells.emptyState' => 'No hay células asignadas todavía',
			'cells.searchHint' => 'Buscar células...',
			'cells.searchMembersHint' => 'Buscar miembros...',
			'cells.noAddress' => 'Sin dirección',
			'cells.everyDay' => ({required Object day}) => 'Cada ${day}',
			'cells.notScheduled' => 'No programado',
			'cells.activeGroup' => 'GRUPO ACTIVO',
			'cells.totalMembers' => 'TOTAL MIEMBROS',
			'cells.memberCount' => ({required Object count}) => '${count} Miembros',
			'cells.leader' => 'Líder',
			'cells.leaders' => 'Líderes',
			'cells.noLeader' => 'No hay líder asignado',
			'cells.noMembers' => 'No hay miembros en esta célula todavía',
			'cells.growth' => ({required Object count}) => '${count} este mes',
			'cells.tags.active' => 'ACTIVA',
			'cells.tags.inactive' => 'INACTIVA',
			'cells.tags.mainCell' => 'CÉLULA PRINCIPAL',
			'cells.levels.direct' => 'Liderazgo Directo',
			'cells.levels.disciples' => 'Células de Discípulos',
			'cells.levels.generic' => ({required Object level}) => 'Nivel ${level}',
			'cells.levels.g12' => ({required Object count}) => 'Los ${count}',
			'cells.errors.loadingCells' => ({required Object error}) => 'Error al cargar las células: ${error}',
			'cells.errors.failedAttendance' => ({required Object error}) => 'Error al registrar la asistencia: ${error}',
			'cells.errors.loadingDisciples' => ({required Object error}) => 'Error al cargar los discípulos: ${error}',
			'cells.errors.loadingLocations' => ({required Object error}) => 'Error al cargar las ubicaciones: ${error}',
			'cells.errors.createCell' => ({required Object error}) => 'Error al crear la célula: ${error}',
			'cells.success.attendanceRecorded' => 'Asistencia registrada con éxito',
			'cells.success.cellCreated' => 'Célula creada con éxito',
			'cells.form.name' => 'Nombre de la Célula',
			'cells.form.lastName' => 'Apellido',
			'cells.form.description' => 'Descripción',
			'cells.form.address' => 'Dirección',
			'cells.form.city' => 'Ciudad',
			'cells.form.locality' => 'Localidad',
			'cells.form.meetingDay' => 'Día de Reunión',
			'cells.form.isMainCell' => '¿Es Célula Principal?',
			'cells.form.mainCellSubtitle' => 'Las células principales son puntos centrales del ministerio',
			'cells.form.openingDate' => 'Fecha de Apertura',
			'cells.form.selectDate' => 'Seleccionar una fecha',
			'training.title' => 'Universidad de la Vida',
			'training.content' => 'Contenido de Capacitación',
			'training.stepDetail' => ({required Object id}) => 'Vista detallada para el paso con ID: ${id}',
			_ => null,
		};
	}
}
