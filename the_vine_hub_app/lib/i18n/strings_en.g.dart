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
	late final Translations$auth$en auth = Translations$auth$en._(_root);
	late final Translations$common$en common = Translations$common$en._(_root);
	late final Translations$nav$en nav = Translations$nav$en._(_root);
	late final Translations$home$en home = Translations$home$en._(_root);
	late final Translations$admin$en admin = Translations$admin$en._(_root);
	late final Translations$dashboard$en dashboard = Translations$dashboard$en._(_root);
	late final Translations$cells$en cells = Translations$cells$en._(_root);
	late final Translations$training$en training = Translations$training$en._(_root);
}

// Path: auth
class Translations$auth$en {
	Translations$auth$en._(this._root);

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

	/// en: 'Logout'
	String get logout => 'Logout';

	/// en: 'JM Ministry'
	String get appName => 'JM Ministry';

	late final Translations$auth$errors$en errors = Translations$auth$errors$en._(_root);
}

// Path: common
class Translations$common$en {
	Translations$common$en._(this._root);

	final Translations _root; // ignore: unused_field

	// Translations

	/// en: 'Loading...'
	String get loading => 'Loading...';

	/// en: 'Error'
	String get error => 'Error';

	/// en: 'Retry'
	String get retry => 'Retry';

	/// en: 'Ladder of Success'
	String get ladderOfSuccess => 'Ladder of Success';

	/// en: 'Overview'
	String get overview => 'Overview';

	/// en: 'Details'
	String get details => 'Details';

	/// en: 'Step {id}'
	String step({required Object id}) => 'Step ${id}';

	/// en: 'Unknown'
	String get unknown => 'Unknown';

	/// en: 'Profile'
	String get profile => 'Profile';

	/// en: 'Success'
	String get success => 'Success';

	/// en: 'Document'
	String get document => 'Document';

	/// en: 'Cancel'
	String get cancel => 'Cancel';

	/// en: 'Save'
	String get save => 'Save';

	late final Translations$common$roles$en roles = Translations$common$roles$en._(_root);
	late final Translations$common$errors$en errors = Translations$common$errors$en._(_root);
	late final Translations$common$validation$en validation = Translations$common$validation$en._(_root);
	late final Translations$common$days$en days = Translations$common$days$en._(_root);
}

// Path: nav
class Translations$nav$en {
	Translations$nav$en._(this._root);

	final Translations _root; // ignore: unused_field

	// Translations

	/// en: 'Home'
	String get home => 'Home';

	/// en: 'Dashboard'
	String get dashboard => 'Dashboard';

	/// en: 'Cells'
	String get cells => 'Cells';

	/// en: 'Training'
	String get training => 'Training';

	/// en: 'Admin'
	String get admin => 'Admin';

	/// en: 'Admin Panel'
	String get adminPanel => 'Admin Panel';

	/// en: 'Search Users'
	String get searchUsers => 'Search Users';
}

// Path: home
class Translations$home$en {
	Translations$home$en._(this._root);

	final Translations _root; // ignore: unused_field

	// Translations

	/// en: 'Home / Announcements'
	String get title => 'Home / Announcements';

	/// en: 'Announcements will appear here.'
	String get emptyState => 'Announcements will appear here.';
}

// Path: admin
class Translations$admin$en {
	Translations$admin$en._(this._root);

	final Translations _root; // ignore: unused_field

	// Translations

	/// en: 'Admin Dashboard'
	String get title => 'Admin Dashboard';

	/// en: 'Admin management tools will appear here.'
	String get emptyState => 'Admin management tools will appear here.';
}

// Path: dashboard
class Translations$dashboard$en {
	Translations$dashboard$en._(this._root);

	final Translations _root; // ignore: unused_field

	// Translations

	/// en: 'Ministry Dashboard'
	String get title => 'Ministry Dashboard';

	/// en: 'Dashboard Content'
	String get content => 'Dashboard Content';
}

// Path: cells
class Translations$cells$en {
	Translations$cells$en._(this._root);

	final Translations _root; // ignore: unused_field

	// Translations

	/// en: 'Cells'
	String get title => 'Cells';

	/// en: 'My Cells'
	String get myCells => 'My Cells';

	/// en: 'Manage your ministry groups and attendance.'
	String get subtitle => 'Manage your ministry groups and attendance.';

