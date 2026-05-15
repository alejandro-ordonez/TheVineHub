namespace JMMinistry.Application.Exceptions;

public class EntityAlreadyExistsException<T>(string reference = "") :
    Exception($"{typeof(T)} already exists {(string.IsNullOrEmpty(reference) ? "" : $"with reference: {reference}")}")
{
}
