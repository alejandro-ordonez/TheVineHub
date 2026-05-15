namespace JMMinistry.Common.Dtos.Gained
{
    public class GainedUser : CreateGainedUser
    {
        public List<GainedEvent> Events { get; set; }
    }
}