	/// en: 'Cells Content'
	String get content => 'Cells Content';

	/// en: 'Report'
	String get report => 'Report';

	/// en: 'New Cell'
	String get newCell => 'New Cell';

	/// en: 'Add Disciple'
	String get addDisciple => 'Add Disciple';

	/// en: 'Submit Weekly Report'
	String get submitReport => 'Submit Weekly Report';

	/// en: 'Meeting Notes'
	String get meetingNotes => 'Meeting Notes';

	/// en: 'What happened in the cell today?'
	String get notesHint => 'What happened in the cell today?';

	/// en: 'Record Attendance'
	String get recordAttendance => 'Record Attendance';

	/// en: 'Pending Attendance'
	String get pendingAttendance => 'Pending Attendance';

	/// en: 'Report last week's meeting'
	String get reportLastMeeting => 'Report last week\'s meeting';

	/// en: 'No cells assigned yet'
	String get emptyState => 'No cells assigned yet';

	/// en: 'Search cells...'
	String get searchHint => 'Search cells...';

	/// en: 'Search members...'
	String get searchMembersHint => 'Search members...';

	/// en: 'No address'
	String get noAddress => 'No address';

	/// en: 'Every {day}'
	String everyDay({required Object day}) => 'Every ${day}';

	/// en: 'Not scheduled'
	String get notScheduled => 'Not scheduled';

	/// en: 'ACTIVE GROUP'
	String get activeGroup => 'ACTIVE GROUP';

	/// en: 'TOTAL MEMBERS'
	String get totalMembers => 'TOTAL MEMBERS';

	/// en: '{count} Members'
	String memberCount({required Object count}) => '${count} Members';

	/// en: 'Leader'
	String get leader => 'Leader';

	/// en: 'Leaders'
	String get leaders => 'Leaders';

	/// en: 'No leader assigned'
	String get noLeader => 'No leader assigned';

	/// en: 'No members in this cell yet'
	String get noMembers => 'No members in this cell yet';

	/// en: '{count} this month'
	String growth({required Object count}) => '${count} this month';

	late final Translations$cells$tags$en tags = Translations$cells$tags$en._(_root);
	late final Translations$cells$levels$en levels = Translations$cells$levels$en._(_root);
	late final Translations$cells$errors$en errors = Translations$cells$errors$en._(_root);
	late final Translations$cells$success$en success = Translations$cells$success$en._(_root);
	late final Translations$cells$form$en form = Translations$cells$form$en._(_root);
}

// Path: training
class Translations$training$en {
	Translations$training$en._(this._root);

	final Translations _root; // ignore: unused_field

	// Translations

	/// en: 'University of Life'
	String get title => 'University of Life';

	/// en: 'Training Content'
	String get content => 'Training Content';

	/// en: 'Detailed view for step ID: {id}'
	String stepDetail({required Object id}) => 'Detailed view for step ID: ${id}';
}

// Path: auth.errors
class Translations$auth$errors$en {
	Translations$auth$errors$en._(this._root);

	final Translations _root; // ignore: unused_field

	// Translations

	/// en: 'Authentication failed'
	String get failed => 'Authentication failed';
}

// Path: common.roles
class Translations$common$roles$en {
	Translations$common$roles$en._(this._root);

	final Translations _root; // ignore: unused_field

	// Translations

	/// en: 'Helper'
	String get helper => 'Helper';

	/// en: 'Leader'
	String get leader => 'Leader';
}

// Path: common.errors
class Translations$common$errors$en {
	Translations$common$errors$en._(this._root);

	final Translations _root; // ignore: unused_field

	// Translations

	/// en: 'Error: {error}'
	String generic({required Object error}) => 'Error: ${error}';

	/// en: 'Error loading steps: {error}'
	String loadingSteps({required Object error}) => 'Error loading steps: ${error}';
}

// Path: common.validation
class Translations$common$validation$en {
	Translations$common$validation$en._(this._root);

	final Translations _root; // ignore: unused_field

	// Translations

	/// en: 'Required'
	String get required => 'Required';
}

// Path: common.days
class Translations$common$days$en {
	Translations$common$days$en._(this._root);

	final Translations _root; // ignore: unused_field

	// Translations

	/// en: 'Sunday'
	String get sunday => 'Sunday';

	/// en: 'Monday'
	String get monday => 'Monday';

	/// en: 'Tuesday'
	String get tuesday => 'Tuesday';

