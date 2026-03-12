namespace JMMinistry.Web.Pages
{
    public static class Routes
    {
        // Common pages
        public const string NotFound = $"/{nameof(NotFound)}";
        public const string Home = "/";
        public const string Auth = $"/{nameof(Auth)}";

        // UserPages
        public const string UserManagement = $"/{nameof(UserManagement)}";
        public const string User = $"/{nameof(User)}";

        // Ministry
        public const string Ministry = $"/{nameof(Ministry)}";
        public const string CellDetails = $"/{nameof(CellDetails)}";
        public const string DiscipleStep = $"/{nameof(DiscipleStep)}";
        public const string MeetingAttendances = $"/{nameof(MeetingAttendances)}";

        // Gained
        public const string Gained = $"/{nameof(Gained)}";

        // Meetings
        public const string Meetings = $"/{nameof(Meetings)}";

        // Admin
        public const string DiscipleStepsAdmin = $"/{nameof(DiscipleStepsAdmin)}";
        public const string StepCycleAdmin = $"/{nameof(StepCycleAdmin)}";
        public const string CycleDetailsAdmin = $"/{nameof(CycleDetailsAdmin)}";



        // Settings
        public const string Settings = $"/{nameof(Settings)}";
    }
}
