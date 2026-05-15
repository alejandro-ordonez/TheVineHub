namespace JMMinistry.Common.Dtos.Common;

public class CityDto
{
    public string Id { get; set; } = string.Empty;
    public required string Name { get; set; }
    public IList<LocalityDto> Localities { get; set; } = [];
}

public class LocalityDto
{
    public string Id { get; set; } = string.Empty;
    public required string Name { get; set; }
}