	/// en: 'Wednesday'
	String get wednesday => 'Wednesday';

	/// en: 'Thursday'
	String get thursday => 'Thursday';

	/// en: 'Friday'
	String get friday => 'Friday';

	/// en: 'Saturday'
	String get saturday => 'Saturday';
}

// Path: cells.tags
class Translations$cells$tags$en {
	Translations$cells$tags$en._(this._root);

	final Translations _root; // ignore: unused_field

	// Translations

	/// en: 'Active'
	String get active => 'Active';

	/// en: 'Inactive'
	String get inactive => 'Inactive';

	/// en: 'Main Cell'
	String get mainCell => 'Main Cell';
}

// Path: cells.levels
class Translations$cells$levels$en {
	Translations$cells$levels$en._(this._root);

	final Translations _root; // ignore: unused_field

	// Translations

	/// en: 'Directly Led'
	String get direct => 'Directly Led';

	/// en: 'Disciples' Cells'
	String get disciples => 'Disciples\' Cells';

	/// en: 'Level {level}'
	String generic({required Object level}) => 'Level ${level}';

	/// en: 'The {count}'
	String g12({required Object count}) => 'The ${count}';
}

// Path: cells.errors
class Translations$cells$errors$en {
	Translations$cells$errors$en._(this._root);

	final Translations _root; // ignore: unused_field

	// Translations

	/// en: 'Error loading cells: {error}'
	String loadingCells({required Object error}) => 'Error loading cells: ${error}';

	/// en: 'Failed to record attendance: {error}'
	String failedAttendance({required Object error}) => 'Failed to record attendance: ${error}';

	/// en: 'Error loading disciples: {error}'
	String loadingDisciples({required Object error}) => 'Error loading disciples: ${error}';

	/// en: 'Error loading locations: {error}'
	String loadingLocations({required Object error}) => 'Error loading locations: ${error}';

	/// en: 'Error creating cell: {error}'
	String createCell({required Object error}) => 'Error creating cell: ${error}';
}

// Path: cells.success
class Translations$cells$success$en {
	Translations$cells$success$en._(this._root);

	final Translations _root; // ignore: unused_field

	// Translations

	/// en: 'Attendance recorded successfully'
	String get attendanceRecorded => 'Attendance recorded successfully';

	/// en: 'Cell created successfully'
	String get cellCreated => 'Cell created successfully';
}

// Path: cells.form
class Translations$cells$form$en {
	Translations$cells$form$en._(this._root);

	final Translations _root; // ignore: unused_field

	// Translations

	/// en: 'Cell Name'
	String get name => 'Cell Name';

	/// en: 'Last Name'
	String get lastName => 'Last Name';

	/// en: 'Description'
	String get description => 'Description';

	/// en: 'Address'
	String get address => 'Address';

	/// en: 'City'
	String get city => 'City';

	/// en: 'Locality'
	String get locality => 'Locality';

	/// en: 'Meeting Day'
	String get meetingDay => 'Meeting Day';

	/// en: 'Is Main Cell?'
	String get isMainCell => 'Is Main Cell?';

	/// en: 'Main cells are central points of the ministry'
	String get mainCellSubtitle => 'Main cells are central points of the ministry';

	/// en: 'Opening Date'
	String get openingDate => 'Opening Date';

