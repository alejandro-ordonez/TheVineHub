namespace JMMinistry.Common.Dtos.Common
{
    public class CityDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public IList<LocalityDto> Localities { get; set; } = [];

        public IEnumerable<LocalityDto> GetLocalities(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return Localities;

            return Localities.Where(l => l.Name == searchTerm);
        }
    }

    public class LocalityDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
