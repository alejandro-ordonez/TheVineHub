namespace JMMinistry.Web.Shared.Components
{
    public class DialogResult<T> where T: class
    {
        public DialogResultOption Option { get; set; }
        public T? Data { get; set; }
    }

    public enum DialogResultOption
    {
        PrimaryButton,
        SecondaryButton
    }
}
