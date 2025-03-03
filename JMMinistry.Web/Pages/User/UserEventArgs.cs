namespace JMMinistry.Web.Pages.User
{
    public class UserEventArgs: EventArgs
    {
        public required int CellId { get; set; }
        public required string Document { get; set; }
    }
}
