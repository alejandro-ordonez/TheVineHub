
namespace JMMinistry.Application.Exceptions
{
    public class MissingInTokenException : ArgumentException
    {
        public MissingInTokenException() : base("Missing document in token")
        {
        }
    }
}
