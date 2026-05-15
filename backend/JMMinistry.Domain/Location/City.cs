namespace JMMinistry.Domain.Location
{
    public class City
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public IList<Locality> Localities { get; set; } = [];
    }
}
