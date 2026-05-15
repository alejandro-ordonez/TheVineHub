namespace JMMinistry.Application.Exceptions
{
    public class NotFoundException<T>(string resourceId) : Exception($"Resource of type {typeof(T)}: {resourceId} not found");

    public class NotFoundException(string message) : NotFoundException<object>(message);
}
