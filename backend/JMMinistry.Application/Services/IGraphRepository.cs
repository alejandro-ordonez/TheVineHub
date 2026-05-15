namespace JMMinistry.Application.Services;

public interface IGraphRepository
{
    Task<IEnumerable<T>> ExecuteCypherAsync<T>(string cypher, object? parameters = null);
    Task ExecuteCypherAsync(string cypher, object? parameters = null);
}