	/// en: 'Select a date'
	String get selectDate => 'Select a date';
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
			'auth.logout' => 'Logout',
			'auth.appName' => 'JM Ministry',
			'auth.errors.failed' => 'Authentication failed',
			'common.loading' => 'Loading...',
			'common.error' => 'Error',
			'common.retry' => 'Retry',
			'common.ladderOfSuccess' => 'Ladder of Success',
			'common.overview' => 'Overview',
			'common.details' => 'Details',
			'common.step' => ({required Object id}) => 'Step ${id}',
			'common.unknown' => 'Unknown',
			'common.profile' => 'Profile',
			'common.success' => 'Success',
			'common.document' => 'Document',
			'common.cancel' => 'Cancel',
			'common.save' => 'Save',
			'common.roles.helper' => 'Helper',
			'common.roles.leader' => 'Leader',
			'common.errors.generic' => ({required Object error}) => 'Error: ${error}',
			'common.errors.loadingSteps' => ({required Object error}) => 'Error loading steps: ${error}',
			'common.validation.required' => 'Required',
			'common.days.sunday' => 'Sunday',
			'common.days.monday' => 'Monday',
			'common.days.tuesday' => 'Tuesday',
			'common.days.wednesday' => 'Wednesday',
			'common.days.thursday' => 'Thursday',
			'common.days.friday' => 'Friday',
			'common.days.saturday' => 'Saturday',
			'nav.home' => 'Home',
			'nav.dashboard' => 'Dashboard',
			'nav.cells' => 'Cells',
			'nav.training' => 'Training',
			'nav.admin' => 'Admin',
			'nav.adminPanel' => 'Admin Panel',
			'nav.searchUsers' => 'Search Users',
			'home.title' => 'Home / Announcements',
			'home.emptyState' => 'Announcements will appear here.',
			'admin.title' => 'Admin Dashboard',
			'admin.emptyState' => 'Admin management tools will appear here.',
			'dashboard.title' => 'Ministry Dashboard',
			'dashboard.content' => 'Dashboard Content',
			'cells.title' => 'Cells',
			'cells.myCells' => 'My Cells',
			'cells.subtitle' => 'Manage your ministry groups and attendance.',
			'cells.content' => 'Cells Content',
			'cells.report' => 'Report',
			'cells.newCell' => 'New Cell',
			'cells.addDisciple' => 'Add Disciple',
			'cells.submitReport' => 'Submit Weekly Report',
			'cells.meetingNotes' => 'Meeting Notes',
			'cells.notesHint' => 'What happened in the cell today?',
			'cells.recordAttendance' => 'Record Attendance',
			'cells.pendingAttendance' => 'Pending Attendance',
			'cells.reportLastMeeting' => 'Report last week\'s meeting',
			'cells.emptyState' => 'No cells assigned yet',
			'cells.searchHint' => 'Search cells...',
			'cells.searchMembersHint' => 'Search members...',
			'cells.noAddress' => 'No address',
			'cells.everyDay' => ({required Object day}) => 'Every ${day}',
			'cells.notScheduled' => 'Not scheduled',
			'cells.activeGroup' => 'ACTIVE GROUP',
			'cells.totalMembers' => 'TOTAL MEMBERS',
			'cells.memberCount' => ({required Object count}) => '${count} Members',
			'cells.leader' => 'Leader',
			'cells.leaders' => 'Leaders',
			'cells.noLeader' => 'No leader assigned',
			'cells.noMembers' => 'No members in this cell yet',
			'cells.growth' => ({required Object count}) => '${count} this month',
			'cells.tags.active' => 'Active',
			'cells.tags.inactive' => 'Inactive',
			'cells.tags.mainCell' => 'Main Cell',
			'cells.levels.direct' => 'Directly Led',
			'cells.levels.disciples' => 'Disciples\' Cells',
			'cells.levels.generic' => ({required Object level}) => 'Level ${level}',
			'cells.levels.g12' => ({required Object count}) => 'The ${count}',
			'cells.errors.loadingCells' => ({required Object error}) => 'Error loading cells: ${error}',
			'cells.errors.failedAttendance' => ({required Object error}) => 'Failed to record attendance: ${error}',
			'cells.errors.loadingDisciples' => ({required Object error}) => 'Error loading disciples: ${error}',
			'cells.errors.loadingLocations' => ({required Object error}) => 'Error loading locations: ${error}',
			'cells.errors.createCell' => ({required Object error}) => 'Error creating cell: ${error}',
			'cells.success.attendanceRecorded' => 'Attendance recorded successfully',
			'cells.success.cellCreated' => 'Cell created successfully',
			'cells.form.name' => 'Cell Name',
			'cells.form.lastName' => 'Last Name',
			'cells.form.description' => 'Description',
			'cells.form.address' => 'Address',
			'cells.form.city' => 'City',
			'cells.form.locality' => 'Locality',
			'cells.form.meetingDay' => 'Meeting Day',
			'cells.form.isMainCell' => 'Is Main Cell?',
			'cells.form.mainCellSubtitle' => 'Main cells are central points of the ministry',
			'cells.form.openingDate' => 'Opening Date',
			'cells.form.selectDate' => 'Select a date',
			'training.title' => 'University of Life',
			'training.content' => 'Training Content',
			'training.stepDetail' => ({required Object id}) => 'Detailed view for step ID: ${id}',
			_ => null,
		};
	}
}
