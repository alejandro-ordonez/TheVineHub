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

        // Ministry
        public const string Gained = $"/{nameof(Gained)}";

        // Settings
        public const string Settings = $"/{nameof(Settings)}";
    }
}
